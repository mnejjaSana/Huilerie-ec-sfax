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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterClient : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterClient _FrmAjouterClient;

        public static FrmAjouterClient InstanceFrmAjouterClient
        {
            get
            {
                if (_FrmAjouterClient == null)
                    _FrmAjouterClient = new FrmAjouterClient();
                return _FrmAjouterClient;
            }
        }



        public FrmAjouterClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterClient = null;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(TxtNom.Text))
            {
                TxtNom.ErrorText = "Nom  est obligatoire";
                return;

            }
          
            if (string.IsNullOrEmpty(TxtAdress.Text))
            {
                TxtAdress.ErrorText = "Adresse  est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtTelephone.Text))
            {
                TxtTelephone.ErrorText = "Téléphone est obligatoire";
                return;

            }

            Client ClientBD = db.Clients.FirstOrDefault(a => a.Tel.Equals(TxtTelephone.Text));


            if (ClientBD != null)
            {
                TxtTelephone.ErrorText = "Téléphone existe déja";
                XtraMessageBox.Show("Client existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Client ClientExiste = db.Clients.SingleOrDefault(a => a.Intitule.Equals(TxtNom.Text));

            if (ClientExiste != null  && ClientExiste.Tel.Equals(TxtTelephone.Text) && ClientExiste.Adresse.Equals(TxtAdress.Text))
            {

                XtraMessageBox.Show("Client existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            Client c = new Client();            
            c.Intitule= TxtNom.Text;
            c.Adresse = TxtAdress.Text;
            c.Tel = TxtTelephone.Text;
            c.MatriculeFiscale =  TxtMatriculeFiscale.Text;


            db.Clients.Add(c);
            db.SaveChanges();
            c.Numero = "CLT" + (c.Id).ToString("D8");
            db.SaveChanges();

            XtraMessageBox.Show("Client Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtNom.Text = string.Empty;
         
            TxtTelephone.Text = string.Empty;
            TxtAdress.Text = string.Empty;
           
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
            if (Application.OpenForms.OfType<FrmClient>().FirstOrDefault()!=null)
            Application.OpenForms.OfType<FrmClient>().First().clientBindingSource.DataSource = db.Clients.ToList();

            if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterVente>().First().clientBindingSource.DataSource = db.Clients.ToList();

            if (Application.OpenForms.OfType<FrmEtatClient>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmEtatClient>().First().clientBindingSource.DataSource = db.Clients.ToList();


        }

        private void FrmAjouterClient_Load(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            TxtAdress.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtTelephone.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;   
            TxtNom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
           
        }

       
    }
}