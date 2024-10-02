using Convertisseur;
using Convertisseur.Entite;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Repport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAchats : DevExpress.XtraEditors.XtraForm
    {
        private string filePath = string.Empty;
        public static int OldQteOlive;
        public static decimal OldPrixKGhuile;
        public static decimal Oldbase;
        public static decimal OldPUOliveFinal;
        public static decimal OldMontantReglement;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private static FrmAchats _FrmAchats;
        public static List<string> Types = new List<string>();

        public static FrmAchats InstanceFrmAchats
        {
            get
            {
                if (_FrmAchats == null)
                {
                    _FrmAchats = new FrmAchats();
                }

                return _FrmAchats;
            }
        }
        public FrmAchats()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAchats_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAchats = null;
        }

        private void FrmAchats_Load(object sender, EventArgs e)
        { /********************** Agriculteurs Liste************************/
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
                fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
            }
            /********************** Date aujourd'hui************************/
            dateEditDateFacture.DateTime = DateTime.Now;

            /********************** liste Achats ************************/
            achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


            /***********************  TypeOlive Liste  ***********************/
            List<string> ListeTypeOlive = Enum.GetNames(typeof(ArticleAchat)).ToList();
            if (ListeTypeOlive != null)
            {
                foreach (var TypeOlive in ListeTypeOlive)
                {
                    comboBoxTypeOlive.Properties.Items.Add(TypeOlive);
                }

                comboBoxTypeOlive.SelectedIndex = 0;
                if (ListeTypeOlive.Count > 0)
                {
                    comboBoxTypeOlive.SelectedItem = ListeTypeOlive[0];
                }
            }


            /***********************  TypeAchat Liste  ***********************/
            List<string> ListeTypeAchat = Enum.GetNames(typeof(TypeAchat)).ToList();



            Societe ste = db.Societe.FirstOrDefault();

            if (Types.Count > 0)
            {
                Types.Clear();
            }

            if (ste.AchatOlive && ste.AchatHuile && ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service


            }
            else if (ste.AchatOlive && !ste.AchatHuile && ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service


            }
            else if (ste.AchatOlive && !ste.AchatHuile && !ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[2]);//Avance
            }
            else if (!ste.AchatOlive && ste.AchatHuile && !ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[2]);//Avance
            }
            else if (!ste.AchatOlive && !ste.AchatHuile && ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance
            }
            else if (!ste.AchatOlive && !ste.AchatHuile && !ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[3]);// service

            }
            else if (ste.AchatOlive && ste.AchatHuile && !ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[2]);//Avance

            }
            else if (ste.AchatOlive && !ste.AchatHuile && ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance

            }
            else if (ste.AchatOlive && !ste.AchatHuile && !ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service

            }
            else if (!ste.AchatOlive && ste.AchatHuile && ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance

            }
            else if (!ste.AchatOlive && ste.AchatHuile && !ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service

            }
            else if (!ste.AchatOlive && !ste.AchatHuile && ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service

            }
            else if (ste.AchatOlive && ste.AchatHuile && ste.AchatBase && !ste.Service)
            {
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[4]); // olive
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance

            }
            else if (ste.AchatOlive && ste.AchatHuile && !ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[4]); // olive

                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service

            }
            else if (!ste.AchatOlive && ste.AchatHuile && ste.AchatBase && ste.Service)
            {
                Types.Add(ListeTypeAchat[0]);// huile
                Types.Add(ListeTypeAchat[1]);// base
                Types.Add(ListeTypeAchat[2]);//Avance
                Types.Add(ListeTypeAchat[3]);// service

            }

            foreach (var t in Types)
            {
                comboBoxTypeAchat.Properties.Items.Add(t);
            }


            comboBoxTypeAchat.SelectedIndex = 0;

            if (Types.Count > 0)
            {
                comboBoxTypeAchat.SelectedItem = Types[0];
            }

            /*************** Qualité Huile ***************/
            List<string> ListeArticle = Enum.GetNames(typeof(ArticleVente)).Where(item => item != ArticleVente.Fatoura.ToString()).ToList();
            if (ListeArticle != null)
            {
                foreach (var Article in ListeArticle)
                {
                    comboBoxQualité.Properties.Items.Add(Article);
                }

                comboBoxQualité.SelectedIndex = 0;
                if (ListeArticle.Count > 0)
                {
                    comboBoxQualité.SelectedItem = ListeArticle[0];
                }
            }

            ///***********************  Emplacements  ***********************/
            emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();


            ///***********************  Mode  Paiement Liste  ***********************/
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            if (ModePaiement != null)
            {
                foreach (var M in ModePaiement)
                {
                    comboBoxModeReglement.Properties.Items.Add(M);
                }

                comboBoxModeReglement.SelectedIndex = 0;
                if (ModePaiement.Count > 0)
                {
                    comboBoxModeReglement.SelectedItem = ModePaiement[0];
                }
            }



        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            if (string.IsNullOrEmpty(searchLookUpFournisseur.Text))
            {
                XtraMessageBox.Show("Choisir un Agriculteur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (comboBoxTypeAchat.Text.Equals("Huile"))
            {
                if (string.IsNullOrEmpty(comboBoxQualité.Text))
                {
                    comboBoxQualité.ErrorText = "Qualité Huile est obligatoire";
                    return;

                }

                if (string.IsNullOrEmpty(TxtQteHuileAchetee.Text))
                {
                    TxtQteHuileAchetee.ErrorText = "Quantité Huile Acheetée est obligatoire";
                    return;

                }


                if (string.IsNullOrEmpty(TxtPrixLitre.Text))
                {
                    TxtPrixLitre.ErrorText = "Prix kg (Huile) est obligatoire";
                    return;

                }

                if (string.IsNullOrEmpty(TxtNuméroBon.Text))
                {
                    TxtNuméroBon.ErrorText = "Numéro de Bon est obligatoire";

                    return;

                }



                if (string.IsNullOrEmpty(searchLookUpPile.Text))
                {
                    XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }

                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);

                if (PrixLitre > 40)
                {
                    XtraMessageBox.Show("Veuillez Vérifier le Prix Kg (Huile) ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPrixLitre.ErrorText = "Vérifier le Prix Kg(Huile)";
                    return;
                }

            }

            if (comboBoxTypeAchat.Text.Equals("Olive"))
            {
                if (string.IsNullOrEmpty(TxtNuméroBon.Text))
                {
                    TxtNuméroBon.ErrorText = "Numéro de Bon est obligatoire";

                    return;

                }

                if (string.IsNullOrEmpty(TxtQteOlive.Text))
                {
                    TxtQteOlive.ErrorText = "Quantité Olive Acheetée est obligatoire";
                    return;

                }

                if (string.IsNullOrEmpty(TxtPrixLitre.Text))
                {
                    TxtPrixLitre.ErrorText = "Prix kg (Huile) est obligatoire";
                    return;

                }

                if (string.IsNullOrEmpty(TxtRendement.Text))
                {
                    TxtRendement.ErrorText = "Base est obligatoire";
                    return;

                }

                if (string.IsNullOrEmpty(TxtPUOliveFinal.Text))
                {
                    TxtPUOliveFinal.ErrorText = "P.U (Olive) Final est obligatoire";
                    return;

                }
                if (string.IsNullOrEmpty(TxtMontantReglement.Text))
                {
                    TxtMontantReglement.ErrorText = "Montant Opération est obligatoire";

                    return;

                }

                int QteOliveAchetee = Convert.ToInt32(TxtQteOlive.Text);

                if (QteOliveAchetee <= 0)
                {
                    XtraMessageBox.Show("Veuillez Vérifier la quantité Olive Acheetée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtQteOlive.ErrorText = "Vérifier la quantité Olive Acheetée";
                    return;
                }

                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);

                if (PrixLitre > 40)
                {
                    XtraMessageBox.Show("Veuillez Vérifier le Prix Kg (Huile) ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPrixLitre.ErrorText = "Vérifier le Prix Kg(Huile)";
                    return;
                }

                decimal Rendement;
                string RendementStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(RendementStr, out Rendement);

                if (Rendement <= 0)
                {
                    XtraMessageBox.Show("Veuillez Vérifier le Base", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtRendement.ErrorText = "Vérifier le Base";
                    return;
                }


                decimal MontantOp;
                string MontantOpStr = TxtMontantReglement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(MontantOpStr, out MontantOp);

                if (MontantOp <= 0)
                {
                    XtraMessageBox.Show("Veuillez Vérifier le montant d'opération", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMontantReglement.ErrorText = "Vérifier le montant d'opération";
                    return;
                }

                decimal PUOliveFinal;
                string PUOliveFinalStr = TxtPUOliveFinal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PUOliveFinalStr, out PUOliveFinal);

                if (PUOliveFinal <= 0)
                {
                    XtraMessageBox.Show("Veuillez Vérifier le P.U (Olive) Final", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPUOliveFinal.ErrorText = "Vérifier le P.U (Olive) Final";
                    return;
                }

            }
            Achat A = new Achat();

            Agriculteur F = new Agriculteur();

            GridView view = searchLookUpFournisseur.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Agriculteurselected = view.GetRowCellValue(rowHandle, fieldName);

            ///Condition existance Fournisseur
            if (Agriculteurselected == null || searchLookUpFournisseur.Text == "")
            {
                XtraMessageBox.Show("Choisir un Agriculteur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpFournisseur.Focus();
                return;

            }
            else
            {

                int IdFournisseur = Convert.ToInt32(Agriculteurselected);
                F = db.Agriculteurs.Find(IdFournisseur);
                A.Founisseur = F;
            }


            if (comboBoxTypeAchat.SelectedItem == null)
            {
                comboBoxTypeAchat.ErrorText = "Type d'Achat est obligatoire";
                return;
            }


            A.Date = dateEditDateFacture.DateTime;

            decimal Poids;
            string PoidsStr = TxtPoids.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PoidsStr, out Poids);
            A.Poids = Poids;

            decimal MontantReglement;
            string MontantReglementStr = TxtMontantReglement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantReglementStr, out MontantReglement);
            A.MontantReglement = MontantReglement;


            decimal MontantRegle = 0m;
            string MontantRegleStr = TxtMontantRegle.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantRegleStr, out MontantRegle);
            A.MontantRegle = MontantRegle;


            if (comboBoxModeReglement.SelectedItem.ToString().Equals("Espèce"))
            {
                A.ModeReglement = ModeReglement.Espèce;
                A.NumeroCheque = "";
                A.DateEcheance = null;
                A.Banque = null;
                A.Coffre = false;
            }

            else if (comboBoxModeReglement.SelectedItem.ToString().Equals("Chèque") || comboBoxModeReglement.SelectedItem.ToString().Equals("Traite"))
            {
                if (string.IsNullOrEmpty(TxtNumCheque.Text))
                {
                    TxtNumCheque.ErrorText = "N° Chéque est Obligatoire";
                    return;
                }

                if (string.IsNullOrEmpty(TxtBank.Text))
                {
                    TxtBank.ErrorText = "Banque est Obligatoire";
                    return;
                }

                if (dateEcheance.EditValue == null)
                {
                    dateEcheance.ErrorText = "Date Echeance est Obligatoire";
                    return;
                }

                if (string.IsNullOrEmpty(TxtMontantRegle.Text))
                {
                    TxtMontantRegle.ErrorText = "Montant Règlement est Obligatoire";
                    return;
                }

                if (MontantRegle <= 0 && !comboBoxModeReglement.SelectedItem.ToString().Equals("Chèque") && comboBoxModeReglement.SelectedItem.ToString().Equals("Traite"))
                {
                    XtraMessageBox.Show("Montant Règlement est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TxtMontantRegle.Text = "";
                    return;
                }
                if (comboBoxModeReglement.SelectedItem.ToString().Equals("Chèque"))
                { A.ModeReglement = ModeReglement.Chèque; }
                else if (comboBoxModeReglement.SelectedItem.ToString().Equals("Traite"))
                { A.ModeReglement = ModeReglement.Traite; }

                A.NumeroCheque = TxtNumCheque.Text;
                A.DateEcheance = dateEcheance.DateTime;
                A.Banque = TxtBank.Text;
                A.Coffre = true;
            }

            #region   controle sur solde caisse

            Caisse CaisseDb = db.Caisse.Find(1);

            decimal MontantCaisse = CaisseDb.MontantTotal;

            if ((comboBoxTypeAchat.Text.Equals("Base") && MontantRegle > MontantCaisse && comboBoxModeReglement.Text.Equals("Espèce"))
                || (comboBoxTypeAchat.Text.Equals("Avance") && MontantRegle > MontantCaisse && comboBoxModeReglement.Text.Equals("Espèce"))
                || (comboBoxTypeAchat.Text.Equals("Huile") && MontantRegle > MontantCaisse && comboBoxModeReglement.Text.Equals("Espèce"))
                || (comboBoxTypeAchat.Text.Equals("Olive") && MontantRegle > MontantCaisse && comboBoxModeReglement.Text.Equals("Espèce")))
            {

                XtraMessageBox.Show("Solde Caisse est Insuffisant", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMontantRegle.Text = string.Empty;

                return;
            }





            #endregion
            // OLIVE
            else if (comboBoxTypeAchat.Text.Equals("Olive"))
            {

                Achat AchatExiste = db.Achats.FirstOrDefault(a => a.NuméroBon.Equals(TxtNuméroBon.Text) && (a.TypeAchat == TypeAchat.Huile || a.TypeAchat == TypeAchat.Base || a.TypeAchat == TypeAchat.Olive));

                if (AchatExiste != null)
                {

                    XtraMessageBox.Show("Numéro de Bon existe déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtNuméroBon.Text = string.Empty;
                    return;


                }

                if (MontantRegle < 0)
                {
                    TxtMontantRegle.ErrorText = "Montant d'Avance est Invalid";

                    XtraMessageBox.Show("Montant d'Avance est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TxtMontantRegle.Text = string.Empty;

                    return;

                }

                if (string.IsNullOrEmpty(TxtNbSac.Text))
                {
                    A.NbSacs = 0;

                }

                A.NuméroBon = TxtNuméroBon.Text;

                A.TypeAchat = TypeAchat.Olive;

                A.StatutProd = StatutProduction.EnAttente;


                if (comboBoxTypeOlive.Text.Equals("OliveVif"))
                {
                    A.TypeOlive = ArticleAchat.OliveVif;
                }
                else if (comboBoxTypeOlive.Text.Equals("Nchira"))
                {
                    A.TypeOlive = ArticleAchat.Nchira;
                }

                A.QteOliveAchetee = Convert.ToInt32(TxtQteOlive.Text);



                Emplacement Emplace = new Emplacement();

                GridView view1 = searchLookUpEmplacement.Properties.View;
                int rowHandle1 = view1.FocusedRowHandle;
                string fieldName1 = "Id"; // or other field name  
                object Empalceselected = view1.GetRowCellValue(rowHandle1, fieldName1);
                int Qteinit = 0;


                if (Empalceselected == null || searchLookUpEmplacement.Text == "")
                {
                    XtraMessageBox.Show("Choisir un Emplacement", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpEmplacement.Focus();
                    return;

                }
                else
                {
                    int IdEmplacement1 = Convert.ToInt32(Empalceselected);
                    Emplace = db.Emplacements.Find(IdEmplacement1);
                    A.Emplacement = Emplace;
                    Qteinit = Emplace.Quantite;
                }


                // sala7
                decimal MontantRegleFinal = 0m;

                List<Personne_Passager> ListePassagers = new List<Personne_Passager>();

                if (MontantRegle >= 3000)
                {
                    int row = 0;

                    while (gridView4.IsValidRowHandle(row))
                    {
                        var data = gridView4.GetRow(row) as Personne_Passager;
                        ListePassagers.Add(data);
                        row++;
                    }
                    if (ListePassagers.Count > 0)
                    {

                        decimal totalGrid = ListePassagers.Sum(x => x.MontantReglement);

                        if (totalGrid != MontantRegle)
                        {
                            XtraMessageBox.Show("Merci de vérifier les montants ajoutés avec les personnes!", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;

                        }


                    }
                }

                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);
                A.PrixLitre = PrixLitre;

                decimal Rendement;
                string RendementStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(RendementStr, out Rendement);
                A.Rendement = Rendement;

                decimal PUOlive;
                string PUOliveStr = TxtPUOlive.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PUOliveStr, out PUOlive);
                A.PUOlive = PUOlive;

                decimal PUOliveFinal;
                string PUOliveFinalStr = TxtPUOliveFinal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PUOliveFinalStr, out PUOliveFinal);
                A.PUOliveFinal = PUOliveFinal;

                decimal MontantOpPrev;
                string MontantOpPrevStr = TxtMtOpPrev.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(MontantOpPrevStr, out MontantOpPrev);
                A.MontantOpPrev = MontantOpPrev;


                A.EtatAchat = EtatAchat.NonReglee;
                A.MontantRegle = 0m;
                A.AvanceAvecAchat = MontantRegle;
                A.Poids = A.QteOliveAchetee;

                A.AvecAmpo = false;
                if (checkImpo.Checked)
                {
                    A.AvecAmpo = true;
                    A.MtAdeduire = decimal.Divide(A.MontantReglement, 100);
                    A.MtAPayeAvecImpo = decimal.Subtract(A.MontantReglement, A.MtAdeduire);
                }
                else
                {
                    A.MtAPayeAvecImpo = A.MontantReglement;
                }

                db.Achats.Add(A);
                db.SaveChanges();
                A.Numero = "OLV" + (A.Id).ToString("D8");
                db.SaveChanges();

                int QteEmpInitial = A.Emplacement.Quantite;
                int QteEmpFinal = QteEmpInitial + A.QteOliveAchetee;
                A.Emplacement.Quantite = QteEmpFinal;

                A.Emplacement.PrixMoyen = Math.Truncate((((A.QteOliveAchetee * A.PUOliveFinal) + (QteEmpInitial * A.Emplacement.PrixMoyen)) / QteEmpFinal) * 100000m) / 100000m;
                A.Emplacement.LastPrixMoyen = A.Emplacement.PrixMoyen;
                A.Emplacement.ValeurMasraf = decimal.Multiply(A.Emplacement.PrixMoyen, QteEmpFinal);

                db.SaveChanges();



                //sirine
                if (MontantRegle > 0)
                {
                    Achat AvnaceSurAchat = new Achat();
                    AvnaceSurAchat.TypeAchat = TypeAchat.Avance;
                    AvnaceSurAchat.PrixLitre = 0;
                    AvnaceSurAchat.MontantRegle = MontantRegle;
                    AvnaceSurAchat.MontantReglement = 0;
                    AvnaceSurAchat.NbSacs = 0;

                    AvnaceSurAchat.Founisseur = F;
                    db.Achats.Add(AvnaceSurAchat);
                    db.SaveChanges();
                    AvnaceSurAchat.Numero = "AVN" + (A.Id).ToString("D8");
                    db.SaveChanges();

                    decimal Deduit = decimal.Multiply(MontantRegle, 0.01m);

                    MontantRegleFinal = decimal.Subtract(MontantRegle, Deduit);

                    if (MontantRegle >= 3000)
                    {
                        F.Solde = decimal.Add(F.Solde, MontantRegleFinal);
                    }
                    else
                    {
                        F.Solde = Decimal.Add(F.Solde, MontantRegle);
                    }
                  
                    db.SaveChanges();

                    // new work


                    if (MontantRegle >= 3000)
                    {
                        AvnaceSurAchat.MontantInitialAvance = MontantRegle;
                        AvnaceSurAchat.MontantRegle = MontantRegleFinal;
                        AvnaceSurAchat.AvanceAvecAchat = MontantRegleFinal;
                       
                        db.SaveChanges();
                        MontantRegle = MontantRegleFinal;

                        if (ListePassagers.Count == 0)
                        {
                            AvnaceSurAchat.PersonnesPassagers = null;

                        }
                        else
                        {
                            foreach (var item in ListePassagers)
                            {
                                A.PersonnesPassagers.Add(
                                  new Personne_Passager { FullName = item.FullName, cin = item.cin, MontantReglement = item.MontantReglement, Numero = AvnaceSurAchat.Numero });
                            }

                        }
                    }

                }



                #region Ajouter Mouvement Olive 

                decimal RendementMov;
                string RendementMovStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(RendementMovStr, out RendementMov);

                MouvementStockOlive mouvementStockOlive = new MouvementStockOlive();
                mouvementStockOlive.Sens = SensStockOlive.Entree;
                mouvementStockOlive.Date = A.Date;
                mouvementStockOlive.Commentaire = "Entree Stock " + A.Numero;
                mouvementStockOlive.QuantiteMasrafInitial = Qteinit;
                mouvementStockOlive.QuantiteMasrafFinal = Qteinit + A.QteOliveAchetee;
                mouvementStockOlive.RENDEMENTMVT = RendementMov;
                mouvementStockOlive.QteEntrante = A.QteOliveAchetee;
                if (Qteinit == 0)
                {
                    mouvementStockOlive.RENDEMENMOY = RendementMov;
                }
                else
                { // =((C3*D3)+(E2*F2))/E3
                    mouvementStockOlive.RENDEMENMOY = Math.Truncate((((A.QteOliveAchetee * RendementMov) + (mouvementStockOlive.QuantiteMasrafInitial * Emplace.RENDEMENMOY)) / mouvementStockOlive.QuantiteMasrafFinal) * 100000m) / 100000m;

                }

                mouvementStockOlive.Emplacement = Emplace;
                mouvementStockOlive.PrixMouvement = A.PUOliveFinal;
                mouvementStockOlive.QteEntrante = A.QteOliveAchetee;
                mouvementStockOlive.QteSortante = 0;
                mouvementStockOlive.Code = A.Numero;
                mouvementStockOlive.Intitulé = A.Founisseur.Numero;
                db.MouvementStockOlive.Add(mouvementStockOlive);
                db.SaveChanges();
                mouvementStockOlive.Numero = "MOVENT" + (mouvementStockOlive.Id).ToString("D8");
                db.SaveChanges();
                Emplace.RENDEMENMOY = mouvementStockOlive.RENDEMENMOY;
                db.SaveChanges();
                if (Application.OpenForms.OfType<FrmEmplacement>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmEmplacement>().First().emplacementBindingSource.DataSource = db.Emplacements.ToList();
                }

                if (Application.OpenForms.OfType<FrmMouvementStockOlive>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMouvementStockOlive>().First().mouvementStockOliveBindingSource.DataSource = db.MouvementStockOlive.ToList();
                }
                #endregion
                #region Ajouter Littrage Avance Sur Achats Type olive

                Agriculteur Agriculteur = db.Agriculteurs.Find(F.Id);
                decimal Solde = F.Solde;
                List<Achat> ListeAchats = db.Achats.Where(x => (x.TypeAchat == TypeAchat.Base || x.TypeAchat == TypeAchat.Huile || x.TypeAchat == TypeAchat.Olive) && x.Founisseur.Id == F.Id && x.MontantReglement > 0 && (x.EtatAchat == EtatAchat.NonReglee || x.EtatAchat == EtatAchat.PartiellementReglee)).OrderBy(x => x.Date).ToList();
                if (ListeAchats.Count > 0 && Solde > 0)
                {
                    foreach (var L in ListeAchats)
                    {
                        decimal MontantEncaisse = 0m;
                        if (Solde >= L.ResteApayer && Solde > 0)
                        {
                            // Totalement Reglèès
                            MontantEncaisse = L.ResteApayer;

                            Achat AchatDb = db.Achats.Find(L.Id);
                            AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                            AchatDb.EtatAchat = EtatAchat.Reglee;
                            db.SaveChanges();
                            #region Ajouter historique paiement achat
                            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                            HP.Founisseur = AchatDb.Founisseur;
                            HP.NumAchat = AchatDb.Numero;
                            HP.MontantReglement = AchatDb.MontantReglement;
                            HP.MontantRegle = MontantEncaisse;
                            HP.ResteApayer = AchatDb.ResteApayer;
                            HP.TypeAchat = AchatDb.TypeAchat;
                            HP.Commentaire = "Règlement Automatique Par Avance ";
                            db.HistoriquePaiementAchats.Add(HP);
                            db.SaveChanges();

                            #endregion

                        }
                        else if (Solde < L.ResteApayer && Solde > 0)
                        {
                            // parceilellement reglè 
                            MontantEncaisse = Solde;
                            Achat AchatDb = db.Achats.Find(L.Id);
                            AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                            AchatDb.EtatAchat = EtatAchat.PartiellementReglee;

                            db.SaveChanges();

                            #region Ajouter historique paiement achat
                            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                            HP.Founisseur = AchatDb.Founisseur;
                            HP.NumAchat = AchatDb.Numero;
                            HP.MontantReglement = AchatDb.MontantReglement;
                            HP.MontantRegle = MontantEncaisse;
                            HP.ResteApayer = AchatDb.ResteApayer;
                            HP.TypeAchat = AchatDb.TypeAchat;
                            HP.Commentaire = "Règlement Automatique Par Avance";
                            db.HistoriquePaiementAchats.Add(HP);
                            db.SaveChanges();

                            #endregion
                            //Solde = decimal.Subtract(Solde, MontantEncaisse);
                            //break; // get out of the loop
                        }
                        Solde = decimal.Subtract(Solde, MontantEncaisse);

                    }

                    Agriculteur.Solde = Solde;
                    db.SaveChanges();
                }



                #endregion

                List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
                if (db.Agriculteurs.Count() > 0)
                {

                    ListAgriculteurs = db.Agriculteurs.ToList();
                    foreach (var l in ListAgriculteurs)
                    {
                        List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                        l.TotalAchats = ListeAchats1.Sum(x => x.MontantReglement);
                        List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                        decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                        l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                        decimal TotalDeduit = ListeAchats1.Sum(x => x.MtAdeduire);
                        decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                        l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                    }

                }
                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Numero, x.Nom, x.Prenom, x.Tel, x.cin, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
                }

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                }

                fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();


                if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }
                if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;
                }

                if (Application.OpenForms.OfType<FrmTransfertEmplacement>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmTransfertEmplacement>().First().emplacementEntrantBindingSource.DataSource = db.Emplacements.AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                }

                if (Application.OpenForms.OfType<FrmTransfertEmplacement>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmTransfertEmplacement>().First().emplacementSortantBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                }


                #region Depense type achat olive et mvt de caisse
                if (MontantRegle > 0)
                {
                    Depense D = new Depense();
                    D.Nature = NatureMouvement.AchatOlive;
                    D.Agriculteur = A.Founisseur;
                    D.CodeTiers = A.Founisseur.Numero;
                    D.DateCreation = A.Date;
                    if (A.ModeReglement == ModeReglement.Espèce)
                    {
                        D.ModePaiement = "Espèce";
                    }
                    else if (A.ModeReglement == ModeReglement.Chèque)
                    {
                        D.ModePaiement = "Chèque";
                        D.Bank = A.Banque;
                        D.DateEcheance = A.DateEcheance;
                        D.NumCheque = A.NumeroCheque;
                    }
                    else if (A.ModeReglement == ModeReglement.Traite)
                    {
                        D.ModePaiement = "Traite";
                        D.Bank = A.Banque;
                        D.DateEcheance = A.DateEcheance;
                        D.NumCheque = A.NumeroCheque;
                    }

                    D.Montant = MontantRegle;
                    D.Tiers = A.Founisseur.FullName;

                    D.Commentaire = "Avance Agriculteur_" + (A.Id).ToString("D8");

                    db.Depenses.Add(D);
                    db.SaveChanges();
                    D.Numero = "D" + (D.Id).ToString("D8");
                    db.SaveChanges();

                    // mouvt caisse
                    if (A.ModeReglement == ModeReglement.Espèce)
                    {
                        MouvementCaisse mvtCaisse = new MouvementCaisse();
                        mvtCaisse.MontantSens = MontantRegle * -1;
                        mvtCaisse.Sens = Sens.Depense;
                        mvtCaisse.Agriculteur = A.Founisseur;
                        mvtCaisse.CodeTiers = A.Founisseur.Numero;
                        mvtCaisse.Date = A.Date;
                        mvtCaisse.Source = "Agriculteur: " + A.Founisseur.FullName;
                        mvtCaisse.Commentaire = "Avance Agriculteur_" + (A.Id).ToString("D8");

                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantRegle);

                        }

                        int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                        mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                        mvtCaisse.Achat = A;
                        mvtCaisse.Montant = CaisseDb.MontantTotal;
                        db.MouvementsCaisse.Add(mvtCaisse);
                        db.SaveChanges();

                    }


                    if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
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
                }

                #endregion



            }
            // Base
            if (comboBoxTypeAchat.Text.Equals("Base"))
            {
                if (string.IsNullOrEmpty(TxtPrixLitre.Text))
                {
                    TxtPrixLitre.ErrorText = "Prix kg (Huile) est obligatoire";
                    return;

                }

                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);

                if (PrixLitre > 40)
                {
                    XtraMessageBox.Show("Veuillez Vérifier le Prix Kg (Huile) ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPrixLitre.ErrorText = "Vérifier le Prix Kg(Huile)";
                    return;
                }


                if (MontantRegle < 0)
                {
                    TxtMontantRegle.ErrorText = "Montant d'Avance est Invalid";

                    XtraMessageBox.Show("Montant d'Avance est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TxtMontantRegle.Text = string.Empty;

                    return;

                }

                decimal MontantRegleFinal = 0m;

                List<Personne_Passager> ListePassagers = new List<Personne_Passager>();

                if (MontantRegle >= 3000)
                {
                    int row = 0;

                    while (gridView4.IsValidRowHandle(row))
                    {
                        var data = gridView4.GetRow(row) as Personne_Passager;
                        ListePassagers.Add(data);
                        row++;
                    }
                    if (ListePassagers.Count > 0)
                    {

                        decimal totalGrid = ListePassagers.Sum(x => x.MontantReglement);

                        if (totalGrid != MontantRegle)
                        {
                            XtraMessageBox.Show("Merci de vérifier les montants ajoutés avec les personnes!", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;

                        }


                    }
                }
                A.StatutProd = StatutProduction.EnAttente;

                if (comboBoxTypeOlive.Text.Equals("OliveVif"))
                {
                    A.TypeOlive = ArticleAchat.OliveVif;
                }
                else if (comboBoxTypeOlive.Text.Equals("Nchira"))
                {
                    A.TypeOlive = ArticleAchat.Nchira;
                }

                if (string.IsNullOrEmpty(TxtNbSac.Text))
                {
                    A.NbSacs = 0;

                }

                else { A.NbSacs = Convert.ToInt32(TxtNbSac.Text); }

                A.TypeAchat = TypeAchat.Base;


                A.PrixLitre = PrixLitre;

                A.NuméroBon = null;
                A.EtatAchat = EtatAchat.NonReglee;
                A.MontantRegle = 0m;

                A.AvanceAvecAchat = MontantRegle;

                A.AvecAmpo = false;
                if (checkImpo.Checked)
                {
                    A.AvecAmpo = true;
                    A.MtAdeduire = decimal.Divide(A.MontantReglement, 100);
                    A.MtAPayeAvecImpo = decimal.Subtract(A.MontantReglement, A.MtAdeduire);
                }
                else
                {
                    A.MtAPayeAvecImpo = A.MontantReglement;

                }
                db.Achats.Add(A);
                db.SaveChanges();

                A.Numero = "ACH" + (A.Id).ToString("D8");
                db.SaveChanges();

                //sirine
                if (A.TypeAchat == TypeAchat.Base && MontantRegle > 0)
                {
                    Achat AvnaceSurAchat = new Achat();

                    AvnaceSurAchat.TypeAchat = TypeAchat.Avance;
                    AvnaceSurAchat.Avance = false;

                    AvnaceSurAchat.PrixLitre = 0;
                    if (comboBoxTypeOlive.Text.Equals("OliveVif"))
                    {
                        AvnaceSurAchat.TypeOlive = ArticleAchat.OliveVif;
                    }
                    else if (comboBoxTypeOlive.Text.Equals("Nchira"))
                    {
                        AvnaceSurAchat.TypeOlive = ArticleAchat.Nchira;
                    }

                    AvnaceSurAchat.MontantRegle = MontantRegle;
                    AvnaceSurAchat.MontantReglement = 0;
                    AvnaceSurAchat.NbSacs = 0;

                    AvnaceSurAchat.Founisseur = F;
                    AvnaceSurAchat.AvanceAvecAchat = MontantRegle;
                    db.Achats.Add(AvnaceSurAchat);
                    db.SaveChanges();
                    AvnaceSurAchat.Numero = "AVN" + (A.Id).ToString("D8");
                    db.SaveChanges();
                    decimal Deduit = decimal.Multiply(MontantRegle, 0.01m);

                    MontantRegleFinal = decimal.Subtract(MontantRegle, Deduit);

                    if (MontantRegle >= 3000)
                    {
                        F.Solde = decimal.Add(F.Solde, MontantRegleFinal);
                    }
                    else
                    {
                        F.Solde = Decimal.Add(F.Solde, MontantRegle);
                    }
                    db.SaveChanges();

                    // new work
                    if (MontantRegle >= 3000)
                    {
                        
                        AvnaceSurAchat.MontantInitialAvance = MontantRegle;
                        AvnaceSurAchat.MontantRegle = MontantRegleFinal;
                        AvnaceSurAchat.AvanceAvecAchat = MontantRegleFinal;
                        F.Solde = decimal.Add(F.Solde, MontantRegleFinal);
                        db.SaveChanges();
                        MontantRegle = MontantRegleFinal;

                        if (ListePassagers.Count == 0)
                        {
                            AvnaceSurAchat.PersonnesPassagers = null;

                        }
                        else
                        {
                            foreach (var item in ListePassagers)
                            {
                                A.PersonnesPassagers.Add(
                                  new Personne_Passager { FullName = item.FullName, cin = item.cin, MontantReglement = item.MontantReglement, Numero = AvnaceSurAchat.Numero });
                            }

                        }
                    }

                    #region Ajouter Littrage Avance Sur Achats Type base

                    Agriculteur Agriculteur = db.Agriculteurs.Find(F.Id);
                    decimal Solde = F.Solde;
                    List<Achat> ListeAchats = db.Achats.Where(x => (x.TypeAchat == TypeAchat.Base || x.TypeAchat == TypeAchat.Huile || x.TypeAchat == TypeAchat.Olive) && x.Founisseur.Id == F.Id && x.MontantReglement > 0 && (x.EtatAchat == EtatAchat.NonReglee || x.EtatAchat == EtatAchat.PartiellementReglee)).OrderBy(x => x.Date).ToList();
                    if (ListeAchats.Count > 0 && Solde > 0)
                    {
                        foreach (var L in ListeAchats)
                        {
                            decimal MontantEncaisse = 0m;
                            if (Solde >= L.ResteApayer && Solde > 0)
                            {
                                // Totalement Reglèès
                                MontantEncaisse = L.ResteApayer;

                                Achat AchatDb = db.Achats.Find(L.Id);
                                AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                                AchatDb.EtatAchat = EtatAchat.Reglee;
                                db.SaveChanges();
                                #region Ajouter historique paiement achat
                                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                                HP.Founisseur = AchatDb.Founisseur;
                                HP.NumAchat = AchatDb.Numero;
                                HP.MontantReglement = AchatDb.MontantReglement;
                                HP.MontantRegle = MontantEncaisse;
                                HP.TypeAchat = AchatDb.TypeAchat;
                                HP.ResteApayer = AchatDb.ResteApayer;
                                HP.Commentaire = "Règlement Automatique Par Avance ";
                                db.HistoriquePaiementAchats.Add(HP);
                                db.SaveChanges();

                                #endregion

                            }
                            else if (Solde < L.ResteApayer && Solde > 0)
                            {
                                // parceilellement reglè 
                                MontantEncaisse = Solde;
                                Achat AchatDb = db.Achats.Find(L.Id);
                                AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                                AchatDb.EtatAchat = EtatAchat.PartiellementReglee;

                                db.SaveChanges();

                                #region Ajouter historique paiement achat
                                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                                HP.Founisseur = AchatDb.Founisseur;
                                HP.NumAchat = AchatDb.Numero;
                                HP.MontantReglement = AchatDb.MontantReglement;
                                HP.MontantRegle = MontantEncaisse;
                                HP.ResteApayer = AchatDb.ResteApayer;
                                HP.TypeAchat = AchatDb.TypeAchat;
                                HP.Commentaire = "Règlement Automatique Par Avance";
                                db.HistoriquePaiementAchats.Add(HP);
                                db.SaveChanges();

                                #endregion
                                //Solde = decimal.Subtract(Solde, MontantEncaisse);
                                //break; // get out of the loop
                            }
                            Solde = decimal.Subtract(Solde, MontantEncaisse);

                        }

                        Agriculteur.Solde = Solde;
                        db.SaveChanges();
                    }



                    #endregion

                    List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
                    if (db.Agriculteurs.Count() > 0)
                    {

                        ListAgriculteurs = db.Agriculteurs.ToList();
                        foreach (var l in ListAgriculteurs)
                        {
                            List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                            l.TotalAchats = ListeAchats1.Sum(x => x.MontantReglement);
                            List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                            decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                            l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                            decimal TotalDeduit = ListeAchats1.Sum(x => x.MtAdeduire);
                            decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                            l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;

                        }

                    }
                    if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Nom, x.Numero, x.cin, x.Prenom, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmAchats>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                    }

                    fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();


                    if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                    }

                    #region ajouter Depense type achat base

                    Depense D = new Depense();
                    D.DateCreation = A.Date;
                    D.Nature = NatureMouvement.AchatOlive;
                    D.Agriculteur = A.Founisseur;
                    D.CodeTiers = A.Founisseur.Numero;
                    D.Tiers = A.Founisseur.FullName;
                    if (A.ModeReglement == ModeReglement.Espèce)
                    {
                        D.ModePaiement = "Espèce";
                    }
                    else if (A.ModeReglement == ModeReglement.Chèque)
                    {
                        D.ModePaiement = "Chèque";
                        D.NumCheque = A.NumeroCheque;
                        D.Bank = A.Banque;
                        D.DateEcheance = A.DateEcheance;
                    }
                    else if (A.ModeReglement == ModeReglement.Traite)
                    {
                        D.ModePaiement = "Traite";
                        D.NumCheque = A.NumeroCheque;
                        D.Bank = A.Banque;
                        D.DateEcheance = A.DateEcheance;
                    }
                    D.Montant = MontantRegle;
                    D.Commentaire = "Avance Agriculteur_" + (A.Id).ToString("D8");
                    db.Depenses.Add(D);
                    db.SaveChanges();

                    D.Numero = "D" + (D.Id).ToString("D8");
                    db.SaveChanges();
                    if (A.ModeReglement == ModeReglement.Espèce)
                    {
                        MouvementCaisse mvtCaisse = new MouvementCaisse();
                        mvtCaisse.MontantSens = MontantRegle * -1;
                        mvtCaisse.Sens = Sens.Depense;
                        mvtCaisse.Agriculteur = A.Founisseur;
                        mvtCaisse.CodeTiers = A.Founisseur.Numero;
                        mvtCaisse.Date = A.Date;
                        mvtCaisse.Source = "Agriculteur: " + A.Founisseur.FullName;
                        mvtCaisse.Commentaire = "Avance Agriculteur_" + (A.Id).ToString("D8");

                        //if (A.ResteApayer < 0)
                        //{ mvtCaisse.Commentaire = "Avance sur Achat N° " + A.Numero; }

                        //else if (A.ResteApayer == 0)
                        //{ mvtCaisse.Commentaire = "Avance sur Achat N° " + A.Numero; }

                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantRegle);

                        }

                        int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                        mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                        mvtCaisse.Montant = CaisseDb.MontantTotal;
                        mvtCaisse.Achat = A;
                        db.MouvementsCaisse.Add(mvtCaisse);
                        db.SaveChanges();
                    }
                    if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
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


                    #endregion



                }
            }

            // huile

            else if (comboBoxTypeAchat.Text.Equals("Huile"))
            {
                Achat AchatExiste = db.Achats.FirstOrDefault(a => a.NuméroBon.Equals(TxtNuméroBon.Text) && (a.TypeAchat == TypeAchat.Huile || a.TypeAchat == TypeAchat.Base));

                if (AchatExiste != null)
                {

                    XtraMessageBox.Show("Numéro de Bon existe déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtNuméroBon.Text = string.Empty;
                    return;


                }

                if (MontantRegle < 0)
                {
                    TxtMontantRegle.ErrorText = "Montant d'Avance est Invalid";

                    XtraMessageBox.Show("Montant d'Avance est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TxtMontantRegle.Text = string.Empty;
                    TxtResteApayer.Text = string.Empty;

                    return;

                }
                decimal MontantRegleFinal = 0m;

                List<Personne_Passager> ListePassagers = new List<Personne_Passager>();

                if (MontantRegle >= 3000)
                {
                    int row = 0;

                    while (gridView4.IsValidRowHandle(row))
                    {
                        var data = gridView4.GetRow(row) as Personne_Passager;
                        ListePassagers.Add(data);
                        row++;
                    }
                    if (ListePassagers.Count > 0)
                    {

                        decimal totalGrid = ListePassagers.Sum(x => x.MontantReglement);

                        if (totalGrid != MontantRegle)
                        {
                            XtraMessageBox.Show("Merci de vérifier les montants ajoutés avec les personnes!", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;

                        }


                    }
                }
                A.StatutProd = StatutProduction.Stocké;
                A.NuméroBon = TxtNuméroBon.Text;

                GridView view1 = searchLookUpPile.Properties.View;

                Pile P = searchLookUpPile.Properties.GetRowByKeyValue(searchLookUpPile.EditValue) as Pile;    // GetIndexByKeyValue(searchLookUpPile.EditValue);

                //   db = new Model.ApplicationContext();

                Pile PileDb = db.Piles.Find(P.Id);

                A.Pile = PileDb;

                int QteHuile = Convert.ToInt32(TxtQteHuileAchetee.Text);

                if (PileDb.Capacite + QteHuile > PileDb.CapaciteMax)
                {
                    XtraMessageBox.Show("Pile est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    view1.FocusInvalidRow();
                    searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                    return;

                }

                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);


                if (string.IsNullOrEmpty(TxtNbSac.Text))
                {
                    A.NbSacs = 0;

                }


                A.TypeAchat = TypeAchat.Huile;

                A.PrixLitre = PrixLitre;

                A.TypeOlive = null;

                A.QteHuileAchetee = QteHuile;

                A.QteHuile = A.QteHuileAchetee;

                if (comboBoxQualité.Text.Equals("Extra"))
                {
                    A.Qualite = ArticleVente.Extra;
                }
                else if (comboBoxQualité.Text.Equals("Lampante"))
                {
                    A.Qualite = ArticleVente.Lampante;
                }
                else if (comboBoxQualité.Text.Equals("Vierge"))
                {
                    A.Qualite = ArticleVente.Vierge;
                }
                else if (comboBoxQualité.Text.Equals("ExtraVierge"))
                {
                    A.Qualite = ArticleVente.ExtraVierge;
                }


                A.EtatAchat = EtatAchat.NonReglee;
                A.MontantRegle = 0m;

                A.AvanceAvecAchat = MontantRegle;

                A.AvecAmpo = false;
                if (checkImpo.Checked)
                {
                    A.AvecAmpo = true;
                    A.MtAdeduire = decimal.Divide(A.MontantReglement, 100);
                    A.MtAPayeAvecImpo = decimal.Subtract(A.MontantReglement, A.MtAdeduire);
                }
                else
                {
                    A.MtAPayeAvecImpo = A.MontantReglement;
                }

                db.Achats.Add(A);

                db.SaveChanges();

                A.Numero = "HLE" + (A.Id).ToString("D8");

                db.SaveChanges();

                PileDb.Capacite = PileDb.Capacite + A.QteHuileAchetee;
                db.SaveChanges();

                #region Ajouter MVT Stock

                MouvementStock MvtStock = new MouvementStock();
                int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;

                MvtStock.Numero = "ENA" + (lastMvtStock).ToString("D8");
                MvtStock.Date = A.Date;
                MvtStock.pile = A.Pile;
                MvtStock.Sens = SensStock.Entree;
                MvtStock.Code = A.Numero;
                MvtStock.Intitulé = A.Founisseur.FullName;
                MvtStock.Qualite = A.Pile.article;
                MvtStock.QuantiteVendue = 0;
                MvtStock.QuantiteProduite = 0;
                MvtStock.QuantiteAchetee = A.QteHuileAchetee;
                MvtStock.QuantiteSOD = 0;
                MvtStock.QteEntrante = A.QteHuileAchetee;
                MvtStock.Achat = A;
                MvtStock.PrixMouvement = A.PrixLitre;
                MvtStock.Commentaire = "Achat Huile N°" + " " + A.Numero;

                //MvtStock.Date = DateTime.Now;

                MvtStock.QuantitePileInitial = A.Pile.Capacite - A.QteHuileAchetee;
                MvtStock.QuantitePileFinal = A.Pile.Capacite;
                db.MouvementsStock.Add(MvtStock);
                db.SaveChanges();


                #endregion

                //// Prix Moyen
                int QuantitePileInitial = PileDb.Capacite - A.QteHuileAchetee;

                int QuantitePileFinal = PileDb.Capacite;

                PileDb.PrixMoyen = Math.Truncate((((A.QteHuileAchetee * A.PrixLitre) + (QuantitePileInitial * PileDb.PrixMoyen)) / QuantitePileFinal) * 100000m) / 100000m;

                db.SaveChanges();

                MvtStock.PMP = PileDb.PrixMoyen;
                db.SaveChanges();

                if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();
                }

                if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();
                }

                if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList();

                }

                if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).ToList();
                }

                if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmTransfertPile>().First().PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();
                }

                if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmTransfertPile>().First().PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.article != ArticleVente.Fatoura && x.Capacite < x.CapaciteMax).ToList();
                }

                if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite).ToList();
                }

                if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();
                }

                if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                }



                //sirine
                if (MontantRegle > 0)
                {
                    Achat AvnaceSurAchat = new Achat();
                    AvnaceSurAchat.TypeAchat = TypeAchat.Avance;
                    AvnaceSurAchat.Avance = false;
                    AvnaceSurAchat.PrixLitre = 0;
                    AvnaceSurAchat.MontantRegle = MontantRegle;
                    AvnaceSurAchat.MontantReglement = 0;
                    AvnaceSurAchat.NbSacs = 0;
                    AvnaceSurAchat.Founisseur = F;
                    AvnaceSurAchat.AvanceAvecAchat = MontantRegle;
                    db.Achats.Add(AvnaceSurAchat);
                    db.SaveChanges();
                    AvnaceSurAchat.Numero = "AVN" + (A.Id).ToString("D8");
                    db.SaveChanges();
                    decimal Deduit = decimal.Multiply(MontantRegle, 0.01m);

                    MontantRegleFinal = decimal.Subtract(MontantRegle, Deduit);

                    if (MontantRegle >= 3000)
                    {
                        F.Solde = decimal.Add(F.Solde, MontantRegleFinal);
                    }
                    else
                    {
                        F.Solde = Decimal.Add(F.Solde, MontantRegle);
                    }
                    db.SaveChanges();


                    // new work
                    if (MontantRegle >= 3000)
                    {
                        
                        AvnaceSurAchat.MontantInitialAvance = MontantRegle;
                        AvnaceSurAchat.MontantRegle = MontantRegleFinal;
                        AvnaceSurAchat.AvanceAvecAchat = MontantRegleFinal;
                        F.Solde = decimal.Add(F.Solde, MontantRegleFinal);
                        db.SaveChanges();
                        MontantRegle = MontantRegleFinal;

                        if (ListePassagers.Count == 0)
                        {
                            AvnaceSurAchat.PersonnesPassagers = null;

                        }
                        else
                        {
                            foreach (var item in ListePassagers)
                            {
                                A.PersonnesPassagers.Add(
                                  new Personne_Passager { FullName = item.FullName, cin = item.cin, MontantReglement = item.MontantReglement, Numero = AvnaceSurAchat.Numero });
                            }

                        }
                    }

                }

                #region Ajouter Littrage Avance Sur Achats Type base

                Agriculteur Agriculteur = db.Agriculteurs.Find(F.Id);
                decimal Solde = F.Solde;
                List<Achat> ListeAchats = db.Achats.Where(x => (x.TypeAchat == TypeAchat.Base || x.TypeAchat == TypeAchat.Huile || x.TypeAchat == TypeAchat.Olive) && x.Founisseur.Id == F.Id && x.MontantReglement > 0 && (x.EtatAchat == EtatAchat.NonReglee || x.EtatAchat == EtatAchat.PartiellementReglee)).OrderBy(x => x.Date).ToList();
                if (ListeAchats.Count > 0 && Solde > 0)
                {
                    foreach (var L in ListeAchats)
                    {
                        decimal MontantEncaisse = 0m;
                        if (Solde >= L.ResteApayer && Solde > 0)
                        {
                            // Totalement Reglèès
                            MontantEncaisse = L.ResteApayer;

                            Achat AchatDb = db.Achats.Find(L.Id);
                            AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                            AchatDb.EtatAchat = EtatAchat.Reglee;
                            db.SaveChanges();
                            #region Ajouter historique paiement achat
                            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                            HP.Founisseur = AchatDb.Founisseur;
                            HP.NumAchat = AchatDb.Numero;
                            HP.MontantReglement = AchatDb.MontantReglement;
                            HP.MontantRegle = MontantEncaisse;
                            HP.ResteApayer = AchatDb.ResteApayer;
                            HP.TypeAchat = AchatDb.TypeAchat;
                            HP.Commentaire = "Règlement Automatique Par Avance ";
                            db.HistoriquePaiementAchats.Add(HP);
                            db.SaveChanges();

                            #endregion

                        }
                        else if (Solde < L.ResteApayer && Solde > 0)
                        {
                            // parceilellement reglè 
                            MontantEncaisse = Solde;
                            Achat AchatDb = db.Achats.Find(L.Id);
                            AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                            AchatDb.EtatAchat = EtatAchat.PartiellementReglee;

                            db.SaveChanges();

                            #region Ajouter historique paiement achat
                            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                            HP.Founisseur = AchatDb.Founisseur;
                            HP.NumAchat = AchatDb.Numero;
                            HP.MontantReglement = AchatDb.MontantReglement;
                            HP.MontantRegle = MontantEncaisse;
                            HP.ResteApayer = AchatDb.ResteApayer;
                            HP.TypeAchat = AchatDb.TypeAchat;
                            HP.Commentaire = "Règlement Automatique Par Avance";
                            db.HistoriquePaiementAchats.Add(HP);
                            db.SaveChanges();

                            #endregion
                            //Solde = decimal.Subtract(Solde, MontantEncaisse);
                            //break; // get out of the loop
                        }
                        Solde = decimal.Subtract(Solde, MontantEncaisse);

                    }

                    Agriculteur.Solde = Solde;
                    db.SaveChanges();
                }



                #endregion

                List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
                if (db.Agriculteurs.Count() > 0)
                {

                    ListAgriculteurs = db.Agriculteurs.ToList();
                    foreach (var l in ListAgriculteurs)
                    {
                        List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                        l.TotalAchats = ListeAchats1.Sum(x => x.MontantReglement);
                        List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                        decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                        l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);

                        decimal TotalDeduit = ListeAchats1.Sum(x => x.MtAdeduire);
                        decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                        l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                    }

                }
                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Nom, x.Numero, x.Prenom, x.Tel, x.cin, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
                }

                if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                }

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                }

                fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();


                if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }



                #region Depense type achat huile et mvt de caisse
                if (MontantRegle > 0)
                {
                    Depense D = new Depense();
                    D.Nature = NatureMouvement.AchatHuile;
                    D.Agriculteur = A.Founisseur;
                    D.CodeTiers = A.Founisseur.Numero;
                    D.DateCreation = A.Date;
                    if (A.ModeReglement == ModeReglement.Espèce)
                    {
                        D.ModePaiement = "Espèce";
                    }
                    else if (A.ModeReglement == ModeReglement.Chèque)
                    {
                        D.ModePaiement = "Chèque";
                        D.Bank = A.Banque;
                        D.DateEcheance = A.DateEcheance;
                        D.NumCheque = A.NumeroCheque;
                    }
                    else if (A.ModeReglement == ModeReglement.Traite)
                    {
                        D.ModePaiement = "Traite";
                        D.Bank = A.Banque;
                        D.DateEcheance = A.DateEcheance;
                        D.NumCheque = A.NumeroCheque;
                    }
                    D.Montant = MontantRegle;
                    D.Tiers = A.Founisseur.FullName;
                    //if (MontantRegle == MontantReglement)
                    //{
                    //    D.Commentaire = "Règlement Achat Huile N° " + A.Numero;
                    //}
                    //else if (MontantRegle < MontantReglement)
                    //{
                    //    D.Commentaire = "Avance Agriculteur Sur Achat Huile N° " + A.Numero;
                    //}
                    D.Commentaire = "Avance Agriculteur_" + (A.Id).ToString("D8");
                    db.Depenses.Add(D);
                    db.SaveChanges();
                    D.Numero = "D" + (D.Id).ToString("D8");
                    db.SaveChanges();

                    // mouvt caisse
                    if (A.ModeReglement == ModeReglement.Espèce)
                    {
                        MouvementCaisse mvtCaisse = new MouvementCaisse();
                        mvtCaisse.MontantSens = MontantRegle * -1;
                        mvtCaisse.Sens = Sens.Depense;
                        mvtCaisse.Agriculteur = A.Founisseur;
                        mvtCaisse.CodeTiers = A.Founisseur.Numero;
                        mvtCaisse.Date = A.Date;
                        mvtCaisse.Source = "Agriculteur: " + A.Founisseur.FullName;
                        mvtCaisse.Commentaire = "Avance Agriculteur_" + (A.Id).ToString("D8");

                        //if (MontantRegle == MontantReglement)
                        //{
                        //    mvtCaisse.Commentaire ="Règlement Achat Huile N° " + A.Numero;
                        //}
                        //else if (MontantRegle < MontantReglement)
                        //{
                        //    mvtCaisse.Commentaire = "Avance Agriculteur Sur Achat Huile N° " + A.Numero;
                        //}

                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantRegle);

                        }

                        int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                        mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                        mvtCaisse.Achat = A;
                        mvtCaisse.Montant = CaisseDb.MontantTotal;
                        db.MouvementsCaisse.Add(mvtCaisse);
                        db.SaveChanges();

                    }
                    if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
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
                }

                #endregion



            }

            // service
            else if (comboBoxTypeAchat.Text.Equals("Service"))
            {

                if (string.IsNullOrEmpty(TxtMontantReglement.Text))
                {
                    TxtMontantReglement.ErrorText = "Montant Opération est obligatoire";
                    return;

                }

                if (MontantReglement <= 0)
                {
                    TxtMontantReglement.ErrorText = "Montant Opération est Invalide";

                    XtraMessageBox.Show("Montant Opération est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TxtMontantReglement.Text = string.Empty;
                    TxtResteApayer.Text = string.Empty;

                    return;

                }

                if (MontantRegle < 0 || MontantRegle > MontantReglement)
                {

                    XtraMessageBox.Show("Montant Règlement est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMontantRegle.Text = string.Empty;
                    TxtResteApayer.Text = string.Empty;
                    return;

                }
                A.StatutProd = StatutProduction.EnAttente;

                A.NuméroBon = null;


                if (comboBoxTypeOlive.Text.Equals("OliveVif"))
                {
                    A.TypeOlive = ArticleAchat.OliveVif;
                }
                else if (comboBoxTypeOlive.Text.Equals("Nchira"))
                {
                    A.TypeOlive = ArticleAchat.Nchira;
                }

                if (string.IsNullOrEmpty(TxtNbSac.Text))
                {
                    A.NbSacs = 0;

                }

                else { A.NbSacs = Convert.ToInt32(TxtNbSac.Text); }
                A.MtAPayeAvecImpo = MontantReglement;

                A.TypeAchat = TypeAchat.Service;

                A.PrixLitre = 0;


                if (MontantRegle == MontantReglement && MontantReglement != 0)
                {
                    A.EtatAchat = EtatAchat.Reglee;
                }
                else if (MontantRegle == 0 && MontantReglement == A.ResteApayer)
                {
                    A.EtatAchat = EtatAchat.NonReglee;
                }
                else if (A.ResteApayer < MontantReglement && MontantReglement != 0 && A.ResteApayer != 0)
                {
                    A.EtatAchat = EtatAchat.PartiellementReglee;
                }

                else if (MontantRegle == 0 && MontantReglement == 0)
                {
                    A.EtatAchat = EtatAchat.NonReglee;
                }

                else if (A.ResteApayer < 0)
                {
                    A.EtatAchat = EtatAchat.PartiellementReglee;
                }

                db.Achats.Add(A);
                db.SaveChanges();

                A.Numero = "SER" + (A.Id).ToString("D8");
                db.SaveChanges();
                #region Ajouter Alimentation et mouvement caisse

                if (MontantRegle > 0)
                {
                    Alimentation Alimentation = new Alimentation();
                    Alimentation.Agriculteur = A.Founisseur;
                    Alimentation.Montant = MontantRegle;
                    Alimentation.Source = SourceAlimentation.Service;

                    //if (A.ResteApayer > 0)
                    //{ Alimentation.Commentaire = "Avance sur Service N° " + A.Numero; }

                    //else if (A.ResteApayer == 0)
                    //{ Alimentation.Commentaire = "Encaissement Service N° " + A.Numero; }

                    Alimentation.Commentaire = "Encaissement Service N° " + A.Numero;

                    db.Alimentations.Add(Alimentation);
                    db.SaveChanges();
                    Alimentation.Numero = "E" + (Alimentation.Id).ToString("D8");
                    db.SaveChanges();

                    #region Ajouter historique paiement achat
                    HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                    HP.Founisseur = A.Founisseur;
                    HP.NumAchat = A.Numero;
                    HP.MontantReglement = A.MontantReglement;
                    HP.MontantRegle = MontantRegle;
                    HP.ResteApayer = A.ResteApayer;
                    HP.TypeAchat = A.TypeAchat;
                    HP.Commentaire = "Règlement Caisse";
                    db.HistoriquePaiementAchats.Add(HP);
                    db.SaveChanges();
                    #endregion


                    int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                    MouvementCaisse mvtCaisse = new MouvementCaisse();
                    mvtCaisse.MontantSens = MontantRegle;
                    mvtCaisse.Date = A.Date;
                    mvtCaisse.Agriculteur = A.Founisseur;
                    mvtCaisse.CodeTiers = A.Founisseur.Numero;
                    mvtCaisse.Source = "Agriculteur: " + A.Founisseur.FullName;
                    mvtCaisse.CodeTiers = A.Founisseur.Numero;

                    mvtCaisse.Sens = Sens.Alimentation;

                    //if (A.ResteApayer > 0)
                    //{ mvtCaisse.Commentaire = "Avance sur Service N° " + A.Numero; }

                    //else if (A.ResteApayer == 0)
                    //{ mvtCaisse.Commentaire = "Encaissement Service N° " + A.Numero; }
                    mvtCaisse.Commentaire = "Encaissement Service N° " + A.Numero;
                    mvtCaisse.Numero = "E" + (lastMouvement).ToString("D8");


                    if (CaisseDb != null)
                    {
                        CaisseDb.MontantTotal = decimal.Add(CaisseDb.MontantTotal, MontantRegle);

                    }

                    mvtCaisse.Achat = A;
                    mvtCaisse.Montant = CaisseDb.MontantTotal;
                    db.MouvementsCaisse.Add(mvtCaisse);
                    db.SaveChanges();


                    if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();
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
                }

                #endregion

            }

            // avance
            else if (comboBoxTypeAchat.Text.Equals("Avance"))
            {
                if (string.IsNullOrEmpty(TxtMontantRegle.Text))
                {
                    TxtMontantRegle.ErrorText = "Avance est obligatoire";
                    return;

                }
                if (MontantRegle <= 0)
                {
                    TxtMontantRegle.ErrorText = "Montant d'Avance est Invalid";
                    XtraMessageBox.Show("Montant d'Avance est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                // new work
                decimal MontantRegleFinal = 0m;
                List<Personne_Passager> ListePassagers = new List<Personne_Passager>();

                if (MontantRegle >= 3000)
                {
                    decimal Deduit = decimal.Multiply(MontantRegle, 0.01m);

                    MontantRegleFinal = decimal.Subtract(MontantRegle, Deduit);

                    A.MontantInitialAvance = MontantRegle;


                    int row = 0;

                    while (gridView4.IsValidRowHandle(row))
                    {
                        var data = gridView4.GetRow(row) as Personne_Passager;
                        ListePassagers.Add(data);
                        row++;
                    }
                    if (ListePassagers.Count == 0)
                    {
                        A.PersonnesPassagers = null;
                        MontantRegle = MontantRegleFinal;
                    }
                    else
                    {
                        decimal totalGrid = ListePassagers.Sum(x => x.MontantReglement);

                        if (totalGrid == MontantRegle)
                        {
                            MontantRegle = MontantRegleFinal;

                            foreach (var item in ListePassagers)
                            {
                                A.PersonnesPassagers.Add(
                                  new Personne_Passager { FullName = item.FullName, cin = item.cin, MontantReglement = item.MontantReglement });
                            }


                        }
                        else
                        {
                            XtraMessageBox.Show("Merci de vérifier les montants ajoutés avec les personnes!", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }

                A.TypeAchat = TypeAchat.Avance;
                A.Avance = true;
                A.NuméroBon = null;
                A.Annulle = "Non";
                A.PrixLitre = 0;

                A.MontantReglement = 0;
                A.NbSacs = 0;
                A.AvanceAvecAchat = 0;
                A.MontantRegle = MontantRegle;

                F.Solde = decimal.Add(F.Solde, MontantRegle);

                db.Achats.Add(A);
                db.SaveChanges();
                A.Numero = "AVN" + (A.Id).ToString("D8");
                db.SaveChanges();

                if (A.PersonnesPassagers != null)
                {
                    foreach (var item in A.PersonnesPassagers)
                    {
                        item.Numero = A.Numero;
                        db.SaveChanges();
                    }
                }

                #region Ajouter Littrage Avance Sur Achats Type avance

                Agriculteur Agriculteur = db.Agriculteurs.Find(F.Id);
                decimal Solde = F.Solde;

                List<Achat> ListeAchats = db.Achats.Where(x => (x.TypeAchat == TypeAchat.Base || x.TypeAchat == TypeAchat.Huile || x.TypeAchat == TypeAchat.Olive) && x.Founisseur.Id == F.Id && x.MontantReglement > 0 && (x.EtatAchat == EtatAchat.NonReglee || x.EtatAchat == EtatAchat.PartiellementReglee)).OrderBy(x => x.Date).ToList();

                if (ListeAchats.Count > 0 && Solde > 0)
                {
                    foreach (var L in ListeAchats)
                    {
                        decimal MontantEncaisse = 0m;
                        if (Solde >= L.ResteApayer && Solde > 0)
                        {
                            // Totalement Reglèès
                            MontantEncaisse = L.ResteApayer;

                            Achat AchatDb = db.Achats.Find(L.Id);
                            AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                            AchatDb.EtatAchat = EtatAchat.Reglee;
                            db.SaveChanges();
                            #region Ajouter historique paiement achat
                            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                            HP.Founisseur = AchatDb.Founisseur;
                            HP.NumAchat = AchatDb.Numero;
                            HP.MontantReglement = AchatDb.MontantReglement;
                            HP.MontantRegle = MontantEncaisse;
                            HP.ResteApayer = AchatDb.ResteApayer;
                            HP.TypeAchat = AchatDb.TypeAchat;
                            HP.Commentaire = "Règlement Automatique Par Avance";
                            db.HistoriquePaiementAchats.Add(HP);
                            db.SaveChanges();

                            #endregion

                        }
                        else if (Solde < L.ResteApayer && Solde > 0)
                        {
                            // parceilellement reglè 
                            MontantEncaisse = Solde;
                            Achat AchatDb = db.Achats.Find(L.Id);
                            AchatDb.MontantRegle = decimal.Add(AchatDb.MontantRegle, MontantEncaisse);
                            AchatDb.EtatAchat = EtatAchat.PartiellementReglee;

                            db.SaveChanges();

                            #region Ajouter historique paiement achat
                            HistoriquePaiementAchats HP = new HistoriquePaiementAchats();
                            HP.Founisseur = AchatDb.Founisseur;
                            HP.NumAchat = AchatDb.Numero;
                            HP.MontantReglement = AchatDb.MontantReglement;
                            HP.MontantRegle = MontantEncaisse;
                            HP.ResteApayer = AchatDb.ResteApayer;
                            HP.TypeAchat = AchatDb.TypeAchat;
                            HP.Commentaire = "Règlement Automatique Par Avance";
                            db.HistoriquePaiementAchats.Add(HP);
                            db.SaveChanges();

                            #endregion
                            //Solde = decimal.Subtract(Solde, MontantEncaisse);
                            //break; // get out of the loop
                        }
                        Solde = decimal.Subtract(Solde, MontantEncaisse);

                    }

                    Agriculteur.Solde = Solde;
                    db.SaveChanges();
                }



                #endregion

                List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
                if (db.Agriculteurs.Count() > 0)
                {

                    ListAgriculteurs = db.Agriculteurs.ToList();
                    foreach (var l in ListAgriculteurs)
                    {
                        List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                        l.TotalAchats = ListeAchats1.Sum(x => x.MontantReglement);
                        List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                        decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                        l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                        decimal TotalDeduit = ListeAchats1.Sum(x => x.MtAdeduire);
                        decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                        l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                    }

                }

                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Nom, x.Numero, x.Prenom, x.cin, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
                }

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                }

                if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
                }

                fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();

                if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }


                #region Depense et mouvement caisse type achat avance

                Depense D = new Depense();
                D.Nature = NatureMouvement.AvanceAgriculteur;
                D.Agriculteur = A.Founisseur;
                D.CodeTiers = A.Founisseur.Numero;
                D.DateCreation = A.Date;
                if (A.ModeReglement == ModeReglement.Espèce)
                {
                    D.ModePaiement = "Espèce";
                }
                else if (A.ModeReglement == ModeReglement.Chèque)
                {
                    D.ModePaiement = "Chèque";
                    D.Bank = A.Banque;
                    D.DateEcheance = A.DateEcheance;
                    D.NumCheque = A.NumeroCheque;
                }
                else if (A.ModeReglement == ModeReglement.Traite)
                {
                    D.ModePaiement = "Traite";
                    D.Bank = A.Banque;
                    D.DateEcheance = A.DateEcheance;
                    D.NumCheque = A.NumeroCheque;
                }


                D.Montant = MontantRegle;
                D.Tiers = A.Founisseur.FullName;
                D.Commentaire = "Avance Agriculteur";
                db.Depenses.Add(D);
                db.SaveChanges();
                D.Numero = "D" + (D.Id).ToString("D8");
                db.SaveChanges();

                // mouvt caisse
                if (A.ModeReglement == ModeReglement.Espèce)
                {
                    MouvementCaisse mvtCaisse = new MouvementCaisse();
                    mvtCaisse.MontantSens = MontantRegle * -1;
                    mvtCaisse.Sens = Sens.Depense;
                    mvtCaisse.Agriculteur = A.Founisseur;
                    mvtCaisse.CodeTiers = A.Founisseur.Numero;
                    mvtCaisse.Date = A.Date;
                    mvtCaisse.Source = "Agriculteur: " + A.Founisseur.FullName;
                    mvtCaisse.Commentaire = "Avance Agriculteur";

                    if (CaisseDb != null)
                    {
                        CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantRegle);

                    }

                    int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                    mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                    mvtCaisse.Achat = A;
                    mvtCaisse.Montant = CaisseDb.MontantTotal;
                    db.MouvementsCaisse.Add(mvtCaisse);
                    db.SaveChanges();

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

                #endregion
            }



            db.SaveChanges();

            Societe societedb = db.Societe.FirstOrDefault();
            if (A.TypeAchat == TypeAchat.Avance)
            {
                XtraMessageBox.Show("Avance Enregistrée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                }

                if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                }

                if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }

                xrAvance xrAvance = new xrAvance();



                xrAvance.Parameters["RsSte"].Value = societedb.RaisonSocial;

                xrAvance.Parameters["RsSte"].Visible = false;

                List<Achat> ListeAchats = new List<Achat>();

                ListeAchats.Add(A);

                xrAvance.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(xrAvance))
                {
                    printTool.ShowPreviewDialog();

                }

                if (A.PersonnesPassagers != null)
                {
                    foreach (var item in A.PersonnesPassagers)
                    {
                        XrAvancePersonne xrAvancePersonne = new XrAvancePersonne();


                        xrAvancePersonne.Parameters["RsSte"].Value = societedb.RaisonSocial;

                        xrAvancePersonne.Parameters["NumAvn"].Value = A.Numero;

                        List<Personne_Passager> personnes = new List<Personne_Passager>();

                        personnes.Add(item);

                        xrAvancePersonne.DataSource = personnes;
                        using (ReportPrintTool printTool = new ReportPrintTool(xrAvancePersonne))
                        {
                            printTool.ShowPreviewDialog();

                        }

                    }
                }

            }

            else if (A.TypeAchat == TypeAchat.Base)
            {
                XtraMessageBox.Show("Achat Base Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }

                if (Application.OpenForms.OfType<FrmListedesAvances>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListedesAvances>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }

                if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                }

                if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                }




            }


            else if (A.TypeAchat == TypeAchat.Huile)
            {
                XtraMessageBox.Show("Achat Huile Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // pileBindingSource.DataSource = db.Piles.ToList();

                string Qualite = comboBoxQualité.Text;

                pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite)).ToList();

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }



            }
            else if (A.TypeAchat == TypeAchat.Olive)
            {
                XtraMessageBox.Show("Achat Olive Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }

                if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;
                }

                if (Application.OpenForms.OfType<FrmEmplacement>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmEmplacement>().First().emplacementBindingSource.DataSource = db.Emplacements.ToList();
                }

            }
            else if (A.TypeAchat == TypeAchat.Service)
            {
                XtraMessageBox.Show("Service Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }
            }

            #region Remise a zero

            dateEditDateFacture.DateTime = DateTime.Now;
            searchLookUpFournisseur.EditValue = searchLookUpFournisseur.Properties.NullText;
            searchLookUpEmplacement.EditValue = searchLookUpEmplacement.Properties.NullText;
            TxtNbSac.Text = string.Empty;
            TxtPoids.Text = string.Empty;
            TxtPrixLitre.Text = string.Empty;
            TxtMontantReglement.Text = string.Empty;
            TxtMontantRegle.Text = string.Empty;
            TxtResteApayer.Text = string.Empty;
            TxtQteHuileAchetee.Text = string.Empty;
            searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
            TxtNuméroBon.Text = string.Empty;
            TxtMtOpPrev.Text = string.Empty;
            TxtPUOlive.Text = string.Empty;
            TxtPUOliveFinal.Text = string.Empty;
            TxtQteOlive.Text = string.Empty;
            TxtRendement.Text = string.Empty;
            TxtBank.Text = string.Empty;
            TxtNumCheque.Text = string.Empty;
            dateEcheance.Text = "";
            checkImpo.Checked = false;

            List<string> ListeTypeOlive = Enum.GetNames(typeof(ArticleAchat)).ToList();
            comboBoxTypeOlive.SelectedItem = ListeTypeOlive[0];

            //type achat
            comboBoxTypeAchat.SelectedItem = Types[0];

            List<string> ListeArticle = Enum.GetNames(typeof(ArticleVente)).Where(item => item != ArticleVente.Fatoura.ToString()).ToList();
            comboBoxQualité.SelectedItem = ListeArticle[0];
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            comboBoxModeReglement.SelectedIndex = 0;
            comboBoxModeReglement.SelectedItem = ModePaiement[0];
            numcheque.Visibility = LayoutVisibility.Never;
            bank.Visibility = LayoutVisibility.Never;
            layoutControlItem12.Visibility = LayoutVisibility.Never;

            //vider grid personne
            for (int i = 0; i < gridView4.RowCount;)
                gridView4.DeleteRow(i);

            #endregion  Remise a zero



            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
            {
                db = new Model.ApplicationContext();
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

            }


            if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)

            {
                db = new Model.ApplicationContext();
                Application.OpenForms.OfType<FrmProduction>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.StatutProd != StatutProduction.Stocké && x.TypeAchat == TypeAchat.Base || x.StatutProd != StatutProduction.Terminée && x.TypeAchat == TypeAchat.Service).OrderByDescending(x => x.Date).ToList();
                Application.OpenForms.OfType<FrmProduction>().First().gridControl1.RefreshDataSource();


            }
            #region Ajouter cheque dans coffre emis
            if (A.ModeReglement == ModeReglement.Chèque || A.ModeReglement == ModeReglement.Traite)
            {
                Coffrecheque Cheque = new Coffrecheque();
                Depense D = new Depense();
                D.CodeTiers = A.Founisseur.Numero;
                D.Nature = NatureMouvement.AvanceAgriculteur;
                if (A.ModeReglement == ModeReglement.Chèque)
                {
                    Cheque.Type = "Chèque";
                }
                else if (A.ModeReglement == ModeReglement.Traite)
                {
                    Cheque.Type = "Traite";
                }

                Cheque.DateCreation = A.Date;
                Cheque.DateEcheance = A.DateEcheance;
                Cheque.NumCheque = A.NumeroCheque;
                Cheque.Bank = A.Banque;
                if (A.TypeAchat == TypeAchat.Avance)
                {
                    Cheque.Montant = A.MontantRegle;
                    D.Commentaire = "Avance N° " + A.Numero;
                }
                else
                {
                    Cheque.Montant = A.AvanceAvecAchat;
                    D.Commentaire = "Avance avec achat N° " + A.Numero;
                }
                Cheque.Depense = D;

                db.CoffreCheques.Add(Cheque);
                db.SaveChanges();

                if (Application.OpenForms.OfType<FrmCoffreChequeEmis>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmCoffreChequeEmis>().First().coffrechequeBindingSource.DataSource = db.CoffreCheques.ToList();
                }
            }
            #endregion



            List<Achat> ListeAchatTickes = new List<Achat>();

            ListeAchatTickes.Add(A);

            TickeAvanceAvecAchat xrAchatTicket = new TickeAvanceAvecAchat();

            xrAvance xrAvance1 = new xrAvance();

            TicketService ticketService = new TicketService();

            Societe societe = db.Societe.FirstOrDefault();

            string RsSte = societe.RaisonSocial;


            if (A.TypeAchat == TypeAchat.Service)
            {
                ticketService.Parameters["RsSte"].Value = RsSte;
                ticketService.DataSource = ListeAchatTickes;
                using (ReportPrintTool printTool = new ReportPrintTool(ticketService))
                {
                    printTool.ShowPreviewDialog();

                }
            }
            else if (A.TypeAchat == TypeAchat.Base)

            {
                xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                xrAchatTicket.Parameters["QteAchetee"].Value = A.NbSacs;

                xrAchatTicket.Parameters["QteAchetee"].Visible = false;

                if (A.TypeOlive == ArticleAchat.Nchira)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Nchira";
                }
                else if (A.TypeOlive == ArticleAchat.OliveVif)
                {
                    xrAchatTicket.Parameters["Type"].Value = "OliveVif";
                }


                xrAchatTicket.Parameters["PU"].Value = A.PrixLitre;

                xrAchatTicket.DataSource = ListeAchatTickes;
                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();

                }


            }


            else if (A.TypeAchat == TypeAchat.Huile)

            {
                xrAchatTicket.Parameters["RsSte"].Value = RsSte;
                xrAchatTicket.Parameters["QteAchetee"].Value = A.QteHuileAchetee;
                xrAchatTicket.Parameters["PU"].Value = A.PrixLitre;

                if (A.Qualite == ArticleVente.Extra)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Extra";
                }
                else if (A.Qualite == ArticleVente.Lampante)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Lampante";
                }
                else if (A.Qualite == ArticleVente.Vierge)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Vierge";
                }
                else if (A.Qualite == ArticleVente.ExtraVierge)
                {
                    xrAchatTicket.Parameters["Type"].Value = "ExtraVierge";
                }


                xrAchatTicket.Parameters["Type"].Visible = false;

                xrAchatTicket.DataSource = ListeAchatTickes;

                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();

                }


            }
            else if (A.TypeAchat == TypeAchat.Olive)

            {

                xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                xrAchatTicket.Parameters["RsSte"].Visible = false;

                xrAchatTicket.Parameters["QteAchetee"].Value = A.QteOliveAchetee;

                xrAchatTicket.Parameters["QteAchetee"].Visible = false;

                xrAchatTicket.Parameters["PU"].Value = A.PUOliveFinal;

                xrAchatTicket.Parameters["PU"].Visible = false;

                if (A.TypeOlive == ArticleAchat.Nchira)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Nchira";
                }
                else if (A.TypeOlive == ArticleAchat.OliveVif)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Olive Vif";
                }


                xrAchatTicket.Parameters["Type"].Visible = false;

                xrAchatTicket.DataSource = ListeAchatTickes;
                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();

                }


            }

            if (A.TypeAchat != TypeAchat.Avance)
            {
                string num = "AVN" + (A.Id).ToString("D8");
                Achat AvanceSurAchat = db.Achats.FirstOrDefault(x => x.Numero.Equals(num));

                if (AvanceSurAchat != null)
                {
                    if (AvanceSurAchat.PersonnesPassagers != null)
                    {
                        foreach (var item in A.PersonnesPassagers)
                        {
                            XrAvancePersonne xrAvancePersonne = new XrAvancePersonne();


                            xrAvancePersonne.Parameters["RsSte"].Value = societedb.RaisonSocial;

                            xrAvancePersonne.Parameters["NumAvn"].Value = AvanceSurAchat.Numero + "_" + A.Numero;

                            List<Personne_Passager> personnes = new List<Personne_Passager>();

                            personnes.Add(item);

                            xrAvancePersonne.DataSource = personnes;
                            using (ReportPrintTool printTool = new ReportPrintTool(xrAvancePersonne))
                            {
                                printTool.ShowPreviewDialog();

                            }

                        }
                    }

                }

            }



        }


        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
            if (db.Agriculteurs.Count() > 0)
            {

                ListAgriculteurs = db.Agriculteurs.ToList();
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
                fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
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
            frm.Activate();
        }

        private void repositoryItemButtonSupprimer_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }


        private void TxtMontantRegle_EditValueChanged(object sender, EventArgs e)
        {
            // GET Value of MontantReglement
            decimal MontantReglement;
            string MontantReglementStr = TxtMontantReglement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantReglementStr, out MontantReglement);

            // GET Value of MontantRegle
            decimal MontantRegle;
            string MontantRegletStr = TxtMontantRegle.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantRegletStr, out MontantRegle);


            // Edit value ResteApayer
            if (comboBoxTypeAchat.Text.Equals("Service") || comboBoxTypeAchat.Text.Equals("Huile"))
            {
                TxtResteApayer.Text = (MontantReglement - MontantRegle).ToString();
            }

        }


        private void comboBoxTypeAchat_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            comboBoxModeReglement.SelectedIndex = 0;
            comboBoxModeReglement.SelectedItem = ModePaiement[0];
            numcheque.Visibility = LayoutVisibility.Never;
            bank.Visibility = LayoutVisibility.Never;
            layoutControlItem12.Visibility = LayoutVisibility.Never;



            // Base

            if (comboBoxTypeAchat.Text.Equals("Base"))
            {
                checkImpo.Enabled = true;
                layoutControlAvance.Text = "Avance";
                layoutControlItem7.Visibility = LayoutVisibility.Always;
                layoutControlAvance.Visibility = LayoutVisibility.Always;

                TxtMontantReglement.ReadOnly = true;

                layoutControlTypeOlive.Visibility = LayoutVisibility.Always;

                layoutControlPrix.Visibility = LayoutVisibility.Always;

                layoutControlMontantReglement.Visibility = LayoutVisibility.Never;


                layoutControlResteAPayer.Visibility = LayoutVisibility.Never;

                layoutControlNbSac.Visibility = LayoutVisibility.Always;

                layoutControlQteAchete.Visibility = LayoutVisibility.Always;

                layoutControlQualite.Visibility = LayoutVisibility.Never;

                layoutControlQteHuileAchetee.Visibility = LayoutVisibility.Never;

                layoutControlPile.Visibility = LayoutVisibility.Never;

                layoutNuméroBon.Visibility = LayoutVisibility.Never;

                PUOlive.Visibility = LayoutVisibility.Never;

                PUOliveFinal.Visibility = LayoutVisibility.Never;

                QteOlive.Visibility = LayoutVisibility.Never;

                MontantPrev.Visibility = LayoutVisibility.Never;

                Emplacement.Visibility = LayoutVisibility.Never;

                Rendement.Visibility = LayoutVisibility.Never;

                if (!(string.IsNullOrEmpty(TxtMontantRegle.Text)))
                {
                    TxtMontantRegle.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtMontantReglement.Text)))
                {
                    TxtMontantReglement.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtResteApayer.Text)))
                {
                    TxtResteApayer.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNuméroBon.Text)))
                {
                    TxtNuméroBon.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtQteHuileAchetee.Text)))
                {
                    TxtQteHuileAchetee.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPrixLitre.Text)))
                {
                    TxtPrixLitre.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNbSac.Text)))
                {
                    TxtNbSac.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPoids.Text)))
                {
                    TxtPoids.Text = string.Empty;
                }


            }

            // service
            else if (comboBoxTypeAchat.Text.Equals("Service"))
            {
                checkImpo.Enabled = false;
                layoutControlItem7.Visibility = LayoutVisibility.Never;
                numcheque.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Never;
                layoutControlItem12.Visibility = LayoutVisibility.Never;

                TxtMontantReglement.ReadOnly = false;

                layoutControlAvance.Text = "Montant Règlement";

                layoutControlTypeOlive.Visibility = LayoutVisibility.Always;

                layoutControlPrix.Visibility = LayoutVisibility.Never;

                layoutControlMontantReglement.Visibility = LayoutVisibility.Always;

                layoutControlAvance.Visibility = LayoutVisibility.Always;

                layoutControlResteAPayer.Visibility = LayoutVisibility.Always;

                layoutControlNbSac.Visibility = LayoutVisibility.Always;

                layoutControlQteAchete.Visibility = LayoutVisibility.Never;

                layoutControlQualite.Visibility = LayoutVisibility.Never;

                layoutControlQteHuileAchetee.Visibility = LayoutVisibility.Never;

                layoutControlPile.Visibility = LayoutVisibility.Never;

                layoutNuméroBon.Visibility = LayoutVisibility.Never;

                PUOlive.Visibility = LayoutVisibility.Never;

                PUOliveFinal.Visibility = LayoutVisibility.Never;

                QteOlive.Visibility = LayoutVisibility.Never;

                MontantPrev.Visibility = LayoutVisibility.Never;

                Emplacement.Visibility = LayoutVisibility.Never;

                Rendement.Visibility = LayoutVisibility.Never;

                layoutControlTypeOlive.Visibility = LayoutVisibility.Never;

                if (!(string.IsNullOrEmpty(TxtMontantRegle.Text)))
                {
                    TxtMontantRegle.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtMontantReglement.Text)))
                {
                    TxtMontantReglement.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtResteApayer.Text)))
                {
                    TxtResteApayer.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNuméroBon.Text)))
                {
                    TxtNuméroBon.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtQteHuileAchetee.Text)))
                {
                    TxtQteHuileAchetee.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPrixLitre.Text)))
                {
                    TxtPrixLitre.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNbSac.Text)))
                {
                    TxtNbSac.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPoids.Text)))
                {
                    TxtPoids.Text = string.Empty;
                }
            }



            // Avance
            else if (comboBoxTypeAchat.Text.Equals("Avance"))
            {
                checkImpo.Enabled = false;
                layoutControlItem7.Visibility = LayoutVisibility.Always;
                TxtMontantReglement.ReadOnly = true;
                layoutControlAvance.Text = "Avance";
                layoutControlTypeOlive.Visibility = LayoutVisibility.Always;

                layoutControlNbSac.Visibility = LayoutVisibility.Never;

                layoutControlQteAchete.Visibility = LayoutVisibility.Never;

                layoutControlPrix.Visibility = LayoutVisibility.Never;

                layoutControlMontantReglement.Visibility = LayoutVisibility.Never;

                layoutControlAvance.Visibility = LayoutVisibility.Always;

                layoutControlResteAPayer.Visibility = LayoutVisibility.Never;

                layoutControlQualite.Visibility = LayoutVisibility.Never;


                layoutControlQteHuileAchetee.Visibility = LayoutVisibility.Never;

                layoutControlPile.Visibility = LayoutVisibility.Never;

                PUOlive.Visibility = LayoutVisibility.Never;

                PUOliveFinal.Visibility = LayoutVisibility.Never;

                QteOlive.Visibility = LayoutVisibility.Never;

                MontantPrev.Visibility = LayoutVisibility.Never;

                Emplacement.Visibility = LayoutVisibility.Never;

                Rendement.Visibility = LayoutVisibility.Never;

                layoutControlAvance.Size = new Size(278, 30);

                layoutNuméroBon.Visibility = LayoutVisibility.Never;

                layoutControlTypeOlive.Visibility = LayoutVisibility.Never;
                if (!(string.IsNullOrEmpty(TxtMontantRegle.Text)))
                {
                    TxtMontantRegle.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtMontantReglement.Text)))
                {
                    TxtMontantReglement.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtResteApayer.Text)))
                {
                    TxtResteApayer.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtQteHuileAchetee.Text)))
                {
                    TxtQteHuileAchetee.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPrixLitre.Text)))
                {
                    TxtPrixLitre.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNbSac.Text)))
                {
                    TxtNbSac.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPoids.Text)))
                {
                    TxtPoids.Text = string.Empty;
                }

            }

            // huile
            else if (comboBoxTypeAchat.Text.Equals("Huile"))
            {
                checkImpo.Enabled = true;
                layoutControlItem7.Visibility = LayoutVisibility.Always;
                TxtMontantReglement.ReadOnly = true;

                layoutControlAvance.Text = "Avance";
                layoutControlAvance.Visibility = LayoutVisibility.Always;

                layoutNuméroBon.Visibility = LayoutVisibility.Always;

                layoutControlTypeOlive.Visibility = LayoutVisibility.Never;

                layoutControlNbSac.Visibility = LayoutVisibility.Never;


                layoutControlQteAchete.Visibility = LayoutVisibility.Never;

                layoutControlPrix.Visibility = LayoutVisibility.Always;

                layoutControlMontantReglement.Visibility = LayoutVisibility.Always;


                layoutControlResteAPayer.Visibility = LayoutVisibility.Never;

                layoutControlQualite.Visibility = LayoutVisibility.Always;

                layoutControlQteHuileAchetee.Visibility = LayoutVisibility.Always;

                layoutControlPile.Visibility = LayoutVisibility.Always;

                PUOlive.Visibility = LayoutVisibility.Never;

                PUOliveFinal.Visibility = LayoutVisibility.Never;

                QteOlive.Visibility = LayoutVisibility.Never;

                MontantPrev.Visibility = LayoutVisibility.Never;

                Emplacement.Visibility = LayoutVisibility.Never;

                Rendement.Visibility = LayoutVisibility.Never;

                if (!(string.IsNullOrEmpty(TxtMontantRegle.Text)))
                {
                    TxtMontantRegle.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtMontantReglement.Text)))
                {
                    TxtMontantReglement.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtResteApayer.Text)))
                {
                    TxtResteApayer.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtNuméroBon.Text)))
                {
                    TxtNuméroBon.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtQteHuileAchetee.Text)))
                {
                    TxtQteHuileAchetee.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPrixLitre.Text)))
                {
                    TxtPrixLitre.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNbSac.Text)))
                {
                    TxtNbSac.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtPoids.Text)))
                {
                    TxtPoids.Text = string.Empty;
                }
            }

            // Olive
            else if (comboBoxTypeAchat.Text.Equals("Olive"))
            {
                checkImpo.Enabled = true;
                layoutControlAvance.Text = "Avance";
                TxtMontantReglement.ReadOnly = false;
                layoutControlItem7.Visibility = LayoutVisibility.Always;
                layoutNuméroBon.Visibility = LayoutVisibility.Always;

                layoutControlTypeOlive.Visibility = LayoutVisibility.Always;

                layoutControlNbSac.Visibility = LayoutVisibility.Never;


                layoutControlQteAchete.Visibility = LayoutVisibility.Never;

                layoutControlPrix.Visibility = LayoutVisibility.Always;

                layoutControlMontantReglement.Visibility = LayoutVisibility.Always;

                layoutControlAvance.Visibility = LayoutVisibility.Always;

                layoutControlResteAPayer.Visibility = LayoutVisibility.Never;

                layoutControlQualite.Visibility = LayoutVisibility.Never;

                layoutControlQteHuileAchetee.Visibility = LayoutVisibility.Never;

                layoutControlPile.Visibility = LayoutVisibility.Never;

                PUOlive.Visibility = LayoutVisibility.Always;

                PUOliveFinal.Visibility = LayoutVisibility.Always;

                QteOlive.Visibility = LayoutVisibility.Always;

                MontantPrev.Visibility = LayoutVisibility.Always;

                Emplacement.Visibility = LayoutVisibility.Always;

                Rendement.Visibility = LayoutVisibility.Always;



                if (!(string.IsNullOrEmpty(TxtMontantRegle.Text)))
                {
                    TxtMontantRegle.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtMontantReglement.Text)))
                {
                    TxtMontantReglement.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtResteApayer.Text)))
                {
                    TxtResteApayer.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtNuméroBon.Text)))
                {
                    TxtNuméroBon.Text = string.Empty;
                }

                if (!string.IsNullOrEmpty(TxtQteOlive.Text))
                {
                    TxtQteOlive.Text = string.Empty;
                }

                if (!string.IsNullOrEmpty(TxtPUOlive.Text))
                {
                    TxtPUOlive.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtPUOliveFinal.Text)))
                {
                    TxtPUOliveFinal.Text = string.Empty;
                }

                if (!(string.IsNullOrEmpty(TxtMtOpPrev.Text)))
                {
                    TxtMtOpPrev.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtNumCheque.Text)))
                {
                    TxtNumCheque.Text = string.Empty;
                }
                if (!(string.IsNullOrEmpty(TxtBank.Text)))
                {
                    TxtBank.Text = string.Empty;
                }

            }



        }

        private void TxtMontantReglement_EditValueChanged(object sender, EventArgs e)
        { // GET Value of MontantReglement
            decimal MontantReglement;
            string MontantReglementStr = TxtMontantReglement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantReglementStr, out MontantReglement);

            if (comboBoxTypeAchat.Text.Equals("Olive") && !string.IsNullOrEmpty(TxtQteOlive.Text))
            {
                int QteOlive = Convert.ToInt32(TxtQteOlive.Text);

                // TxtPUOliveFinal.Text = Math.Round(decimal.Divide(MontantReglement, QteOlive), 3).ToString();
                TxtPUOliveFinal.Text = (Math.Truncate(decimal.Divide(MontantReglement, QteOlive) * 100000m) / 100000m).ToString();
                OldPUOliveFinal = Math.Truncate(decimal.Divide(MontantReglement, QteOlive) * 100000m) / 100000m;
            }



            // GET Value of MontantRegle
            decimal MontantRegle;
            string MontantRegletStr = TxtMontantRegle.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantRegletStr, out MontantRegle);

            // Edit value ResteApayer
            TxtResteApayer.Text = decimal.Subtract(MontantReglement, MontantRegle).ToString();



        }


        private void repositoryItemButtonImprimer_Click_1(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;
            db = new Model.ApplicationContext();
            Achat AchatDb = db.Achats.Find(A.Id);

            if (AchatDb.TypeAchat == TypeAchat.Base || AchatDb.TypeAchat == TypeAchat.Service)

            {
                List<Achat> ListeAchats = new List<Achat>();

                ListeAchats.Add(AchatDb);

                BonAchat AchatIpression = new BonAchat();

                AchatIpression.Parameters["Qte"].Value = AchatDb.NbSacs;

                AchatIpression.Parameters["Qte"].Visible = false;

                AchatIpression.Parameters["Type"].Value = AchatDb.TypeOlive.ToString();

                AchatIpression.Parameters["Type"].Visible = false;

                AchatIpression.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(AchatIpression))
                {
                    printTool.ShowPreviewDialog();

                }

                BonAchatAvance AchatAvanceImpression = new BonAchatAvance();

                AchatAvanceImpression.Parameters["Qte"].Value = AchatDb.NbSacs;

                AchatAvanceImpression.Parameters["Qte"].Visible = false;

                AchatAvanceImpression.Parameters["Type"].Value = AchatDb.TypeOlive.ToString();

                AchatAvanceImpression.Parameters["Type"].Visible = false;

                AchatAvanceImpression.DataSource = ListeAchats;

                using (ReportPrintTool printTool = new ReportPrintTool(AchatAvanceImpression))
                {
                    printTool.ShowPreviewDialog();

                }

            }
            else if (AchatDb.TypeAchat == TypeAchat.Huile)

            {
                List<Achat> ListeAchats = new List<Achat>();
                ListeAchats.Add(AchatDb);

                BonAchat AchatIpression = new BonAchat();


                AchatIpression.Parameters["Qte"].Value = AchatDb.QteHuileAchetee;

                AchatIpression.Parameters["Qte"].Visible = false;

                AchatIpression.Parameters["Type"].Value = AchatDb.Qualite.ToString();

                AchatIpression.Parameters["Type"].Visible = false;

                AchatIpression.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(AchatIpression))
                {
                    printTool.ShowPreviewDialog();

                }

                BonAchatAvance AchatAvanceImpression = new BonAchatAvance();


                AchatAvanceImpression.Parameters["Qte"].Value = AchatDb.QteHuileAchetee;

                AchatAvanceImpression.Parameters["Qte"].Visible = false;

                AchatAvanceImpression.Parameters["Type"].Value = AchatDb.Qualite.ToString();

                AchatAvanceImpression.Parameters["Type"].Visible = false;
                AchatAvanceImpression.DataSource = ListeAchats;
                ReportPrintTool tool2 = new ReportPrintTool(AchatAvanceImpression);
                tool2.ShowPreviewDialog();
            }

            else if (AchatDb.TypeAchat == TypeAchat.Olive)

            {
                List<Achat> ListeAchats = new List<Achat>();
                ListeAchats.Add(AchatDb);

                BonAchat AchatIpression = new BonAchat();


                AchatIpression.Parameters["Qte"].Value = AchatDb.QteOliveAchetee;

                AchatIpression.Parameters["Qte"].Visible = false;

                AchatIpression.Parameters["Type"].Value = AchatDb.TypeOlive.ToString();

                AchatIpression.Parameters["Type"].Visible = false;

                AchatIpression.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(AchatIpression))
                {
                    printTool.ShowPreviewDialog();

                }
                BonAchatAvance AchatAvanceImpression = new BonAchatAvance();


                AchatAvanceImpression.Parameters["Qte"].Value = AchatDb.QteOliveAchetee;

                AchatAvanceImpression.Parameters["Qte"].Visible = false;

                AchatAvanceImpression.Parameters["Type"].Value = AchatDb.TypeOlive.ToString();

                AchatAvanceImpression.Parameters["Type"].Visible = false;
                AchatAvanceImpression.DataSource = ListeAchats;
                ReportPrintTool tool2 = new ReportPrintTool(AchatAvanceImpression);
                tool2.ShowPreviewDialog();
            }



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

                //         EnAttente = 1,
                // Encours = 2,
                //Terminée = 3,
                //Archivée = 4

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

        private void TxtNbSac_EditValueChanged(object sender, EventArgs e)
        {
            decimal sac;
            string sacStr = TxtNbSac.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(sacStr, out sac);

            TxtPoids.Text = (sac * 70).ToString();
        }

        private void comboBoxQualité_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Qualite = comboBoxQualité.Text;

            pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite)).ToList();
        }

        private void TxtPrixLitre_EditValueChanged(object sender, EventArgs e)
        {

            if (comboBoxTypeAchat.Text.Equals("Huile"))
            {
                int QteHuile;

                if (string.IsNullOrEmpty(TxtQteHuileAchetee.Text))
                {
                    QteHuile = 0;
                }
                else
                {
                    QteHuile = Convert.ToInt32(TxtQteHuileAchetee.Text);
                }


                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);

                TxtMontantReglement.Text = Decimal.Multiply(QteHuile, PrixLitre).ToString("0.000");


            }
            else if (comboBoxTypeAchat.Text.Equals("Olive"))
            {
                decimal PrixLitre;
                string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(PrixLitreStr, out PrixLitre);

                decimal Rendement;
                string RendementStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(RendementStr, out Rendement);

                decimal PUOlive;
                //  PUOlive = Math.Round(decimal.Divide(decimal.Multiply(PrixLitre, Rendement), 100), 3);
                PUOlive = Math.Truncate(decimal.Divide(decimal.Multiply(PrixLitre, Rendement), 100) * 100000m) / 100000m;

                TxtPUOlive.Text = PUOlive.ToString();

                OldPrixKGhuile = PrixLitre;

            }
        }

        private void BtnImprimerTicket_Click(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Find(A.Id);

            List<Achat> ListeAchats = new List<Achat>();

            ListeAchats.Add(AchatDb);

            TickeAvanceAvecAchat xrAchatTicket = new TickeAvanceAvecAchat();

            xrAvance xrAvance2 = new xrAvance();

            TicketService ticketService = new TicketService();

            Societe societe = db.Societe.FirstOrDefault();

            string RsSte = societe.RaisonSocial;


            if (AchatDb.TypeAchat == TypeAchat.Service)
            {
                ticketService.Parameters["RsSte"].Value = RsSte;
                ticketService.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(ticketService))
                {
                    printTool.ShowPreviewDialog();

                }

            }
            else if (AchatDb.TypeAchat == TypeAchat.Base)

            {
                xrAchatTicket.Parameters["RsSte"].Value = RsSte;

                xrAchatTicket.Parameters["QteAchetee"].Value = Convert.ToInt32(AchatDb.NbSacs);

                xrAchatTicket.Parameters["QteAchetee"].Visible = false;

                if (AchatDb.TypeOlive == ArticleAchat.Nchira)
                {
                    xrAchatTicket.Parameters["Type"].Value = "Nchira";
                }
                else if (AchatDb.TypeOlive == ArticleAchat.OliveVif)
                {
                    xrAchatTicket.Parameters["Type"].Value = "OliveVif";
                }


                xrAchatTicket.Parameters["PU"].Value = AchatDb.PrixLitre;

                xrAchatTicket.DataSource = ListeAchats;
                using (ReportPrintTool printTool = new ReportPrintTool(xrAchatTicket))
                {
                    printTool.ShowPreviewDialog();

                }


            }


            else if (AchatDb.TypeAchat == TypeAchat.Huile)

            {
                xrAchatTicket.Parameters["RsSte"].Value = RsSte;
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

                xrAchatTicket.Parameters["QteAchetee"].Value = Convert.ToInt32(AchatDb.QteOliveAchetee);

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



        private void TxtQteHuileAchetee_EditValueChanged(object sender, EventArgs e)
        {
            int QteHuile;
            if (comboBoxTypeAchat.Text.Equals("Huile"))
            {
                if (!string.IsNullOrEmpty(TxtPrixLitre.Text))
                {
                    if (string.IsNullOrEmpty(TxtQteHuileAchetee.Text))
                    {
                        QteHuile = 0;
                    }
                    else
                    {
                        QteHuile = Convert.ToInt32(TxtQteHuileAchetee.Text);
                    }


                    decimal PrixLitre;
                    string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                    decimal.TryParse(PrixLitreStr, out PrixLitre);

                    TxtMontantReglement.Text = Decimal.Multiply(QteHuile, PrixLitre).ToString("0.000");

                }


            }
        }

        private void searchLookUpFournisseur_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
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
                fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();
            }


            /********************** liste Achats ************************/
            achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void TxtQteOlive_EditValueChanged(object sender, EventArgs e)
        {
            int QteOlive;

            decimal PUOlive;
            string PUOliveStr = TxtPUOlive.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PUOliveStr, out PUOlive);

            if (!string.IsNullOrEmpty(TxtQteOlive.Text) && !TxtQteOlive.Text.Equals(".") && !TxtQteOlive.Text.Equals(",") && !TxtQteOlive.Text.Equals("-"))
            {
                QteOlive = Convert.ToInt32(TxtQteOlive.Text);
                OldQteOlive = Convert.ToInt32(TxtQteOlive.Text);
            }

            else
            {
                QteOlive = 0;
            }

            if (QteOlive != 0 && PUOlive != 0)
            {
                TxtMtOpPrev.Text = (Math.Truncate(decimal.Multiply(PUOlive, QteOlive) * 100000m) / 100000m).ToString("0.000");
            }

            decimal PUOliveFianl;
            string PUOliveFinalStr = TxtPUOliveFinal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PUOliveFinalStr, out PUOliveFianl);


            if (QteOlive != 0 && PUOliveFianl != 0)
            {
                TxtMontantReglement.Text = (Math.Truncate(decimal.Multiply(QteOlive, PUOliveFianl) * 100000m) / 100000m).ToString("0.000");
            }
        }

        private void comboBoxTypeOlive_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeOlive.SelectedItem.Equals("Nchira"))
            {
                emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.Nchira).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            }



            else if (comboBoxTypeOlive.SelectedItem.Equals("OliveVif"))
            {
                emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            }
        }

        private void TxtRendement_EditValueChanged(object sender, EventArgs e)
        {
            decimal PrixLitre;
            string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PrixLitreStr, out PrixLitre);

            decimal Rendement;
            string RendementStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(RendementStr, out Rendement);

            decimal PUOlive;
            // PUOlive = Math.Round(, 3);
            PUOlive = Math.Truncate(decimal.Divide(decimal.Multiply(PrixLitre, Rendement), 100) * 100000m) / 100000m;


            TxtPUOlive.Text = PUOlive.ToString();
            Oldbase = Rendement;
        }

        private void TxtPUOlive_EditValueChanged(object sender, EventArgs e)
        {
            int QteOlive;

            decimal PUOlive;
            string PUOliveStr = TxtPUOlive.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PUOliveStr, out PUOlive);



            if (!string.IsNullOrEmpty(TxtQteOlive.Text) && !TxtQteOlive.Text.Equals(".") && !TxtQteOlive.Text.Equals(",") && !TxtQteOlive.Text.Equals("-"))
            {
                QteOlive = Convert.ToInt32(TxtQteOlive.Text);
            }

            else
            {
                QteOlive = 0;
            }

            TxtMtOpPrev.Text = decimal.Multiply(PUOlive, QteOlive).ToString("0.000");

            TxtPUOliveFinal.Text = TxtPUOlive.Text;
            decimal PUOliveFianl;
            string PUOliveFinalStr = TxtPUOliveFinal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PUOliveFinalStr, out PUOliveFianl);
            OldPUOliveFinal = PUOliveFianl;
        }

        private void TxtPUOliveFinal_EditValueChanged(object sender, EventArgs e)
        {
            decimal MontantReglement;
            string MontantReglementtStr = TxtMontantReglement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantReglementtStr, out MontantReglement);

            decimal PUOliveFianl;
            string PUOliveFinalStr = TxtPUOliveFinal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PUOliveFinalStr, out PUOliveFianl);

            int QteOlive;

            if (!string.IsNullOrEmpty(TxtQteOlive.Text))
            {
                QteOlive = Convert.ToInt32(TxtQteOlive.Text);
            }

            else
            {
                QteOlive = 0;
            }
            decimal PrixLitre;
            string PrixLitreStr = TxtPrixLitre.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PrixLitreStr, out PrixLitre);
            decimal Rendement;
            string RendementStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(RendementStr, out Rendement);


            if (PUOliveFianl != 0 && QteOlive != 0 && OldQteOlive == QteOlive && OldPrixKGhuile == PrixLitre && Oldbase == Rendement)
            {
                if (OldPUOliveFinal != PUOliveFianl && OldMontantReglement != MontantReglement)
                {
                    TxtMontantReglement.Text = TxtMontantReglement.Text;
                }
                else
                {
                    TxtMontantReglement.Text = (Math.Truncate(decimal.Multiply(QteOlive, PUOliveFianl) * 100000m) / 100000m).ToString("0.000");
                }


            }
            else if (PUOliveFianl != 0 && QteOlive != 0)
            {
                TxtMontantReglement.Text = (Math.Truncate(decimal.Multiply(QteOlive, PUOliveFianl) * 100000m) / 100000m).ToString("0.000");
            }

            OldMontantReglement = MontantReglement;
        }

        private void comboBoxModeReglement_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cheque
            if (comboBoxModeReglement.SelectedIndex == 1 || comboBoxModeReglement.SelectedIndex == 2)
            {
                numcheque.Visibility = LayoutVisibility.Always;
                bank.Visibility = LayoutVisibility.Always;
                layoutControlItem12.Visibility = LayoutVisibility.Always;
            }

            // espece
            else if (comboBoxModeReglement.SelectedIndex == 0)
            {
                numcheque.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Never;
                layoutControlItem12.Visibility = LayoutVisibility.Never;


            }
        }

        private void BtnImprimerFacture_Click(object sender, EventArgs e)
        {
            Achat A = gridView1.GetFocusedRow() as Achat;

            db = new Model.ApplicationContext();

            Achat AchatDb = db.Achats.Include("Founisseur").FirstOrDefault(x => x.Id == A.Id);

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

        private void TxtPoids_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            int visibleIndex = gridView4.GetVisibleIndex(gridView4.FocusedRowHandle);
            gridView4.DeleteRow(visibleIndex);
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
                    for (int row = 0; row < gridView4.DataRowCount; row++)
                    {
                        var existingCIN = gridView4.GetRowCellValue(row, "cin") as string;
                        if (existingCIN == newValue)
                        {
                            // Affichez un message d'erreur si le CIN existe déjà
                            XtraMessageBox.Show("Ce CIN existe déjà.", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            // Rétablir la valeur précédente ou effacer la cellule
                            gridView4.SetRowCellValue(e.RowHandle, e.Column, null); // ou utilisez la valeur précédente
                            return;
                        }
                    }
                }

            }
        }
    }
}