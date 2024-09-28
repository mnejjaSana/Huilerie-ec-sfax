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
    public partial class FrmListeBanques : DevExpress.XtraEditors.XtraForm
    {
        public FrmListeBanques()
        {
            InitializeComponent();
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

            string path = "Liste des Banques.xlsx";

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
    }
}