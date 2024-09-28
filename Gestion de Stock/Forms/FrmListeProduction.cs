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
using Gestion_de_Stock.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeProduction : DevExpress.XtraEditors.XtraForm

    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmListeProduction _FrmListeProduction;
        
        public static FrmListeProduction InstanceFrmListeProduction
        {
            get
            {
                if (_FrmListeProduction == null)
                    _FrmListeProduction = new FrmListeProduction();
                return _FrmListeProduction;
            }
        }


        public FrmListeProduction()
        {

            db = new Model.ApplicationContext();
            InitializeComponent();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            GridView view = sender as GridView;

            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath0 = executingFolder + "\\Image\\imagesaisie.png";
            Image imagesaisie = Image.FromFile(dbPath0);

            var dbPath = executingFolder + "\\Image\\lance.png";
            Image imageLance = Image.FromFile(dbPath);

            var dbPath2 = executingFolder + "\\Image\\Termine.png";
            Image imageTermine = Image.FromFile(dbPath2);

            var dbPath3 = executingFolder + "\\Image\\archive.png";
            Image imageArchive = Image.FromFile(dbPath3);


            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (e.Column.FieldName == "StatutProd")
                {

                    if (Convert.ToInt32(e.CellValue) == 1)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imagesaisie, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }
                    else if (Convert.ToInt32(e.CellValue) == 2)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageLance, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 3)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageTermine, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 4)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageArchive, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                }
            }

        }

        private void FrmListeProduction_Load(object sender, EventArgs e)
        {
            productionBindingSource.DataSource = db.Productions.ToList();
        }

        private void FrmListeProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeProduction = null;
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Productions.xlsx";

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

        

        private void dateDébut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDébut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            //if (DateMaxJour.CompareTo(DateMin)<0)
            //{
            //    XtraMessageBox.Show("Date Fin est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.DateProd.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.DateProd.CompareTo(DateMin) >= 0 && x.DateProd.CompareTo(DateMaxJour) <= 0).ToList();
            }

        }

        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDébut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.DateProd.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.DateProd.CompareTo(DateMin) >= 0 && x.DateProd.CompareTo(DateMaxJour) <= 0).ToList();
            }
        }

        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
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

        private void repositoryBtnDetail_Click(object sender, EventArgs e)
        {
            Production prod = gridView1.GetFocusedRow() as Production;

            if (prod.StatutProd == Model.Enumuration.StatutProduction.Stocké)
            { 

                 db = new Model.ApplicationContext();

                List<LigneStock> ligneStockDb = db.LignesStock.Where(x => x.production.Id.Equals(prod.Id)).ToList();

                FormshowNotParent(Forms.FrmDetailsProdution.InstanceDetailsProdution);

                if (Application.OpenForms.OfType<FrmDetailsProdution>().FirstOrDefault() != null)
                {
                     Application.OpenForms.OfType<FrmDetailsProdution>().First().ligneStockBindingSource.DataSource = ligneStockDb;
                }

            }
            else
            {

                XtraMessageBox.Show("Votre Demande est Non Autorisée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

      

        private void FrmListeProduction_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {

                FormshowNotParent(Forms.FrmModifierProduction.InstanceFrmModifierProduction);
            }
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            productionBindingSource.DataSource = db.Productions.ToList();
        }
    }
    
}