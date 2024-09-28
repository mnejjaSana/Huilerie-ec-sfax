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
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmTransfertPile : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;

        private static FrmTransfertPile _FrmTransfertPile;

        public static FrmTransfertPile InstanceFrmTransfertPile
        {
            get
            {
                if (_FrmTransfertPile == null)
                    _FrmTransfertPile = new FrmTransfertPile();
                return _FrmTransfertPile;
            }
        }

        public FrmTransfertPile()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmTransfertPile_Load(object sender, EventArgs e)
        {
            PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article!= ArticleVente.Fatoura).ToList();
            PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.article != ArticleVente.Fatoura && x.Capacite < x.CapaciteMax ).ToList();
            TxtQteHuile.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        private void FrmTransfertPile_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmTransfertPile = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            if (string.IsNullOrEmpty(searchLookUpPileSortante.Text))
            {
                XtraMessageBox.Show("Choisir une pile Sortante", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(searchLookUpPileEntrante.Text))
            {
                XtraMessageBox.Show("Choisir une pile Entrante ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            Pile PileSortante = new Pile();
            Pile PileEntrante = new Pile();
            int stockPileSortante = 0;
            int stockPileEntrante = 0;

            // PileSortante
            GridView view = searchLookUpPileSortante.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Pileselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (Pileselected == null)
            {
                XtraMessageBox.Show("Choisir une pile Sortante ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPileSortante.Focus();
                return;

            }
            else
            {

                int IdPile = Convert.ToInt32(Pileselected);
                PileSortante = db.Piles.Find(IdPile);
                stockPileSortante = PileSortante.Capacite;
            }

            // PileEntrante
            GridView view1 = searchLookUpPileEntrante.Properties.View;
            int rowHandle1 = view1.FocusedRowHandle;
            string fieldName1 = "Id"; // or other field name  
            object PileselectedEntrante = view1.GetRowCellValue(rowHandle1, fieldName1);
            ///Condition existance Pile
            if (PileselectedEntrante == null)
            {
                XtraMessageBox.Show("Choisir une pile Entrante ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPileEntrante.Focus();
                return;

            }
            else
            {

                int IdPile = Convert.ToInt32(PileselectedEntrante);
                PileEntrante = db.Piles.Find(IdPile);

                stockPileEntrante = PileEntrante.Capacite;
            }
            if (string.IsNullOrEmpty(TxtQteHuile.Text))
            {
                TxtQteHuile.ErrorText = "Quantité Invalide";
                XtraMessageBox.Show("Quantité Huile est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int QteHuile = int.Parse(TxtQteHuile.Text);


            if(QteHuile <= 0 || (QteHuile + PileEntrante.Capacite) > PileEntrante.CapaciteMax || QteHuile > PileSortante.Capacite)
            {
                XtraMessageBox.Show("Quantité Huile est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQteHuile.Text = string.Empty;
                return;
            }

            //  pile entrante
            if ((QteHuile + PileEntrante.Capacite) <= PileEntrante.CapaciteMax)
            {
                var capaciteInitial = PileEntrante.Capacite;

                PileEntrante.Capacite = PileEntrante.Capacite + QteHuile;

                PileEntrante.PrixMoyen = Math.Truncate((((PileSortante.PrixMoyen * QteHuile) + (capaciteInitial * PileEntrante.PrixMoyen)) / PileEntrante.Capacite) * 100000m) / 100000m;

                db.SaveChanges();

                #region Ajouter MVT Stock  Entrante
                MouvementStock MvtStockEntrante = new MouvementStock();

                int lastMvtStock1 = db.MouvementsStock.ToList().Count() + 1;
                MvtStockEntrante.Numero = "TRF" + (lastMvtStock1).ToString("D8");
                MvtStockEntrante.pile = PileEntrante;
                MvtStockEntrante.Sens = SensStock.Entree;
                MvtStockEntrante.Qualite = PileEntrante.article;
                MvtStockEntrante.QuantiteSOD = 0;
                MvtStockEntrante.QuantiteVendue = 0;
                MvtStockEntrante.QuantiteProduite = 0;
                MvtStockEntrante.QteEntrante = QteHuile;
                MvtStockEntrante.Commentaire = "Transfert de " + PileSortante.Intitule + " Vers " + PileEntrante.Intitule;
                MvtStockEntrante.PrixMouvement = PileSortante.PrixMoyen;
                MvtStockEntrante.PMP = PileEntrante.PrixMoyen;
                MvtStockEntrante.QuantitePileInitial = capaciteInitial;
                MvtStockEntrante.QuantitePileFinal = PileEntrante.Capacite;
                db.MouvementsStock.Add(MvtStockEntrante);

                db.SaveChanges();

                #endregion
            }
            else
            {
                XtraMessageBox.Show("Quantité Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQteHuile.Text = string.Empty;
                return;
            }


            // pile sortante

            if (QteHuile <= PileSortante.Capacite)
            {
                // Mouvement de Stock
                #region Ajouter MVT Stock  Sortante
                MouvementStock MvtStock = new MouvementStock();

                int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;
                MvtStock.Numero = "TRF" + (lastMvtStock).ToString("D8");
                MvtStock.pile = PileSortante;
                MvtStock.Sens = SensStock.Sortie;
                MvtStock.Qualite = PileSortante.article;
                MvtStock.QuantiteSOD = 0;
                MvtStock.QuantiteVendue = 0;
                MvtStock.QuantiteProduite = 0;
                MvtStock.QteSortante = QteHuile;

                MvtStock.Commentaire = "Transfert de " + PileSortante.Intitule + " Vers " + PileEntrante.Intitule;
                MvtStock.QuantitePileInitial = stockPileSortante;
                MvtStock.PrixMouvement = PileSortante.PrixMoyen;
                MvtStock.PMP = PileSortante.PrixMoyen;
                db.MouvementsStock.Add(MvtStock);
                db.SaveChanges();
                #endregion

                PileSortante.Capacite = PileSortante.Capacite - QteHuile;
                db.SaveChanges();

                if (PileSortante.Capacite == 0)

                {
                    PileSortante.PrixMoyen = 0;
                    db.SaveChanges();
                }




                MvtStock.QuantitePileFinal = PileSortante.Capacite;

                db.SaveChanges();
            }
            else
            {
                XtraMessageBox.Show("Quantité Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQteHuile.Text = string.Empty;
                return;
            }


            XtraMessageBox.Show("Transfert Pile Terminé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            searchLookUpPileEntrante.EditValue = searchLookUpPileEntrante.Properties.NullText;
            searchLookUpPileSortante.EditValue = searchLookUpPileSortante.Properties.NullText;

            TxtQteHuile.Text = string.Empty;
            TxtPrixMoyen.Text = string.Empty;

           this.Close();

            if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();

            if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();

            if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

            if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
            { Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList(); }


            if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

            if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();



            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
            {
                string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();
          

            }
            

            if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();


            if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmTransfertPile>().First().PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

            if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmTransfertPile>().First().PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();


        }

        private void searchLookUpPileSortante_EditValueChanged(object sender, EventArgs e)
        {

            // PileSortante
            GridView view = searchLookUpPileSortante.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Pileselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (Pileselected != null)
            {
                int IdPile = Convert.ToInt32(Pileselected);
                var PileSortante = db.Piles.Find(IdPile);
                TxtPrixMoyen.Text = (Math.Truncate(PileSortante.PrixMoyen * 1000m) / 1000m).ToString();
            }


        }

        private void searchLookUpPileEntrante_EditValueChanged(object sender, EventArgs e)
        {
            // PileSortante

            Pile PileSortante = new Pile();

            GridView view = searchLookUpPileSortante.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Pileselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (Pileselected != null)
            {
                int IdPile = Convert.ToInt32(Pileselected);
                PileSortante = db.Piles.Find(IdPile);

            }

            // PileEntrante

            Pile PileEntrante = new Pile();
            GridView view1 = searchLookUpPileEntrante.Properties.View;
            int rowHandle1 = view1.FocusedRowHandle;
            string fieldName1 = "Id"; // or other field name  
            object PileselectedEntrante = view1.GetRowCellValue(rowHandle1, fieldName1);
            if (PileselectedEntrante != null)
            {
                int IdPile = Convert.ToInt32(PileselectedEntrante);
                PileEntrante = db.Piles.Find(IdPile);

            }

            if (PileSortante.Id == PileEntrante.Id)
            {
                XtraMessageBox.Show("Pile Entrante est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                searchLookUpPileEntrante.EditValue = searchLookUpPileEntrante.Properties.NullText;
                return;

            }

        }
    }
}