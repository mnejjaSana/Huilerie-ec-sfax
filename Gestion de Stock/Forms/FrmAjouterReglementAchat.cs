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
    public partial class FrmAjouterReglementAchat : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAjouterReglementAchat _FrmAjouterReglementAchat;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;

        public static FrmAjouterReglementAchat InstanceFrmAjouterReglementAchat
        {
            get
            {
                if (_FrmAjouterReglementAchat == null)
                    _FrmAjouterReglementAchat = new FrmAjouterReglementAchat();
                return _FrmAjouterReglementAchat;
            }
        }


        public FrmAjouterReglementAchat()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }



        private void FrmAjouterReglementAchat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterReglementAchat = null;

        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Caisse caisse = db.Caisse.FirstOrDefault();

            int idAchat = int.Parse(TxtCodeAchat.Text);

            decimal MontantEncaisse;
            string MontantEncaisseStr = TxtMontantEncaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantEncaisseStr, out MontantEncaisse);

            decimal Solde;
            string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);


            var Achat = db.Achats.Find(idAchat);

            if ((MontantEncaisse > Solde || MontantEncaisse <= 0) && Achat.TypeAchat == TypeAchat.Service)
            {
                XtraMessageBox.Show("Montant Règlement est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }

            if (MontantEncaisse > caisse.MontantTotal && (Achat.TypeAchat == TypeAchat.Base || Achat.TypeAchat == TypeAchat.Huile || Achat.TypeAchat == TypeAchat.Olive))
            {
                XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }

            if ((MontantEncaisse > Solde || MontantEncaisse <= 0) && (Achat.TypeAchat == TypeAchat.Base || Achat.TypeAchat == TypeAchat.Huile || Achat.TypeAchat == TypeAchat.Olive))
            {
                XtraMessageBox.Show("Montant à Payer est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }


            Achat.MontantRegle = decimal.Add(Achat.MontantRegle, MontantEncaisse);


            //  decimal MontantTotal = Achat.MontantReglement;
            decimal MontantTotal = Achat.MtAPayeAvecImpo;
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


            #region
            //Achat.Nom = Nom.Text;
            //Achat.Prenom= Prenom.Text;
            //Achat.CIN = CIN.Text;
            #endregion
            db.SaveChanges();

            #region Ajouter Alimentation if type achat service

            if (Achat.TypeAchat == TypeAchat.Service && MontantEncaisse > 0)
            {


                Alimentation A = new Alimentation();
                A.Agriculteur = Achat.Founisseur;
                A.Source = SourceAlimentation.Service;
                A.Montant = MontantEncaisse;
                A.Commentaire = "Encaissement Service N° " + Achat.Numero;

                // A.Commentaire = "Règlement Service N°  " + Achat.Numero;

                //if (Achat.ResteApayer > 0)
                //{ A.Commentaire = "Avance sur Service N° " + Achat.Numero; }

                //else if (Achat.ResteApayer == 0)
                //{ A.Commentaire = "Encaissement Service N° " + Achat.Numero; }

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

                //if (Achat.ResteApayer > 0)
                //{ mvtCaisse.Commentaire = "Avance sur Service N° " + Achat.Numero; }

                //else if (Achat.ResteApayer == 0)
                //{ mvtCaisse.Commentaire = "Encaissement Service N° " + Achat.Numero; }

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


            #region Ajouter Depense et mvt caisse if type achat Base
            else if ((Achat.TypeAchat == TypeAchat.Base || Achat.TypeAchat == TypeAchat.Huile || Achat.TypeAchat == TypeAchat.Olive) && MontantEncaisse > 0)
            {
                Depense D = new Depense();

                if (Achat.TypeAchat == TypeAchat.Base)
                {
                    D.Nature = NatureMouvement.AchatOlive;
                }

                else if (Achat.TypeAchat == TypeAchat.Huile)
                {
                    D.Nature = NatureMouvement.AchatHuile;
                }
                else if (Achat.TypeAchat == TypeAchat.Olive)
                {
                    D.Nature = NatureMouvement.AchatOlive;
                }


                D.CodeTiers = Achat.Founisseur.Numero;
                D.Agriculteur = Achat.Founisseur;
                D.Montant = MontantEncaisse;
                D.ModePaiement = "Espèce";
                D.Tiers = Achat.Founisseur.FullName;

                //if (Achat.ResteApayer != 0 && Achat.TypeAchat == TypeAchat.Base)
                //{ D.Commentaire = "Avance sur Achat N° " + Achat.Numero; }

                //else if (Achat.ResteApayer != 0 && Achat.TypeAchat == TypeAchat.Huile)
                //{ D.Commentaire = "Avance sur Achat Huile N° " + Achat.Numero; }

                //else if (Achat.ResteApayer == 0 && Achat.TypeAchat == TypeAchat.Base)
                //{ D.Commentaire = "Règlement Achat N° " + Achat.Numero; }

                //else if (Achat.ResteApayer == 0 && Achat.TypeAchat == TypeAchat.Huile)
                //{ D.Commentaire = "Règlement Achat Huile N° " + Achat.Numero; }

                if (Achat.TypeAchat == TypeAchat.Base)
                { D.Commentaire = "Règlement Achat N° " + Achat.Numero; }

                else if (Achat.TypeAchat == TypeAchat.Huile)
                { D.Commentaire = "Règlement Achat Huile N° " + Achat.Numero; }
                else if (Achat.TypeAchat == TypeAchat.Olive)
                { D.Commentaire = "Règlement Achat Olive N° " + Achat.Numero; }

                db.Depenses.Add(D);
                db.SaveChanges();
                int lastDep = db.Depenses.ToList().Count() + 1;
                D.Numero = "D" + (lastDep).ToString("D8");
                db.SaveChanges();

                MouvementCaisse mvtCaisse = new MouvementCaisse();
                mvtCaisse.MontantSens = MontantEncaisse * -1;
                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Agriculteur = Achat.Founisseur;
                mvtCaisse.CodeTiers = Achat.Founisseur.Numero;
                mvtCaisse.Source = "Agriculteur: " + Achat.Founisseur.FullName;

                Caisse CaisseDb = db.Caisse.Find(1);
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantEncaisse);

                }


                //if (Achat.ResteApayer != 0)
                //{ mvtCaisse.Commentaire = "Avance sur Achat N° " + Achat.Numero; }

                //else if (Achat.ResteApayer == 0)
                //{ mvtCaisse.Commentaire = "Règlement Achat N° " + Achat.Numero; }

                if (Achat.TypeAchat == TypeAchat.Base)
                { mvtCaisse.Commentaire = "Règlement Achat N° " + Achat.Numero; }

                else if (Achat.TypeAchat == TypeAchat.Huile)
                { mvtCaisse.Commentaire = "Règlement Achat Huile N° " + Achat.Numero; }
                else if (Achat.TypeAchat == TypeAchat.Olive)
                { mvtCaisse.Commentaire = "Règlement Achat Olive N° " + Achat.Numero; }
                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Achat = Achat;
                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();

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



                if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();

                if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();

                    if (db.MouvementsCaisse.Count() > 0)
                    {

                        List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                        MouvementCaisse mvt = ListeMvtCaisse.Last();

                        Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                    }
                    #endregion
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
                    Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();


                if (Achat.TypeAchat == TypeAchat.Base || Achat.TypeAchat == TypeAchat.Huile || Achat.TypeAchat == TypeAchat.Olive)
                {
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


        }
        private void BtnSupprimer_Click(object sender, EventArgs e)
        {

            int visibleIndex = gridView1.GetVisibleIndex(gridView1.FocusedRowHandle);
            gridView1.DeleteRow(visibleIndex);




        }
        private void FrmAjouterReglementAchat_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "cin")
            {
                var newValue = e.Value as string;

                // Check if the new value is not null and contains exactly 8 digits
                if (newValue != null)
                {
                    // Check if the length is not 8 or contains non-digit characters
                    if (newValue.Length != 8 || !newValue.All(char.IsDigit))
                    {
                        // Show a message to the user
                        XtraMessageBox.Show("Le CIN doit contenir exactement 8 chiffres.", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
               
                        
                        return;
                    }
                }
            }
        }
    }


}