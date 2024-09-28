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
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeDepensesAgriculteurs : DevExpress.XtraEditors.XtraForm
    {

        public Model.ApplicationContext db { get; set; }
        private static FrmListeDepensesAgriculteurs _FrmListeDepensesAgriculteurs;



        public static FrmListeDepensesAgriculteurs InstanceFrmListeDepensesAgriculteurs
        {
            get
            {
                if (_FrmListeDepensesAgriculteurs == null)
                    _FrmListeDepensesAgriculteurs = new FrmListeDepensesAgriculteurs();
                return _FrmListeDepensesAgriculteurs;
            }
        }

        public FrmListeDepensesAgriculteurs()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeDepensesAgriculteurs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeDepensesAgriculteurs = null;
        }

        private void FrmListeDepensesAgriculteurs_Load(object sender, EventArgs e)
        {
            depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
        }

        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);


            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.Nature != NatureMouvement.Autre && x.Nature != NatureMouvement.ClôtureCaisse && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.Salarié && x.Nature != NatureMouvement.ModificationService).ToList();
            }
            else
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0 && x.Nature != NatureMouvement.Autre && x.Nature != NatureMouvement.ClôtureCaisse && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.Salarié && x.Nature != NatureMouvement.ModificationService).ToList();
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
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.Nature != NatureMouvement.Autre && x.Nature != NatureMouvement.ClôtureCaisse && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.Salarié && x.Nature != NatureMouvement.ModificationService && x.Montant > 0).ToList();
            }
            else
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0 && x.Nature != NatureMouvement.Autre && x.Nature != NatureMouvement.ClôtureCaisse && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.Salarié && x.Nature != NatureMouvement.ModificationService && x.Montant > 0).ToList();
            }

        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Depenses Agriculteurs.xlsx";

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

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
        }
    }
}