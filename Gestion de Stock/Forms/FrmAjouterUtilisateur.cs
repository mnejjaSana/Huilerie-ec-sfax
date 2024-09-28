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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterUtilisateur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmAjouterUtilisateur _FrmAjouterUtilisateur;
        public static FrmAjouterUtilisateur InstanceFrmAjouterUtilisateur
        {
            get
            {
                if (_FrmAjouterUtilisateur == null)
                    _FrmAjouterUtilisateur = new FrmAjouterUtilisateur();
                return _FrmAjouterUtilisateur;
            }
        }
        public FrmAjouterUtilisateur()
        {

            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterUtilisateur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterUtilisateur = null;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            
           if (String.IsNullOrEmpty(TxtLogin.Text))
            {
                TxtLogin.ErrorText = "Login  est obligatoire";
                return;

            }
            if (String.IsNullOrEmpty(TxtPassword.Text))
            {
                TxtPassword.ErrorText = "Password  est obligatoire";
                return;
            }
            if (String.IsNullOrEmpty(TxtNom.Text))
            {
                TxtNom.ErrorText = "Nom  est obligatoire";
                return;
            }
            if (String.IsNullOrEmpty(TxtPrenom.Text))
            {
                TxtPrenom.ErrorText = "Prenom  est obligatoire";
                return;
            }
            if (String.IsNullOrEmpty(TxTEmail.Text))
            {
                TxTEmail.ErrorText = "Email  est obligatoire";
                return;
            }
            else
            {
                string email = TxTEmail.Text;
                System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{1,28}@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (!expr.IsMatch(email))
                {
                    TxTEmail.ErrorText = "Adresse EMAIL non Valide";
                    return;
                }
            }
            Boolean AdminRole = false;
            if(checkEditAdmin.Checked)
            { AdminRole = true; }
            else
            { AdminRole = false; }
            db.Utilisateurs.Add(new Model.Utilisateur {Id = 0,Login=TxtLogin.Text.Trim(),Nom=TxtNom.Text.Trim(), Prenom=TxtPrenom.Text.Trim(), Password=TxtPassword.Text.Trim() });
            db.SaveChanges();
            
            XtraMessageBox.Show("votre compte d'utilisateur a été ajouté", "Ajouter Utilisateur", MessageBoxButtons.OK);
            TxtNom.Text = string.Empty;
            TxtPrenom.Text = string.Empty;
            TxtLogin.Text = string.Empty;
            TxtPassword.Text = string.Empty;
           
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
            Application.OpenForms.OfType<FrmUtilisateur>().First().utilisateurBindingSource.DataSource = db.Utilisateurs.ToList();
        }

        private void FrmAjouterUtilisateur_Load(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            TxtNom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtLogin.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtPassword.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtPrenom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
         
        }

        private void FrmAjouterUtilisateur_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtLogin;
        }
    }
}