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
using Gestion_de_Stock.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using System.IO;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmFournisseur : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmFournisseur _FrmFournisseur;
        public static FrmFournisseur InstanceFrmFournisseur
        {
            get
            {
                if (_FrmFournisseur == null)
                    _FrmFournisseur = new FrmFournisseur();
                return _FrmFournisseur;
            }
        }
        public FrmFournisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmFournisseur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmFournisseur = null;
        }

        private void FrmFournisseur_Load(object sender, EventArgs e)
        {
            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                    db.SaveChanges();
                }
                fournisseurBindingSource.DataSource = ListAgriculteurs;
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterFournisseur.InstanceFrmAjouterFournisseur);
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





        private void BtnExportXLS_Click(object sender, EventArgs e)
        {
            string path = "Liste Founisseurs.xlsx";

            ////Customize export options
            //(gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            //XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            //advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.SheetName = "Exported from Data Grid";

            //gridControl1.ExportToXlsx(path, advOptions);
            //// Open the created XLSX file with the default application.
            //Process.Start(path);

            //string path = "Liste Achats.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            // Check whether or not the Grid Control can be printed.
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            string cellValue = "";

            if (gridView1.RowCount>0)
            {
                cellValue = gridView1.GetFocusedRowCellValue("Numero").ToString();
            }
           if(string.IsNullOrEmpty(cellValue))
            {
                XtraMessageBox.Show("Aucun Agriculteur séléctionné", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Agriculteur FounisseurDb = db.Agriculteurs.FirstOrDefault(x => x.Numero.Equals(cellValue));

            FormshowNotParent(Forms.FrmModifierFournisseur.InstanceFrmModifierFournisseur);

            if (Application.OpenForms.OfType<FrmModifierFournisseur>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtNumero.Text = FounisseurDb.Id.ToString();
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtCin.Text = FounisseurDb.cin;

                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtNom.Text = FounisseurDb.Nom;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtPrenom.Text = FounisseurDb.Prenom;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtTel.Text = FounisseurDb.Tel;
                Application.OpenForms.OfType<FrmModifierFournisseur>().First().TxtVehicule.Text = FounisseurDb.Vehicule;

            }
        }


        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer cet agriculteur ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Agriculteur Agr = gridView1.GetFocusedRow() as Agriculteur;
                if (Agr == null)
                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Agriculteur AgrDb = db.Agriculteurs.Find(Agr.Id);

                Achat Achat = db.Achats.Where(x => x.Founisseur.Id == AgrDb.Id).FirstOrDefault();

                if (Achat != null)

                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    db.Agriculteurs.Remove(AgrDb);
                    db.SaveChanges();


                    /***************************** reload DataGridView ***********************************/
                    fournisseurBindingSource.DataSource = db.Agriculteurs.ToList();


                    List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                    foreach (var l in ListAgriculteurs)
                    {
                        List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                        l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                        List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                        decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                        l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                        decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                        decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                        l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                    }


                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();


                    /***************************** reload DataGridView  ***********************************/
                    XtraMessageBox.Show("Agriculteur Supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
            }
            else
            {

                XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                    db.SaveChanges();
                }
                fournisseurBindingSource.DataSource = ListAgriculteurs;
            }

        }
    }
}