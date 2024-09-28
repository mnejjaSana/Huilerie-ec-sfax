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
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Repport;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using System.Globalization;
using Gestion_de_Stock.Model.Enumuration;
using System.Diagnostics;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeVente : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeVente _FrmListeVente;
        public static FrmListeVente InstanceFrmListeVente
        {
            get
            {
                if (_FrmListeVente == null)
                    _FrmListeVente = new FrmListeVente();
                return _FrmListeVente;
            }
        }
        public FrmListeVente()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeVente_Load(object sender, EventArgs e)
        {

            venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();
        }

        private void FrmListeVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeVente = null;
        }




        private void repositoryImpression_Click(object sender, EventArgs e)
        {

            Vente vente = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            Societe Ste = db.Societe.FirstOrDefault();

            Vente VentetDb = db.Vente.FirstOrDefault(x => x.Id == vente.Id);

            Client ClientDb = db.Clients.FirstOrDefault(x=> x.Id== VentetDb.IdClient);

            BondeLivraison BondeLivraisonReport = new BondeLivraison();
            if (Ste != null)
            {

                BondeLivraisonReport.Parameters["AdresseClient"].Value = ClientDb.Adresse;

                BondeLivraisonReport.Parameters["AdresseClient"].Visible = false;

                BondeLivraisonReport.Parameters["MF"].Value = Ste.MatriculFiscal;

                BondeLivraisonReport.Parameters["MF"].Visible = false;

                BondeLivraisonReport.Parameters["Adresse"].Value = Ste.Adresse;

                BondeLivraisonReport.Parameters["Adresse"].Visible = false;

                BondeLivraisonReport.Parameters["Tel"].Value = Ste.Telephone;

                BondeLivraisonReport.Parameters["Tel"].Visible = false;

                BondeLivraisonReport.Parameters["Date"].Value = DateTime.Now;

                BondeLivraisonReport.Parameters["Date"].Visible = false;

            

                BondeLivraisonReport.Parameters["QuantitéTotale"].Value = VentetDb.QteVendue;

                List<TypeQualite> typeQualites = new List<TypeQualite>();

                TypeQualite A = new TypeQualite { Description = "Lampante", Value = "Lampante" };

                TypeQualite b = new TypeQualite { Description = "Extra", Value = "Extra" };
                TypeQualite c = new TypeQualite { Description = "Fatoura", Value = "Fatoura" };
                TypeQualite d = new TypeQualite { Description = "Vierge", Value = "Vierge" };
                TypeQualite f = new TypeQualite { Description = "ExtraVierge", Value = "ExtraVierge" };

                typeQualites.Add(b);
                typeQualites.Add(A);
                typeQualites.Add(c);
                typeQualites.Add(d);
                typeQualites.Add(f);

                DynamicListLookUpSettings lookupSettings = new DynamicListLookUpSettings();
                lookupSettings.DataSource = typeQualites;
                lookupSettings.ValueMember = "Value";
                lookupSettings.DisplayMember = "Description";

                BondeLivraisonReport.Parameters["Qualité"].LookUpSettings = lookupSettings;
                List<Vente> Listeventes = new List<Vente>();
                Listeventes.Add(VentetDb);

                BondeLivraisonReport.DataSource = Listeventes;
                using (ReportPrintTool printTool = new ReportPrintTool(BondeLivraisonReport))
                {
                    printTool.ShowPreviewDialog();
                  //  printTool.ShowPreviewDialog(UserLookAndFeel.Default);
                }
            }
            else
            {
                XtraMessageBox.Show("Ajouter les coordonnées de la société", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;

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
                if (e.Column.FieldName == "EtatVente")
                {
                    if (Convert.ToInt32(e.CellValue) == 1)
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
                    else if (Convert.ToInt32(e.CellValue) == 3)
                    {
                        //e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                        e.Graphics.DrawImage(imageReglee, e.Bounds.Location);
                        // e.DisplayText = " ";
                    }


                }
            }
        }

        private void repositoryItemDeatis_Click(object sender, EventArgs e)
        {
            Vente vente = gridView1.GetFocusedRow() as Vente;
            db = new Model.ApplicationContext();
            Vente VentetDb = db.Vente.Include("LigneVentes").FirstOrDefault(x => x.Id == vente.Id);

            List<LigneVente> ListeLV = new List<LigneVente>();

            ListeLV = VentetDb.LigneVentes;

            //  FrmDetailVente.ligneVenteBindingSource.DataSource = ListeLV;

            FormshowNotParent(Forms.FrmDetailVente.InstanceFrmDetailVente);
            if (Application.OpenForms.OfType<FrmDetailVente>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmDetailVente>().First().ligneVenteBindingSource.DataSource = ListeLV;
            }
        }

        private void repositoryBtnAjouterReglement_Click(object sender, EventArgs e)
        {
            Vente v = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            Vente VenteDb = db.Vente.Find(v.Id);

            if (VenteDb.EtatVente != EtatVente.Reglee)
            {
                FormshowNotParent(Forms.FrmAjouterReglementVente.InstanceFrmAjouterReglementVente);

                if (Application.OpenForms.OfType<FrmAjouterReglementVente>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtNumVente.Text = v.Id.ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtClient.Text = v.IntituleClient;
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtTotalCommande.Text =(Math.Truncate(v.TotalHT * 1000m) / 1000m).ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtAvance.Text = (Math.Truncate(v.MontantRegle * 1000m) / 1000m).ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtResteAPayer.Text =  (Math.Truncate(v.ResteApayer * 1000m) / 1000m).ToString();
                    Application.OpenForms.OfType<FrmAjouterReglementVente>().First().TxtMTRegle.Text = (Math.Truncate(v.ResteApayer * 1000m) / 1000m).ToString();

                }

            }
            else
            {
                XtraMessageBox.Show("Vente est Réglée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void repositoryItemButtonEditBondeSortie_Click(object sender, EventArgs e)
        {

            Vente vente = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            Vente VentetDb = db.Vente.FirstOrDefault(x => x.Id == vente.Id);

            Client ClientDb = db.Clients.FirstOrDefault(x => x.Id == VentetDb.IdClient);

            Societe Ste = db.Societe.FirstOrDefault();

            if (Ste != null)
            {
                RapportBondeSortie BondeSortieReportReport = new RapportBondeSortie();


                BondeSortieReportReport.Parameters["ClientAdresse"].Value = ClientDb.Adresse;

                BondeSortieReportReport.Parameters["MatriculeFiscale"].Value = Ste.MatriculFiscal;

                BondeSortieReportReport.Parameters["MatriculeFiscale"].Visible = false;

                BondeSortieReportReport.Parameters["Adresse"].Value = Ste.Adresse;

                BondeSortieReportReport.Parameters["Adresse"].Visible = false;

                BondeSortieReportReport.Parameters["Tel"].Value = Ste.Telephone;

                BondeSortieReportReport.Parameters["Tel"].Visible = false;

                string Date = DateTime.Now.ToString("MM/dd/yyyy");

                BondeSortieReportReport.Parameters["Date"].Value = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                BondeSortieReportReport.Parameters["Date"].Visible = false;

                BondeSortieReportReport.Parameters["QuantitéTotale"].Value = VentetDb.QteVendue;


                List<TypeQualite> typeQualites = new List<TypeQualite>();

                TypeQualite A = new TypeQualite { Description = "Lampante", Value = "Lampante" };

                TypeQualite b = new TypeQualite { Description = "Extra", Value = "Extra" };
                TypeQualite c = new TypeQualite { Description = "Fatoura", Value = "Fatoura" };
                TypeQualite d = new TypeQualite { Description = "Vierge", Value = "Vierge" };
                TypeQualite f = new TypeQualite { Description = "ExtraVierge", Value = "ExtraVierge" };

                typeQualites.Add(b);
                typeQualites.Add(A);
                typeQualites.Add(c);
                typeQualites.Add(d);
                typeQualites.Add(f);

                DynamicListLookUpSettings lookupSettings = new DynamicListLookUpSettings();
                lookupSettings.DataSource = typeQualites;
                lookupSettings.ValueMember = "Value";
                lookupSettings.DisplayMember = "Description";

                BondeSortieReportReport.Parameters["Qualité"].LookUpSettings = lookupSettings;
                List<Vente> Listeventes = new List<Vente>();
                Listeventes.Add(VentetDb);

                BondeSortieReportReport.DataSource = Listeventes;

                using (ReportPrintTool printTool = new ReportPrintTool(BondeSortieReportReport))
                {
                    printTool.ShowPreviewDialog();
                    //printTool.ShowPreviewDialog(UserLookAndFeel.Default);
                }
            }
            else
            {
                XtraMessageBox.Show("Ajouter les coordonnées de la société", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                return;

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
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
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
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                venteBindingSource.DataSource = db.Vente.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void repositorHistoriquePaiementVente_Click(object sender, EventArgs e)
        {

            Vente vente = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            List<HistoriquePaiementVente> result = db.HistoriquePaiementVente.Where(x => x.NumVente.Equals(vente.Numero)).ToList();

            FormshowNotParent(Forms.FrmHistoriquePaiementVente.InstanceFrmHistoriquePaiementVente);

            if (Application.OpenForms.OfType<FrmHistoriquePaiementVente>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmHistoriquePaiementVente>().First().historiquePaiementVenteBindingSource.DataSource = result;
            }
        }

        private void repositoryBtnModifierVente_Click(object sender, EventArgs e)
        {
            Vente vente = gridView1.GetFocusedRow() as Vente;

            db = new Model.ApplicationContext();

            Vente VenteDb = db.Vente.Where(x => x.Id == vente.Id).FirstOrDefault();

            if (VenteDb.EtatVente != Model.Enumuration.EtatVente.Reglee)
            {

                FormshowNotParent(Forms.FrmModifierVente.InstanceFrmModifierVente);
                if (Application.OpenForms.OfType<FrmModifierVente>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmModifierVente>().First().TxtCode.Text = VenteDb.Id.ToString(); ;
                    Application.OpenForms.OfType<FrmModifierVente>().First().TxtClient.Text = VenteDb.IntituleClient;
                    Application.OpenForms.OfType<FrmModifierVente>().First().TxtQteVendue.Text = VenteDb.QteVendue.ToString();
                    Application.OpenForms.OfType<FrmModifierVente>().First().TxtTotalCommande.Text = VenteDb.MontantReglement.ToString();
                    Application.OpenForms.OfType<FrmModifierVente>().First().TxtAvance.Text = VenteDb.MontantRegle.ToString();
                    Application.OpenForms.OfType<FrmModifierVente>().First().TxtSolde.Text = VenteDb.ResteApayer.ToString();


                }
            }
            else
            {
                XtraMessageBox.Show("Votre demande est non Autorisée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Ventes.xlsx";
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
            venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();
        }
    }
}