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
    public partial class FrmModifierClient : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierClient _FrmModifierClient;
        private object gridView1;

        public static FrmModifierClient InstanceFrmModifierClient
        {
            get
            {
                if (_FrmModifierClient == null)
                    _FrmModifierClient = new FrmModifierClient();
                return _FrmModifierClient;
            }
        }
        public FrmModifierClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierClient_Load(object sender, EventArgs e)
        {

        }

        private void FrmModifierClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierClient = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCode.Text);
            Client ClientDb = db.Clients.Find(id);
           if(ClientDb!= null) {

                ClientDb.Intitule = TxtNom.Text;
               
                ClientDb.Adresse = TxtAdress.Text;
                ClientDb.Tel = TxtTelephone.Text;
                ClientDb.MatriculeFiscale= TxtMF.Text;


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
            if (Application.OpenForms.OfType<FrmClient>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmClient>().FirstOrDefault().clientBindingSource.DataSource = db.Clients.ToList();
            XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Echec de l'enregisterment  ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}