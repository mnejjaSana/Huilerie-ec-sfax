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
using Gestion_de_Stock.Repport;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmResultatCaisse : DevExpress.XtraEditors.XtraForm
    {
        public Model.ApplicationContext db { get; set; }

        private static FrmResultatCaisse _FrmResultatCaisse;

        public static FrmResultatCaisse InstanceFrmResultatCaisse
        {
            get
            {
                if (_FrmResultatCaisse == null)
                    _FrmResultatCaisse = new FrmResultatCaisse();
                return _FrmResultatCaisse;
            }
        }

        public FrmResultatCaisse()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmResultatCaisse_Load(object sender, EventArgs e)
        {
            dateDebut.DateTime = DateTime.Now;
        }

        private void FrmResultatCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmResultatCaisse = null;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            RapportResultatCaisse RapportResultat = new RapportResultatCaisse() ;

            RapportResultat.Parameters["Du"].Value = DateTime.Now;

          
                /*******************************Vente********************************/

                // vente extra 
                List<LigneVente> ListeVenteExtra = db.LignesVente.Where(x => x.ArticleVente.Equals("Extra")).ToList();

                decimal VenteExtra = decimal.Divide(ListeVenteExtra.Sum(x => x.TotalLigneHT), 1000);

                RapportResultat.Parameters["TotalVenteExtra"].Value = VenteExtra;

                // vente lampante 
                List<LigneVente> ListeVenteLampante = db.LignesVente.Where(x =>  x.ArticleVente.Equals("Lampante")).ToList();

                decimal VenteLampante = decimal.Divide(ListeVenteLampante.Sum(x => x.TotalLigneHT), 1000);

                RapportResultat.Parameters["TotalVenteLampante"].Value = VenteLampante;

            // vente fatoura 
            List<LigneVente> ListeVenteFatoura = db.LignesVente.Where(x => x.ArticleVente.Equals("Fatoura")).ToList();

            decimal VenteFatoura = decimal.Divide(ListeVenteFatoura.Sum(x => x.TotalLigneHT), 1000);

            RapportResultat.Parameters["TotalVenteFatoura"].Value = VenteFatoura.ToString();

            // vente vierge 
            List<LigneVente> ListeVenteVierge = db.LignesVente.Where(x => x.ArticleVente.Equals("Vierge")).ToList();

            decimal VenteVierge = decimal.Divide(ListeVenteVierge.Sum(x => x.TotalLigneHT), 1000);

            RapportResultat.Parameters["TotalVenteVierge"].Value = VenteVierge.ToString(); 

            // vente xtra 
            List<LigneVente> ListeVenteXtra = db.LignesVente.Where(x => x.ArticleVente.Equals("ExtraVierge")).ToList();

            decimal VenteXtra = decimal.Divide(ListeVenteXtra.Sum(x => x.TotalLigneHT), 1000);

            RapportResultat.Parameters["TotalVenteXtra"].Value = VenteXtra.ToString();


            // total vente huile 
            decimal totalLampanteExtra1 = decimal.Add(VenteLampante, VenteExtra);

            decimal totalViergeExtraVierge2 = decimal.Add(VenteVierge, VenteXtra);

            decimal total12 = decimal.Add(totalLampanteExtra1, totalViergeExtraVierge2);

            decimal totalVenteHuile = decimal.Add(total12, VenteFatoura);

            RapportResultat.Parameters["TotalVenteHuile"].Value = totalVenteHuile;
           
                // total service 

                List<Achat> ListeServices = db.Achats.Where(x =>  x.TypeAchat == TypeAchat.Service).ToList();

                decimal TotalService = decimal.Divide(ListeServices.Sum(x => x.MontantReglement), 1000);

                RapportResultat.Parameters["TotalServices"].Value = TotalService;

                // totale des ventes huile + servises

                decimal VEN_SER = decimal.Divide(decimal.Add(totalVenteHuile, TotalService), 1000);

                RapportResultat.Parameters["TotalVentes"].Value = VEN_SER;




                /**********************************Achat ******************************/

                // depenses achat huile ou Rendement  Extra 
                List<Achat> ListeAchatHuileExtra = db.Achats.Where(x =>  (x.TypeAchat== TypeAchat.Huile && x.Qualite.Equals("Extra"))|| (x.TypeAchat == TypeAchat.Base && x.TypeOlive.Equals("OliveVif"))).ToList();

                decimal TotalExtra = decimal.Divide(ListeAchatHuileExtra.Sum(x => x.MontantReglement),1000);

                RapportResultat.Parameters["TotalHuileExtra"].Value = Math.Truncate(TotalExtra * 100000m) / 100000m;


            // depenses achat huile ou Rendement  Lampante 
            List<Achat> ListeAchatHuileLampante = db.Achats.Where(x => ((x.TypeAchat == TypeAchat.Huile && x.Qualite.Equals("Lampante")) || (x.TypeAchat == TypeAchat.Base && x.TypeOlive.Equals("Nchira")))).ToList();

                decimal TotalLampante = decimal.Divide(ListeAchatHuileLampante.Sum(x => x.MontantReglement), 1000); 

                RapportResultat.Parameters["TotalHuileLampante"].Value = Math.Truncate(TotalLampante * 100000m) / 100000m;

            // depenses achat huile vierge  
            List<Achat> ListeAchatHuileVierge = db.Achats.Where(x =>x.TypeAchat == TypeAchat.Huile && x.Qualite.Equals("Vierge")).ToList();

            decimal TotalVierge = decimal.Divide(ListeAchatHuileVierge.Sum(x => x.MontantReglement), 1000); 

            RapportResultat.Parameters["TotalAchatVierge"].Value = (Math.Truncate(TotalVierge * 100000m) / 100000m).ToString();

            // depenses achat huile ExtraVierge  
            List<Achat> ListeAchatHuileExtraVierge = db.Achats.Where(x => x.TypeAchat == TypeAchat.Huile && x.Qualite.Equals("ExtraVierge")).ToList();

            decimal TotalExtraVierge = decimal.Divide(ListeAchatHuileExtraVierge.Sum(x => x.MontantReglement), 1000); 

            RapportResultat.Parameters["TotalAchatXtra"].Value = (Math.Truncate(TotalExtraVierge * 100000m) / 100000m).ToString();


            // total achat extra et lampante

            decimal totalAchatHuileExtraLampante = decimal.Add(TotalExtra, TotalLampante);

            // total achat extra et lampante
            decimal totalAchatHuileViergeXtra =decimal.Add(TotalVierge, TotalExtraVierge);

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
            List<Depense> ListeDepenseSalaries = db.Depenses.Where(x => x.Nature == NatureMouvement.Salarié ).ToList();

                decimal DepenseSalaries = decimal.Divide(ListeDepenseSalaries.Sum(x => x.Montant), 1000);

                RapportResultat.Parameters["TotalSalaries"].Value = DepenseSalaries;

                // depense prelevement

                List<Depense> ListePrelevements = db.Depenses.Where(x => x.Nature == NatureMouvement.Prélèvement ).ToList();

                decimal Prelevements = decimal.Divide(ListePrelevements.Sum(x => x.Montant), 1000);

                RapportResultat.Parameters["TotalPrelevements"].Value = Prelevements;

                // depense autre
                List<Depense> ListeAutre = db.Depenses.Where(x => x.Nature == NatureMouvement.Autre).ToList();

                decimal Autre = decimal.Divide(ListeAutre.Sum(x => x.Montant),1000);

                RapportResultat.Parameters["TotalAutre"].Value = Autre;

            // totale charges 

            decimal SAL_Prelev = decimal.Add(DepenseSalaries, Prelevements);

            decimal ACH_Autre = decimal.Add(totalAchatHuile, Autre);


            decimal Charge = decimal.Add(SAL_Prelev, ACH_Autre);

            decimal charge_olive = decimal.Add(Charge, totalAchatOlive);

            RapportResultat.Parameters["TotaleCharges"].Value = Math.Truncate(charge_olive * 100000m) / 100000m;

            /******************************** Resultat Vente - Charge************************/

            RapportResultat.Parameters["ResultatVenteCharge"].Value = Math.Truncate(decimal.Subtract(VEN_SER, charge_olive) * 100000m) / 100000m;

            /******************************* Valeur Stock ************************************/

            List<Pile> Piles = db.Piles.ToList();

                RapportResultat.Parameters["Stock"].Value = Piles.Sum(a=> a.Capacite);

                /******************************** Solde Client ************************************/

                List<Vente> ListeVentes = db.Vente.ToList();

                decimal SoldeClients = decimal.Divide(ListeVentes.Sum(x=> x.ResteApayer),1000);

                RapportResultat.Parameters["SoldeClients"].Value = SoldeClients;

            /******************************* Solde Caisse ***********************************/

            Caisse Caisse = db.Caisse.FirstOrDefault();

            RapportResultat.Parameters["SoldeCaisse"].Value = Caisse.MontantTotal;


            /******************************* Solde Fournisseurs ***********************************/

            List<Agriculteur> ListeAgriculteurs = db.Agriculteurs.ToList();

            decimal SoldeAgriculteurs = decimal.Divide(ListeAgriculteurs.Sum(x=> x.SoldeAgriculteur),1000);

            RapportResultat.Parameters["SoldeAgriculteurs"].Value = SoldeAgriculteurs;

        }
    }
}