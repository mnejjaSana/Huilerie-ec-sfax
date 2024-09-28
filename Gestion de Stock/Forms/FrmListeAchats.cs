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
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model;
using System.IO;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using System.Data.Entity;
using Gestion_de_Stock.Model.Enumuration;
using Convertisseur;
using Convertisseur.Entite;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeAchats : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeAchats _FrmListeAchats;
        public static FrmListeAchats InstanceFrmListeAchats
        {
            get
            {
                if (_FrmListeAchats == null)
                    _FrmListeAchats = new FrmListeAchats();
                return _FrmListeAchats;
            }
        }
        public FrmListeAchats()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
           
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = DateFin.DateTime.Date.AddDays(1).AddSeconds(-1);


            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin  && x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin && x.Date <= DateMaxJour && x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
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
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date>= DateMin && x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                achatBindingSource.DataSource = db.Achats.Where(x => x.Date >= DateMin  && x.Date <= DateMaxJour && x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }
        }

        private void FrmListeAchats_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeAchats = null;
        }

        private void FrmListeAchats_Load(object sender, EventArgs e)
        {
           
            achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
        
            string path = "Liste Achats.xlsx";
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
            frm.Activate();
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
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
            achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
        }

        private void repositoryItemButtonEditViewDetais_Click(object sender, EventArgs e)
        {
            string CodeAchat = gridView1.GetFocusedRowCellValue("Code").ToString();
            // Achat GetAchatDB = db.Achats.Include("Lines").Where(x=>x.Code.Equals(CodeAchat)).FirstOrDefault();
            // FormshowNotParent(Gestion_de_Stock.Forms.FrmdetaisVente.InstanceFrmdetaisAchats);
            //if (Application.OpenForms.OfType<FrmdetaisAchats>().FirstOrDefault() != null)
            //    Application.OpenForms.OfType<FrmdetaisAchats>().FirstOrDefault().ligneAchatsBindingSource.DataSource = GetAchatDB.Lines.ToList();
        }

        private void repositoryItemButtonEditCertificateRS_Click(object sender, EventArgs e)
        {
            //RapportCertificateRS RFIpression = new RapportCertificateRS();
            ////RFIpression.Parameters["Date"].Value = DateTime.Now;
            ////RFIpression.Parameters["Date"].Visible = false;
            //RFIpression.DataSource =null;
            //ReportPrintTool tool = new ReportPrintTool(RFIpression);
            //tool.ShowPreview();
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
                if (e.Column.FieldName == "EtatAchat")
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

        private void repositoryBtnAjouterReglement_Click(object sender, EventArgs e)
        {

            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Find(A.Id);


            if (AchatDb.EtatAchat != EtatAchat.Reglee && AchatDb.TypeAchat != TypeAchat.Avance)
            {
                if (AchatDb.TypeAchat == TypeAchat.Base && AchatDb.MontantReglement == 0)
                {
                    XtraMessageBox.Show("Vous ne pouvez pas ajouter un règlement qu'aprés la production!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    FormshowNotParent(Forms.FrmAjouterReglementAchat.InstanceFrmAjouterReglementAchat);

                    if (Application.OpenForms.OfType<FrmAjouterReglementAchat>().FirstOrDefault() != null)
                    {
                        if (A.TypeAchat == TypeAchat.Base || A.TypeAchat == TypeAchat.Huile)
                        {
                            Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().layoutControlMtAPayer.Text = "Montant à Payer";
                        }
                        else if (A.TypeAchat == TypeAchat.Service)
                        {
                            Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().layoutControlMtAPayer.Text = "Montant Règlement";
                        }

                        Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtCodeAchat.Text = A.Id.ToString();
                        Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtAgriculteur.Text = A.Founisseur.FullName;
                        
                        Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtMontantOperation.Text =  (Math.Truncate(A.MontantReglement * 1000m) / 1000m).ToString();
                        Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtAvance.Text = (Math.Truncate(A.MontantRegle * 1000m) / 1000m).ToString();
                        Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtSolde.Text =  (Math.Truncate(A.ResteApayer * 1000m) / 1000m).ToString();
                        Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtMontantEncaisse.Text = (Math.Truncate(A.ResteApayer * 1000m) / 1000m).ToString();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Votre demande est non Autorisée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

            }


        }

        private void repositoryBtnHistoriquePaiement_Click(object sender, EventArgs e)
        {
            Achat achat = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

           List<HistoriquePaiementAchats> result = db.HistoriquePaiementAchats.Where(x => x.NumAchat.Equals(achat.Numero)).ToList(); 

            FormshowNotParent(Forms.FrmHistoriquePaiementAchat.InstanceFrmHistoriquePaiementAchat);

            if (Application.OpenForms.OfType<FrmHistoriquePaiementAchat>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmHistoriquePaiementAchat>().First().historiquePaiementAchatsBindingSource.DataSource = result;
            }
        }

        private void BtnActualiser_Click_1(object sender, EventArgs e)
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
            db = new Model.ApplicationContext();
            achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
        }

        private void ImprimerTicket_Click(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Find(A.Id);
            List<Achat> ListeAchats = new List<Achat>();
            ListeAchats.Add(AchatDb);

            xrAchatTicket xrAchatTicket = new xrAchatTicket();

            xrAvance xrAvance = new xrAvance();

            Societe societe = db.Societe.FirstOrDefault();
            string RsSte = societe.RaisonSocial;



         if (AchatDb.TypeAchat == TypeAchat.Base)

            {
                // ticket avec solde 
                xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                xrAchatTicket.Parameters["RsSte"].Visible = false;

                xrAchatTicket.Parameters["QteAchetee"].Value = AchatDb.NbSacs;

                xrAchatTicket.Parameters["QteAchetee"].Visible = false;

                if (AchatDb.TypeOlive == ArticleAchat.Nchira)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Nchira";
                }
                else if (AchatDb.TypeOlive == ArticleAchat.OliveVif)
                {
                    xrAchatTicket.Parameters["Type"].Value = "OliveVif";
                }

                if (AchatDb.TypeAchat == TypeAchat.Base)
                {
                    xrAchatTicket.Parameters["PU"].Value = AchatDb.PrixLitre;
                }
             

                xrAchatTicket.Parameters["PU"].Visible = false;

                xrAchatTicket.Parameters["Type"].Visible = false;

                xrAchatTicket.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();
               
                }



            }

            else if (AchatDb.TypeAchat == TypeAchat.Service)
            {
                TicketService ticketService = new TicketService();
                ticketService.Parameters["RsSte"].Value = RsSte;
                ticketService.DataSource = ListeAchats;
                ReportPrintTool tool1 = new ReportPrintTool(ticketService);
                tool1.ShowPreviewDialog();
            }
            else if (AchatDb.TypeAchat == TypeAchat.Huile)

            {

                xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                xrAchatTicket.Parameters["RsSte"].Visible = false;

                xrAchatTicket.Parameters["QteAchetee"].Value = AchatDb.QteHuileAchetee;

                xrAchatTicket.Parameters["QteAchetee"].Visible = false;

                xrAchatTicket.Parameters["PU"].Value = AchatDb.PrixLitre;

                xrAchatTicket.Parameters["PU"].Visible = false;

                if (AchatDb.Qualite == ArticleVente.Extra)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Extra";
                }
                else if (AchatDb.Qualite == ArticleVente.Lampante)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Lampante";
                }
                else if (AchatDb.Qualite == ArticleVente.Vierge)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Vierge";
                }
                else if (AchatDb.Qualite == ArticleVente.ExtraVierge)
                {
                    xrAchatTicket.Parameters["Type"].Value = "ExtraVierge";
                }


                xrAchatTicket.Parameters["Type"].Visible = false;

                xrAchatTicket.DataSource = ListeAchats;

                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();
               
                }

            }
            else if (AchatDb.TypeAchat == TypeAchat.Olive)

            {

                xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                xrAchatTicket.Parameters["RsSte"].Visible = false;

                xrAchatTicket.Parameters["QteAchetee"].Value = AchatDb.QteOliveAchetee;

                xrAchatTicket.Parameters["QteAchetee"].Visible = false;

                xrAchatTicket.Parameters["PU"].Value = AchatDb.PUOliveFinal;

                xrAchatTicket.Parameters["PU"].Visible = false;

                if (AchatDb.TypeOlive == ArticleAchat.Nchira)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Nchira";
                }
                else if (AchatDb.TypeOlive == ArticleAchat.OliveVif)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Olive Vif";
                }


                xrAchatTicket.Parameters["Type"].Visible = false;

                xrAchatTicket.DataSource = ListeAchats;

                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();
               
                }


            }


        }

        private void repositoryImprimerFacture_Click(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Include("Founisseur").FirstOrDefault(x=>x.Id==A.Id);

            Societe Ste = db.Societe.FirstOrDefault();
            FactureAchats FactureAchats = new FactureAchats();
            FactureAchats.Parameters["MF"].Value = Ste.MatriculFiscal;
            FactureAchats.Parameters["Adresse"].Value = Ste.Adresse;
            FactureAchats.Parameters["Tel"].Value = Ste.Telephone;

           

            FactureAchats.Parameters["Date"].Value = AchatDb.Date.ToString("dd/MM/yyyy");
            FactureAchats.Parameters["CodeFacture"].Value = AchatDb.Numero;
            FactureAchats.Parameters["FounisseurFullName"].Value = AchatDb.Founisseur.FullName;
            FactureAchats.Parameters["CinFounisseur"].Value = AchatDb.Founisseur.cin;          
            FactureAchats.Parameters["TelephneFounisseur"].Value = AchatDb.Founisseur.Tel;

            var convertisseur = ConvertisseurNombreEnLettre.Parametrage
           .AppliquerUneUnite(Unite.Creer("dinar", "dinars", " millime", "millimes"))
           .ModifierLaVirgule("et")
           .ValiderLeParametrage();
            FactureAchats.Parameters["TotalFacture"].Value = AchatDb.MontantReglement + " " + "TND";
            FactureAchats.Parameters["TotalEnChiffre"].Value = convertisseur.Convertir(AchatDb.MontantReglement);

            List<Achat> ListeAchats = new List<Achat>();
            ListeAchats.Add(AchatDb);
            FactureAchats.DataSource = ListeAchats;
            using (ReportPrintTool printTool = new ReportPrintTool(FactureAchats))
            {
                printTool.ShowPreviewDialog();
            }
        }

        private void btnAjouterReg_Click(object sender, EventArgs e)
        {
            List<Achat> ListeGrid = new List<Achat>();
            //int rowHandle3 = 0;
            var Gride = System.Windows.Forms.Application.OpenForms.OfType<FrmListeAchats>().First().gridView1;
            for (int j = 0; j < Gride.SelectedRowsCount; j++)
            {
                if (Gride.GetSelectedRows()[j] >= 0)
                    ListeGrid.Add(Gride.GetRow(Gride.GetSelectedRows()[j]) as Achat);
            }
            if (ListeGrid.Count == 0)
            {

                XtraMessageBox.Show("Aucune ligne sélectionnée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                var firstAgriculteur = ListeGrid.First().Founisseur;

                if (ListeGrid.Any(a => a.Founisseur != firstAgriculteur))
                {
                    XtraMessageBox.Show("Veuillez sélectionner des achats du même agriculteur", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    FormshowNotParent(Forms.FrmAjouterReglementAchat.InstanceFrmAjouterReglementAchat);

                    if (Application.OpenForms.OfType<FrmAjouterReglementAchat>().FirstOrDefault() != null)
                    {
                        foreach (var Empolyeur in ListeGrid)
                        {
                            if (Empolyeur.TypeAchat == TypeAchat.Base || Empolyeur.TypeAchat == TypeAchat.Huile)
                            {
                                Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().layoutControlMtAPayer.Text = "Montant à Payer";
                            }

                            var achatIds = ListeGrid.Select(a => a.Numero.ToString()).ToArray();
                          
                            Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtCodeAchat.Text = string.Join(", ", achatIds);
                            Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtAgriculteur.Text = firstAgriculteur.FullName;
                            decimal totalMontantReglement = ListeGrid.Sum(a => a.MontantReglement);
                            Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtMontantOperation.Text = (Math.Truncate(totalMontantReglement * 1000m) / 1000m).ToString();
                            decimal totalAvance = ListeGrid.Sum(a => a.MontantRegle);
                            decimal totalResteApayer = ListeGrid.Sum(a => a.ResteApayer);
                            decimal totalMontantEncaisse = totalResteApayer; // Assuming this is intended to be the same as ResteApayer

                            // Update the respective text fields
                             Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtAvance.Text = (Math.Truncate(totalAvance * 1000m) / 1000m).ToString();
                             Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtSolde.Text = (Math.Truncate(totalResteApayer * 1000m) / 1000m).ToString();
                            Application.OpenForms.OfType<FrmAjouterReglementAchat>().First().TxtMontantEncaisse.Text = (Math.Truncate(totalMontantEncaisse * 1000m) / 1000m).ToString();


                        }
                    }

                }
            }
        }
    }
}      