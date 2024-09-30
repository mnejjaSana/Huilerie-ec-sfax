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

            decimal MontantEncaisse;
            string MontantEncaisseStr = TxtMontantEncaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantEncaisseStr, out MontantEncaisse);

            decimal MontantOperation;
            string MontantOperationStr = TxtMontantOperation.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantOperationStr, out MontantOperation);

            decimal Solde;
            string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);
            

            var codesAchats = TxtCodeAchat.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(code => code.Trim()).ToList();

            if ((MontantEncaisse > Solde || MontantEncaisse <= 0))
            {
                XtraMessageBox.Show("Montant Règlement Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }

            if (MontantEncaisse > caisse.MontantTotal)
            {
                XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }


        
            //si aucune ligne dans la grid et le montant de TxtMontantEncaisse superieur a 3 mille
            var mtTicket = 0m;
            string num = codesAchats[0].Trim();
            Achat Achat = db.Achats.Where(x => x.Numero.Equals(num)).FirstOrDefault();
            if (gridView1.RowCount == 0 && MontantEncaisse >= 3000 && MontantEncaisse == MontantOperation)
            { // Calculer 1% de MontantEncaisse
                
                
                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                var MtAdeduireAjouterREG = decimal.Divide(MontantEncaisse, 100);
                var MtAPayeAvecImpoAjouterREG = decimal.Subtract(MontantEncaisse, MtAdeduireAjouterREG);
                mtTicket = MtAPayeAvecImpoAjouterREG;

                HP.AvecAmpoAjouterREG = true;
                HP.MtAdeduireAjouterREG = MtAdeduireAjouterREG;
                HP.MtAPayeAvecImpoAjouterREG = MtAPayeAvecImpoAjouterREG;
                HP.MontantRegle = MontantEncaisse;
                HP.Founisseur = Achat.Founisseur;
                HP.NumAchat = TxtCodeAchat.Text;
                HP.ResteApayer = decimal.Subtract(MontantOperation, MontantEncaisse);
                HP.Commentaire = "Règlement Caisse avec impo";
                db.HistoriquePaiementAchats.Add(HP);
                db.SaveChanges();


                foreach (var code in codesAchats)
                {

                    Achat Achatdb = db.Achats.Where(x => x.Numero.Equals(code.Trim())).FirstOrDefault();
                    if (Achatdb != null)
                    {
                        Achatdb.EtatAchat = EtatAchat.Reglee;
                        Achatdb.MontantRegle = Achatdb.MontantReglement;

                        HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats();

                        HPAchat.Founisseur = Achatdb.Founisseur;
                        HPAchat.NumAchat = Achatdb.Numero;
                        HPAchat.MontantReglement = Achatdb.MontantReglement;
                        HPAchat.MontantRegle = Achatdb.MontantReglement;
                        HPAchat.ResteApayer = 0;
                        HPAchat.Commentaire = "Règlement Caisse";
                        HPAchat.TypeAchat = Achatdb.TypeAchat;
                        db.HistoriquePaiementAchats.Add(HPAchat);
                        db.SaveChanges();
                    }


                }

                // Depense 
                Depense D = new Depense();


                D.Nature = NatureMouvement.ReglementImpo;
                D.CodeTiers = Achat.Founisseur.Numero;
                D.Agriculteur = Achat.Founisseur;
                D.Montant = MtAPayeAvecImpoAjouterREG;
                D.ModePaiement = "Espèce";
                D.Tiers = Achat.Founisseur.FullName;
                D.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;
                db.Depenses.Add(D);
                db.SaveChanges();
                int lastDep = db.Depenses.ToList().Count() + 1;
                D.Numero = "D" + (lastDep).ToString("D8");
                db.SaveChanges();

                // mvmCaisse
                MouvementCaisse mvtCaisse = new MouvementCaisse();
                mvtCaisse.MontantSens = MtAPayeAvecImpoAjouterREG * -1;
                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Agriculteur = Achat.Founisseur;
                mvtCaisse.CodeTiers = Achat.Founisseur.Numero;
                mvtCaisse.Source = "Agriculteur: " + Achat.Founisseur.FullName;

                Caisse CaisseDb = db.Caisse.Find(1);
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MtAPayeAvecImpoAjouterREG);

                }
                mvtCaisse.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;

                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Achat = Achat;
                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();
            }

            if (gridView1.RowCount == 0 && MontantEncaisse >= 3000 && MontantEncaisse != MontantOperation)
            { // Calculer 1% de MontantEncaisse


                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                var MtAdeduireAjouterREG = decimal.Divide(MontantEncaisse, 100);
                var MtAPayeAvecImpoAjouterREG = decimal.Subtract(MontantEncaisse, MtAdeduireAjouterREG);
                mtTicket = MtAPayeAvecImpoAjouterREG;

                HP.AvecAmpoAjouterREG = true;
                HP.MtAdeduireAjouterREG = MtAdeduireAjouterREG;
                HP.MtAPayeAvecImpoAjouterREG = MtAPayeAvecImpoAjouterREG;
                HP.MontantRegle = MontantEncaisse;
                HP.Founisseur = Achat.Founisseur;
                HP.NumAchat = TxtCodeAchat.Text;
                HP.ResteApayer = decimal.Subtract(MontantOperation, MontantEncaisse);
                HP.Commentaire = "Règlement Caisse avec impo";
                db.HistoriquePaiementAchats.Add(HP);
                db.SaveChanges();


                foreach (var code in codesAchats)
                {

                    Achat Achatdb = db.Achats.Where(x => x.Numero.Equals(code.Trim())).FirstOrDefault();
                    if (Achatdb != null)
                    {
                        Achatdb.EtatAchat = EtatAchat.Reglee;
                        Achatdb.MontantRegle = Achatdb.MontantReglement;

                        HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats();

                        HPAchat.Founisseur = Achatdb.Founisseur;
                        HPAchat.NumAchat = Achatdb.Numero;
                        HPAchat.MontantReglement = Achatdb.MontantReglement;
                        HPAchat.MontantRegle = Achatdb.MontantReglement;
                        HPAchat.ResteApayer = 0;
                        HPAchat.Commentaire = "Règlement Caisse";
                        HPAchat.TypeAchat = Achatdb.TypeAchat;
                        db.HistoriquePaiementAchats.Add(HPAchat);
                        db.SaveChanges();
                    }


                }

                // Depense 
                Depense D = new Depense();


                D.Nature = NatureMouvement.ReglementImpo;
                D.CodeTiers = Achat.Founisseur.Numero;
                D.Agriculteur = Achat.Founisseur;
                D.Montant = MtAPayeAvecImpoAjouterREG;
                D.ModePaiement = "Espèce";
                D.Tiers = Achat.Founisseur.FullName;
                D.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;
                db.Depenses.Add(D);
                db.SaveChanges();
                int lastDep = db.Depenses.ToList().Count() + 1;
                D.Numero = "D" + (lastDep).ToString("D8");
                db.SaveChanges();

                // mvmCaisse
                MouvementCaisse mvtCaisse = new MouvementCaisse();
                mvtCaisse.MontantSens = MtAPayeAvecImpoAjouterREG * -1;
                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Agriculteur = Achat.Founisseur;
                mvtCaisse.CodeTiers = Achat.Founisseur.Numero;
                mvtCaisse.Source = "Agriculteur: " + Achat.Founisseur.FullName;

                Caisse CaisseDb = db.Caisse.Find(1);
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MtAPayeAvecImpoAjouterREG);

                }
                mvtCaisse.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;

                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Achat = Achat;
                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();
            }



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


                TxtMontantEncaisse.Text = string.Empty;


            }
            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
            {
                db = new Model.ApplicationContext();
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


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

            }


            XtraMessageBox.Show("Règlement Ajouté avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            TicketAvanceSurAchat Ticket = new TicketAvanceSurAchat();

            Societe societe = db.Societe.FirstOrDefault();

            string RsSte = societe.RaisonSocial;

            Ticket.Parameters["RsSte"].Value = RsSte;

            Ticket.Parameters["RsSte"].Visible = false;

            Ticket.Parameters["MtPaye"].Value = mtTicket;

            Ticket.Parameters["MtPaye"].Visible = false;
            List<Achat> AchatSource = new List<Achat>();
            Achat AchatRapport = new Achat();
            AchatRapport.Numero = TxtCodeAchat.Text;
            AchatSource.Add(AchatRapport);

            Ticket.DataSource = AchatSource;
            using (ReportPrintTool printTool = new ReportPrintTool(Ticket))
            {
                printTool.ShowPreviewDialog();

            }
        }
 

    


            private void FrmAjouterReglementAchat_Load(object sender, EventArgs e)
            {

            }

            private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
            {
                if (e.Column.FieldName == "cin")
                {
                    var newValue = e.Value as string;

                    // Vérifiez si la nouvelle valeur n'est pas nulle et contient exactement 8 chiffres
                    if (!string.IsNullOrEmpty(newValue))
                    {
                        // Vérifiez si la longueur est 8 ou contient des caractères non numériques
                        if (newValue.Length != 8 || !newValue.All(char.IsDigit))
                        {
                            // Affichez un message d'erreur
                            XtraMessageBox.Show("Le CIN doit contenir exactement 8 chiffres.", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }

                        // Vérifiez si le CIN existe déjà dans le GridView
                        for (int row = 0; row < gridView1.DataRowCount; row++)
                        {
                            var existingCIN = gridView1.GetRowCellValue(row, "cin") as string;
                            if (existingCIN == newValue)
                            {
                                // Affichez un message d'erreur si le CIN existe déjà
                                XtraMessageBox.Show("Ce CIN existe déjà.", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                // Rétablir la valeur précédente ou effacer la cellule
                                gridView1.SetRowCellValue(e.RowHandle, e.Column, null); // ou utilisez la valeur précédente
                                return;
                            }
                        }
                    }

                }

                }


                private void BtnSupprimer_Click_1(object sender, EventArgs e)
                {
                    int visibleIndex = gridView1.GetVisibleIndex(gridView1.FocusedRowHandle);
                    gridView1.DeleteRow(visibleIndex);

                }



            } }