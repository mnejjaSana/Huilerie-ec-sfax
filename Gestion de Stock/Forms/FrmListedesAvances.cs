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
using Gestion_de_Stock.Model;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Repport;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListedesAvances : DevExpress.XtraEditors.XtraForm
    {
        private static FrmListedesAvances _FrmListedesAvances;
        private Model.ApplicationContext db;

        public static FrmListedesAvances InstanceFrmListedesAvances
        {
            get
            {
                if (_FrmListedesAvances == null)
                    _FrmListedesAvances = new FrmListedesAvances();
                return _FrmListedesAvances;
            }
        }

        public FrmListedesAvances()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListedesAvances_Load(object sender, EventArgs e)
        {
          achatBindingSource.DataSource=  db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
        }

        private void FrmListedesAvances_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListedesAvances = null;
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste des Avences.xlsx";       
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

        private void DateDebut_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin  && x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin  && x.Date <= DateMaxJour && x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void DateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour < DateMin)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin  && x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin && x.Date <= DateMaxJour && x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void BtnImprimerTicket_Click(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Find(A.Id);

            List<Achat> ListeAchats = new List<Achat>();

            if (AchatDb.MontantRegle > 0 && AchatDb.Avance == true)
            {
                ListeAchats.Add(AchatDb);

                xrAvance xrAvance = new xrAvance();

                Societe societe = db.Societe.FirstOrDefault();
                string RsSte = societe.RaisonSocial;

                if (AchatDb.TypeAchat == TypeAchat.Avance)
                {
                    xrAvance.Parameters["RsSte"].Value = RsSte;

                    xrAvance.Parameters["RsSte"].Visible = false;

                    xrAvance.DataSource = ListeAchats;
                    using (ReportPrintTool printTool = new ReportPrintTool(xrAvance))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }
                }
            }

           
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
        }
    }
}