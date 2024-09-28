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
using Gestion_de_Stock.Model;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSuivie : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmSuivie _FrmSuivie;
        public static FrmSuivie InstanceFrmSuivie
        {
            get
            {
                if (_FrmSuivie == null)
                    _FrmSuivie = new FrmSuivie();
                return _FrmSuivie;
            }
        }


        public FrmSuivie()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmSuivie_Load(object sender, EventArgs e)
        {
            productionBindingSource.DataSource = db.Productions.ToList();
        }

        private void FrmSuivie_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmSuivie = null;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            GridView view = sender as GridView;

            #region image etat Achat
            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath = executingFolder + "\\Image\\Reglee_16x16.png";
            Image imageReglee = Image.FromFile(dbPath);

            var dbPath2 = executingFolder + "\\Image\\NonReglee_16x16.png";
            Image imageNonReglee = Image.FromFile(dbPath2);

            var dbPath3 = executingFolder + "\\Image\\PR_16x16.png";
            Image imagePR = Image.FromFile(dbPath3);
            #endregion

            #region image statut Prod
            var dbPath0 = executingFolder + "\\Image\\imagesaisie.png";
            Image imagesaisie = Image.FromFile(dbPath0);

            var dbPath4 = executingFolder + "\\Image\\lance.png";
            Image imageLance = Image.FromFile(dbPath4);

            var dbPath5 = executingFolder + "\\Image\\Termine.png";
            Image imageTermine = Image.FromFile(dbPath5);

            var dbPath6 = executingFolder + "\\Image\\archive.png";
            Image imageArchive = Image.FromFile(dbPath6);

            #endregion

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (e.Column.FieldName == "Achat.EtatAchat")
                {

                    if (Convert.ToInt32(e.CellValue) == 3)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 1)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageNonReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                    else if (Convert.ToInt32(e.CellValue) == 2)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imagePR, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }

                }


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

        private void repositoryItemBtnDetailEmplacement_Click(object sender, EventArgs e)
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

                XtraMessageBox.Show("Production Non Stockée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            //if (DateMaxJour.CompareTo(DateMin)<0)
            //{
            //    XtraMessageBox.Show("Date Fin est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.Achat.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.Achat.Date.CompareTo(DateMin) >= 0 && x.Achat.Date.CompareTo(DateMaxJour) <= 0).ToList();
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
                productionBindingSource.DataSource = db.Productions.Where(x => x.Achat.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                productionBindingSource.DataSource = db.Productions.Where(x => x.Achat.Date.CompareTo(DateMin) >= 0 && x.Achat.Date.CompareTo(DateMaxJour) <= 0).ToList();
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Suivie.xlsx";

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

        private void BtnExportPdf_Click(object sender, EventArgs e)
        {
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
            productionBindingSource.DataSource = db.Productions.ToList();
        }
    }
}