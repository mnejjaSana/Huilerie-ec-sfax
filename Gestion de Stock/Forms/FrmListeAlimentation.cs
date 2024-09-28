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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeAlimentation : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmListeAlimentation _FrmListeAlimentation;
        public static FrmListeAlimentation InstanceFrmListeAlimentation
        {
            get
            {
                if (_FrmListeAlimentation == null)
                    _FrmListeAlimentation = new FrmListeAlimentation();
                return _FrmListeAlimentation;
            }
        }

        public FrmListeAlimentation()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeAlimentation_Load(object sender, EventArgs e)
        {
            if (db.Alimentations.Count() > 0)
                alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x=>x.DateCreation).ToList();
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

        private void FrmListeAlimentation_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeAlimentation = null;
        }

       
        private void BtnExportExcel_Click(object sender, EventArgs e)
        {

            string path = "Liste Alimentations.xlsx";     
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPdF_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                alimentationBindingSource.DataSource = db.Alimentations.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                alimentationBindingSource.DataSource = db.Alimentations.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).ToList();
            }

        }

        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                alimentationBindingSource.DataSource = db.Alimentations.Where(x => x.DateCreation.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                alimentationBindingSource.DataSource = db.Alimentations.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0).ToList();
            }
           
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            if (db.Alimentations.Count() > 0)
                alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();
        }
    }
}