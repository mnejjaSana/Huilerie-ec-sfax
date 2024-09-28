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
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEmplacement : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmEmplacement _FrmEmplacement;
        public static FrmEmplacement InstanceFrmEmplacement
        {
            get
            {
                if (_FrmEmplacement == null)
                    _FrmEmplacement = new FrmEmplacement();
                return _FrmEmplacement;
            }
        }

        public FrmEmplacement()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmEmplacement_Load(object sender, EventArgs e)
        {
            emplacementBindingSource.DataSource = db.Emplacements.ToList();
        }

        private void FrmEmplacement_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEmplacement = null;
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Emplacements.xlsx";

            gridControl1.ExportToXlsx(path);

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

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            emplacementBindingSource.DataSource = db.Emplacements.ToList();
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

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterEmplacement.InstanceFrmAjouterEmplacement);
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer cet emplacement ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                Emplacement emp = gridView1.GetFocusedRow() as Emplacement;

                if (emp == null)
                {
                    XtraMessageBox.Show("Aucun Emplacement séléctionné", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db = new Model.ApplicationContext();

                Emplacement empDB = db.Emplacements.Find(emp.Id);

                Achat Achatbd = db.Achats.Where(x => x.TypeAchat== Model.Enumuration.TypeAchat.Olive && x.Emplacement.Id== empDB.Id ).FirstOrDefault();

                Production Prod = db.Productions.Where(x => x.Emplacement.Id == empDB.Id).FirstOrDefault();

                MouvementStockOlive empMvmStock = db.MouvementStockOlive.Where(x => x.Emplacement.Id == empDB.Id).FirstOrDefault();


                if ( Achatbd != null || Prod != null || empMvmStock != null || empDB.Quantite > 0)

                {
                    XtraMessageBox.Show("Votre demande est non autorisée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.Emplacements.Remove(empDB);
                    db.SaveChanges();

                    /***************************** reload DataGridView ***********************************/
                    emplacementBindingSource.DataSource = db.Emplacements.ToList();
                    /***************************** reload DataGridView  ***********************************/
                    XtraMessageBox.Show("Emplacement Supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db = new Model.ApplicationContext();
                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    {

                        if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("Nchira"))
                        {
                            Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.Nchira).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                        }

                        else if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("OliveVif"))
                        {
                            Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

                        }

                    }

                    if (Application.OpenForms.OfType<FrmTransfertEmplacement>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmTransfertEmplacement>().First().emplacementEntrantBindingSource.DataSource = db.Emplacements.AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                        emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;
                    }



                }
            }

            else
            {

                XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {

            Emplacement Emplacement = gridView1.GetFocusedRow() as Emplacement;
            db = new Model.ApplicationContext();
            if (Emplacement != null)
            {
                Emplacement EmplacementDb = db.Emplacements.Find(Emplacement.Id);

                if(EmplacementDb==null)
                {
                    XtraMessageBox.Show("Emplacement introuvable", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (EmplacementDb.Quantite == 0)
                {
                    FormshowNotParent(Forms.FrmModifierMasraf.InstanceFrmModifierMasraf);

                    if (Application.OpenForms.OfType<FrmModifierMasraf>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmModifierMasraf>().First().TxtId.Text = EmplacementDb.Id.ToString(); ;
                        Application.OpenForms.OfType<FrmModifierMasraf>().First().TxtIntitule.Text = EmplacementDb.Intitule;

                        
                        if ((int)EmplacementDb.Article == 1)
                        {
                            Application.OpenForms.OfType<FrmModifierMasraf>().First().comboBoxTypeOlive.SelectedItem = "OliveVif";

                        }

                        else if ((int)EmplacementDb.Article == 2)
                        {
                            Application.OpenForms.OfType<FrmModifierMasraf>().First().comboBoxTypeOlive.SelectedItem = "Nchira";

                        }
                      
                    }
                }
                else
                {

                    XtraMessageBox.Show("Masraf plein", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Aucun Emplacement séléctionné", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}