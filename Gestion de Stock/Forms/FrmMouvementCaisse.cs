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
using DevExpress.XtraLayout.Utils;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmMouvementCaisse : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmMouvementCaisse _FrmMouvementCaisse;

        public static FrmMouvementCaisse InstanceFrmMouvementCaisse
        {
            get
            {
                if (_FrmMouvementCaisse == null)
                    _FrmMouvementCaisse = new FrmMouvementCaisse();
                return _FrmMouvementCaisse;
            }
        }

        public FrmMouvementCaisse()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmMouvementCaisse_Load(object sender, EventArgs e)
        {
            if (db.MouvementsCaisse.Count() > 0)
            {

                List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                mouvementCaisseBindingSource.DataSource = ListeMvtCaisse;

                MouvementCaisse mvt = ListeMvtCaisse.Last();

                TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

            }


        }

        private void FrmMouvementCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMouvementCaisse = null;
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
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();
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
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0).ToList();
            }
            else
            {
                mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.Where(x => x.Date.CompareTo(DateMin) >= 0 && x.Date.CompareTo(DateMaxJour) <= 0).ToList();
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Caisse.xlsx";

            ////Customize export options
            //(gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            //XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            //advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.SheetName = "Exported from Data Grid";

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

        private void repositoryDetailMvmCaisse_Click(object sender, EventArgs e)
        {
            MouvementCaisse MvmCaisse = gridView1.GetFocusedRow() as MouvementCaisse;

            db = new Model.ApplicationContext();

            var mvmCaisseDb = db.MouvementsCaisse.Find(MvmCaisse.Id);

            if (mvmCaisseDb.Achat != null)
            {
                int codeAchat = mvmCaisseDb.Achat.Id;

                Achat AchatDb = db.Achats.FirstOrDefault(x => x.Id == codeAchat);

                List<HistoriquePaiementAchats> result = db.HistoriquePaiementAchats.Where(x => x.NumAchat.Equals(AchatDb.Numero)).ToList();

                #region type achat service 
                // if type achat service 
                if (AchatDb.TypeAchat == Model.Enumuration.TypeAchat.Service)
                {
                    FormshowNotParent(Forms.FrmDetailServiceMvmCaisse.InstanceFrmDetailAchatMvmCaisse);

                    if (Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().FirstOrDefault() != null)
                    {

                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtNum.Text = AchatDb.Numero.ToString();
                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtDate.Text = AchatDb.Date.ToString("dd/MM/yyyy HH:mm");
                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtAgriculteur.Text = AchatDb.Founisseur.FullName.ToString();
                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtNbSacs.Text = AchatDb.NbSacs.ToString();
                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtQteAchete.Text = Convert.ToInt32(AchatDb.Poids).ToString();
                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtTypeOlive.Text = AchatDb.TypeOlive.ToString();


                        // Etat Service
                        if ((int)AchatDb.EtatAchat == 1)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtEtatAchat.Text = "Non Réglé";
                        }
                        else if ((int)AchatDb.EtatAchat == 2)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtEtatAchat.Text = "Partiellement Réglé";
                        }
                        else if ((int)AchatDb.EtatAchat == 3)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtEtatAchat.Text = "Réglé";
                        }

                        // Statut Service

                        if ((int)AchatDb.StatutProd == 1)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtStatut.Text = "En Attente";
                        }
                        else if ((int)AchatDb.StatutProd == 2)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtStatut.Text = "En Cours";
                        }
                        else if ((int)AchatDb.StatutProd == 3)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtStatut.Text = "Términé";
                        }
                        else if ((int)AchatDb.StatutProd == 4)
                        {
                            Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().TxtStatut.Text = "Stocké";
                        }

                        Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().historiquePaiementAchatsBindingSource.DataSource = result;
                    }
                }

                #endregion

                if (!mvmCaisseDb.Commentaire.Contains("_"))
                {
                    #region type achat Rendement 

                    if (AchatDb.TypeAchat == Model.Enumuration.TypeAchat.Base)
                    {
                        FormshowNotParent(Forms.FrmDetailAchatMvmCaissecs.InstanceFrmDetailAchatMvmCaissecs);

                        if (Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().FirstOrDefault() != null)
                        {

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtNum.Text = AchatDb.Numero.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().txtNumBon.Text = AchatDb.NuméroBon.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtDate.Text = AchatDb.Date.ToString("dd/MM/yyyy HH:mm");
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtAgriculteur.Text = AchatDb.Founisseur.FullName.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtNbSacs.Text = AchatDb.NbSacs.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtQteAchete.Text = Convert.ToInt32(AchatDb.Poids).ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtTypeOlive.Text = AchatDb.TypeOlive.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtQteProduite.Text = Convert.ToInt32(AchatDb.QteLitre).ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtPrixLitre.Text = (Math.Truncate(AchatDb.PrixLitre * 1000m) / 1000m).ToString();
                            // Etat Achat
                            if ((int)AchatDb.EtatAchat == 1)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text = "Non Réglé";
                            }
                            else if ((int)AchatDb.EtatAchat == 2)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text = "Partiellement Réglé";
                            }
                            else if ((int)AchatDb.EtatAchat == 3)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text = "Réglé";
                            }

                            // Statut Service

                            if ((int)AchatDb.StatutProd == 1)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "En Attente";
                            }
                            else if ((int)AchatDb.StatutProd == 2)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "En Cours";
                            }
                            else if ((int)AchatDb.StatutProd == 3)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "Términé";
                            }
                            else if ((int)AchatDb.StatutProd == 4)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "Stocké";
                            }

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().historiquePaiementAchatsBindingSource.DataSource = result;
                        }
                    }

                    #endregion

                    #region type achat huile

                    if (AchatDb.TypeAchat == TypeAchat.Huile)
                    {
                        FormshowNotParent(Forms.FrmDetailAchatMvmCaissecs.InstanceFrmDetailAchatMvmCaissecs);

                        if (Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().FirstOrDefault() != null)
                        {

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtNum.Text = AchatDb.Numero.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().txtNumBon.Text = AchatDb.NuméroBon.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtDate.Text = AchatDb.Date.ToString("dd/MM/yyyy HH:mm");
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtAgriculteur.Text = AchatDb.Founisseur.FullName.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().layoutNbSac.Visibility = LayoutVisibility.Never;
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtQteAchete.Text = AchatDb.QteHuileAchetee.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().layoutTypeOlive.Text = "Qualité Huile";
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtTypeOlive.Text = AchatDb.Qualite.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().layoutQteProduite.Text = "Pile";
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtQteProduite.Text = AchatDb.Pile.Intitule;

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtPrixLitre.Text = (Math.Truncate(AchatDb.PrixLitre * 1000m) / 1000m).ToString();
                            // Etat achat
                            if ((int)AchatDb.EtatAchat == 1)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text = "Non Réglé";
                            }
                            else if ((int)AchatDb.EtatAchat == 2)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text = "Partiellement Réglé";
                            }
                            else if ((int)AchatDb.EtatAchat == 3)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text = "Réglé";
                            }


                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "Stocké";



                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().historiquePaiementAchatsBindingSource.DataSource = result;
                        }
                    }

                    #endregion


                    #region type achat Olive

                    if (AchatDb.TypeAchat == TypeAchat.Olive)
                    {
                        FormshowNotParent(Forms.FrmDetailAchatMvmCaissecs.InstanceFrmDetailAchatMvmCaissecs);

                        if (Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().FirstOrDefault() != null)
                        {

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtNum.Text = AchatDb.Numero.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().txtNumBon.Text = AchatDb.NuméroBon.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtDate.Text = AchatDb.Date.ToString("dd/MM/yyyy HH:mm");
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtAgriculteur.Text = AchatDb.Founisseur.FullName.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().layoutNbSac.Visibility = LayoutVisibility.Never;
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtQteAchete.Text = AchatDb.QteOliveAchetee.ToString();

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtTypeOlive.Text = AchatDb.QualiteRepport.ToString();
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().layoutQteProduite.Text = "PU (Olive) Final";
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtQteProduite.Text =  (Math.Truncate(AchatDb.PUOliveFinal * 1000m) / 1000m).ToString();

                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().EtatAchat.Text = "Base";
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtEtatAchat.Text =  (Math.Truncate(AchatDb.Rendement * 1000m) / 1000m).ToString();


                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtPrixLitre.Text = (Math.Truncate(AchatDb.PrixLitre * 1000m) / 1000m).ToString();
                            // Etat achat
                            if ((int)AchatDb.EtatAchat == 1)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "Non Réglé";
                            }
                            else if ((int)AchatDb.EtatAchat == 2)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "Partiellement Réglé";
                            }
                            else if ((int)AchatDb.EtatAchat == 3)
                            {
                                Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().TxtStatut.Text = "Réglé";
                            }

                            
                            Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().historiquePaiementAchatsBindingSource.DataSource = result;
                        }
                    }

                    #endregion







                }

            }

            if (mvmCaisseDb.Vente != null)
            {
                var codeVente = mvmCaisseDb.Vente.Id;
                Vente VenteDb = db.Vente.Include("LigneVentes").FirstOrDefault(x => x.Id == mvmCaisseDb.Vente.Id);
                #region vente


                List<LigneVente> ListeLV = new List<LigneVente>();

                ListeLV = VenteDb.LigneVentes;

                List<HistoriquePaiementVente> listeHPV = db.HistoriquePaiementVente.Where(x => x.NumVente.Equals(VenteDb.Numero)).ToList();

                FormshowNotParent(Forms.FrmDetailVenteMvmCaissecs.InstanceFrmDetailVenteMvmCaissecs);

                if (Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().FirstOrDefault() != null)
                {

                    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtNum.Text = VenteDb.Numero.ToString();
                    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtDate.Text = VenteDb.Date.ToString("dd/MM/yyyy HH:mm");
                    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtClient.Text = VenteDb.IntituleClient;
                    //  Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtModePaiement.Text = VenteDb.ModeReglement.ToString();
                    //if ((int)VenteDb.ModeReglement == 1)
                    //{
                    //Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtNumCheque.Text = VenteDb.NumeroCheque.ToString();
                    //Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtDateEcheance.Text = VenteDb.DateEcheance.ToString();
                    //Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtBank.Text = VenteDb.Bank.ToString();
                    //}

                    //else if ((int)VenteDb.ModeReglement == 0)
                    //{

                    //    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().numCheque.Visibility = LayoutVisibility.Never;
                    //    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().bank.Visibility = LayoutVisibility.Never;

                    //    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().dateEcheance.Visibility = LayoutVisibility.Never;



                    //}
                    // Etat Vente
                    if ((int)VenteDb.EtatVente == 1)
                    {
                        Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtEtatVente.Text = "Non Réglé";
                    }
                    else if ((int)VenteDb.EtatVente == 2)
                    {
                        Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtEtatVente.Text = "Partiellement Réglé";
                    }
                    else if ((int)VenteDb.EtatVente == 3)
                    {
                        Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().TxtEtatVente.Text = "Réglé";
                    }

                    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().historiquePaiementVenteBindingSource.DataSource = listeHPV;
                    Application.OpenForms.OfType<FrmDetailVenteMvmCaissecs>().First().ligneVenteBindingSource.DataSource = ListeLV;

                }

                #endregion
            }

            //if (mvmCaisseDb.Salarie != null)
            //{
            //    var codeSalarie = mvmCaisseDb.Salarie.Id;

            //    Salarier salarierDb = db.Salariers.Where(x => x.Id == mvmCaisseDb.Salarie.Id).FirstOrDefault();

            //    List<HistoriquePaiementSalarie> listeHPS = db.HistoriquePaiementSalaries.Where(x => x.Salarie.Id.Equals(salarierDb.Id)).ToList();

            //    FormshowNotParent(Forms.FrmDetailSalarieMvmCaisse.InstanceFrmDetailSalarieMvmCaisse);

            //    if (Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().FirstOrDefault() != null)
            //    {

            //        Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().TxtNum.Text = salarierDb.Id.ToString();
            //        Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().TxtNom.Text = salarierDb.Intitule.ToString();
            //        Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().TxtNbJourTrav.Text = salarierDb.NombredeJour.ToString();


            //        if ((int)salarierDb.EtatSalarie == 1)
            //        {
            //            Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().TxtEtat.Text = "Non Réglé";
            //        }
            //        else if ((int)salarierDb.EtatSalarie == 2)
            //        {
            //            Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().TxtEtat.Text = "Partiellement Réglé";
            //        }
            //        else if ((int)salarierDb.EtatSalarie == 3)
            //        {
            //            Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().TxtEtat.Text = "Réglé";
            //        }

            //        Application.OpenForms.OfType<FrmDetailSalarieMvmCaisse>().First().historiquePaiementSalarieBindingSource.DataSource = listeHPS;


            //    }

            //}



        }

        private void repositoryImprimerTicket_Click(object sender, EventArgs e)
        {
            MouvementCaisse MvmCaisse = gridView1.GetFocusedRow() as MouvementCaisse;

            db = new Model.ApplicationContext();

            var mvmCaisseDb = db.MouvementsCaisse.Find(MvmCaisse.Id);

            Societe societe = db.Societe.FirstOrDefault();

            string RsSte = societe.RaisonSocial;


            if (mvmCaisseDb.Achat != null)
            {

                int codeAchat = mvmCaisseDb.Achat.Id;

                Achat AchatDb = db.Achats.FirstOrDefault(x => x.Id == codeAchat);

                if (mvmCaisseDb.Commentaire.Equals("Avance Agriculteur"))
                {
                    xrAvance xrAvance = new xrAvance();

                    if (AchatDb.TypeAchat == TypeAchat.Avance)
                    {
                        List<Achat> ListeAchats = new List<Achat>();
                        ListeAchats.Add(AchatDb);
                        xrAvance.Parameters["RsSte"].Value = RsSte;
                        xrAvance.DataSource = ListeAchats;
                        using (ReportPrintTool printTool = new ReportPrintTool(xrAvance))
                        {
                            printTool.ShowPreviewDialog();
                       
                        }

                    }
                }



                if (mvmCaisseDb.Commentaire.Contains("_"))
                {
                    TickeAvanceAvecAchat xrAchatTicket = new TickeAvanceAvecAchat();

                    List<Achat> ListeAchats = new List<Achat>();

                    ListeAchats.Add(AchatDb);

                    xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                   

                    if (AchatDb.TypeAchat == TypeAchat.Base)
                    {
                        xrAchatTicket.Parameters["QteAchetee"].Value = Convert.ToInt32(AchatDb.NbSacs);
                        xrAchatTicket.Parameters["PU"].Value = AchatDb.PrixLitre;
               

                        if (AchatDb.TypeOlive == ArticleAchat.Nchira)
                        {
                            xrAchatTicket.Parameters["Type"].Value = "Nchira";
                        }
                        else if (AchatDb.TypeOlive == ArticleAchat.OliveVif)
                        {
                            xrAchatTicket.Parameters["Type"].Value = "OliveVif";
                        }

                    }


                    else if (AchatDb.TypeAchat == TypeAchat.Huile)
                    {
                        xrAchatTicket.Parameters["QteAchetee"].Value = Convert.ToInt32(AchatDb.QteHuileAchetee);
                        xrAchatTicket.Parameters["PU"].Value = AchatDb.PrixLitre;
                  
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


                    }

                    else if (AchatDb.TypeAchat == TypeAchat.Olive)
                    {
                        xrAchatTicket.Parameters["QteAchetee"].Value = Convert.ToInt32(AchatDb.QteOliveAchetee);
                        xrAchatTicket.Parameters["PU"].Value = AchatDb.PUOliveFinal;
                  
                        if (AchatDb.TypeOlive == ArticleAchat.OliveVif)
                        {
                            xrAchatTicket.Parameters["Type"].Value = "OliveVif";
                        }
                        else if (AchatDb.TypeOlive == ArticleAchat.Nchira)
                        {
                            xrAchatTicket.Parameters["Type"].Value = "Nchira";
                        }
                        

                    }

                    xrAchatTicket.DataSource = ListeAchats;
                    using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }

                }

                if (!mvmCaisseDb.Commentaire.Contains("_") && (AchatDb.TypeAchat == TypeAchat.Huile || AchatDb.TypeAchat == TypeAchat.Base || AchatDb.TypeAchat== TypeAchat.Olive))
                {
                    TicketMvtCaisse Ticket = new TicketMvtCaisse();

                    Ticket.Parameters["RsSte"].Value = RsSte;

                    Ticket.Parameters["NumAchat"].Value = AchatDb.Numero;

                    Ticket.Parameters["Agriculteur"].Value = AchatDb.Founisseur.FullName;

                    Ticket.Parameters["Montant"].Value = decimal.Multiply(mvmCaisseDb.MontantSens, -1);

                    List<Achat> AchatListe = new List<Achat>();

                    AchatListe.Add(AchatDb);

                    Ticket.DataSource = AchatListe;
                    using (ReportPrintTool printTool = new ReportPrintTool(Ticket))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }
                }
            }

        }

        private void Actualiser_Click(object sender, EventArgs e)
        {
            if (db.MouvementsCaisse.Count() > 0)
            {

                List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                mouvementCaisseBindingSource.DataSource = ListeMvtCaisse;

                MouvementCaisse mvt = ListeMvtCaisse.Last();

                TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

            }

        }
    }
}