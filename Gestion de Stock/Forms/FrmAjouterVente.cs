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
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraLayout.Utils;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterVente : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmAjouterVente _FrmAjouterVente;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;

        public static FrmAjouterVente InstanceFrmAjouterVente
        {
            get
            {
                if (_FrmAjouterVente == null)
                    _FrmAjouterVente = new FrmAjouterVente();
                return _FrmAjouterVente;
            }
        }
        public FrmAjouterVente()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAjouterVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterVente = null;
        }

        private void FrmAjouterVente_Load(object sender, EventArgs e)
        {

            pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList(); 

           // pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).ToList();
            /********************** Client Liste************************/
            clientBindingSource.DataSource = db.Clients.ToList();


            dateVente.DateTime = DateTime.Now;

            ///***********************  Mode  Paiement Liste  ***********************/
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).Where(item => item != ModeReglement.Traite.ToString()).ToList();
            if (ModePaiement != null)
            {
                foreach (var M in ModePaiement)
                {
                    comboBoxModeReglement.Properties.Items.Add(M);
                }

                comboBoxModeReglement.SelectedIndex = 0;
                if (ModePaiement.Count > 0)
                    comboBoxModeReglement.SelectedItem = ModePaiement[0];

            }

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            if (string.IsNullOrEmpty(searchLookUpEditClient.Text))
            {
                XtraMessageBox.Show("Choisir un Client", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(searchLookUpEditPile.Text))
            {
                XtraMessageBox.Show("Choisir une Pile", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(TxtPrix.Text))
            {
                TxtPrix.ErrorText = "Prix est obligatoire";
                return;

            }

            if (string.IsNullOrEmpty(TxtQuantite.Text))
            {
                TxtQuantite.ErrorText = "Quantité est obligatoire";
                return;
            }

            decimal Prix;
            string PrixStr = TxtPrix.Text.ToString().Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PrixStr, out Prix);

            if (Prix <= 0)
            {
                XtraMessageBox.Show("Prix est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtPrix.Text = string.Empty;
                return;

            }

            int Quantite;

            Quantite = Convert.ToInt32(TxtQuantite.Text);

            if (Quantite <= 0)
            {
                XtraMessageBox.Show("Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtQuantite.Text = string.Empty;
                return;

            }


            LigneVente LV = new LigneVente();


            LV.Quantity = Quantite;

            LV.PrixHT = Prix;

            var calcule = 0;

            // Pile
            Pile P = new Pile();

            GridView view = searchLookUpEditPile.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object PileSelected = view.GetRowCellValue(rowHandle, fieldName);


            if (PileSelected == null)
            {
                XtraMessageBox.Show("Choisir une pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEditPile.Focus();
                return;

            }
            else
            {
                int IdPile = Convert.ToInt32(PileSelected);
                P = db.Piles.Find(IdPile);

                LV.ArticleVente = P.article;
                LV.IdPile = P.Id;
                LV.NomPile = P.Intitule;
                LV.QuantitePileInitial = P.Capacite;


                if (P.Capacite < Quantite)
                {
                    XtraMessageBox.Show("Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    searchLookUpEditPile.Focus();
                    TxtQuantite.Text = "";
                    return;

                }

                else
                {

                    // recupeer tout les lignes de vente dans la grid view 
                    List<LigneVente> ListeGrid = new List<LigneVente>();
                    int rowHandle3 = 0;
                    while (gridView1.IsValidRowHandle(rowHandle3))
                    {
                        var data = gridView1.GetRow(rowHandle3) as LigneVente;
                        ListeGrid.Add(data);


                        bool isSelected = gridView1.IsRowSelected(rowHandle3);
                        rowHandle3++;
                    }

                    if (ListeGrid.Count == 0)
                    {
                        // Ajouter Ligne de vente a la gride

                        ListeGrid.Add(LV);

                        Pile Pile = db.Piles.Find(LV.IdPile);
                        calcule = P.Capacite;

                        LV.QuantitePileFinal = LV.QuantitePileInitial - Quantite;

                        Pile.Capacite = LV.QuantitePileFinal;

                        LV.PrixMoyenPile = Math.Truncate(Pile.PrixMoyen * 100000m) / 100000m;

                        //if (LV.Pile.Capacite == 0)
                        //{ LV.Pile.PrixMoyen = 0; }

                        //  db.SaveChanges();

                    }
                    else
                    {
                        var LigneExiste = ListeGrid.FirstOrDefault(x => x.IdPile == LV.IdPile);

                        if (LigneExiste == null)
                        {
                            ListeGrid.Add(LV);

                            LV.QuantitePileFinal = LV.QuantitePileInitial - Quantite;

                            Pile Pile = db.Piles.Find(LV.IdPile);

                            Pile.Capacite = LV.QuantitePileFinal;

                            LV.PrixMoyenPile = Math.Truncate(Pile.PrixMoyen * 100000m) / 100000m;



                            //  db.SaveChanges();
                        }
                        else
                        {
                            foreach (var L in ListeGrid)
                            {
                                if (L.IdPile == LV.IdPile)
                                {
                                    var qteini = L.Quantity;
                                    Pile Pile = db.Piles.Find(LV.IdPile);
                                    L.Quantity = LV.Quantity;
                                    L.PrixHT = LV.PrixHT;

                                    L.QuantitePileInitial = P.Capacite + qteini;

                                    L.QuantitePileFinal = L.QuantitePileInitial - LV.Quantity;

                                    Pile.Capacite = L.QuantitePileFinal;


                                    //   db.SaveChanges();


                                }
                            }
                        }

                    }

                    ligneVenteBindingSource.DataSource = ListeGrid;

                    TxtMontantReglement.Text = ListeGrid.Sum(x => x.TotalLigneHT).ToString();

                }

                XtraMessageBox.Show("Ligne Vente Ajoutée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                searchLookUpEditPile.EditValue = searchLookUpEditPile.Properties.NullText;
                TxtPrix.Text = string.Empty;
                TxtQuantite.Text = string.Empty;
                TxtTypeHuile.Text = string.Empty;


            }

        }

        private void searchLookUpEditPile_EditValueChanged(object sender, EventArgs e)
        {
            Pile P = new Pile();

            GridView view = searchLookUpEditPile.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object PileSelected = view.GetRowCellValue(rowHandle, fieldName);

            
            if (PileSelected == null)
            {
                XtraMessageBox.Show("Choisir une pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpEditPile.Focus();
                return;

            }
            else
            {
                int IdPile = Convert.ToInt32(PileSelected);
                
                P = db.Piles.Find(IdPile);

                ArticleVente typeHuile = P.article;

                if (typeHuile.Equals(ArticleVente.Extra))
                {
                    TxtTypeHuile.Text = "Extra";
                }

                else if (typeHuile.Equals(ArticleVente.Lampante))
                {
                    TxtTypeHuile.Text = "Lampante";
                }
                else if (typeHuile.Equals(ArticleVente.Fatoura))
                {
                    TxtTypeHuile.Text = "Fatoura";
                }
                else if (typeHuile.Equals(ArticleVente.Vierge))
                {
                    TxtTypeHuile.Text = "Vierge";
                }
                else if (typeHuile.Equals(ArticleVente.ExtraVierge))
                {
                    TxtTypeHuile.Text = "ExtraVierge";
                }
            }
        }

        private void repositoryBtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                LigneVente Lv = gridView1.GetFocusedRow() as LigneVente;

                Pile P = db.Piles.Where(x => x.Id == Lv.IdPile).FirstOrDefault();

                P.Capacite += Lv.Quantity;

                db.SaveChanges();

                gridView1.DeleteSelectedRows();

                // recupeer tout les lignes de vente dans la grid view 
                List<LigneVente> ListeGrid = new List<LigneVente>();
                int rowHandle3 = 0;
                while (gridView1.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView1.GetRow(rowHandle3) as LigneVente;
                    ListeGrid.Add(data);


                    bool isSelected = gridView1.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }

                TxtMontantReglement.Text = ListeGrid.Sum(x => x.TotalLigneHT).ToString();

            }
        }


        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Vente Vente = new Vente();

            decimal MontantReglement;

            decimal MontantRegle;

            List<LigneVente> ListeGrid = new List<LigneVente>();

            int rowHandle3 = 0;

            while (gridView1.IsValidRowHandle(rowHandle3))
            {
                var data = gridView1.GetRow(rowHandle3) as LigneVente;

                var L = new LigneVente();

                Pile PileDb = db.Piles.Find(data.IdPile);

                L.ArticleVente = data.ArticleVente;
                L.IdPile = PileDb.Id;
                L.NomPile = PileDb.Intitule;
                L.Quantity = data.Quantity;
                L.PrixHT = data.PrixHT;
                L.QuantitePileInitial = data.QuantitePileInitial;
                L.QuantitePileFinal = data.QuantitePileFinal;
                L.PrixMoyenPile = data.PrixMoyenPile;
                ListeGrid.Add(L);

                rowHandle3++;
            }

            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("Merci d'Ajouter Ligne Vente", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Vente.Date = dateVente.DateTime;

                Client C = new Client();
                GridView view1 = searchLookUpEditClient.Properties.View;

                Client Clientelected = searchLookUpEditClient.Properties.GetRowByKeyValue(searchLookUpEditClient.EditValue) as Client;// view1.GetRowCellValue(rowHandle1, fieldName1);

                if (Clientelected != null)
                {
                    int IdClient = Convert.ToInt32(Clientelected.Id);
                    C = db.Clients.Find(IdClient);
                    Vente.IdClient = C.Id;
                    Vente.IntituleClient = C.Intitule;
                    Vente.NumClient = C.Numero;
                }

                string MontantReglementStr = TxtMontantReglement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(MontantReglementStr, out MontantReglement);

                string MontantRegletStr = TxtMontantRegle.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(MontantRegletStr, out MontantRegle);

                if (MontantRegle > MontantReglement || MontantRegle < 0)
                {
                    XtraMessageBox.Show("Montant Règlement est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TxtMontantRegle.Text = "";
                    return;
                }
                else
                {
                    Vente.MontantReglement = MontantReglement;

                    Vente.MontantRegle = MontantRegle;

                    if (comboBoxModeReglement.SelectedItem.ToString().Equals("Espèce"))
                    {
                        Vente.ModeReglement = ModeReglement.Espèce;
                        Vente.NumeroCheque = "";
                        Vente.DateEcheance = null;
                        Vente.Bank = null;
                    }

                    else if (comboBoxModeReglement.SelectedItem.ToString().Equals("Chèque"))
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

                        if (MontantRegle <= 0)
                        {
                            XtraMessageBox.Show("Montant Règlement est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            TxtMontantRegle.Text = "";
                            return;
                        }

                        Vente.ModeReglement = ModeReglement.Chèque;
                        Vente.NumeroCheque = TxtNumCheque.Text;
                        Vente.DateEcheance = dateEcheance.DateTime;
                        Vente.Bank = TxtBank.Text;
                    }

                    Vente.LigneVentes = new List<LigneVente>();

                    Vente.LigneVentes.AddRange(ListeGrid);

                    Vente.QteVendue = ListeGrid.Sum(x => x.Quantity);

                    if (MontantRegle == MontantReglement && MontantReglement != 0)
                    {
                        Vente.EtatVente = EtatVente.Reglee;
                    }

                    else if (MontantRegle == 0 && MontantReglement == Vente.ResteApayer)
                    {
                        Vente.EtatVente = EtatVente.NonReglee;
                    }


                    else if (Vente.ResteApayer < MontantReglement && MontantReglement != 0 && Vente.ResteApayer != 0)
                    {
                        Vente.EtatVente = EtatVente.PartiellementReglee;
                    }

                    else if (MontantRegle == 0 && MontantReglement == 0)
                    {
                        Vente.EtatVente = EtatVente.NonReglee;
                    }

                    Vente.TotalHT = ListeGrid.Sum(x => x.TotalLigneHT);

                    db.Vente.Add(Vente);
                    db.SaveChanges();

                    Vente.Numero = "VEN" + (Vente.Id).ToString("D8");

                    //espece
                    if (Vente.ModeReglement == ModeReglement.Espèce)
                    {
                        Vente.Coffre = false;
                    }
                    //cheque
                    else if (Vente.ModeReglement == ModeReglement.Chèque)
                    {
                        Vente.Coffre = true;
                    }
                    db.SaveChanges();

                    List<LigneVente> listeLV = new List<LigneVente>();

                    listeLV = Vente.LigneVentes;

                    foreach (var L in listeLV)
                    {
                        int idPile = L.IdPile;

                        Pile PileDb = db.Piles.Find(idPile);

                        MouvementStock MvtStock = new MouvementStock();

                        int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;
                        MvtStock.Numero = "SOV" + (lastMvtStock).ToString("D8");
                        MvtStock.Date = Vente.Date;
                        MvtStock.pile = PileDb;
                        MvtStock.Sens = SensStock.Sortie;
                        MvtStock.Qualite = L.ArticleVente;
                        MvtStock.QuantiteVendue = L.Quantity;
                        MvtStock.QuantiteProduite = 0;
                        MvtStock.QuantiteSOD = 0;
                        MvtStock.QuantiteAchetee = 0;
                        MvtStock.QteSortante = L.Quantity;

                        MvtStock.Commentaire = "Vente N° " + Vente.Numero;
                        MvtStock.Vente = Vente;
                        MvtStock.Code = Vente.Numero;
                        MvtStock.Intitulé = Vente.IntituleClient;
                        MvtStock.PrixMouvement = PileDb.PrixMoyen;
                        MvtStock.QuantitePileInitial = L.QuantitePileInitial;
                        MvtStock.QuantitePileFinal = L.QuantitePileFinal;
                        db.MouvementsStock.Add(MvtStock);
                        MvtStock.PMP = PileDb.PrixMoyen;
                        db.SaveChanges();

                        // Traitement Pile 
                        PileDb.Capacite = PileDb.Capacite - L.Quantity;
                        if (PileDb.Capacite == 0)
                        { PileDb.PrixMoyen = 0; }
                        db.SaveChanges();

                    }

                    XtraMessageBox.Show("Vente Enregistrée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();

                    if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();

                    searchLookUpEditClient.EditValue = searchLookUpEditClient.Properties.NullText;

                    List<string> ListeModePaiement = Enum.GetNames(typeof(ModeReglement)).Where(item => item != ModeReglement.Traite.ToString()).ToList();
                    comboBoxModeReglement.SelectedItem = ListeModePaiement[0];
                    TxtMontantRegle.Text = string.Empty;
                    TxtMontantReglement.Text = string.Empty;
                    TxtResteAPayer.Text = string.Empty;
                    TxtNumCheque.Text = string.Empty;
                    TxtBank.Text = string.Empty;
                    dateEcheance.EditValue = null;
                    dateVente.DateTime = DateTime.Now;

                    ligneVenteBindingSource.DataSource = null;

                    if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                    {
                        db = new Model.ApplicationContext();
                        Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();

                    }

                    #region Alimentation

                    if (Vente.Coffre == false && Vente.MontantRegle > 0)
                    {
                        Alimentation A = new Alimentation();
                        A.Client = db.Clients.Find(Vente.IdClient);
                        A.Source = SourceAlimentation.Vente;
                        A.Montant = MontantRegle;
                        A.Commentaire = "Encaissement Vente N° " + Vente.Numero;
                        db.Alimentations.Add(A);
                        db.SaveChanges();
                        A.Numero = "E" + (A.Id).ToString("D8");
                        db.SaveChanges();


                        if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                            Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();

                        MouvementCaisse mvtCaisse = new MouvementCaisse();
                        mvtCaisse.MontantSens = MontantRegle;
                        mvtCaisse.Sens = Sens.Alimentation;
                        mvtCaisse.Date = DateTime.Now;
                        mvtCaisse.Client = db.Clients.Find(Vente.IdClient);
                        mvtCaisse.CodeTiers = Vente.NumClient;
                        mvtCaisse.Source = "Client :" + Vente.IntituleClient;
                        mvtCaisse.Vente = db.Vente.Find(Vente.Id);
                        Caisse CaisseDb = db.Caisse.Find(1);
                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Add(CaisseDb.MontantTotal, MontantRegle);

                        }

                        int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                        mvtCaisse.Montant = CaisseDb.MontantTotal;

                        mvtCaisse.Commentaire = "Encaissement Vente N° " + Vente.Numero;
                        mvtCaisse.Numero = "E" + (lastMouvement).ToString("D8");
                        db.MouvementsCaisse.Add(mvtCaisse);
                        db.SaveChanges();
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

                    #region Historique paiement vente
                    if (MontantRegle > 0)
                    {
                        HistoriquePaiementVente hpv = new HistoriquePaiementVente();
                        hpv.IdVente = Vente.Id;
                        hpv.IdClient = Vente.IdClient;
                        hpv.IntituleClient = Vente.IntituleClient;
                        hpv.NumClient = Vente.NumClient;
                        hpv.MontantRegle = MontantRegle;
                        hpv.MontantReglement = Vente.MontantReglement;
                        hpv.ResteApayer = Vente.ResteApayer;
                        hpv.NumVente = Vente.Numero;
                        hpv.ModeReglement = Vente.ModeReglement;
                        hpv.NumCheque = Vente.NumeroCheque;
                        hpv.Bank = Vente.Bank;
                        hpv.DateEcheance = Vente.DateEcheance;
                        hpv.Coffre = Vente.Coffre;
                        hpv.Commentaire = "";
                        db.HistoriquePaiementVente.Add(hpv);
                        db.SaveChanges();
                    }



                    #endregion

                    if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList();


                    if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();


                    //waiting Form 
                    if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();


                    if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmTransfertPile>().First().PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

                    if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmTransfertPile>().First().PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.article != ArticleVente.Fatoura && x.Capacite < x.CapaciteMax).ToList();

                    if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();


                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    {
                        string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                        Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();


                    }

                    if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();

                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();



                }
            }
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

            TxtResteAPayer.Text = (MontantReglement - MontantRegle).ToString();

        }

        private void TxtMontantReglement_EditValueChanged(object sender, EventArgs e)
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
            TxtResteAPayer.Text = (MontantReglement - MontantRegle).ToString();
        }

        private void comboBoxModeReglement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModeReglement.SelectedIndex == 1)
            {
                layoutControlItem20.Visibility = LayoutVisibility.Always;
                layoutControlBank.Visibility = LayoutVisibility.Always;
                layoutControlDateEcheance.Visibility = LayoutVisibility.Always;



            }

            else if (comboBoxModeReglement.SelectedIndex == 0)
            {
                layoutControlItem20.Visibility = LayoutVisibility.Never;
                layoutControlBank.Visibility = LayoutVisibility.Never;
                layoutControlDateEcheance.Visibility = LayoutVisibility.Never;


            }
        }


    }



}