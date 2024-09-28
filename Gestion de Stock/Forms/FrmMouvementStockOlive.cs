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
using System.Diagnostics;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmMouvementStockOlive : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmMouvementStockOlive _FrmMouvementStockOlive;


        public static FrmMouvementStockOlive InstanceFrmMouvementStockOlive
        {
            get
            {
                if (_FrmMouvementStockOlive == null)
                    _FrmMouvementStockOlive = new FrmMouvementStockOlive();
                return _FrmMouvementStockOlive;
            }
        }
        public FrmMouvementStockOlive()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmMouvementStockOlive_Load(object sender, EventArgs e)
        {
            mouvementStockOliveBindingSource.DataSource = db.MouvementStockOlive.ToList();
        }

        private void exportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste des Mouvements Stock Olive.xlsx";

            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void FrmMouvementStockOlive_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMouvementStockOlive = null;
        }
    }
}