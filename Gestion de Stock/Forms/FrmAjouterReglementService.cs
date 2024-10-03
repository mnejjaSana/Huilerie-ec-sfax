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
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterReglementService : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAjouterReglementService _FrmAjouterReglementService;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;

        public static FrmAjouterReglementService InstanceFrmAjouterReglementService
        {
            get
            {
                if (_FrmAjouterReglementService == null)
                    _FrmAjouterReglementService = new FrmAjouterReglementService();
                return _FrmAjouterReglementService;
            }
        }


        public FrmAjouterReglementService()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }



       

        private void BtnValider_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Caisse caisse = db.Caisse.FirstOrDefault();

           
            decimal MontantEncaisse;
            string MontantEncaisseStr = TxtMontantEncaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantEncaisseStr, out MontantEncaisse);

            decimal Solde;
            string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);


            var Achat = db.Achats.FirstOrDefault(x=>x.Numero== TxtCodeAchat.Text.Trim());

            if ((MontantEncaisse > Solde || MontantEncaisse <= 0) && Achat.TypeAchat == TypeAchat.Service)
            {
                XtraMessageBox.Show("Montant Règlement est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }

            decimal MontantTotal = decimal.Add(Achat.MontantRegle, MontantEncaisse);

            Achat.MontantRegle = MontantTotal;

            db.SaveChanges();

            if (Achat.MontantRegle == MontantTotal && Achat.ResteApayer == 0)
            {
                Achat.EtatAchat = EtatAchat.Reglee;
            }

            else if (MontantEncaisse == 0 && MontantTotal == Achat.ResteApayer)
            {
                Achat.EtatAchat = EtatAchat.NonReglee;
            }


            else if (Achat.ResteApayer < MontantTotal && MontantTotal != 0 && Achat.ResteApayer != 0)
            {
                Achat.EtatAchat = EtatAchat.PartiellementReglee;
            }

            else if (MontantEncaisse == 0 && MontantTotal == 0)
            {
                Achat.EtatAchat = EtatAchat.NonReglee;
            }

            db.SaveChanges();

            #region Ajouter Alimentation if type achat service

            if (Achat.TypeAchat == TypeAchat.Service && MontantEncaisse > 0)
            {


                Alimentation A = new Alimentation();
                A.Agriculteur = Achat.Founisseur;
                A.Source = SourceAlimentation.Service;
                A.Montant = MontantEncaisse;
                A.Commentaire = "Encaissement Service N° " + Achat.Numero;


                MouvementCaisse mvtCaisse = new MouvementCaisse();
                mvtCaisse.MontantSens = MontantEncaisse;
                mvtCaisse.Agriculteur = Achat.Founisseur;
                mvtCaisse.CodeTiers = Achat.Founisseur.Numero;
                mvtCaisse.Sens = Sens.Alimentation;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Source = "Agriculteur: " + Achat.Founisseur.FullName;

                Caisse CaisseDb = db.Caisse.Find(1);
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal = decimal.Add(CaisseDb.MontantTotal, MontantEncaisse);

                }
                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Montant = CaisseDb.MontantTotal;

                mvtCaisse.Commentaire = "Encaissement Service N° " + Achat.Numero;
                mvtCaisse.Achat = Achat;

                db.Alimentations.Add(A);
                db.SaveChanges();
                A.Numero = "E" + (A.Id).ToString("D8");
                db.SaveChanges();

                mvtCaisse.Numero = "E" + (lastMouvement).ToString("D8");
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();

                if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();

                if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();


                    if (db.MouvementsCaisse.Count() > 0)
                    {

                        List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                        MouvementCaisse mvt = ListeMvtCaisse.Last();

                        Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                    }
                }
                #endregion

                #region Ajouter historique paiement achat
                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                HP.Founisseur = Achat.Founisseur;
                HP.NumAchat = Achat.Numero;
                HP.MontantReglement = Achat.MontantReglement;
                HP.MontantRegle = MontantEncaisse;
                HP.ResteApayer = Achat.ResteApayer;
                HP.Commentaire = "Règlement Caisse";
                HP.TypeAchat = Achat.TypeAchat;
                db.HistoriquePaiementAchats.Add(HP);
                db.SaveChanges();

                #endregion

            }

                if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();

                    if (db.MouvementsCaisse.Count() > 0)
                    {

                        List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                        MouvementCaisse mvt = ListeMvtCaisse.Last();

                        Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                    }
                  
                }


            TxtMontantEncaisse.Text = string.Empty;
           this.Close();


            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
            {
                db = new Model.ApplicationContext();
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

            XtraMessageBox.Show("Règlement Ajouté avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                }
                //waiting Form
                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Numero, x.Nom, x.Prenom, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();

                
                    TicketAvanceSurAchat Ticket = new TicketAvanceSurAchat();

                    Societe societe = db.Societe.FirstOrDefault();

                    string RsSte = societe.RaisonSocial;

                    Ticket.Parameters["RsSte"].Value = RsSte;

                    Ticket.Parameters["RsSte"].Visible = false;

                    Ticket.Parameters["MtPaye"].Value = MontantEncaisse;

                    Ticket.Parameters["MtPaye"].Visible = false;

                    List<Achat> AchatDb = new List<Achat>();

                    AchatDb.Add(Achat);

                    Ticket.DataSource = AchatDb;
                    using (ReportPrintTool printTool = new ReportPrintTool(Ticket))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }



            }


        }

        private void FrmAjouterReglementService_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterReglementService = null;
        }
    }


}