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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmlistePrélèvements : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmlistePrélèvements _FrmlistePrélèvements;

        public static FrmlistePrélèvements InstanceFrmlistePrélèvements
        {
            get
            {
                if (_FrmlistePrélèvements == null)
                    _FrmlistePrélèvements = new FrmlistePrélèvements();
                return _FrmlistePrélèvements;
            }
        }
        public FrmlistePrélèvements()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmlistePrélèvements_Load(object sender, EventArgs e)
        {

            if (db.Prelevements.Count() > 0)
                prelevementBindingSource.DataSource = db.Prelevements.OrderByDescending(x => x.Date).ToList();
        }

        private void FrmlistePrélèvements_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmlistePrélèvements = null;
        }

        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

          
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                prelevementBindingSource.DataSource = db.Prelevements.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                prelevementBindingSource.DataSource = db.Prelevements.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();
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
                prelevementBindingSource.DataSource = db.Prelevements.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                prelevementBindingSource.DataSource = db.Prelevements.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();
            }
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Prelevements.xlsx";

            ////Customize export options
            //(gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            //XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            //advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.SheetName = "Exported from Data Grid";

            //gridControl1.ExportToXlsx(path, advOptions);
            //// Open the created XLSX file with the default application.
            //Process.Start(path);

          
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            if (db.Prelevements.Count() > 0)
                prelevementBindingSource.DataSource = db.Prelevements.OrderByDescending(x => x.Date).ToList();
        }
    }
}