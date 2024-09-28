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
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using System.Globalization;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmModifierProduction : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private static FrmModifierProduction _FrmModifierProduction;
        public static FrmModifierProduction InstanceFrmModifierProduction
        {
            get
            {
                if (_FrmModifierProduction == null)
                    _FrmModifierProduction = new FrmModifierProduction();
                return _FrmModifierProduction;
            }
        }


        public FrmModifierProduction()
        {
            InitializeComponent();

            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmModifierProduction_Load(object sender, EventArgs e)
        {
            productionBindingSource.DataSource = db.Productions.ToList();
        }

        private void searchLookUpProduction_EditValueChanged(object sender, EventArgs e)
        {
            Production P = new Production();
            GridView view = searchLookUpProduction.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object ProdSelected = view.GetRowCellValue(rowHandle, fieldName);

            if (ProdSelected != null)
            {

                int IdProd = Convert.ToInt32(ProdSelected);
                P = db.Productions.Find(IdProd);

                TxtNumAchat.Text = P.Achat.Numero;

                TxtAgriculteur.Text = P.Achat.Founisseur.FullName;

                TxtQteHuileProd.Text =  Math.Round(P.Achat.QteLitre,3).ToString();

                TxtMontantOperation.Text = Math.Round(P.Achat.MontantReglement,3).ToString();

                TxtAvance.Text = Math.Round(P.Achat.MontantRegle,3).ToString();

                TxtSolde.Text = Math.Round(P.Achat.ResteApayer,3).ToString();


                if (P.Achat.TypeAchat == Model.Enumuration.TypeAchat.Base)
                {
                    TxtPrixKgHuile.Text = P.Achat.PrixLitre.ToString();
                    layoutControlPrixKgHuile.Visibility = LayoutVisibility.Always;

                }
                else if (P.Achat.TypeAchat == Model.Enumuration.TypeAchat.Service)
                {
                    layoutControlPrixKgHuile.Visibility = LayoutVisibility.Never;
                    layoutNumAchat.Text = "N° Service";
                    TxtMontantOperation.ReadOnly = false;

                }
                
              

            }
        }

        private void FrmModifierProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierProduction = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            decimal PrixKgHuile;
            string PrixLitreStr = TxtPrixKgHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PrixLitreStr, out PrixKgHuile);


            decimal MontantReglement;
            string MontantOperationStr = TxtMontantOperation.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantOperationStr, out MontantReglement);

            decimal Avance;
            string AvanceStr = TxtAvance.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(AvanceStr, out Avance);


            decimal Solde;
            string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);


            Production P = new Production();
            GridView view = searchLookUpProduction.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object ProdSelected = view.GetRowCellValue(rowHandle, fieldName);

            if (ProdSelected != null)
            {
                int IdProd = Convert.ToInt32(ProdSelected);
                P = db.Productions.Find(IdProd);

            }


          

            P.Achat.MontantReglement = MontantReglement;

          


            if (P.Achat.TypeAchat == TypeAchat.Base)
            {
                P.Achat.PrixLitre = PrixKgHuile;


                if (Avance == MontantReglement && MontantReglement != 0)
                {
                    P.Achat.EtatAchat = EtatAchat.Reglee;
                }

 
                else if (P.Achat.ResteApayer < MontantReglement && MontantReglement != 0 && P.Achat.ResteApayer!= 0)
                {
                    P.Achat.EtatAchat = EtatAchat.PartiellementReglee;
                }

                else if (Avance == 0 && MontantReglement == 0)
                {
                    P.Achat.EtatAchat = EtatAchat.NonReglee;
                }

                else if (P.Achat.ResteApayer < 0)
                {
                    P.Achat.EtatAchat = EtatAchat.PartiellementReglee;
                }

            }

            if (P.Achat.TypeAchat == TypeAchat.Service)
            {

                if (Avance > MontantReglement && MontantReglement != 0 && P.Achat.ResteApayer < 0)
                {
                    P.Achat.EtatAchat = EtatAchat.Reglee;
                }

                

                else if (P.Achat.ResteApayer < MontantReglement && MontantReglement != 0 && P.Achat.ResteApayer > 0)
                {
                    P.Achat.EtatAchat = EtatAchat.PartiellementReglee;
                }

            }

            // Modifier Prix Moyen Pile

           
            //decimal QteHuile;
            //string QteHuileStr = TxtQteHuileProd.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            //decimal.TryParse(QteHuileStr, out QteHuile);


            //List<LigneStock> LS = db.LignesStock.Where(x => x.production.Id == P.Id).ToList();
            //foreach (var item in LS)
            //{
            //    var capaciteInitial = item.QuantitePileInitial;

            //    var capaciteFinal = item.QuantitePileFinal;

            //    Pile PileDb = db.Piles.FirstOrDefault(x => x.Id == item.pile.Id);

            //    PileDb.PrixMoyen = decimal.Divide(decimal.Add( decimal.Multiply(PrixKgHuile, QteHuile) , decimal.Multiply(capaciteInitial, PileDb.PrixMoyen) ) , capaciteFinal);
            //    db.SaveChanges();
            //}

            //db.SaveChanges();

            //if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
            //    Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();


            #region Ajouter historique paiement achat

            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();

            HP.DateCreation = DateTime.Now;
            HP.Founisseur = P.Achat.Founisseur;
            HP.NumAchat = P.Achat.Numero;
            HP.MontantReglement = P.Achat.MontantReglement;
            HP.MontantRegle = P.Achat.MontantRegle;
            HP.ResteApayer = P.Achat.ResteApayer;
            HP.Commentaire = "Modification Achat";
            HP.TypeAchat = P.Achat.TypeAchat;
            db.HistoriquePaiementAchats.Add(HP);
            db.SaveChanges();


            #endregion

            if (P.Achat.TypeAchat == TypeAchat.Service && MontantReglement < Avance)
            {
           
                 // Ajouter dépense
                   Depense D = new Depense();

                    D.Montant = Avance - MontantReglement;

                D.Nature = NatureMouvement.ModificationService;

                D.Commentaire = "Modification Service N° " + P.Achat.Numero;

                    db.Depenses.Add(D);

                //Ajouter mvt caisse
                    MouvementCaisse mvtCaisse = new MouvementCaisse();
                    mvtCaisse.MontantSens = (Avance - MontantReglement) * -1;
                    mvtCaisse.Sens = Sens.Depense;
                    mvtCaisse.Date = DateTime.Now;
                    mvtCaisse.Source = "Agriculteur: " + P.Achat.Founisseur.FullName;


                     mvtCaisse.Commentaire = "Modification Service N° " + P.Achat.Numero;

                Caisse CaisseDb = db.Caisse.Find(1);

                if (CaisseDb != null)
                    {
                        CaisseDb.MontantTotal = CaisseDb.MontantTotal - (Avance - MontantReglement);

                    }
                    int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                    mvtCaisse.Montant = CaisseDb.MontantTotal;
                    db.Depenses.Add(D);
                    db.SaveChanges();
                    mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                    mvtCaisse.Achat = P.Achat;
                    db.MouvementsCaisse.Add(mvtCaisse);
                    db.SaveChanges();

                    if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.ToList();

                    if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)

                    {
                        Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();

                        db = new Model.ApplicationContext();

                        if (db.MouvementsCaisse.Count() > 0)
                        {

                            List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                            MouvementCaisse mvt = ListeMvtCaisse.Last();

                            Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                    }
                    }
                }

       

           this.Close();

            searchLookUpProduction.EditValue = searchLookUpProduction.Properties.NullText;
            TxtAgriculteur.Text = string.Empty;
            TxtAvance.Text = string.Empty;
            TxtMontantOperation.Text = string.Empty;
            TxtNumAchat.Text = string.Empty;
            TxtPrixKgHuile.Text = string.Empty;
            TxtQteHuileProd.Text = string.Empty;
            TxtSolde.Text = string.Empty;


            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();

            XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

            if (Application.OpenForms.OfType<FrmSuivie>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmSuivie>().First().productionBindingSource.DataSource = db.Productions.OrderByDescending(x => x.DateProd).ToList();

        }

        private void TxtPrixKgHuile_EditValueChanged(object sender, EventArgs e)
        {
            Production P = new Production();
            GridView view = searchLookUpProduction.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object ProdSelected = view.GetRowCellValue(rowHandle, fieldName);

            if (ProdSelected != null)
            {
                int IdProd = Convert.ToInt32(ProdSelected);
                P = db.Productions.Find(IdProd);

            }

            decimal PrixKgHuile;
            string PrixLitreStr = TxtPrixKgHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PrixLitreStr, out PrixKgHuile);

            decimal QteHuileProd;
            string QteHuileProdStr = TxtQteHuileProd.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QteHuileProdStr, out QteHuileProd);


            decimal Avance;
            string AvanceStr = TxtAvance.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(AvanceStr, out Avance);

            var NVMontantOperation = PrixKgHuile * QteHuileProd;

            TxtMontantOperation.Text = Math.Round(NVMontantOperation).ToString();

            TxtSolde.Text = Math.Round(( NVMontantOperation - Avance)).ToString();
        }

        private void TxtMontantOperation_EditValueChanged(object sender, EventArgs e)
        {

            decimal MontantReglement;
            string MontantOperationStr = TxtMontantOperation.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantOperationStr, out MontantReglement);


            decimal Avance;
            string AvanceStr = TxtAvance.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(AvanceStr, out Avance);


            TxtSolde.Text = Math.Round(MontantReglement - Avance).ToString();
        }
    }
}