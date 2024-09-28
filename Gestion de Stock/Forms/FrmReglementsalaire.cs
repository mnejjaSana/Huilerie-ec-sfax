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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmReglementsalaire : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmReglementsalaire _FrmReglementsalaire;
        public static FrmReglementsalaire InstanceFrmReglementsalaire
        {
            get
            {
                if (_FrmReglementsalaire == null)
                    _FrmReglementsalaire = new FrmReglementsalaire();
                return _FrmReglementsalaire;
            }
        }

        public FrmReglementsalaire()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmReglementsalaire_Load(object sender, EventArgs e)
        {
            List<Salarier> SalarieList = db.Salariers.ToList();
            salarierBindingSource.DataSource = SalarieList;
        }

        private void FrmReglementsalaire_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmReglementsalaire = null;
        }

        private void repositoryItemAjouterReglement_Click(object sender, EventArgs e)
        {
            //Salarier s = gridView1.GetFocusedRow() as Salarier;
            //db = new Model.ApplicationContext();
            //Salarier SalarierDb = db.Salariers.Find(s.Id);

            //if (SalarierDb.EtatSalarie != EtatSalarie.Reglee)
            //{ 
            //     FormshowNotParent(Forms.FrmAjouterReglementSalarier.InstanceFrmAjouterReglementSalarier);
            //     if (Application.OpenForms.OfType<FrmAjouterReglementSalarier>().FirstOrDefault() != null)
            //        {
            //            Application.OpenForms.OfType<FrmAjouterReglementSalarier>().First().TxtCodeSalarier.Text = SalarierDb.Id.ToString();
            //            Application.OpenForms.OfType<FrmAjouterReglementSalarier>().First().Txtintitule.Text  = SalarierDb.Intitule;
            //            Application.OpenForms.OfType<FrmAjouterReglementSalarier>().First().TxtAvance.Text = SalarierDb.MontantReglé.ToString();
            //            Application.OpenForms.OfType<FrmAjouterReglementSalarier>().First().TxtMontantTotal.Text = SalarierDb.MontantTotal.ToString();
            //            Application.OpenForms.OfType<FrmAjouterReglementSalarier>().First().TxtSolde.Text = SalarierDb.MontantRestReglé.ToString();
            //            Application.OpenForms.OfType<FrmAjouterReglementSalarier>().First().TxtMontantAPayer.Text = SalarierDb.MontantRestReglé.ToString();
            //         }


            //}
            //else
            //{
            //    XtraMessageBox.Show("Salarié Réglé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //}

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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;

            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath = executingFolder + "\\Image\\Reglee_16x16.png";
            Image imageReglee = Image.FromFile(dbPath);

            var dbPath2 = executingFolder + "\\Image\\NonReglee_16x16.png";
            Image imageNonReglee = Image.FromFile(dbPath2);

            var dbPath3 = executingFolder + "\\Image\\PR_16x16.png";
            Image imagePR = Image.FromFile(dbPath3);


            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (e.Column.FieldName == "EtatSalarie")
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
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void repositoryHistoriquePaiement_Click(object sender, EventArgs e)
        {
            Salarier S = gridView1.GetFocusedRow() as Salarier;

            db = new Model.ApplicationContext();

            List<HistoriquePaiementSalarie> result = db.HistoriquePaiementSalaries.Where(x => x.Salarie.numero.Equals(S.numero)).ToList();

            FormshowNotParent(Forms.FrmHistoriquePaiementSalarie.InstanceFrmHistoriquePaiementSalarie);

            if (Application.OpenForms.OfType<FrmHistoriquePaiementSalarie>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmHistoriquePaiementSalarie>().First().historiquePaiementSalarieBindingSource.DataSource = result;
            }
        }
    }
}