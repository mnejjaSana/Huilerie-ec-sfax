using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAnnulationAvance : DevExpress.XtraEditors.XtraForm
    {

        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }


        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;

        private static FrmAnnulationAvance _FrmAnnulationAvance;

        public static FrmAnnulationAvance InstanceFrmAnnulationAvance
        {
            get
            {
                if (_FrmAnnulationAvance == null)
                    _FrmAnnulationAvance = new FrmAnnulationAvance();
                return _FrmAnnulationAvance;
            }
        }

        public FrmAnnulationAvance()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAnnulationAvance_Load(object sender, EventArgs e)
        {
            /********************** Agriculteurs Liste************************/
            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != TypeAchat.Avance && x.TypeAchat != TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }
                agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();
            }

            /********************** Avances Liste************************/
            achatBindingSource.DataSource = null;
        }

        private void FrmAnnulationAvance_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAnnulationAvance = null;
        }

        private void searchLookUpAgr_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMontant.Text))
            {
                TxtMontant.Text = string.Empty;
            }
            
         
            Agriculteur Agr = new Agriculteur();

            GridView view = searchLookUpAgr.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Agriculteurselected = view.GetRowCellValue(rowHandle, fieldName);

            if (Agriculteurselected!=null)
            {
                int IdAgriculteur = Convert.ToInt32(Agriculteurselected);

                Agr = db.Agriculteurs.Find(IdAgriculteur);
                
                List<Achat> Avances = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance && x.Founisseur.Id == Agr.Id && Agr.Solde >= x.MontantRegle && x.MontantRegle > 0 && x.Annulle.Equals("Non")).OrderByDescending(x=> x.Id).ToList();

                achatBindingSource.DataSource = Avances.Select(x => new { x.Id, x.Numero, x.Date,  x.MontantRegle }).ToList(); ;

            }
            else
            {
                achatBindingSource.DataSource = null;
                searchLookUpAgr.Focus();
            }

        }


        private void BtnValider_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Caisse CaisseDb = db.Caisse.Find(1);

            Agriculteur Agr = new Agriculteur();

            GridView view = searchLookUpAgr.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Agriculteurselected = view.GetRowCellValue(rowHandle, fieldName);

            ///Condition existance Fournisseur
            if (Agriculteurselected == null)
            {
                XtraMessageBox.Show("Choisir un Agriculteur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpAgr.Focus();
                return;

            }
            else
            {
                int IdAgriculteur = Convert.ToInt32(Agriculteurselected);
                Agr = db.Agriculteurs.Find(IdAgriculteur);

            }

            if (string.IsNullOrEmpty(TxtMontant.Text))
            {
                XtraMessageBox.Show("Choisir une Avance", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            Achat Avance = new Achat();

            GridView view1 = searchLookUpAvance.Properties.View;
            int rowHandle1 = view1.FocusedRowHandle;
            string fieldName1 = "Id"; // or other field name  
            object Achatselected = view1.GetRowCellValue(rowHandle1, fieldName1);

            ///Condition existance achat
            if (Achatselected == null)
            {
                XtraMessageBox.Show("Choisir une Avance", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpAvance.Focus();
                return;

            }
            else
            {
                int IdAchat = Convert.ToInt32(Achatselected);
                Avance = db.Achats.Find(IdAchat);

            }

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);

            #region Ajouter Alimentation et mouvement caisse

            Alimentation Alimentation = new Alimentation();
            Alimentation.Agriculteur = Agr;
            Alimentation.Montant = Montant;
            Alimentation.Source = SourceAlimentation.AnnulationAvance;
            Alimentation.Commentaire = "Avance Agriculteur ANUL: " + Avance.Numero;
            db.Alimentations.Add(Alimentation);
            db.SaveChanges();
            Alimentation.Numero = "E" + (Alimentation.Id).ToString("D8");

            int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
            MouvementCaisse mvtCaisse = new MouvementCaisse();
            mvtCaisse.MontantSens = Montant;
            mvtCaisse.Date = DateTime.Now;
            mvtCaisse.Agriculteur = Agr;
            mvtCaisse.CodeTiers = Agr.Numero;
            mvtCaisse.Source = "Agriculteur: " + Agr.FullName;
            mvtCaisse.CodeTiers = Agr.Numero;
            mvtCaisse.Sens = Sens.Alimentation;
            mvtCaisse.Commentaire = "Avance Agriculteur ANUL: " + Avance.Numero;
            mvtCaisse.Numero = "E" + (lastMouvement).ToString("D8");


            if (CaisseDb != null)
            {
                CaisseDb.MontantTotal = decimal.Add(CaisseDb.MontantTotal, Montant);

            }

            mvtCaisse.Achat = Avance;
            mvtCaisse.Montant = CaisseDb.MontantTotal;
            db.MouvementsCaisse.Add(mvtCaisse);
            db.SaveChanges();


            if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();

            if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();



                if (db.MouvementsCaisse.Count() > 0)
                {

                    List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                    MouvementCaisse mvt = ListeMvtCaisse.Last();

                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                }

            }


            #endregion

            #region Ajouter avance négative

            Achat A = new Achat();
            A.Avance = false;
            A.AvanceAvecAchat = 0;
            A.Founisseur = Agr;     
            A.NuméroBon = null;
            A.TypeAchat = TypeAchat.Avance;
            A.PrixLitre = 0;
            A.MontantRegle = decimal.Multiply(Montant, -1);
            A.MontantReglement = 0;
            A.NbSacs = 0;
            Agr.Solde = Decimal.Add(Agr.Solde, A.MontantRegle);
            db.Achats.Add(A);
            db.SaveChanges();
            A.Numero = "ANL" + (A.Id).ToString("D8");
            db.SaveChanges();

            List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
            if (db.Agriculteurs.Count() > 0)
            {

                ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats1.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats1.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }

            }
            if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Nom, x.Numero, x.Prenom, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAchats>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();

            if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            

            #endregion


            XtraMessageBox.Show("Avance Anuulée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();

           this.Close();

            Avance.Annulle = "Oui";
            db.SaveChanges();

            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs2 = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs2)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != TypeAchat.Avance && x.TypeAchat != TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }
                agriculteurBindingSource.DataSource = ListAgriculteurs2.Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
            }

            searchLookUpAgr.Text = string.Empty;
            searchLookUpAvance.Text = string.Empty;
            TxtMontant.Text = string.Empty;
            achatBindingSource.DataSource = null;          
        }

        private void searchLookUpAvance_EditValueChanged(object sender, EventArgs e)
        {
            Achat Avance = new Achat();

            GridView view = searchLookUpAvance.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Achatselected = view.GetRowCellValue(rowHandle, fieldName);

            if (Achatselected != null)
            {
                int IdAchat = Convert.ToInt32(Achatselected);
                Avance = db.Achats.Find(IdAchat);
                TxtMontant.Text = Avance.MontantRegle.ToString();
            }

           
        }
    }
}