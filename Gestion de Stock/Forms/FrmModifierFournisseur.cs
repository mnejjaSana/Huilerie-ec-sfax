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
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmModifierFournisseur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierFournisseur _FrmModifierFournisseur;
        public static FrmModifierFournisseur InstanceFrmModifierFournisseur
        {
            get
            {
                if (_FrmModifierFournisseur == null)
                    _FrmModifierFournisseur = new FrmModifierFournisseur();
                return _FrmModifierFournisseur;
            }
        }
        public FrmModifierFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierFournisseur_Load(object sender, EventArgs e)
        {

        }

        private void FrmModifierFournisseur_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmModifierFournisseur = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(TxtTel.Text))
            {
                TxtTel.ErrorText = "Téléphone est obligatoire";
                return;

            }

            if (TxtCin.Text.Length != 8)
            {
                TxtCin.ErrorText = "CIN est invalid";
                return;
            }

            int id = Convert.ToInt32(TxtNumero.Text);

            Agriculteur FournisseurDb = db.Agriculteurs.Find(id);

            if (FournisseurDb != null)
            {
                FournisseurDb.cin = TxtCin.Text;
                FournisseurDb.Nom = TxtNom.Text;
                FournisseurDb.Prenom = TxtPrenom.Text;
                FournisseurDb.Tel = TxtTel.Text;
                FournisseurDb.Vehicule = TxtVehicule.Text;

                //  Agriculteur AgriculteurBD = db.Agriculteurs.SingleOrDefault(a => a.Tel.Equals(TxtTel.Text));
                Agriculteur AgriculteurBD = db.Agriculteurs.Where(x => x.Id != FournisseurDb.Id).SingleOrDefault(a => a.Tel.Equals(TxtTel.Text));


                if (AgriculteurBD != null)
                {
                    TxtTel.ErrorText = "Téléphone existe déja";
                    XtraMessageBox.Show("Agriculteur existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Agriculteur AgriculteurExiste = db.Agriculteurs.Where(x => x.Id != FournisseurDb.Id).FirstOrDefault(x => x.cin.Equals(TxtCin.Text));
                if (AgriculteurExiste != null)
                {
                    TxtCin.ErrorText = "Cin existe déja";
                    XtraMessageBox.Show("Agriculteur existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                db.SaveChanges();

               this.Close();

                // waiting Form
                //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                //for (int i = 0; i < 100; i++)
                //{
                //    Thread.Sleep(10);
                //}
                //SplashScreenManager.CloseForm();
                //waiting Form


                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }


                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = /*db.Agriculteurs.ToList();*/ ListAgriculteurs.Select(x => new { x.Id, x.Numero, x.Nom, x.Prenom, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();


                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault().fournisseurBindingSource.DataSource = db.Agriculteurs.ToList();//ListAgriculteurs.Select(x => new { x.Id, x.Numero, x.Nom, x.Prenom, x.Tel, x.Vehicule, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();

                XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                XtraMessageBox.Show("Echec d'enregisterment  ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}