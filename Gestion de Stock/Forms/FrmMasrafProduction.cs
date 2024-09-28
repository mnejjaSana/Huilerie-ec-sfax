using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmMasrafProduction : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmMasrafProduction _FrmMasrafProduction;

        string decimalSeparator;

        public static FrmMasrafProduction InstanceFrmMasrafProduction
        {
            get
            {
                if (_FrmMasrafProduction == null)
                {
                    _FrmMasrafProduction = new FrmMasrafProduction();
                }

                return _FrmMasrafProduction;
            }
        }



        public FrmMasrafProduction()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();

        }
        private void FrmMasrafProduction_Load(object sender, EventArgs e)
        {
            emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            productionBindingSource.DataSource = db.Productions.Where(a => a.Emplacement != null && a.StatutProd != StatutProduction.Stocké).OrderByDescending(x => x.NumeroProduction).ToList();
            pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

            TxtDatefinPartiel.DateTime = DateTime.Now.AddMinutes(2);
            DateDebut.DateTime = DateTime.Now;
            /***************liste Machine***************/
            List<string> ListeMachine = db.Chaines.Select(x => x.Intitule).ToList();
            if (ListeMachine != null)
            {
                foreach (var Machine in ListeMachine)
                {
                    comboBoxMachine.Properties.Items.Add(Machine);
                }
            }

        }

        private void FrmMasrafProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMasrafProduction = null;
        }

        private void colSupp_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                LigneProduction L = gridView2.GetFocusedRow() as LigneProduction;

                LigneProduction LigneProductionDb = db.LigneProductions.Find(L.Id);
                db.LigneProductions.Remove(LigneProductionDb);

                db.SaveChanges();

                gridView2.DeleteSelectedRows();

                List<LigneProduction> ListeGrid = new List<LigneProduction>();

                int rowHandle3 = 0;
                while (gridView2.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView2.GetRow(rowHandle3) as LigneProduction;
                    ListeGrid.Add(data);


                    bool isSelected = gridView2.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }

                int TotaleNbS = ListeGrid.Sum(x => x.NombreSacs);
                //  int NombreSacs = Convert.ToInt32(TxtNombreSacs.Text);
                //   int RestNombreSac = NombreSacs - TotaleNbS;
                //    TxtNombreSacsPartiel.Text = RestNombreSac.ToString();
                TxtQteHuileTotal.Text = ListeGrid.Sum(x => x.QuantiteHuileProduite).ToString();

            }

        }

        private void BtnProduction_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            Production prod = new Production();

            prod.TypeAchat = TypeAchat.Olive;
            prod.QuantiteOlive = TxtQteOlive.Text;
            prod.DateProd = DateDebut.DateTime;
            // Masraf
            Emplacement E = new Emplacement();
            GridView view = searchlookupMasraf.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object MasrafSelected = view.GetRowCellValue(rowHandle, fieldName);
            int Qteinit = 0;
            if (MasrafSelected == null)
            {
                XtraMessageBox.Show("Choisir un emplacement ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchlookupMasraf.Focus();
                return;
            }
            else
            {
                int Idemp = Convert.ToInt32(MasrafSelected);
                E = db.Emplacements.Find(Idemp);
                prod.Emplacement = E;
                prod.RendementMoyenPrevu = E.RENDEMENMOY;
                Qteinit = E.Quantite;
            }
            if (string.IsNullOrEmpty(TxtQteOlive.Text))
            {
                XtraMessageBox.Show("Qté Olive est obligatoire", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                TxtQteOlive.ErrorText = "Qté Olive est obligatoire";
                return;
            }

            int QteOlive = Convert.ToInt32(TxtQteOlive.Text);
            if (QteOlive > Qteinit || QteOlive <= 0 || QteOlive == 0)
            {
                XtraMessageBox.Show("Quantité Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                TxtQteOlive.Focus();

                TxtQteOlive.Text = string.Empty;
                //  searchlookupMasraf.EditValue = searchLookUpPile.Properties.NullText;
                return;

            }
            else
            {
                E.Quantite = Qteinit - QteOlive;
                
                if (E.Quantite == 0)
                {
                    E.LastPrixMoyen = E.PrixMoyen;
                    E.RENDEMENMOY = 0;
                    E.ValeurMasraf = 0;
                    E.PrixMoyen = 0;


                }


                //réduire min production 
            }




            TxtQteHuileTotal.ReadOnly = true;

            if (comboBoxMachine.SelectedItem == null)
            {
                comboBoxMachine.ErrorText = "Machine est obligatoire";
                return;
            }

            if (comboBoxMachine.SelectedItem.ToString().Equals("Chaine1"))
            {
                prod.Machine = chaine.Chaine1;
            }
            else if (comboBoxMachine.SelectedItem.ToString().Equals("Chaine2"))
            {
                prod.Machine = chaine.Chaine2;
            }
            prod.DateProd = DateDebut.DateTime;


            prod.StatutProd = StatutProduction.Encours;

       



            db.Productions.Add(prod);
            db.SaveChanges();
            prod.NumeroProduction = "P" + (prod.Id).ToString("D8");
            db.SaveChanges();

            Root1.Visibility = LayoutVisibility.Always;
            Root2.Visibility = LayoutVisibility.Always;
            BtnProduction.Enabled = false;
            searchlookupMasraf.ReadOnly = true;
            searchlookupMasraf.Properties.NullText = prod.Emplacement.Intitule;
            searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;
            comboBoxMachine.ReadOnly = true;
            DateDebut.ReadOnly = true;
            comboBoxMachine.ReadOnly = true;
            DateDebut.ReadOnly = true;
            TxtQteOlive.ReadOnly = true;

            emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            #region Ajouter Mouvement Olive 
            MouvementStockOlive mouvementStockOlive = new MouvementStockOlive();
            mouvementStockOlive.Sens = SensStockOlive.Sortie;

            mouvementStockOlive.Emplacement = prod.Emplacement;


            mouvementStockOlive.Commentaire = "Sortie Stock " + prod.NumeroProduction;
            mouvementStockOlive.QuantiteMasrafInitial = Qteinit;
            mouvementStockOlive.QuantiteMasrafFinal = Qteinit - QteOlive;
            if (mouvementStockOlive.QuantiteMasrafFinal == 0)
            {
                mouvementStockOlive.RENDEMENMOY = 0;

            }
            else
            {
                mouvementStockOlive.RENDEMENMOY = prod.Emplacement.RENDEMENMOY;

                mouvementStockOlive.RENDEMENTMVT = prod.Emplacement.RENDEMENMOY;
            }

            mouvementStockOlive.PrixMouvement = E.LastPrixMoyen;
            mouvementStockOlive.QteEntrante = 0;
            mouvementStockOlive.QteSortante = QteOlive;

            mouvementStockOlive.Code = prod.NumeroProduction;
            mouvementStockOlive.Intitulé = "";
            db.MouvementStockOlive.Add(mouvementStockOlive);
            db.SaveChanges();
            mouvementStockOlive.Numero = "MOVENT" + (mouvementStockOlive.Id).ToString("D8");
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

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
            {

                if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("Nchira"))
                {
                    Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.Nchira).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                }

                else if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("OliveVif"))
                {
                    Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

                }

            }
            if (Application.OpenForms.OfType<FrmTransfertEmplacement>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmTransfertEmplacement>().First().emplacementEntrantBindingSource.DataSource = db.Emplacements.AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            }
            if (Application.OpenForms.OfType<FrmTransfertEmplacement>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmTransfertEmplacement>().First().emplacementSortantBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            }

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }

            if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).ToList();
            }
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            int FocusedRowHandle = gridView3.FocusedRowHandle;
            int count = gridView3.SelectedRowsCount;

            //new production masraf
            if (count == 0)
            {
                List<LigneProduction> ListeGrid = new List<LigneProduction>();
                int rowHandle = 0;

                while (gridView2.IsValidRowHandle(rowHandle))
                {
                    var data = gridView2.GetRow(rowHandle) as LigneProduction;
                    ListeGrid.Add(data);
                    rowHandle++;

                }

                if (ListeGrid.Count == 0)
                {
                    XtraMessageBox.Show("Ajouter une ligne de Production!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }


                decimal QteHuileTotal;
                string QteHuileTotalStr = TxtQteHuileTotal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteHuileTotalStr, out QteHuileTotal);

                int max = db.Productions.Max(p => p.Id);

                Production LastProd = db.Productions.Include("Emplacement").Where(x => x.Id == max).FirstOrDefault();
                //achat
                Achat achatDB = db.Achats.Find(LastProd.Id);


                List<LigneProduction> ListeLP = db.LigneProductions.Where(x => x.prod.Id == LastProd.Id).ToList();
                LastProd.DateFinProd = TxtDatefinPartiel.DateTime;
                DateTime MaxDate = default(DateTime);
                DateTime MinDate = default(DateTime);

                decimal QteOlive;
                string QteOliveStr = TxtQteOlive.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteOliveStr, out QteOlive);


                var RendementLignePTotal = 0m;
                var valeurLignePTotal = 0m;
                var PULigneProdTotal = 0m;

                if (ListeLP.Count > 0)
                {
                    MaxDate = db.LigneProductions.Where(x => x.prod.Id == LastProd.Id).Max(x => x.DateFinProd);
                    MinDate = db.LigneProductions.Where(x => x.prod.Id == LastProd.Id).Min(x => x.DateFinProd);

                    foreach (var item in ListeLP)
                    {
                        RendementLignePTotal = (item.QuantiteHuileProduite / QteOlive);

                        PULigneProdTotal = (valeurLignePTotal / item.QuantiteHuileProduite);
                        item.RendementLignePTotal = RendementLignePTotal;


                    }
                    db.SaveChanges();

                    List<LigneProduction> ListeLProd = db.LigneProductions.Where(x => x.prod.Id == LastProd.Id).ToList();

                    var rendementTot = ListeLProd.Sum(x => x.RendementLignePTotal);
                    var valeurTotal = QteOlive * LastProd.Emplacement.LastPrixMoyen;
                    var qteHuile = ListeLProd.Sum(x => x.QuantiteHuileProduite);
                    var PUTotal = valeurTotal / qteHuile;

                    LastProd.PUTotal = Math.Truncate(PUTotal * 100000m) / 100000m;
                    db.SaveChanges();


                }
                else
                {
                    MaxDate = DateTime.Now.AddMinutes(2);
                    MinDate = DateTime.Now;

                }




                TxtQteReste.Text = decimal.Round(QteHuileTotal, 0, MidpointRounding.AwayFromZero).ToString();
                TxtQteHuileTotal.ReadOnly = true;
                decimal QteHuile;
                string QteHuileStr = TxtQteHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteHuileStr, out QteHuile);
                LastProd.QuantiteHuile = QteHuileTotal;


                LastProd.RendementReel = decimal.Multiply(decimal.Divide(QteHuileTotal, QteOlive), 100);
                LastProd.DateFinProd = MaxDate;
                LastProd.DateProd = DateDebut.DateTime;
                LastProd.StatutProd = StatutProduction.Terminée;
                LastProd.NuméroBon = TxtNumBon.Text;

                var duree = MaxDate - MinDate;
                LastProd.dureeProduction = duree.ToString(@"hh\:mm");
                db.SaveChanges();



                TxtQteHuileTotal.ReadOnly = true;
                TxtQteOlive.ReadOnly = true;
                BtnEnregistrer.Enabled = false;
                TxtQteHuileTotal.ReadOnly = true;
                comboBoxMachine.ReadOnly = true;
                DateDebut.ReadOnly = true;
                TxtDatefinPartiel.ReadOnly = true;

                TxtQteHuilePartiel.ReadOnly = true;
                TxtDatefinPartiel.ReadOnly = true;
                BtnAjouterPartiel.Enabled = false;
                colSupprimer.OptionsColumn.AllowEdit = false;

                TxtNumBon.ReadOnly = true;


                XtraMessageBox.Show("Production Terminée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).OrderByDescending(x => x.Id).ToList();
                }
            }
            else
            {


                Production p1 = gridView3.GetFocusedRow() as Production;

                Production prod = db.Productions.Include("Emplacement").Where(x => x.Id == p1.Id).FirstOrDefault();

                Achat achatDB = db.Achats.Find(prod.Id);
                List<LigneProduction> ListeGrid = new List<LigneProduction>();
                int rowHandle = 0;

                while (gridView2.IsValidRowHandle(rowHandle))
                {
                    var data = gridView2.GetRow(rowHandle) as LigneProduction;
                    ListeGrid.Add(data);
                    rowHandle++;

                }

                if (ListeGrid.Count == 0)
                {
                    XtraMessageBox.Show("Ajouter une ligne de Production!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }


                decimal QteHuileTotal;
                string QteHuileTotalStr = TxtQteHuileTotal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteHuileTotalStr, out QteHuileTotal);



                List<LigneProduction> ListeLP = db.LigneProductions.Where(x => x.prod.Id == prod.Id).ToList();

                DateTime MaxDate = default(DateTime);
                DateTime MinDate = default(DateTime);

                var RendementLignePTotal = 0m;
                var valeurLignePTotal = 0m;
                var PULigneProdTotal = 0m;

                decimal QteOlive;
                string QteOliveStr = TxtQteOlive.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteOliveStr, out QteOlive);



                if (ListeLP.Count > 0)
                {
                    MaxDate = db.LigneProductions.Where(x => x.prod.Id == prod.Id).Max(x => x.DateFinProd);
                    MinDate = db.LigneProductions.Where(x => x.prod.Id == prod.Id).Min(x => x.DateFinProd);

                    foreach (var item in ListeLP)
                    {
                        RendementLignePTotal = (item.QuantiteHuileProduite / QteOlive);

                        PULigneProdTotal = (valeurLignePTotal / item.QuantiteHuileProduite);
                        item.RendementLignePTotal = RendementLignePTotal;


                    }

                    db.SaveChanges();

                    List<LigneProduction> ListeLProd = db.LigneProductions.Where(x => x.prod.Id == prod.Id).ToList();
                    // tester avec si taher
                    var rendementTot = ListeLProd.Sum(x => x.RendementLignePTotal);
                    var valeurTotal = QteOlive * prod.Emplacement.LastPrixMoyen;
                    var qteHuile = ListeLProd.Sum(x => x.QuantiteHuileProduite);
                    var PUTotal = valeurTotal / qteHuile;

                    prod.PUTotal = Math.Truncate(PUTotal * 100000m) / 100000m;
                    db.SaveChanges();


                }
                else
                {
                    MaxDate = DateTime.Now.AddMinutes(2);
                    MinDate = DateTime.Now;

                }

                TxtQteReste.Text = decimal.Round(QteHuileTotal, 0, MidpointRounding.AwayFromZero).ToString();
                TxtQteHuileTotal.ReadOnly = true;
                decimal QteHuile;
                string QteHuileStr = TxtQteHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteHuileStr, out QteHuile);
                prod.QuantiteHuile = QteHuileTotal;
                prod.RendementReel = decimal.Multiply(decimal.Divide(QteHuileTotal, QteOlive), 100);
                prod.DateFinProd = MaxDate;
                prod.DateProd = DateDebut.DateTime;
                prod.StatutProd = StatutProduction.Terminée;
                prod.NuméroBon = TxtNumBon.Text;

                var duree = MaxDate - MinDate;
                prod.dureeProduction = duree.ToString(@"hh\:mm");

                db.SaveChanges();
                #region  refresh grid keeping selected
                productionBindingSource.DataSource = db.Productions.Where(a => a.Emplacement != null && a.StatutProd != StatutProduction.Stocké).OrderByDescending(x => x.NumeroProduction).ToList();
                gridView3.SelectRow(FocusedRowHandle);
                #endregion


                TxtQteHuileTotal.ReadOnly = true;
                TxtQteOlive.ReadOnly = true;
                BtnEnregistrer.Enabled = false;
                TxtQteHuileTotal.ReadOnly = true;
                comboBoxMachine.ReadOnly = true;
                DateDebut.ReadOnly = true;
                TxtDatefinPartiel.ReadOnly = true;

                TxtQteHuilePartiel.ReadOnly = true;
                TxtDatefinPartiel.ReadOnly = true;
                BtnAjouterPartiel.Enabled = false;
                colSupprimer.OptionsColumn.AllowEdit = false;

                TxtNumBon.ReadOnly = true;


                XtraMessageBox.Show("Production Terminée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).OrderByDescending(x => x.Id).ToList();
                }
            }

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            int FocusedRowHandle = gridView3.FocusedRowHandle;
            int count = gridView3.SelectedRowsCount;
            if (count == 0)
            {


                int max = db.Productions.Max(p => p.Id);

                Production p2 = db.Productions.Find(max);


                if (String.IsNullOrEmpty(TxtQteHuile.Text))
                {
                    TxtQteHuile.ErrorText = "Quantité est obligatoire";

                    return;

                }

                decimal QuantiteInterface;
                string QuantiteInterfaceStr = TxtQteHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QuantiteInterfaceStr, out QuantiteInterface);

                int Quantite = Convert.ToInt32(QuantiteInterface);



                LigneStock LS = new LigneStock();
                decimal QteReste;
                string QteResteStr = TxtQteReste.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteResteStr, out QteReste);

                if (Quantite > Convert.ToInt32(QteReste) || Quantite <= 0)
                {

                    XtraMessageBox.Show("Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    TxtQteHuile.Text = string.Empty;
                    return;

                }


                LS.Quantite = Quantite;


                // Pile
                Pile P = new Pile();
                GridView view = searchLookUpPile.Properties.View;
                int rowHandle = view.FocusedRowHandle;
                string fieldName = "Id"; // or other field name  
                object PileSelected = view.GetRowCellValue(rowHandle, fieldName);

                if (PileSelected == null)
                {
                    XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpPile.Focus();
                    return;
                }
                else
                {
                    int IdPile = Convert.ToInt32(PileSelected);
                    P = db.Piles.Find(IdPile);

                    LS.article = P.article;
                    LS.pile = P;
                    LS.QuantitePileInitial = P.Capacite;
                    LS.Date = DateTime.Now;
                    if (P.Capacite + Quantite > P.CapaciteMax || Quantite < 0 || Quantite == 0)
                    {
                        XtraMessageBox.Show("Quantité Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        searchLookUpPile.Focus();

                        TxtQteHuile.Text = string.Empty;
                        searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                        return;

                    }

                    else
                    {

                        // recupeer tout les lignes de vente dans la grid view 
                        List<LigneStock> ListeGrid = new List<LigneStock>();
                        int rowHandle3 = 0;
                        while (gridView1.IsValidRowHandle(rowHandle3))
                        {
                            var data = gridView1.GetRow(rowHandle3) as LigneStock;
                            ListeGrid.Add(data);


                            bool isSelected = gridView1.IsRowSelected(rowHandle3);
                            rowHandle3++;
                        }




                        if (ListeGrid.Count == 0)
                        {
                            // Ajouter Ligne de vente a la gride

                            ListeGrid.Add(LS);
                            TxtQteReste.Text = (p2.QuantiteHuile - Quantite).ToString();
                            LS.QuantitePileFinal = LS.QuantitePileInitial + Quantite;
                            LS.pile.Capacite = LS.QuantitePileFinal;

                            //  db.SaveChanges();

                        }
                        else
                        {
                            var LigneExiste = ListeGrid.FirstOrDefault(x => x.pile.Id == LS.pile.Id);

                            if (LigneExiste == null)
                            {
                                ListeGrid.Add(LS);
                                int TotaleQtehuileStock = ListeGrid.Sum(x => x.Quantite);
                                TxtQteReste.Text = (p2.QuantiteHuile - TotaleQtehuileStock).ToString();
                                LS.QuantitePileFinal = LS.QuantitePileInitial + Quantite;
                                LS.pile.Capacite = LS.QuantitePileFinal;
                                //  db.SaveChanges();
                            }
                            else
                            {
                                foreach (var L in ListeGrid)
                                {
                                    if (L.pile.Id == LS.pile.Id)
                                    {
                                        var qteini = L.Quantite;

                                        L.Quantite = LS.Quantite;

                                        L.QuantitePileInitial = P.Capacite - qteini;

                                        L.QuantitePileFinal = L.QuantitePileInitial + LS.Quantite;

                                        LS.pile.Capacite = L.QuantitePileFinal;

                                        int TotaleQtehuileStock = ListeGrid.Sum(x => x.Quantite);

                                        TxtQteReste.Text = (p2.QuantiteHuile - TotaleQtehuileStock).ToString();

                                        //   db.SaveChanges();


                                    }
                                }
                            }


                        }

                        TxtQteHuile.Text = string.Empty;

                        ligneStockBindingSource.DataSource = ListeGrid;



                        TxtQteHuile.Text = string.Empty;

                        searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                        pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                        searchLookUpPile.Properties.DataSource = pileBindingSource.DataSource;
                    }

                }

            }
            else
            {
                Production prod = gridView3.GetFocusedRow() as Production;

                Production p1 = db.Productions.Where(x => x.Id == prod.Id).FirstOrDefault();


                if (String.IsNullOrEmpty(TxtQteHuile.Text))
                {
                    TxtQteHuile.ErrorText = "Quantité est obligatoire";

                    return;

                }

                decimal QuantiteInterface;
                string QuantiteInterfaceStr = TxtQteHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QuantiteInterfaceStr, out QuantiteInterface);

                int Quantite = Convert.ToInt32(QuantiteInterface);



                LigneStock LS = new LigneStock();
                decimal QteReste;
                string QteResteStr = TxtQteReste.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteResteStr, out QteReste);

                if (Quantite > Convert.ToInt32(QteReste) || Quantite <= 0)
                {

                    XtraMessageBox.Show("'Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    TxtQteHuile.Text = string.Empty;
                    return;

                }


                LS.Quantite = Quantite;


                // Pile
                Pile P = new Pile();
                GridView view = searchLookUpPile.Properties.View;
                int rowHandle = view.FocusedRowHandle;
                string fieldName = "Id"; // or other field name  
                object PileSelected = view.GetRowCellValue(rowHandle, fieldName);

                if (PileSelected == null)
                {
                    XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    searchLookUpPile.Focus();
                    return;
                }
                else
                {
                    int IdPile = Convert.ToInt32(PileSelected);
                    P = db.Piles.Find(IdPile);

                    LS.article = P.article;
                    LS.pile = P;
                    LS.QuantitePileInitial = P.Capacite;
                    LS.Date = DateTime.Now;
                    if (P.Capacite + Quantite > P.CapaciteMax || Quantite < 0 || Quantite == 0)
                    {
                        XtraMessageBox.Show("Quantité Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        searchLookUpPile.Focus();

                        TxtQteHuile.Text = string.Empty;
                        searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                        return;

                    }

                    else
                    {

                        // recupeer tout les lignes de vente dans la grid view 
                        List<LigneStock> ListeGrid = new List<LigneStock>();
                        int rowHandle3 = 0;
                        while (gridView1.IsValidRowHandle(rowHandle3))
                        {
                            var data = gridView1.GetRow(rowHandle3) as LigneStock;
                            ListeGrid.Add(data);


                            bool isSelected = gridView1.IsRowSelected(rowHandle3);
                            rowHandle3++;
                        }




                        if (ListeGrid.Count == 0)
                        {
                            // Ajouter Ligne de vente a la gride

                            ListeGrid.Add(LS);
                            TxtQteReste.Text = (p1.QuantiteHuile - Quantite).ToString();
                            LS.QuantitePileFinal = LS.QuantitePileInitial + Quantite;
                            LS.pile.Capacite = LS.QuantitePileFinal;

                            //  db.SaveChanges();

                        }
                        else
                        {
                            var LigneExiste = ListeGrid.FirstOrDefault(x => x.pile.Id == LS.pile.Id);

                            if (LigneExiste == null)
                            {
                                ListeGrid.Add(LS);
                                int TotaleQtehuileStock = ListeGrid.Sum(x => x.Quantite);
                                TxtQteReste.Text = (p1.QuantiteHuile - TotaleQtehuileStock).ToString();
                                LS.QuantitePileFinal = LS.QuantitePileInitial + Quantite;
                                LS.pile.Capacite = LS.QuantitePileFinal;
                                //  db.SaveChanges();
                            }
                            else
                            {
                                foreach (var L in ListeGrid)
                                {
                                    if (L.pile.Id == LS.pile.Id)
                                    {
                                        var qteini = L.Quantite;

                                        L.Quantite = LS.Quantite;

                                        L.QuantitePileInitial = P.Capacite - qteini;

                                        L.QuantitePileFinal = L.QuantitePileInitial + LS.Quantite;

                                        LS.pile.Capacite = L.QuantitePileFinal;

                                        int TotaleQtehuileStock = ListeGrid.Sum(x => x.Quantite);

                                        TxtQteReste.Text = (p1.QuantiteHuile - TotaleQtehuileStock).ToString();

                                        //   db.SaveChanges();


                                    }
                                }
                            }


                        }


                        TxtQteHuile.Text = string.Empty;

                        ligneStockBindingSource.DataSource = ListeGrid;



                        TxtQteHuile.Text = string.Empty;

                        searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                        pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                        searchLookUpPile.Properties.DataSource = pileBindingSource.DataSource;
                    }
                }
            }

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

            int max = db.Productions.Max(p => p.Id);

            Production LastProd = db.Productions.Find(max);

            if (XtraMessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                LigneStock L = gridView1.GetFocusedRow() as LigneStock;

                gridView1.DeleteSelectedRows();

                List<LigneStock> ListeGrid = new List<LigneStock>();

                Pile P = db.Piles.Where(x => x.Id == L.pile.Id).FirstOrDefault();
                P.Capacite -= L.Quantite;
                db.SaveChanges();

                int rowHandle3 = 0;
                while (gridView1.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView1.GetRow(rowHandle3) as LigneStock;
                    ListeGrid.Add(data);


                    bool isSelected = gridView1.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }


                int TotaleQtehuileStock = ListeGrid.Sum(x => x.Quantite);
                TxtQteReste.Text = (Convert.ToInt32(LastProd.QuantiteHuile) - TotaleQtehuileStock).ToString();


            }

        }

        private void BtnArchiver_Click(object sender, EventArgs e)
        {
            int FocusedRowHandle = gridView3.FocusedRowHandle;
            int count = gridView3.SelectedRowsCount;

            decimal zero;
            string zeroStr = TxtQteReste.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(zeroStr, out zero);
            if (zero == 0)
            {

                if (count == 0)
                {

                    int max = db.Productions.Max(p => p.Id);

                    Production LastProd = db.Productions.Find(max);


                    List<LigneStock> ListeGrid = new List<LigneStock>();

                    // remplir  ListeGrid avec les lignes de stock de la gride
                    int rowHandle3 = 0;

                    while (gridView1.IsValidRowHandle(rowHandle3))
                    {
                        var data = gridView1.GetRow(rowHandle3) as LigneStock;
                        ListeGrid.Add(data);


                        bool isSelected = gridView1.IsRowSelected(rowHandle3);
                        rowHandle3++;
                    }

                    if (ListeGrid.Count == 0)
                    {
                        XtraMessageBox.Show("Aucune ligne de stock trouvée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        LastProd.LignesStock = new List<LigneStock>();

                        MouvementStock MvtStock = new MouvementStock();

                        foreach (var L in ListeGrid)
                        {
                            decimal PrixLitre = LastProd.PUTotal;
                            LigneStock ligneStock = new LigneStock();
                            Pile P = db.Piles.Find(L.pile.Id);
                            ligneStock.pile = P;
                            ligneStock.Date = DateTime.Now;
                            ligneStock.Quantite = L.Quantite;
                            ligneStock.article = L.article;
                            ligneStock.QuantitePileInitial = L.QuantitePileInitial;
                            ligneStock.QuantitePileFinal = L.QuantitePileFinal;

                            // Mvt Stock
                            int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;
                            MvtStock.Numero = "ENP" + (lastMvtStock).ToString("D8");
                            MvtStock.pile = P;
                            MvtStock.Sens = SensStock.Entree;
                            MvtStock.Qualite = L.article;
                            MvtStock.QuantiteVendue = 0;
                            MvtStock.QuantiteProduite = L.Quantite;
                            MvtStock.QuantiteSOD = 0;
                            MvtStock.QuantiteAchetee = 0;
                            MvtStock.Commentaire = "Production N° " + LastProd.NumeroProduction;
                            MvtStock.QuantitePileInitial = L.QuantitePileInitial;
                            MvtStock.QuantitePileFinal = L.QuantitePileFinal;
                            MvtStock.QteEntrante = L.Quantite;
                            MvtStock.PrixMouvement = PrixLitre;
                            MvtStock.Prod = LastProd;

                            db.MouvementsStock.Add(MvtStock);
                            db.SaveChanges();

                            // Prix Moyen
                            P.PrixMoyen = Math.Truncate((((L.Quantite * PrixLitre) + (L.QuantitePileInitial * P.PrixMoyen)) / L.QuantitePileFinal) * 100000m) / 100000m;

                            //  P.Capacite += L.Quantite;
                            MvtStock.PMP = P.PrixMoyen;
                            db.SaveChanges();


                            LastProd.LignesStock.Add(ligneStock);

                        }
                        if (Application.OpenForms.OfType<FrmEmplacement>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmEmplacement>().First().emplacementBindingSource.DataSource = db.Emplacements.ToList();
                        }

                        if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();
                        }

                        if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();
                        }

                        if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                        {
                            string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                            Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();
                        }

                        if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList();

                        }

                        if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();
                        }

                        if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                            Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();

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
                            Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();
                        }


                    }



                    LastProd.StatutProd = StatutProduction.Stocké;


                    db.SaveChanges();

                    searchlookupMasraf.ReadOnly = false;
                    comboBoxMachine.ReadOnly = false;
                    DateDebut.ReadOnly = false;
                    comboBoxMachine.ReadOnly = false;
                    DateDebut.ReadOnly = false; ;
                    TxtQteOlive.ReadOnly = false;
                    TxtNumBon.ReadOnly = false;
                    TxtQteHuilePartiel.ReadOnly = false;
                    TxtDatefinPartiel.ReadOnly = false;

                    TxtDatefinPartiel.DateTime = DateTime.Now.AddMinutes(2);
                    BtnAjouterPartiel.Enabled = true;
                    BtnEnregistrer.Enabled = true;

                    ligneStockBindingSource.DataSource = null;
                    Root2.Visibility = LayoutVisibility.Never;
                    Root1.Visibility = LayoutVisibility.Never;
                    TxtQteHuileTotal.Text = string.Empty;
                    TxtQteReste.Text = string.Empty;


                    TxtQteHuileTotal.Text = string.Empty;
                    TxtQteReste.Text = string.Empty;
                    TxtQteOlive.Text = string.Empty;
                    TxtQteOlive.ReadOnly = false;

                    TxtQteHuile.Text = string.Empty;



                    searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                    pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                    searchLookUpPile.Properties.DataSource = pileBindingSource.DataSource;

                    //  searchlookupMasraf.EditValue = searchlookupMasraf.Properties.NullText;

                    emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;

                    //emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).ToList();
                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    }
                    searchlookupMasraf.ReadOnly = false;

                    TxtQteHuile.Text = string.Empty;
                    searchLookUpPile.Text = string.Empty;

                    comboBoxMachine.ReadOnly = false;

                    DateDebut.ReadOnly = false;

                    List<string> ListeMachine = db.Chaines.Select(x => x.Intitule).ToList();

                    comboBoxMachine.SelectedItem = ListeMachine[0];

                    XtraMessageBox.Show("Production Stockée avec succées", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnProduction.Enabled = true;
                    TxtQteOlive.Text = string.Empty;
                    comboBoxMachine.Text = string.Empty;
                    DateDebut.DateTime = DateTime.Now;
                    TxtQteHuilePartiel.Text = string.Empty;
                    TxtNumBon.Text = string.Empty;

                    ligneProductionBindingSource.DataSource = null;
                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.Emplacement != null && a.StatutProd != StatutProduction.Stocké).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmSuivie>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmSuivie>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).ToList();
                    }
                }


                else
                {
                    Production p1 = gridView3.GetFocusedRow() as Production;

                    Production prod = db.Productions.Where(x => x.Id == p1.Id).FirstOrDefault();


                    List<LigneStock> ListeGrid = new List<LigneStock>();

                    // remplir  ListeGrid avec les lignes de stock de la gride
                    int rowHandle3 = 0;

                    while (gridView1.IsValidRowHandle(rowHandle3))
                    {
                        var data = gridView1.GetRow(rowHandle3) as LigneStock;
                        ListeGrid.Add(data);


                        bool isSelected = gridView1.IsRowSelected(rowHandle3);
                        rowHandle3++;
                    }

                    if (ListeGrid.Count == 0)
                    {
                        XtraMessageBox.Show("Aucune ligne de stock trouvée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        prod.LignesStock = new List<LigneStock>();

                        MouvementStock MvtStock = new MouvementStock();

                        foreach (var L in ListeGrid)
                        {
                            decimal PrixLitre = prod.PUTotal;
                            LigneStock ligneStock = new LigneStock();
                            Pile P = db.Piles.Find(L.pile.Id);
                            ligneStock.pile = P;
                            ligneStock.Date = DateTime.Now;
                            ligneStock.Quantite = L.Quantite;
                            ligneStock.article = L.article;
                            ligneStock.QuantitePileInitial = L.QuantitePileInitial;
                            ligneStock.QuantitePileFinal = L.QuantitePileFinal;

                            // Mvt Stock
                            int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;
                            MvtStock.Numero = "ENP" + (lastMvtStock).ToString("D8");
                            MvtStock.pile = P;
                            MvtStock.Sens = SensStock.Entree;
                            MvtStock.Qualite = L.article;
                            MvtStock.QuantiteVendue = 0;
                            MvtStock.QuantiteProduite = L.Quantite;
                            MvtStock.QuantiteSOD = 0;
                            MvtStock.QuantiteAchetee = 0;
                            MvtStock.Commentaire = "Production N° " + prod.NumeroProduction;
                            MvtStock.QuantitePileInitial = L.QuantitePileInitial;
                            MvtStock.QuantitePileFinal = L.QuantitePileFinal;
                            MvtStock.QteEntrante = L.Quantite;
                            MvtStock.PrixMouvement = PrixLitre;
                            MvtStock.Prod = prod;

                            db.MouvementsStock.Add(MvtStock);
                            db.SaveChanges();

                            gridView3.RefreshRow(gridView3.FocusedRowHandle);
                            // Prix Moyen
                            P.PrixMoyen = Math.Truncate((((L.Quantite * PrixLitre) + (L.QuantitePileInitial * P.PrixMoyen)) / L.QuantitePileFinal) * 100000m) / 100000m;
                            //  P.Capacite += L.Quantite;
                            MvtStock.PMP = P.PrixMoyen;
                            db.SaveChanges();


                            prod.LignesStock.Add(ligneStock);

                        }




                        if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();
                        }

                        if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();
                        }

                        if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                        {
                            string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                            Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();

                        }

                        if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList();

                        }

                        if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                        {
                            Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();
                        }

                        if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                            Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();

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
                            Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();
                        }
                    }



                    prod.StatutProd = StatutProduction.Stocké;


                    db.SaveChanges();

                    searchlookupMasraf.ReadOnly = false;
                    comboBoxMachine.ReadOnly = false;
                    DateDebut.ReadOnly = false;
                    comboBoxMachine.ReadOnly = false;
                    DateDebut.ReadOnly = false; ;
                    TxtQteOlive.ReadOnly = false;
                    TxtNumBon.ReadOnly = false;
                    TxtQteHuilePartiel.ReadOnly = false;
                    TxtDatefinPartiel.ReadOnly = false;

                    TxtDatefinPartiel.DateTime = DateTime.Now.AddMinutes(2);
                    BtnAjouterPartiel.Enabled = true;
                    BtnEnregistrer.Enabled = true;

                    ligneStockBindingSource.DataSource = null;
                    Root2.Visibility = LayoutVisibility.Never;
                    Root1.Visibility = LayoutVisibility.Never;
                    TxtQteHuileTotal.Text = string.Empty;
                    TxtQteReste.Text = string.Empty;


                    TxtQteHuileTotal.Text = string.Empty;
                    TxtQteReste.Text = string.Empty;
                    TxtQteOlive.Text = string.Empty;
                    TxtQteOlive.ReadOnly = false;

                    TxtQteHuile.Text = string.Empty;



                    searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                    pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                    searchLookUpPile.Properties.DataSource = pileBindingSource.DataSource;



                    emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;
                    //searchlookupMasraf.EditValue = searchlookupMasraf.Properties.NullText;

                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                    }
                    searchlookupMasraf.ReadOnly = false;

                    TxtQteHuile.Text = string.Empty;
                    searchLookUpPile.Text = string.Empty;

                    comboBoxMachine.ReadOnly = false;

                    DateDebut.ReadOnly = false;

                    List<string> ListeMachine = db.Chaines.Select(x => x.Intitule).ToList();

                    comboBoxMachine.SelectedItem = ListeMachine[0];

                    XtraMessageBox.Show("Production Stockée avec succées", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnProduction.Enabled = true;
                    TxtQteOlive.Text = string.Empty;
                    comboBoxMachine.Text = string.Empty;
                    DateDebut.DateTime = DateTime.Now;
                    TxtQteHuilePartiel.Text = string.Empty;
                    TxtNumBon.Text = string.Empty;

                    ligneProductionBindingSource.DataSource = null;
                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.Emplacement != null && a.StatutProd != StatutProduction.Stocké).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                    }

                    if (Application.OpenForms.OfType<FrmSuivie>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmSuivie>().First().productionBindingSource.DataSource = db.Productions.Where(a => a.StatutProd != StatutProduction.Stocké).ToList();
                    }
                }
            }

            else
            {
                XtraMessageBox.Show("Stockage non terminé!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


















        private void searchlookupMasraf_EditValueChanged(object sender, EventArgs e)
        {
            Emplacement emplacement = new Emplacement();


            GridView view = searchlookupMasraf.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id";
            object MasrafSelected = view.GetRowCellValue(rowHandle, fieldName);
            int Qteinit = 0;
            if (MasrafSelected == null)
            {
                XtraMessageBox.Show("Choisir un emplacement ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPile.Focus();
                return;

            }
            else
            {
                db = new Model.ApplicationContext();
                int IdMasraf = Convert.ToInt32(MasrafSelected);
                emplacement = db.Emplacements.Find(IdMasraf);
                db = new Model.ApplicationContext();
                Qteinit = emplacement.Quantite;
                TxtQteOlive.Text = emplacement.Quantite.ToString();
            }


        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            db = new Model.ApplicationContext();
            //sélection d'une seule ligne à l'aide de cases à cocher

            GridView view = sender as GridView;
            view.BeginSelection();
            if (e.Action == CollectionChangeAction.Add && view.GetSelectedRows().Length > 1)
            {
                view.ClearSelection();
            }

            if (e.Action == CollectionChangeAction.Refresh)
            {
                view.SelectRow(view.FocusedRowHandle);
            }
            //an additional check
            if (e.Action == CollectionChangeAction.Remove & view.GetSelectedRows().Length == 1)
            {
                view.UnselectRow(view.FocusedRowHandle);
            }
            //      
            view.EndSelection();


            int count = gridView3.SelectedRowsCount;

            //cad selectionée production masraf
            if (count == 1)
            {
                Production P = gridView3.GetFocusedRow() as Production;
                Production prod = db.Productions.Where(x => x.Id == P.Id).FirstOrDefault();
                ligneProductionBindingSource.DataSource = null;
                pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                ligneStockBindingSource.DataSource = null;


                if (P.StatutProd != StatutProduction.EnAttente && P.TypeAchat == TypeAchat.Olive)
                {
                    List<LigneProduction> LP = db.LigneProductions.Where(x => x.prod.Id == prod.Id).ToList();

                    string valueEmp = gridView3.GetFocusedRowCellValue("Emplacement.Intitule").ToString();

                    TxtQteOlive.Text = prod.QuantiteOlive;
                    // remplire searchlookupedit :value grid in  searchlookupedit
                    if (emplacementBindingSource.DataSource != null)
                    {
                        searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;
                        searchlookupMasraf.Properties.NullText = valueEmp;
                    }
                    DateDebut.Text = prod.DateProd.ToString();
                    DateDebut.ReadOnly = true;
                    Root2.Visibility = LayoutVisibility.Always;
                    Root1.Visibility = LayoutVisibility.Always;
                    BtnProduction.Enabled = false;
                    BtnAjouterPartiel.Enabled = true;
                    TxtQteReste.Text = decimal.Round(P.QuantiteHuile, 0, MidpointRounding.AwayFromZero).ToString();
                    comboBoxMachine.ReadOnly = true;
                    searchlookupMasraf.ReadOnly = true;
                    TxtQteOlive.ReadOnly = true;


                    ligneProductionBindingSource.DataSource = LP;

                    TxtQteHuilePartiel.Text = string.Empty;
                    TxtQteHuileTotal.Text = Convert.ToInt32(LP.Sum(x => x.QuantiteHuileProduite)).ToString();


                    if ((int)prod.Machine == 0)
                    {

                        comboBoxMachine.SelectedItem = "Chaine1";
                    }
                    else if ((int)prod.Machine == 1)
                    {
                        comboBoxMachine.SelectedItem = "Chaine2";
                    }



                    if (P.StatutProd == StatutProduction.Encours)
                    {
                        colSupprimer.OptionsColumn.AllowEdit = true;
                        Achat achatDB = db.Achats.Find(P.Id);

                        int TotaleNbS = LP.Sum(x => x.NombreSacs);




                        BtnEnregistrer.Enabled = true;

                        TxtQteHuilePartiel.ReadOnly = false;
                        TxtQteHuileTotal.Text = string.Empty;
                        TxtDatefinPartiel.ReadOnly = false;
                        TxtQteHuileTotal.Text = Convert.ToInt32(LP.Sum(x => x.QuantiteHuileProduite)).ToString();
                        TxtNumBon.Text = string.Empty;
                        TxtNumBon.ReadOnly = false;
                    }

                    if (P.StatutProd == StatutProduction.Terminée)
                    {
                        TxtDatefinPartiel.Text = prod.DateFinProd.ToString();
                        TxtNumBon.Text = P.NuméroBon;
                        TxtQteHuileTotal.Text = Convert.ToInt32(P.QuantiteHuile).ToString();

                        colSupprimer.OptionsColumn.AllowEdit = false;

                        TxtQteHuilePartiel.ReadOnly = true;
                        TxtQteHuilePartiel.Text = string.Empty;
                        TxtDatefinPartiel.ReadOnly = true;
                        TxtQteHuileTotal.ReadOnly = true;
                        BtnEnregistrer.Enabled = false;
                        BtnAjouterPartiel.Enabled = false;
                        colSupprimer.OptionsColumn.AllowEdit = false;
                        TxtNumBon.ReadOnly = true;


                    }
                    if (P.StatutProd == (StatutProduction.Stocké))
                    {
                        TxtQteHuileTotal.ReadOnly = true;
                        BtnEnregistrer.Enabled = false;

                        TxtQteReste.ReadOnly = true;
                    }

                }
                //if status saisie


            }

            //deselectionner
            else
            {
                //vider searchlookupedit
                searchlookupMasraf.Properties.NullText = "";
                searchlookupMasraf.Properties.DataSource = emplacementBindingSource.DataSource;


                searchlookupMasraf.ReadOnly = false;

                TxtQteOlive.ReadOnly = false;
                TxtQteOlive.Text = string.Empty;
                TxtNumBon.Text = string.Empty;

                DateDebut.ReadOnly = false;
                Root1.Visibility = LayoutVisibility.Never;
                Root2.Visibility = LayoutVisibility.Never;
                BtnProduction.Enabled = true; ;
                BtnEnregistrer.Enabled = true;

                TxtQteReste.Text = string.Empty;



                pileBindingSource.DataSource = null;
                ligneStockBindingSource.DataSource = null;
                TxtQteHuile.Text = string.Empty;
                searchLookUpPile.Text = string.Empty;
                comboBoxMachine.ReadOnly = false;
                DateDebut.ReadOnly = false;
                ligneProductionBindingSource.DataSource = null;

                TxtQteHuilePartiel.Text = string.Empty;
                TxtQteHuileTotal.Text = string.Empty;

                TxtDatefinPartiel.DateTime = DateTime.Now;
                TxtQteHuilePartiel.ReadOnly = false;
                TxtNumBon.ReadOnly = false;
                TxtDatefinPartiel.ReadOnly = false;
                BtnAjouterPartiel.Enabled = true;
                List<string> ListeMachine = db.Chaines.Select(x => x.Intitule).ToList();


            }

        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;

            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath0 = executingFolder + "\\Image\\imagesaisie.png";
            Image imagesaisie = Image.FromFile(dbPath0);

            var dbPath = executingFolder + "\\Image\\lance.png";
            Image imageLance = Image.FromFile(dbPath);

            var dbPath2 = executingFolder + "\\Image\\Termine.png";
            Image imageTermine = Image.FromFile(dbPath2);

            var dbPath3 = executingFolder + "\\Image\\archive.png";
            Image imageArchive = Image.FromFile(dbPath3);


            for (int i = 0; i < gridView3.RowCount; i++)
            {
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

        private void BtnAjouterPartiel_Click(object sender, EventArgs e)
        {
            List<LigneProduction> ListeGrid = new List<LigneProduction>();

            if (string.IsNullOrEmpty(TxtQteHuilePartiel.Text))
            {
                XtraMessageBox.Show("Quantité Huile est Obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (string.IsNullOrEmpty(TxtNumBon.Text))
            {
                XtraMessageBox.Show("Num Bon est Obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int FocusedRowHandle = gridView3.FocusedRowHandle;
            int count = gridView3.SelectedRowsCount;
            if (count == 0)
            {
                db = new Model.ApplicationContext();
                int max = db.Productions.Max(p => p.Id);
                Production LastProd = db.Productions.Find(max);


                LigneProduction LP = new LigneProduction();
                int numB = Convert.ToInt32(TxtNumBon.Text);
                LigneProduction LProdExiste = db.LigneProductions.FirstOrDefault(a => a.NuméroBon == numB && a.prod.Id != LastProd.Id);

                if (LProdExiste != null)
                {
                    XtraMessageBox.Show("Numéro de Bon existe déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtNumBon.Text = "";

                    return;

                }
                else
                {
                    LP.NuméroBon = Convert.ToInt32(TxtNumBon.Text);

                }


                TxtQteHuileTotal.ReadOnly = true;


                int rowHandle3 = 0;



                // recupeer tout les lignes de la ligne de production dans la grid view 

                while (gridView2.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView2.GetRow(rowHandle3) as LigneProduction;
                    ListeGrid.Add(data);


                    bool isSelected = gridView2.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }


                {

                    if (string.IsNullOrEmpty(TxtQteHuilePartiel.Text))
                    {
                        LP.QuantiteHuileProduite = 0;
                    }
                    else
                    {
                        LP.QuantiteHuileProduite = Convert.ToInt32(TxtQteHuilePartiel.Text);
                    }

                    LP.DateFinProd = TxtDatefinPartiel.DateTime;
                    LP.prod = LastProd;
                    LP.NuméroBon = Convert.ToInt32(TxtNumBon.Text);

                    db.LigneProductions.Add(LP);

                    db.SaveChanges();


                    LastProd.NuméroBon = LP.NuméroBon.ToString();
                }

                decimal QteTotaleHuile = 0;







                // Ajouter Ligne de vente a la gride 
                ListeGrid.Add(LP);


                QteTotaleHuile = ListeGrid.Sum(x => x.QuantiteHuileProduite);
                TxtQteHuileTotal.Text = QteTotaleHuile.ToString();
                // TxtQteHuilePartiel.Text = string.Empty;


                ligneProductionBindingSource.DataSource = ListeGrid;

            }
            else
            {
                db = new Model.ApplicationContext();
                Production p1 = gridView3.GetFocusedRow() as Production;

                Production prod = db.Productions.Where(x => x.Id == p1.Id).FirstOrDefault();


                LigneProduction LP = new LigneProduction();
                int numB = Convert.ToInt32(TxtNumBon.Text);
                LigneProduction LProdExiste = db.LigneProductions.FirstOrDefault(a => a.NuméroBon == numB && a.prod.Id != prod.Id);

                if (LProdExiste != null)
                {
                    XtraMessageBox.Show("Numéro de Bon existe déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtNumBon.Text = "";

                    return;

                }
                else
                {
                    prod.NuméroBon = TxtNumBon.Text;

                }


                TxtQteHuileTotal.ReadOnly = true;


                int rowHandle3 = 0;



                // recupeer tout les lignes de la ligne de production dans la grid view 

                while (gridView2.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView2.GetRow(rowHandle3) as LigneProduction;
                    ListeGrid.Add(data);


                    bool isSelected = gridView2.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }


                {

                    if (string.IsNullOrEmpty(TxtQteHuilePartiel.Text))
                    {
                        LP.QuantiteHuileProduite = 0;
                    }
                    else
                    {
                        LP.QuantiteHuileProduite = Convert.ToInt32(TxtQteHuilePartiel.Text);
                    }

                    LP.DateFinProd = TxtDatefinPartiel.DateTime;
                    LP.prod = prod;
                    LP.NuméroBon = Convert.ToInt32(TxtNumBon.Text);

                    db.LigneProductions.Add(LP);

                    db.SaveChanges();
                }

                decimal QteTotaleHuile = 0;



                // Ajouter Ligne de vente a la gride 
                ListeGrid.Add(LP);


                QteTotaleHuile = ListeGrid.Sum(x => x.QuantiteHuileProduite);
                TxtQteHuileTotal.Text = QteTotaleHuile.ToString();
                // TxtQteHuilePartiel.Text = string.Empty;


                ligneProductionBindingSource.DataSource = ListeGrid;

            }

            #region refrech emplacement
            db = new Model.ApplicationContext();

            if (Application.OpenForms.OfType<FrmEmplacement>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmEmplacement>().First().emplacementBindingSource.DataSource = db.Emplacements.ToList();
            }

           
            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
            {

                if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("Nchira"))
                {
                    Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.Nchira).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                }

                else if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("OliveVif"))
                {
                    Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

                }

            }
            #endregion

        }

        private void searchLookUpPile_EditValueChanged(object sender, EventArgs e)
        {
            Pile P = new Pile();


            GridView view = searchLookUpPile.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id";
            object PileSelected = view.GetRowCellValue(rowHandle, fieldName);

            if (PileSelected == null)
            {
                XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPile.Focus();
                return;

            }
            else
            {

                int IdPile = Convert.ToInt32(PileSelected);
                P = db.Piles.Find(IdPile);
            }
            decimal QteHuileReste;
            string QteHuileResteStr = TxtQteReste.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QteHuileResteStr, out QteHuileReste);

            int CapaciteVide = P.CapaciteVide;

            if (CapaciteVide >= QteHuileReste)
            {
                TxtQteHuile.Text = TxtQteReste.Text;

            }
            else if (CapaciteVide < QteHuileReste)
            {
                TxtQteHuile.Text = CapaciteVide.ToString();

            }

        }
    }
}