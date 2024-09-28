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
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraLayout.Utils;
using System.Globalization;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmProduction : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmProduction _FrmProduction;

        string decimalSeparator;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        public static FrmProduction InstanceFrmProduction
        {
            get
            {
                if (_FrmProduction == null)
                    _FrmProduction = new FrmProduction();
                return _FrmProduction;
            }
        }

        public FrmProduction()
        {

            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmProduction_Load(object sender, EventArgs e)
        {
            TxtQteHuileTotal.ReadOnly = true;
            achatBindingSource.DataSource = db.Achats.Where(x => x.StatutProd != StatutProduction.Stocké && x.TypeAchat == TypeAchat.Base || x.StatutProd != StatutProduction.Terminée && x.TypeAchat == TypeAchat.Service).OrderByDescending(x => x.Date).ToList();

            TxtNombreSacs.ReadOnly = true;

            DateDebut.DateTime = DateTime.Now;

            TxtDatefinPartiel.DateTime = DateTime.Now.AddMinutes(2);

            /***************liste Machine***************/
            List<string> ListeMachine = Enum.GetNames(typeof(chaine)).ToList();
            if (ListeMachine != null)
            {
                foreach (var Machine in ListeMachine)
                {
                    comboBoxMachine.Properties.Items.Add(Machine);
                }

                comboBoxMachine.SelectedIndex = 0;
                if (ListeMachine.Count > 0)
                    comboBoxMachine.SelectedItem = ListeMachine[0];

            }

        }

        private void FrmProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmProduction = null;
        }

        //Selection
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //sélection d'une seule ligne à l'aide de cases à cocher

            GridView view = sender as GridView;
            view.BeginSelection();
            if (e.Action == CollectionChangeAction.Add && view.GetSelectedRows().Length > 1)
                view.ClearSelection();
            if (e.Action == CollectionChangeAction.Refresh)
                view.SelectRow(view.FocusedRowHandle);
            //an additional check
            if (e.Action == CollectionChangeAction.Remove & view.GetSelectedRows().Length == 1)
                view.UnselectRow(view.FocusedRowHandle);
            //      
            view.EndSelection();





            int count = gridView1.SelectedRowsCount;

            //cad selectionée achat
            if (count == 1)
            {
                Achat A = gridView1.GetFocusedRow() as Achat;
                Production prod = db.Productions.Where(x => x.Achat.Id == A.Id).FirstOrDefault();

                TxtQteOlive.Text = decimal.Round(A.Poids, 0, MidpointRounding.AwayFromZero).ToString();
                TxtNombreSacs.Text = A.NbSacs.ToString();
                TxtTypeAchat.Text = A.TypeAchat.ToString();
                ligneProductionBindingSource.DataSource = null;
                pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
                stockBindingSource.DataSource = null;


                //if (A.StatutProd != (StatutProduction.EnAttente) && A.TypeAchat == TypeAchat.Service)
                //{
                //    List<LigneProduction> LP = db.LigneProductions.Where(x => x.prod.Id == prod.Id).ToList();
                //    TxtQteHuileTotal.Text = LP.Sum(x => x.QuantiteHuileProduite).ToString();
                //    DateDebut.ReadOnly = true;
                //    BtnProduction.Enabled = false;
                //    if ((int)prod.Machine == 0)
                //    {

                //        comboBoxMachine.SelectedItem = "Chaine1";
                //    }
                //    else if ((int)prod.Machine == 1)
                //    {
                //        comboBoxMachine.SelectedItem = "Chaine2";
                //    }

                //    comboBoxMachine.ReadOnly = true;
                //    Root1.Visibility = LayoutVisibility.Always;
                //    ligneProductionBindingSource.DataSource = LP;


                //    if (A.StatutProd == (StatutProduction.Encours))
                //    {
                //        colSupprimer.OptionsColumn.AllowEdit = true;
                //        TxtDatefinPartiel.ReadOnly = false;
                //        Root2.Visibility = LayoutVisibility.Never;
                //        Achat achatDB = db.Achats.Find(A.Id);

                //        TxtNumBon.Text = A.NuméroBon;

                //        int TotaleNbS = LP.Sum(x => x.NombreSacs);
                //        int NombreSacs = Convert.ToInt32(TxtNombreSacs.Text);
                //        int RestNombreSac = NombreSacs - TotaleNbS;
                //        TxtNombreSacsPartiel.Text = RestNombreSac.ToString();

                //        BtnAjouterPartiel.Enabled = true;
                //        TxtQteHuileTotal.ReadOnly = true;
                //        BtnEnregistrer.Enabled = true;
                //        TxtNombreSacsPartiel.ReadOnly = false;
                //        TxtQteHuilePartiel.ReadOnly = false;

                //        TxtQteHuileTotal.Text = LP.Sum(x => x.QuantiteHuileProduite).ToString();
                //    }

                //    if (A.StatutProd == StatutProduction.Terminée)
                //    {
                //        TxtNumBon.Text = prod.NuméroBon.ToString();
                //        TxtNumBon.ReadOnly = true;

                //        colSupprimer.OptionsColumn.AllowEdit = false;
                //        ligneProductionBindingSource.DataSource = LP;
                //        ligneProductionBindingSource.DataSource = LP;
                //        TxtNombreSacsPartiel.Text = string.Empty;
                //        TxtQteHuilePartiel.Text = string.Empty;
                //        TxtQteHuileTotal.Text = LP.Sum(x => x.QuantiteHuileProduite).ToString();

                //        TxtQteHuileTotal.Text = decimal.Round(A.QteLitre, 0, MidpointRounding.AwayFromZero).ToString();
                //        ligneProductionBindingSource.DataSource = db.LigneProductions.Where(x => x.prod.Id == prod.Id).ToList();

                //        TxtQteHuileTotal.ReadOnly = true;
                //        BtnEnregistrer.Enabled = false;


                //    }
                //}

                //else 

                if (A.StatutProd == StatutProduction.EnAttente && A.TypeAchat == TypeAchat.Service)
                {

                    DateDebut.ReadOnly = false;
                    comboBoxMachine.ReadOnly = false;
                    Root1.Visibility = LayoutVisibility.Never;
                    Root2.Visibility = LayoutVisibility.Never;
                    BtnEnregistrer.Enabled = true;
                    TxtQteHuileTotal.Text = string.Empty;
                    BtnProduction.Enabled = true;
                    List<string> ListeMachine = Enum.GetNames(typeof(chaine)).ToList();
                    comboBoxMachine.SelectedItem = ListeMachine[0];


                }

                if (A.StatutProd != StatutProduction.EnAttente && A.TypeAchat == TypeAchat.Base)
                {
                    List<LigneProduction> LP = db.LigneProductions.Where(x => x.prod.Id == prod.Id).ToList();

                    DateDebut.ReadOnly = true;
                    Root2.Visibility = LayoutVisibility.Always;
                    Root1.Visibility = LayoutVisibility.Always;
                    BtnProduction.Enabled = false;
                    BtnAjouterPartiel.Enabled = true;
                    TxtQteReste.Text = decimal.Round(A.QteLitre, 0, MidpointRounding.AwayFromZero).ToString();
                    comboBoxMachine.ReadOnly = true;



                    ligneProductionBindingSource.DataSource = LP;

                    TxtQteHuilePartiel.Text = string.Empty;
                    TxtQteHuileTotal.Text = LP.Sum(x => x.QuantiteHuileProduite).ToString();



                    if ((int)prod.Machine == 0)
                    {

                        comboBoxMachine.SelectedItem = "Chaine1";
                    }
                    else if ((int)prod.Machine == 1)
                    {
                        comboBoxMachine.SelectedItem = "Chaine2";
                    }



                    if (A.StatutProd == StatutProduction.Encours)
                    {
                        colSupprimer.OptionsColumn.AllowEdit = true;
                        Achat achatDB = db.Achats.Find(A.Id);

                        int TotaleNbS = LP.Sum(x => x.NombreSacs);
                        int NombreSacs = Convert.ToInt32(TxtNombreSacs.Text);
                        int RestNombreSac = NombreSacs - TotaleNbS;
                        TxtNombreSacsPartiel.Text = RestNombreSac.ToString();

                        BtnEnregistrer.Enabled = true;
                        TxtNombreSacsPartiel.ReadOnly = false;
                        TxtQteHuilePartiel.ReadOnly = false;
                        TxtQteHuileTotal.Text = string.Empty;
                        TxtDatefinPartiel.ReadOnly = false;
                        TxtQteHuileTotal.Text = LP.Sum(x => x.QuantiteHuileProduite).ToString();
                        TxtNumBon.Text = string.Empty;
                        TxtNumBon.ReadOnly = false;
                    }

                    if (A.StatutProd == StatutProduction.Terminée)
                    {
                        TxtNumBon.Text = A.NuméroBon;

                        colSupprimer.OptionsColumn.AllowEdit = false;
                        TxtNombreSacsPartiel.Text = string.Empty;
                        TxtNombreSacsPartiel.ReadOnly = true;
                        TxtQteHuilePartiel.ReadOnly = true;
                        TxtQteHuilePartiel.Text = string.Empty;
                        TxtDatefinPartiel.ReadOnly = true;
                        TxtQteHuileTotal.ReadOnly = true;
                        BtnEnregistrer.Enabled = false;
                        BtnAjouterPartiel.Enabled = false;
                        colSupprimer.OptionsColumn.AllowEdit = false;
                        TxtNumBon.ReadOnly = true;


                    }
                    if (A.StatutProd == (StatutProduction.Stocké))
                    {
                        TxtQteHuileTotal.ReadOnly = true;
                        BtnEnregistrer.Enabled = false;

                        TxtQteReste.ReadOnly = true;
                    }

                }
                //if status saisie
                else if (A.StatutProd == StatutProduction.EnAttente && A.TypeAchat == TypeAchat.Base)
                {


                    DateDebut.ReadOnly = false;

                    comboBoxMachine.ReadOnly = false;
                    Root2.Visibility = LayoutVisibility.Never;
                    Root1.Visibility = LayoutVisibility.Never;
                    BtnEnregistrer.Enabled = true;
                    TxtQteHuile.Text = string.Empty;

                    stockBindingSource.DataSource = null;

                    TxtQteHuileTotal.Text = string.Empty;
                    TxtQteReste.Text = string.Empty;
                    BtnProduction.Enabled = true;

                    TxtNumBon.ReadOnly = false;


                    TxtQteHuile.Text = string.Empty;
                    List<string> ListeMachine = Enum.GetNames(typeof(chaine)).ToList();

                    comboBoxMachine.SelectedItem = ListeMachine[0];

                }

            }

            //deselectionner
            else
            {
                TxtNumBon.Text = string.Empty;

                DateDebut.ReadOnly = false;
                Root1.Visibility = LayoutVisibility.Never;
                Root2.Visibility = LayoutVisibility.Never;
                BtnProduction.Enabled = true; ;
                BtnEnregistrer.Enabled = true;

                TxtQteReste.Text = string.Empty;
                TxtQteOlive.Text = string.Empty;
                TxtNombreSacs.Text = string.Empty;
                TxtTypeAchat.Text = string.Empty;
                pileBindingSource.DataSource = null;
                stockBindingSource.DataSource = null;
                TxtQteHuile.Text = string.Empty;
                searchLookUpPile.Text = string.Empty;
                comboBoxMachine.ReadOnly = false;
                DateDebut.ReadOnly = false;
                ligneProductionBindingSource.DataSource = null;
                TxtNombreSacsPartiel.Text = string.Empty;
                TxtQteHuilePartiel.Text = string.Empty;
                TxtQteHuileTotal.Text = string.Empty;

                TxtDatefinPartiel.DateTime = DateTime.Now;

                List<string> ListeMachine = Enum.GetNames(typeof(chaine)).ToList();

                comboBoxMachine.SelectedItem = ListeMachine[0];

            }


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



        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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


            for (int i = 0; i < gridView1.RowCount; i++)
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



        private void TxtDatefinPartiel_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = DateDebut.DateTime;
            DateTime DateMaxJour = TxtDatefinPartiel.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



        private void BtnProduction_Click(object sender, EventArgs e)
        {


            TxtQteHuileTotal.ReadOnly = true;
            int FocusedRowHandle = gridView1.FocusedRowHandle;
            int count = gridView1.SelectedRowsCount;
            // si la ligne n'est pas seléctionner
            if (count == 0)
            {
                XtraMessageBox.Show("Merci de sélectionner une ligne", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                Production prod = new Production();

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

                var A = gridView1.GetFocusedRow() as Achat;

                Achat achatDB = db.Achats.Find(A.Id);
                prod.Achat = achatDB;
                prod.DateProd = DateDebut.DateTime;

                TxtNombreSacsPartiel.Text = achatDB.NbSacs.ToString();

                BtnEnregistrer.Visible = false;


                if (TxtTypeAchat.Text.Equals("Base"))
                {

                    achatDB.StatutProd = StatutProduction.Encours;

                    db.SaveChanges();
                    prod.StatutProd = StatutProduction.Encours;

                    db.Productions.Add(prod);
                    db.SaveChanges();
                    prod.NumeroProduction = "P" + (prod.Id).ToString("D8");
                    db.SaveChanges();
                    #region  refresh grid keeping selected
                    achatBindingSource.DataSource = db.Achats.Where(x => x.StatutProd != StatutProduction.Stocké && x.TypeAchat == TypeAchat.Base || x.StatutProd != StatutProduction.Terminée && x.TypeAchat == TypeAchat.Service).OrderByDescending(x => x.Date).OrderByDescending(x => x.Date).ToList();
                    gridView1.SelectRow(FocusedRowHandle);
                    #endregion
                    gridView1.RefreshRow(gridView1.FocusedRowHandle);
                    Root1.Visibility = LayoutVisibility.Always;
                    Root2.Visibility = LayoutVisibility.Always;
                    BtnProduction.Enabled = false;
                    gridView1.RefreshRow(FocusedRowHandle);
                    comboBoxMachine.ReadOnly = true;
                    DateDebut.ReadOnly = true;



                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

                    if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


                    if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.ToList();


                    if (Application.OpenForms.OfType<FrmSuivie>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmSuivie>().First().productionBindingSource.DataSource = db.Productions.ToList();

                }

                else if (TxtTypeAchat.Text.Equals("Service"))
                {

                    achatDB.StatutProd = StatutProduction.Terminée;
                    db.SaveChanges();
                    prod.StatutProd = StatutProduction.Terminée;
                    prod.NuméroBon = achatDB.NuméroBon;
                    db.Productions.Add(prod);
                    db.SaveChanges();
                    prod.NumeroProduction = "P" + (prod.Id).ToString("D8");
                    db.SaveChanges();

                    BtnProduction.Enabled = false;
                    comboBoxMachine.ReadOnly = true;
                    DateDebut.ReadOnly = true;
                    Root1.Visibility = LayoutVisibility.Never;


                    #region  refresh grid keeping selected
                    achatBindingSource.DataSource = db.Achats.Where(x => x.StatutProd != StatutProduction.Stocké && x.TypeAchat == TypeAchat.Base || x.StatutProd != StatutProduction.Terminée && x.TypeAchat == TypeAchat.Service).OrderByDescending(x => x.Date).OrderByDescending(x => x.Date).ToList();

                    #endregion

                    XtraMessageBox.Show("Production Terminée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TxtTypeAchat.Text = string.Empty;
                    TxtNombreSacs.Text = string.Empty;
                    TxtQteOlive.Text = string.Empty;

                    BtnProduction.Enabled = true;
                    comboBoxMachine.ReadOnly = false;
                    DateDebut.ReadOnly = false;
                    List<string> ListeMachine = Enum.GetNames(typeof(chaine)).ToList();
                    comboBoxMachine.SelectedIndex = 0;
                    if (ListeMachine.Count > 0)
                        comboBoxMachine.SelectedItem = ListeMachine[0];


                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

                    if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


                    if (Application.OpenForms.OfType<FrmSuivie>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmSuivie>().First().productionBindingSource.DataSource = db.Productions.ToList();


                    if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.ToList();



                }
            }
        }


        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {

            List<LigneProduction> ListeGrid = new List<LigneProduction>();
            int rowHandle = 0;
            while (gridView4.IsValidRowHandle(rowHandle))
            {
                var data = gridView4.GetRow(rowHandle) as LigneProduction;
                ListeGrid.Add(data);
                rowHandle++;
            }

            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("Ajouter une ligne de Production!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            TxtQteHuileTotal.ReadOnly = true;
            decimal QteHuileTotal;
            string QteHuileTotalStr = TxtQteHuileTotal.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QteHuileTotalStr, out QteHuileTotal);

            Achat A1 = gridView1.GetFocusedRow() as Achat;

            Production P = db.Productions.Where(x => x.Achat.Id == A1.Id).FirstOrDefault();
            List<LigneProduction> ListeLP = db.LigneProductions.Where(x => x.prod.Id == P.Id).ToList();
            DateTime MaxDate = default(DateTime);
            DateTime MinDate = default(DateTime);
            if (ListeLP.Count > 0)
            {
                MaxDate = db.LigneProductions.Where(x => x.prod.Id == P.Id).Max(x => x.DateFinProd);
                MinDate = db.LigneProductions.Where(x => x.prod.Id == P.Id).Min(x => x.DateFinProd);
            }
            else
            {
                MaxDate = DateTime.Now.AddMinutes(2);
                MinDate = DateTime.Now;

            }

            int FocusedRowHandle = gridView1.FocusedRowHandle;

            if (TxtTypeAchat.Text.Equals("Base"))
            {

                TxtQteReste.Text = decimal.Round(QteHuileTotal, 0, MidpointRounding.AwayFromZero).ToString();
                TxtQteHuileTotal.ReadOnly = true;
                decimal QteHuile;
                string QteHuileStr = TxtQteHuile.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
                decimal.TryParse(QteHuileStr, out QteHuile);
                P.QuantiteHuile = QteHuileTotal;
                P.DateFinProd = MaxDate;
                P.DateProd = DateDebut.DateTime;
                P.StatutProd = StatutProduction.Terminée;
                P.Achat.QteLitre = QteHuileTotal;
                P.Achat.QteHuile= QteHuileTotal;
                P.Achat.QteRestStockhuile = QteHuile;
                P.Achat.StatutProd = StatutProduction.Terminée;
                var duree = MaxDate - MinDate;
                P.dureeProduction = duree.ToString(@"hh\:mm");
                P.NuméroBon = TxtNumBon.Text;
                P.Achat.NuméroBon = P.NuméroBon;
                db.SaveChanges();

                if (P.Achat.PrixLitre > 0)
                {
                    P.Achat.MontantReglement = decimal.Multiply(P.Achat.PrixLitre , QteHuileTotal);

                    if (P.Achat.AvecAmpo== true)
                    {
                        P.Achat.MtAdeduire = decimal.Divide(P.Achat.MontantReglement, 100);
                        P.Achat.MtAPayeAvecImpo = decimal.Subtract(P.Achat.MontantReglement, P.Achat.MtAdeduire);
                    }
                    else
                    {
                        P.Achat.MtAPayeAvecImpo = P.Achat.MontantReglement;
                    }

                }
                db.SaveChanges();

                #region Ajouter Littrage Avance Sur Achats Type Base
                Agriculteur Agriculteur = db.Agriculteurs.Find(P.Achat.Founisseur.Id);
                decimal Solde = Agriculteur.Solde;
                List<Achat> ListeAchats = db.Achats.Where(x => x.TypeAchat == TypeAchat.Base && x.Founisseur.Id == Agriculteur.Id && x.MontantReglement > 0 && (x.EtatAchat == EtatAchat.NonReglee || x.EtatAchat == EtatAchat.PartiellementReglee)).OrderBy(x => x.Date).ToList();
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
                            HP.Commentaire = "Règlement Automatique Par Avance ";
                            HP.TypeAchat = AchatDb.TypeAchat;
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
                            HP.Commentaire = "Reglement Automatique Par Avance ";
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
                    Application.OpenForms.OfType<FrmFournisseur>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id,x.Numero, x.Nom, x.Prenom, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
                }

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().First().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m  , TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m , x.SoldeAgriculteurAvecSens }).ToList();



                gridView1.RefreshRow(FocusedRowHandle);
                BtnEnregistrer.Enabled = false;
                TxtQteHuileTotal.ReadOnly = true;
                comboBoxMachine.ReadOnly = true;
                DateDebut.ReadOnly = true;
                TxtDatefinPartiel.ReadOnly = true;
                TxtNombreSacsPartiel.ReadOnly = true;
                TxtQteHuilePartiel.ReadOnly = true;
                TxtDatefinPartiel.ReadOnly = true;
                BtnAjouterPartiel.Enabled = false;
                colSupprimer.OptionsColumn.AllowEdit = false;

                TxtNumBon.ReadOnly = true;


                XtraMessageBox.Show("Production Terminée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

                if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();

                if (Application.OpenForms.OfType<FrmHistoriquePaiementAchat>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmHistoriquePaiementAchat>().First().historiquePaiementAchatsBindingSource.DataSource = db.HistoriquePaiementAchats.ToList();

                if (Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmDetailAchatMvmCaissecs>().First().historiquePaiementAchatsBindingSource.DataSource = db.HistoriquePaiementAchats.ToList();

                if (Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmDetailServiceMvmCaisse>().First().historiquePaiementAchatsBindingSource.DataSource = db.HistoriquePaiementAchats.ToList();



                if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.ToList();




                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {

                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
                }
            }

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {


            Achat A1 = gridView1.GetFocusedRow() as Achat;

            if (String.IsNullOrEmpty(TxtQteHuile.Text))
            {
                TxtQteHuile.ErrorText = "Quantité est obligatoire";

                return;

            }


            int Quantite;

            Quantite = Convert.ToInt32(TxtQteHuile.Text);

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
                    while (gridView3.IsValidRowHandle(rowHandle3))
                    {
                        var data = gridView3.GetRow(rowHandle3) as LigneStock;
                        ListeGrid.Add(data);


                        bool isSelected = gridView3.IsRowSelected(rowHandle3);
                        rowHandle3++;
                    }




                    if (ListeGrid.Count == 0)
                    {
                        // Ajouter Ligne de vente a la gride

                        ListeGrid.Add(LS);
                        TxtQteReste.Text = (A1.QteLitre - Quantite).ToString();
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
                            TxtQteReste.Text = (A1.QteLitre - TotaleQtehuileStock).ToString();
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

                                    TxtQteReste.Text = (A1.QteLitre - TotaleQtehuileStock).ToString();

                                    //   db.SaveChanges();


                                }
                            }
                        }


                    }


                    stockBindingSource.DataSource = ListeGrid;

                    TxtQteHuile.Text = string.Empty;
                    searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;

                }
            }
        }

        private void repositoryBtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                LigneProduction L = gridView4.GetFocusedRow() as LigneProduction;

                LigneProduction LigneProductionDb = db.LigneProductions.Find(L.Id);
                db.LigneProductions.Remove(LigneProductionDb);
                db.SaveChanges();

                gridView4.DeleteSelectedRows();

                List<LigneProduction> ListeGrid = new List<LigneProduction>();

                int rowHandle3 = 0;
                while (gridView4.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView4.GetRow(rowHandle3) as LigneProduction;
                    ListeGrid.Add(data);


                    bool isSelected = gridView4.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }

                int TotaleNbS = ListeGrid.Sum(x => x.NombreSacs);
                int NombreSacs = Convert.ToInt32(TxtNombreSacs.Text);
                int RestNombreSac = NombreSacs - TotaleNbS;
                TxtNombreSacsPartiel.Text = RestNombreSac.ToString();
                TxtQteHuileTotal.Text = ListeGrid.Sum(x => x.QuantiteHuileProduite).ToString();
            }
        }

        private void repositoryItemButtonsupprimmerPile_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                Achat A1 = gridView1.GetFocusedRow() as Achat;
                LigneStock L = gridView3.GetFocusedRow() as LigneStock;

                gridView3.DeleteSelectedRows();

                List<LigneStock> ListeGrid = new List<LigneStock>();

                Pile P = db.Piles.Where(x => x.Id == L.pile.Id).FirstOrDefault();
                P.Capacite -= L.Quantite;
                db.SaveChanges();

                int rowHandle3 = 0;
                while (gridView3.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView3.GetRow(rowHandle3) as LigneStock;
                    ListeGrid.Add(data);


                    bool isSelected = gridView3.IsRowSelected(rowHandle3);
                    rowHandle3++;
                }


                int TotaleQtehuileStock = ListeGrid.Sum(x => x.Quantite);
                TxtQteReste.Text = (A1.QteLitre - TotaleQtehuileStock).ToString();


            }
        }

        private void BtnArchiver_Click(object sender, EventArgs e)
        {
            decimal zero;
            string zeroStr = TxtQteReste.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(zeroStr, out zero);
            if (zero == 0)
            {
                Achat A1 = gridView1.GetFocusedRow() as Achat;

                Production prod = db.Productions.Where(x => x.Achat.Id == A1.Id).FirstOrDefault();

                int FocusedRowHandle = gridView1.FocusedRowHandle;
                int count = gridView1.SelectedRowsCount;
                if (count == 0)
                {
                    XtraMessageBox.Show("Merci de sélectionner une ligne", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<LigneStock> ListeGrid = new List<LigneStock>();

                // remplir  ListeGrid avec les lignes de stock de la gride
                int rowHandle3 = 0;

                while (gridView3.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView3.GetRow(rowHandle3) as LigneStock;
                    ListeGrid.Add(data);


                    bool isSelected = gridView3.IsRowSelected(rowHandle3);
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
                        Achat Achatdb = gridView1.GetFocusedRow() as Achat;

                        Production productiondb = db.Productions.Where(x => x.Achat.Id == Achatdb.Id).FirstOrDefault();
                        decimal PrixLitre = productiondb.Achat.PrixLitre;
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
                        MvtStock.Commentaire = "Production N° " + productiondb.NumeroProduction;
                        MvtStock.Achat = db.Achats.Find(productiondb.Achat.Id);
                        MvtStock.QuantitePileInitial = L.QuantitePileInitial;
                        MvtStock.QuantitePileFinal = L.QuantitePileFinal;
                        MvtStock.QteEntrante = L.Quantite;
                        MvtStock.PrixMouvement = PrixLitre;
                       
                        MvtStock.Prod = productiondb;
                        MvtStock.Code = Achatdb.Numero;
                        MvtStock.Intitulé = Achatdb.Founisseur.FullName;
                        db.MouvementsStock.Add(MvtStock);
                        db.SaveChanges();

                        // Prix Moyen
                        P.PrixMoyen = Math.Truncate((((L.Quantite * PrixLitre) + (L.QuantitePileInitial * P.PrixMoyen)) / L.QuantitePileFinal) * 100000m) / 100000m;
                        db.SaveChanges();

                        MvtStock.PMP = P.PrixMoyen;
                        db.SaveChanges();

                        prod.LignesStock.Add(ligneStock);

                    }


                    if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();


                    if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();

                    if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    {
                        string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                        Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();


                    }


                    if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                    { Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList(); }


                    if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();



                    if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmTransfertPile>().First().PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

                    if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmTransfertPile>().First().PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();



                    if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();

                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();
                    }
                    if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();

                }



                prod.StatutProd = StatutProduction.Stocké;
                prod.Achat.StatutProd = StatutProduction.Stocké;

                db.SaveChanges();


                achatBindingSource.DataSource = db.Achats.Where(x => x.StatutProd != StatutProduction.Stocké && x.TypeAchat == TypeAchat.Base || x.StatutProd != StatutProduction.Terminée && x.TypeAchat == TypeAchat.Service).OrderByDescending(x => x.Date).ToList(); ;

                stockBindingSource.DataSource = null;
                Root2.Visibility = LayoutVisibility.Never;
                Root1.Visibility = LayoutVisibility.Never;
                TxtQteHuileTotal.Text = string.Empty;
                TxtQteReste.Text = string.Empty;
                TxtQteOlive.Text = string.Empty;
                TxtNombreSacs.Text = string.Empty;
                TxtTypeAchat.Text = string.Empty;
                TxtQteHuile.Text = string.Empty;
                searchLookUpPile.Text = string.Empty;

                comboBoxMachine.ReadOnly = false;

                DateDebut.ReadOnly = false;

                List<string> ListeMachine = Enum.GetNames(typeof(chaine)).ToList();

                comboBoxMachine.SelectedItem = ListeMachine[0];

                XtraMessageBox.Show("Production Stockée avec succées", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BtnProduction.Enabled = true;



                if (Application.OpenForms.OfType<FrmListeProduction>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeProduction>().First().productionBindingSource.DataSource = db.Productions.ToList();



                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();



                if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


                if (Application.OpenForms.OfType<FrmSuivie>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmSuivie>().First().productionBindingSource.DataSource = db.Productions.ToList();


            }
            else
            {
                XtraMessageBox.Show("Stockage non terminé!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void BtnAjouterPartiel_Click(object sender, EventArgs e)
        {
            Achat A1 = gridView1.GetFocusedRow() as Achat;
            List<LigneProduction> ListeGrid = new List<LigneProduction>();
            int TotaleNbSacs = ListeGrid.Sum(x => x.NombreSacs) + Convert.ToInt32(TxtNombreSacsPartiel.Text);

            int rowHandle3 = 0;

            if (string.IsNullOrEmpty(TxtQteHuilePartiel.Text) && A1.TypeAchat == TypeAchat.Base)
            {
                XtraMessageBox.Show("Quantité Huile est Obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (string.IsNullOrEmpty(TxtNumBon.Text) && A1.TypeAchat == TypeAchat.Base)
            {
                XtraMessageBox.Show("Num Bon est Obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Achat AchatExiste = db.Achats.FirstOrDefault(a => a.NuméroBon.Equals(TxtNumBon.Text) && (a.TypeAchat == TypeAchat.Huile || a.TypeAchat == TypeAchat.Base));

            if (AchatExiste != null)
            {
                XtraMessageBox.Show("Numéro de Bon existe déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNumBon.Text = "";

                return;

            }


            TxtQteHuileTotal.ReadOnly = true;

            Production prod = db.Productions.Where(x => x.Achat.Id == A1.Id).FirstOrDefault();

            LigneProduction LP = new LigneProduction();


            // recupeer tout les lignes de la ligne de production dans la grid view 

            while (gridView4.IsValidRowHandle(rowHandle3))
            {
                var data = gridView4.GetRow(rowHandle3) as LigneProduction;
                ListeGrid.Add(data);


                bool isSelected = gridView4.IsRowSelected(rowHandle3);
                rowHandle3++;
            }

            if (TotaleNbSacs <= A1.NbSacs)
            {
                LP.NombreSacs = Convert.ToInt32(TxtNombreSacsPartiel.Text);
                if (string.IsNullOrEmpty(TxtQteHuilePartiel.Text) && A1.TypeAchat == TypeAchat.Service)
                {
                    LP.QuantiteHuileProduite = 0;
                }
                else
                {
                    LP.QuantiteHuileProduite = Convert.ToInt32(TxtQteHuilePartiel.Text);
                }

                LP.DateFinProd = TxtDatefinPartiel.DateTime;
                LP.prod = prod;
                LP.AchatId = A1.Id.ToString();

                db.LigneProductions.Add(LP);

                db.SaveChanges();
            }


            decimal QteTotaleHuile = 0;
            if (TotaleNbSacs <= A1.NbSacs) //&& Convert.ToInt32(TxtNombreSacsPartiel.Text) != 0
            {
                // Ajouter Ligne de vente a la gride 
                ListeGrid.Add(LP);
                int TotaleNbS = ListeGrid.Sum(x => x.NombreSacs);
                int NombreSacs = Convert.ToInt32(TxtNombreSacs.Text);
                int RestNombreSac = NombreSacs - TotaleNbS;
                TxtNombreSacsPartiel.Text = RestNombreSac.ToString();
                QteTotaleHuile = ListeGrid.Sum(x => x.QuantiteHuileProduite);
                TxtQteHuileTotal.Text = QteTotaleHuile.ToString();
                TxtQteHuilePartiel.Text = string.Empty;
            }
            //else
            //{


            //    XtraMessageBox.Show("Nombre de sacs invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    int TotaleNbS = ListeGrid.Sum(x => x.NombreSacs);
            //    int NombreSacs = Convert.ToInt32(TxtNombreSacs.Text);
            //    int RestNombreSac = NombreSacs - TotaleNbS;
            //    TxtQteReste.Text = RestNombreSac.ToString();
            //    return;

            //}


            ligneProductionBindingSource.DataSource = ListeGrid;




        }
    }
}











