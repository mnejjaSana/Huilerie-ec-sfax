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
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmClient : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmClient _FrmClient;
        public static FrmClient InstanceFrmClient
        {
            get
            {
                if (_FrmClient == null)
                    _FrmClient = new FrmClient();
                return _FrmClient;
            }
        }
        public FrmClient()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            List<Client> ClientList = db.Clients.ToList();
            clientBindingSource.DataSource = ClientList;



        }

        private void FrmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmClient = null;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            Client C = gridView1.GetFocusedRow() as Client;
           
            db = new Model.ApplicationContext();
            if (C != null)
            {
                Client ClientDb = db.Clients.Find(C.Id);
                FormshowNotParent(Forms.FrmModifierClient.InstanceFrmModifierClient);
                if (Application.OpenForms.OfType<FrmModifierClient>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtCode.Text = ClientDb.Id.ToString();

                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtNom.Text = ClientDb.Intitule;

                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtTelephone.Text = ClientDb.Tel;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtAdress.Text = ClientDb.Adresse;
                    Application.OpenForms.OfType<FrmModifierClient>().First().TxtMF.Text = ClientDb.MatriculeFiscale;

                }

            }
            else
            {
                XtraMessageBox.Show("Aucun Client séléctionné", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer ce client ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Client C = gridView1.GetFocusedRow() as Client;
                if(C==null)
                {
                    XtraMessageBox.Show("Echec de Suppression", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Client ClientDb = db.Clients.Find(C.Id);

                Vente v = db.Vente.Where(x => x.IdClient == ClientDb.Id).FirstOrDefault();

                if (v != null)

                {
                    XtraMessageBox.Show("Votre Demande est Non Autorisée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    db.Clients.Remove(ClientDb);
                    db.SaveChanges();
                    List<Client> ClientList = db.Clients.ToList();
                   clientBindingSource.DataSource = ClientList;

                //ClientBb.Status = Status.Bloquer;

                /***************************** reload DataGridView ***********************************/
                // clientBindingSource.DataSource = db.Clients.Where(x=>x.Status== Status.Active).Select(x => new { x.Code, x.RaisonSociale, x.Nom, x.Prenom, x.Telephone, x.Ville, x.Adresse, x.Email }).ToList();
                //     clientBindingSource.DataSource = db.Clients.Where(x => x.Status == Status.Active).ToList();
                /***************************** reload DataGridView  ***********************************/
                XtraMessageBox.Show("Le client a été supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else
            {
             
                XtraMessageBox.Show("La Suppression a été annulée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       

       

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterClient.InstanceFrmAjouterClient);
        }
        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter ....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void BtnExporterXLS_Click(object sender, EventArgs e)
        {
            string path = "Liste Clients.xlsx";

            //Customize export options
            (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = true;
            XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            advOptions.SheetName = "Exported from Data Grid";

            gridControl1.ExportToXlsx(path, advOptions);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExporterPDF_Click(object sender, EventArgs e)
        {
            // Check whether or not the Grid Control can be printed.
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            List<Client> ClientList = db.Clients.ToList();
            clientBindingSource.DataSource = ClientList;

        }
    }
}