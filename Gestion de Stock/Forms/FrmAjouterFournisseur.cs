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
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.IO;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterFournisseur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private string filePathBattante = string.Empty;
        private string filePathRegistredecommerce = string.Empty;
        private string filePathAttestationExoneration = string.Empty;


        private static FrmAjouterFournisseur _FrmAjouterFournisseur;
        public static FrmAjouterFournisseur InstanceFrmAjouterFournisseur
        {
            get
            {
                if (_FrmAjouterFournisseur == null)
                    _FrmAjouterFournisseur = new FrmAjouterFournisseur();
                return _FrmAjouterFournisseur;
            }
        }
        public FrmAjouterFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterFournisseur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterFournisseur = null;
        }

        private void FrmAjouterFournisseur_Load(object sender, EventArgs e)
        {

            TxtNom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtPrenom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtTelephone.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

         

        }


        private void BtnAjouter_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(TxtNom.Text))
            {
                TxtNom.ErrorText = "Nom est obligatoire";
                return;


            }
            if (string.IsNullOrEmpty(TxtPrenom.Text))
            {
                TxtPrenom.ErrorText = "Prénom est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtCin.Text))
            {
                TxtCin.ErrorText = "CIN est obligatoire";
                return;
            }
            if (string.IsNullOrEmpty(TxtTelephone.Text))
            {
                TxtTelephone.ErrorText = "Téléphone est obligatoire";
                return;

            }

            if (TxtCin.Text.Length !=8)
            {
                TxtCin.ErrorText = "CIN est invalid";
                return;
            }

            Agriculteur AgriculteurBD = db.Agriculteurs.SingleOrDefault(a => a.Tel.Equals(TxtTelephone.Text));


            if (AgriculteurBD != null)
            {
                TxtTelephone.ErrorText = "Téléphone existe déja";
                XtraMessageBox.Show("Agriculteur existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Agriculteur AgriculteurExiste = db.Agriculteurs.FirstOrDefault(x => x.cin.Equals(TxtCin.Text));
            if (AgriculteurExiste != null)
            {
                TxtCin.ErrorText = "Cin existe déja";
                XtraMessageBox.Show("Agriculteur existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Agriculteur Agriculteur = new Agriculteur();

            Agriculteur.cin = TxtCin.Text;
            Agriculteur.Nom = TxtNom.Text;
            Agriculteur.Prenom = TxtPrenom.Text;
            Agriculteur.Tel = TxtTelephone.Text;
            Agriculteur.Vehicule = TxtVehicule.Text;
            db.Agriculteurs.Add(Agriculteur);
            db.SaveChanges();
            Agriculteur.Numero = "AGR" + (Agriculteur.Id).ToString("D8");
            db.SaveChanges();
            XtraMessageBox.Show("Agriculteur Enregisté ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtCin.Text = string.Empty;
            TxtNom.Text = string.Empty;
            TxtPrenom.Text = string.Empty;
            TxtTelephone.Text = string.Empty;
            TxtVehicule.Text = string.Empty;


           this.Close();

            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();
            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }
                //waiting Form
                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Numero, x.Nom, x.Prenom, x.cin, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();

                if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();




            }

        }



    }
}