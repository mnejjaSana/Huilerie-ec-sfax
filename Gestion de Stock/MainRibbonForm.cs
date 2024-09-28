using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Forms;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Repport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Gestion_de_Stock
{
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm


    {
        private Model.ApplicationContext db;

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;

        public MainRibbonForm()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }


        private void barSociete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSociete.InstanceFrmSociete);
        }
        public void Formshow(Form frm)
        {
            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            // SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            // for (int i = 0; i < 100; i++)
            // {
            //     Thread.Sleep(10);
            // }
            // SplashScreenManager.CloseForm();
            //waiting Form
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
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


        private void Utilisateurs_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmUtilisateur.InstanceFrmUtilisateur);
        }

        private void MainRibbonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AjouterUtilisateur_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAjouterUtilisateur.InstanceFrmAjouterUtilisateur);
        }





        private void barbarAjouterClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmAjouterClient.InstanceFrmAjouterClient);
        }

        private void barAjouterfournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmAjouterFournisseur.InstanceFrmAjouterFournisseur);
        }

        private void barlisteClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmClient.InstanceFrmClient);
        }

        private void bardashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAccueil.InstanceFrmAccueil);
        }

        private void MainRibbonForm_Load(object sender, EventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAccueil.InstanceFrmAccueil);


        }

        private void barFournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmFournisseur.InstanceFrmFournisseur);
        }

        private void barAchat_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe ste = db.Societe.FirstOrDefault();
            if (!ste.AchatOlive && !ste.AchatHuile && !ste.AchatBase && !ste.Service)

            {
                XtraMessageBox.Show("Merci de choisir les types d'achat dans Société", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Formshow(Gestion_de_Stock.Forms.FrmAchats.InstanceFrmAchats);
            }
        }

        private void barButtonDepense_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonReleveeFournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonImportFournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonCaisse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmMouvementCaisse.InstanceFrmMouvementCaisse);
        }

        private void barButtonEnvoyer_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonDeponse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeDepenses.InstanceFrmListeDepenses);
        }

        private void barButtonVente_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeVente.InstanceFrmListeVente);
        }

        private void barAPropos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Formshow(Form frm);
            //  FormshowNotParent(Gestion_de_Stock.Forms.FrmAPropos.InstanceFrmAPropos);
        }



        private void barButtonMatriculeVerification_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmMatriculeFiscale.InstanceFrmMatriculeFiscale);
        }

        private void barBtnListeAchats_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeAchats.InstanceFrmListeAchats);
        }




        private void barBtnAjouterVente_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAjouterVente.InstanceFrmAjouterVente);
        }



        private void barButtonItemDevis_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemListeDevis_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemListeReglementFournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeReglementFounisseur.InstanceFrmListeReglementFounisseur);
        }



        private void barButtonItemListeSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSalarier.InstanceFrmOuvrier);
        }

        private void barButtonItemPointages_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Gestion_de_Stock.Forms.FrmPointage.InstanceFrmPointage);
        }

        private void barButtonAlimentation_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeAlimentation.InstanceFrmListeAlimentation);
        }

        private void barButtonProduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatBase)
            {
                Formshow(Gestion_de_Stock.Forms.FrmProduction.InstanceFrmProduction);
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }


        private void barButtonReglementsalaire_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmReglementsalaire.InstanceFrmReglementsalaire);
        }

        private void barBtnListeProduction_ItemClick(object sender, ItemClickEventArgs e)
        {

            Formshow(Gestion_de_Stock.Forms.FrmListeProduction.InstanceFrmListeProduction);
        }

        private void barBtnMouvementStock_ItemClick(object sender, ItemClickEventArgs e)
        {

            Formshow(Gestion_de_Stock.Forms.FrmStockHuile.InstanceFrmStockHuile);
        }

        private void barButtonItemReleveeFournisseur_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmReleveeFournisseurs.InstanceFrmReleveeFournisseurs);
        }

        private void barButtonItemPile_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmPile.InstanceFrmPile);
        }

        private void barBtnClotureCaisse_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (XtraMessageBox.Show("Voulez vous Clôturer la Caisse ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                db = new Model.ApplicationContext();

                Caisse CaisseDb = db.Caisse.Find(1);

                decimal MontantCaisse = Math.Truncate(CaisseDb.MontantTotal * 1000m) / 1000m;

                if (MontantCaisse == 0)
                {
                    XtraMessageBox.Show("Caisse Vide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    FormshowNotParent(Gestion_de_Stock.Forms.FrmClotureCaisse.InstanceFrmClotureCaisse);
                }


            }
        }

        private void barBtnCoffre_ItemClick(object sender, ItemClickEventArgs e)
        {


            db = new Model.ApplicationContext();

            List<HistoriquePaiementVente> result = db.HistoriquePaiementVente.Where(x => x.Coffre == true).ToList();

            FormshowNotParent(Forms.Coffre.InstanceFrmCoffre);

            if (Application.OpenForms.OfType<Coffre>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<Coffre>().First().historiquePaiementVenteBindingSource.DataSource = result;
            }
        }

        private void barBtnSuivie_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSuivie.InstanceFrmSuivie);
        }

        private void barBtnChequeVente_ItemClick(object sender, ItemClickEventArgs e)
        {

            Formshow(Gestion_de_Stock.Forms.Coffre.InstanceFrmCoffre);
        }

        private void barBtnChequeSalarie_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmCoffreChequeEmis.InstanceFrmCoffreChequeEmis);

        }

        private void BtnSortieDivers_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmSortieDiversPile.InstanceFrmSortieDiversPile);
        }

        private void MainRibbonForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.M && (e.Control || e.Shift))
            {

                FormshowNotParent(Forms.FrmModifierProduction.InstanceFrmModifierProduction);

            }
        }

        private void barBtnEtatClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatClient.InstanceFrmEtatClient);
        }

        private void barBtnEtatAgriculteur_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatAgriculteur.InstanceFrmEtatAgriculteur);
        }

        private void barBtnEtatCaisse_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEtatCaisse.InstanceFrmEtatCaisse);
        }

        private void barBtnResultat_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();

            RapportResultatCaisse RapportResultat = new RapportResultatCaisse();

            RapportResultat.Parameters["Du"].Value = DateTime.Now;


            /*******************************Vente********************************/

            // vente extra 
            List<LigneVente> ListeVenteExtra = db.LignesVente.Where(x => x.ArticleVente == ArticleVente.Extra).ToList();

            decimal VenteExtra = 0;

            if (ListeVenteExtra != null)
            {
                VenteExtra = decimal.Divide(ListeVenteExtra.Sum(x => x.TotalLigneHT), 1000);
            }


            RapportResultat.Parameters["TotalVenteExtra"].Value = Math.Truncate(VenteExtra * 100000m) / 100000m;




            // vente fatoura 
            List<LigneVente> ListeVenteFatoura = db.LignesVente.Where(x => x.ArticleVente == ArticleVente.Fatoura).ToList();

            decimal VenteFatoura = decimal.Divide(ListeVenteFatoura.Sum(x => x.TotalLigneHT), 1000);

            RapportResultat.Parameters["TotalVenteFatoura"].Value = (Math.Truncate(VenteFatoura * 100000m) / 100000m).ToString();

            // vente vierge 
            List<LigneVente> ListeVenteVierge = db.LignesVente.Where(x => x.ArticleVente == ArticleVente.Vierge).ToList();

            decimal VenteVierge = decimal.Divide(ListeVenteVierge.Sum(x => x.TotalLigneHT), 1000);

            RapportResultat.Parameters["TotalVenteVierge"].Value = (Math.Truncate(VenteVierge * 100000m) / 100000m).ToString();

            // vente xtra 
            List<LigneVente> ListeVenteXtra = db.LignesVente.Where(x => x.ArticleVente == ArticleVente.ExtraVierge).ToList();

            decimal VenteXtra = decimal.Divide(ListeVenteXtra.Sum(x => x.TotalLigneHT), 1000);

            RapportResultat.Parameters["TotalVenteXtra"].Value = (Math.Truncate(VenteXtra * 100000m) / 100000m).ToString();




            // vente lampante 
            List<LigneVente> ListeVenteLampante = db.LignesVente.Where(x => x.ArticleVente == ArticleVente.Lampante).ToList();

            decimal VenteLampante = 0;

            if (ListeVenteLampante != null)
            {
                VenteLampante = decimal.Divide(ListeVenteLampante.Sum(x => x.TotalLigneHT), 1000);
            }

            RapportResultat.Parameters["TotalVenteLampante"].Value = Math.Truncate(VenteLampante * 100000m) / 100000m;


            // total vente huile 
            decimal totalLampanteExtra1 = decimal.Add(VenteLampante, VenteExtra);

            decimal totalViergeExtraVierge2 = decimal.Add(VenteVierge, VenteXtra);

            decimal total12 = decimal.Add(totalLampanteExtra1, totalViergeExtraVierge2);

            decimal totalVenteHuile = decimal.Add(total12, VenteFatoura);

            RapportResultat.Parameters["TotalVenteHuile"].Value = Math.Truncate(totalVenteHuile * 100000m) / 100000m;


            // total service 

            List<Achat> ListeServices = db.Achats.Where(x => x.TypeAchat == TypeAchat.Service).ToList();
            decimal TotalService = 0;

            if (ListeServices != null)
            {
                TotalService = decimal.Divide(ListeServices.Sum(x => x.MontantReglement), 1000);
            }


            RapportResultat.Parameters["TotalServices"].Value = Math.Truncate(TotalService * 100000m) / 100000m;

            // totale des ventes huile + servises

            decimal VEN_SER = decimal.Add(totalVenteHuile, TotalService);

            RapportResultat.Parameters["TotalVentes"].Value = Math.Truncate(VEN_SER * 100000m) / 100000m;


            /********************************** Charges ******************************/

            // depenses achat huile ou Rendement  Extra 

            List<Achat> ListeAchatHuileExtra = db.Achats.Where(x => (x.TypeAchat == TypeAchat.Huile && x.Qualite == ArticleVente.Extra) || (x.TypeAchat == TypeAchat.Base && x.TypeOlive == ArticleAchat.OliveVif)).ToList();

            decimal TotalExtra = 0;

            if (ListeAchatHuileExtra != null)
            {
                TotalExtra = decimal.Divide(ListeAchatHuileExtra.Sum(x => x.MontantReglement), 1000);
            }


            RapportResultat.Parameters["TotalHuileExtra"].Value = Math.Truncate(TotalExtra * 100000m) / 100000m;


            // depenses achat huile ou Rendement  Lampante 
            List<Achat> ListeAchatHuileLampante = db.Achats.Where(x => ((x.TypeAchat == TypeAchat.Huile && x.Qualite == ArticleVente.Lampante) || (x.TypeAchat == TypeAchat.Base && x.TypeOlive == ArticleAchat.Nchira))).ToList();
            decimal TotalLampante = 0;

            if (ListeAchatHuileLampante != null)
            {
                TotalLampante = decimal.Divide(ListeAchatHuileLampante.Sum(x => x.MontantReglement), 1000);
            }


            RapportResultat.Parameters["TotalHuileLampante"].Value = Math.Truncate(TotalLampante * 100000m) / 100000m;


            // depenses achat huile vierge  
            List<Achat> ListeAchatHuileVierge = db.Achats.Where(x => x.TypeAchat == TypeAchat.Huile && x.Qualite == ArticleVente.Vierge).ToList();

            decimal TotalVierge = decimal.Divide(ListeAchatHuileVierge.Sum(x => x.MontantReglement), 1000);

            RapportResultat.Parameters["TotalAchatVierge"].Value = (Math.Truncate(TotalVierge * 100000m) / 100000m).ToString();

            // depenses achat huile ExtraVierge  
            List<Achat> ListeAchatHuileExtraVierge = db.Achats.Where(x => x.TypeAchat == TypeAchat.Huile && x.Qualite == ArticleVente.ExtraVierge).ToList();

            decimal TotalExtraVierge = decimal.Divide(ListeAchatHuileExtraVierge.Sum(x => x.MontantReglement), 1000);

            RapportResultat.Parameters["TotalAchatXtra"].Value = (Math.Truncate(TotalExtraVierge * 100000m) / 100000m).ToString();

            // total achat extra et lampante

            decimal totalAchatHuileExtraLampante = decimal.Add(TotalExtra, TotalLampante);

            // total achat extra et lampante
            decimal totalAchatHuileViergeXtra = decimal.Add(TotalVierge, TotalExtraVierge);

            decimal totalAchatHuile = decimal.Add(totalAchatHuileExtraLampante, totalAchatHuileViergeXtra);

            RapportResultat.Parameters["TotalAchatHuile"].Value = Math.Truncate(totalAchatHuile * 100000m) / 100000m;

            // total achat olive nchira

            List<Achat> ListeAchatOliveNchira = db.Achats.Where(x => x.TypeAchat == TypeAchat.Olive && x.TypeOlive == ArticleAchat.Nchira).ToList();
            decimal TotalOliveNchira = 0;

            if (ListeAchatOliveNchira != null)
            {
                TotalOliveNchira = decimal.Divide(ListeAchatOliveNchira.Sum(x => x.MontantReglement), 1000);
            }


            RapportResultat.Parameters["TotalAchatOliveNchira"].Value = Math.Truncate(TotalOliveNchira * 100000m) / 100000m;

            // total achat olive vif

            List<Achat> ListeAchatOliveVif = db.Achats.Where(x => x.TypeAchat == TypeAchat.Olive && x.TypeOlive == ArticleAchat.OliveVif).ToList();
            decimal TotalOliveVif = 0;

            if (ListeAchatOliveVif != null)
            {
                TotalOliveVif = decimal.Divide(ListeAchatOliveVif.Sum(x => x.MontantReglement), 1000);
            }


            RapportResultat.Parameters["TotalAchatOliveVif"].Value = Math.Truncate(TotalOliveVif * 100000m) / 100000m;

            // total achat nchira et oliv vif

            decimal totalAchatOlive = decimal.Add(TotalOliveVif, TotalOliveNchira);

            RapportResultat.Parameters["TotalAchatOlive"].Value = Math.Truncate(totalAchatOlive * 100000m) / 100000m;



            // depenses salariés
            List<Depense> ListeDepenseSalaries = db.Depenses.Where(x => x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList();
            decimal DepenseSalaries = 0;

            if (ListeDepenseSalaries != null)
            {
                DepenseSalaries = decimal.Divide(ListeDepenseSalaries.Sum(x => x.Montant), 1000);
            }



            RapportResultat.Parameters["TotalSalaries"].Value = Math.Truncate(DepenseSalaries * 100000m) / 100000m;

            // depense prelevement


            List<Depense> ListePrelevements = db.Depenses.Where(x => x.Nature == NatureMouvement.Prélèvement).ToList();

            decimal Prelevements = 0;

            if (ListePrelevements != null)
            {
                Prelevements = decimal.Divide(ListePrelevements.Sum(x => x.Montant), 1000);
            }


            RapportResultat.Parameters["TotalPrelevements"].Value = Math.Truncate(Prelevements * 100000m) / 100000m;

            // depense autre
            List<Depense> ListeAutre = db.Depenses.Where(x => x.Nature == NatureMouvement.Autre).ToList();
            decimal Autre = 0;

            if (ListeAutre != null)
            {
                Autre = decimal.Divide(ListeAutre.Sum(x => x.Montant), 1000);
            }


            RapportResultat.Parameters["TotalAutre"].Value = Math.Truncate(Autre * 100000m) / 100000m;

            // totale charges 

            decimal SAL_Prelev = decimal.Add(DepenseSalaries, Prelevements);

            decimal ACH_Autre = decimal.Add(totalAchatHuile, Autre);


            decimal Charge = decimal.Add(SAL_Prelev, ACH_Autre);

            decimal charge_olive = decimal.Add(Charge, totalAchatOlive);

            RapportResultat.Parameters["TotaleCharges"].Value = Math.Truncate(charge_olive * 100000m) / 100000m;

            /******************************** Resultat Vente - Charge************************/

            RapportResultat.Parameters["ResultatVenteCharge"].Value = Math.Truncate(decimal.Subtract(VEN_SER, charge_olive) * 100000m) / 100000m;

            /******************************* Valeur Stock ************************************/

            List<Pile> Piles = db.Piles.Where(x => x.Capacite > 0).OrderBy(x => x.article).ToList();
            List<Emplacement> emplacements = db.Emplacements.Where(x => x.Quantite > 0).OrderBy(x => x.Article).ToList();

            if (Piles != null)
            {
                decimal valeurStock = 0;

                decimal valeurStockPile = 0;

                foreach (var P in Piles)

                {
                    valeurStockPile = decimal.Multiply(P.Capacite, P.PrixMoyen);

                    valeurStock = decimal.Add(valeurStock, valeurStockPile);
                }


                RapportResultat.Parameters["Stock"].Value = Math.Truncate(decimal.Divide(valeurStock, 1000) * 100000m) / 100000m;
            }

            else
            {
                RapportResultat.Parameters["Stock"].Value = 0;
            }





            /******************************** Solde Client ************************************/

            List<Vente> ListeVentes = db.Vente.ToList();

            decimal SoldeClients = 0;

            if (ListeVentes != null)
            {
                SoldeClients = decimal.Divide(ListeVentes.Sum(x => x.ResteApayer), 1000) * -1;
            }

            RapportResultat.Parameters["SoldeClients"].Value = Math.Truncate(SoldeClients * 100000m) / 100000m;

            /******************************* Solde Caisse ***********************************/

            Caisse Caisse = db.Caisse.FirstOrDefault();

            RapportResultat.Parameters["SoldeCaisse"].Value = Math.Truncate(decimal.Divide(Caisse.MontantTotal, 1000) * 100000m) / 100000m; ;


            /******************************* Solde Fournisseurs ***********************************/

            List<Agriculteur> ListeAgriculteurs = db.Agriculteurs.ToList();
            decimal SoldeAgriculteurs = 0;

            if (ListeAgriculteurs != null)
            {
                SoldeAgriculteurs = decimal.Divide(ListeAgriculteurs.Sum(x => x.SoldeAgriculteurAvecSens), 1000);

            }

            RapportResultat.Parameters["SoldeAgriculteurs"].Value = Math.Truncate(SoldeAgriculteurs * 100000m) / 100000m;

            List<PileRapport> ListePilesRapport = new List<PileRapport>();
            List<Emplacement> ListeEmplacement = new List<Emplacement>();
            foreach (var p in Piles)
            {
                PileRapport PR = new PileRapport();
                PR.Intitule = p.Intitule;
                PR.article = p.article;
                PR.Capacite = p.Capacite;
                PR.PrixMoyen = p.PrixMoyen;
                ListePilesRapport.Add(PR);


            }

            foreach (var em in emplacements)
            {
                Emplacement EM = new Emplacement();
                EM.Intitule = em.Intitule;
                EM.Article = em.Article;
                EM.Quantite = em.Quantite;
                EM.PrixMoyen = em.PrixMoyen;
                EM.ValeurMasraf = decimal.Divide(em.ValeurMasraf, 1000);
                ListeEmplacement.Add(EM);
            }
            var stockEM = ListeEmplacement.Sum(x => x.ValeurMasraf);
            RapportResultat.Parameters["StockOlive"].Value = stockEM;
            List<PileEmplacement> pileEmplacements = new List<PileEmplacement>();
            PileEmplacement pileEmplacement = new PileEmplacement();
            pileEmplacement.ListeEmplacement = ListeEmplacement;
            pileEmplacement.ListePilesRapport = ListePilesRapport;
            pileEmplacements.Add(pileEmplacement);


            RapportResultat.DataSource = pileEmplacements;

            using (ReportPrintTool printTool = new ReportPrintTool(RapportResultat))
            {
                printTool.ShowPreviewDialog();
           
            }

        }

        private void barBtnSociete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmSociete.InstanceFrmSociete);
        }

        private void barBtnTransfertPile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmTransfertPile.InstanceFrmTransfertPile);
        }

        private void barButtonListeDesAvances_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmListedesAvances.InstanceFrmListedesAvances);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmListeDepenseSaison.InstanceFrmListeDepenseSaison);
        }

        private void barButtonItemlistePrélèvements_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmlistePrélèvements.InstanceFrmlistePrélèvements);
        }

        private void barButtonItemAjouertDepense_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterDepense.InstanceFrmDepense);
        }

        private void barButtonItemAjouterAlimentation_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterAlimentation.InstanceFrmAlimentation);
        }





        private void barBtnListeDepensesAgriculteurs_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmListeDepensesAgriculteurs.InstanceFrmListeDepensesAgriculteurs);
        }

        private void barBtnModifierProduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmModifierProduction.InstanceFrmModifierProduction);
        }

        private void btnEntreeDivers_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmEntreeDivers.InstanceFrmEntreeDivers);
        }

        private void BtnAnnulerAvance_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAnnulationAvance.InstanceFrmAnnulationAvance);
        }



        private static String ConnectionLocaldb
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            }
        }
        private const string QueryDeleteMouvementStocks = @"delete from [dbo].[MouvementStocks] ";
        private const string QueryDeleteMouvementCaisses = @"delete from [dbo].[MouvementCaisses] ";
        private const string QueryDeleteLigneVentes = @"delete from [dbo].[LigneVentes] ";
        private const string QueryDeleteVentes = @"delete from [dbo].[Ventes] ";

        private const string QueryDeleteHistoriquePaiementVentes = @"delete from [dbo].[HistoriquePaiementVentes] ";
        private const string QueryDeleteHistoriquePaiementSalaries = @"delete from [dbo].[HistoriquePaiementSalaries] ";
        private const string QueryDeleteHistoriquePaiementAchats = @"delete from [dbo].[HistoriquePaiementAchats] ";
        private const string QueryDeleteDepenses = @"delete from [dbo].[Depenses] ";
        private const string QueryDeleteCoffrecheques = @"delete from [dbo].[Coffrecheques] ";
        private const string QueryDeleteAlimentations = @"delete from [dbo].[Alimentations] ";
        private const string QueryUpdateAgr = @"UPDATE [dbo].[Agriculteurs]
        SET
       [Solde] = 0
      ,[TotalAvances] = 0
      ,[TotalAchats] =0
      ,[SoldeAgriculteur] = 0";

        private const string QueryDeleteAchats = @"delete from [dbo].[Achats] ";

        private const string QueryUpdatePile = @"UPDATE [dbo].[Piles] SET [PrixMoyen] = 0, [Capacite]=0";
        private const string QueryDeletePrelevements = @"delete from [dbo].[Prelevements] ";
        private const string QueryDeleteLigneStocks = @"delete from [dbo].[LigneStocks] ";

        private const string QueryDeleteLigneProductions = @"delete from [dbo].[LigneProductions] ";
        private const string QueryDeleteProductions = @"delete from [dbo].[Productions] ";

        private const string QueryUpdateCaisse = @" UPDATE [dbo].[Caisses] SET [MontantTotal] =0";


        private void suppSqlClient()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionLocaldb))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdatePile, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteMouvementStocks, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteMouvementCaisses, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteLigneVentes, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(QueryDeleteHistoriquePaiementVentes, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(QueryDeleteVentes, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteHistoriquePaiementSalaries, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteHistoriquePaiementAchats, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteDepenses, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.ToList();
                }

                if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                }

                if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteCoffrecheques, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                List<Coffrecheque> result = db.CoffreCheques.Where(x => x.Depense.Id != 0).ToList();

                if (Application.OpenForms.OfType<FrmCoffreChequeEmis>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmCoffreChequeEmis>().First().coffrechequeBindingSource.DataSource = result;
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteAlimentations, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.ToList();
                };


                using (SqlCommand cmd = new SqlCommand(QueryUpdateAgr, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = db.Agriculteurs.ToList();
                };

                using (SqlCommand cmd = new SqlCommand(QueryDeleteLigneStocks, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteLigneProductions, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteProductions, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryDeleteAchats, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.ToList();
                };


                using (SqlCommand cmd = new SqlCommand(QueryDeletePrelevements, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmlistePrélèvements>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmlistePrélèvements>().First().prelevementBindingSource.DataSource = db.Prelevements.ToList();
                }

                using (SqlCommand cmd = new SqlCommand(QueryUpdateCaisse, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                if (Application.OpenForms.OfType<FrmClotureCaisse>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmClotureCaisse>().First().TxtMontantCaisse.Text = "0";
                }

                connection.Close();

            }



            XtraMessageBox.Show("L'application est remise à zéro", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Exercice_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmExercice.InstanceFrmExercice);
        }

        private void BtnAjouterEmplacement_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterEmplacement.InstanceFrmAjouterEmplacement);
        }

        private void BtnListeEmplacements_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatOlive)
            {
                Formshow(Forms.FrmEmplacement.InstanceFrmEmplacement);
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void BtnMvtStockOlive_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatOlive)
            {
                Formshow(Forms.FrmMouvementStockOlive.InstanceFrmMouvementStockOlive);
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatOlive)
            {
                if (db.Chaines.ToList().Count == 0)
                {
                    XtraMessageBox.Show("Merci d'ajouter votre liste de chaines ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Formshow(Forms.FrmMasrafProduction.InstanceFrmMasrafProduction);
                }
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void barEtatImpots_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();

            Societe Ste = db.Societe.FirstOrDefault();
            EtatImpots etatImpots = new EtatImpots();
            etatImpots.Parameters["MF"].Value = Ste.MatriculFiscal;
            etatImpots.Parameters["Adresse"].Value = Ste.Adresse;
            etatImpots.Parameters["Tel"].Value = Ste.Telephone;
            etatImpots.Parameters["Date"].Value = DateTime.Now;
            List<Achat> ListeAchats = new List<Achat>();
            ListeAchats = db.Achats.Where(x => x.AvecAmpo).ToList();
            etatImpots.DataSource = ListeAchats;
            using (ReportPrintTool printTool = new ReportPrintTool(etatImpots))
            {
                printTool.ShowPreviewDialog();
           
            }
        }

        private void BtnListeChaines_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatOlive)
            {
                Formshow(Forms.FrmListeChaines.InstanceFrmListeChaines);
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void BtnTransfetEmplacement_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatOlive)
            {
                FormshowNotParent(Forms.FrmTransfertEmplacement.InstanceFrmTransfertEmplacement);
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void barListePointageSalarier_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(Forms.FrmPointage.InstanceFrmPointage);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}