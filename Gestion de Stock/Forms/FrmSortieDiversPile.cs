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
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSortieDiversPile : DevExpress.XtraEditors.XtraForm
    {
        private static FrmSortieDiversPile _FrmSortieDiversPile;
        private Model.ApplicationContext db;

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;

        public static FrmSortieDiversPile InstanceFrmSortieDiversPile
        {
            get
            {
                if (_FrmSortieDiversPile == null)
                    _FrmSortieDiversPile = new FrmSortieDiversPile();
                return _FrmSortieDiversPile;
            }
        }


        public FrmSortieDiversPile()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmSortieDiversPile_Load(object sender, EventArgs e)
        {
            List<Pile> ListPile = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

            pileBindingSource.DataSource = ListPile;
        }

        private void FrmSortieDiversPile_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmSortieDiversPile = null;
        }

        private void searchLookUpPile_EditValueChanged(object sender, EventArgs e)
        {
            Pile P = new Pile();

            GridView view = searchLookUpPile.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Pileselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (Pileselected == null)
            {
                XtraMessageBox.Show("Choisir une pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPile.Focus();
                return;

            }
            else
            {

                int IdPile = Convert.ToInt32(Pileselected);
                P = db.Piles.Find(IdPile);
            }

            TxtStock.Text = P.Capacite.ToString();



        }

        private void TxtQte_EditValueChanged(object sender, EventArgs e)
        {
            int Stock = Convert.ToInt32(TxtStock.Text);

            //int Qte= Convert.ToInt32(TxtQte.Text);

            decimal Qte;
            string QteStr = TxtQte.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(QteStr, out Qte);

            TxtReste.Text = (Stock - Qte).ToString();

        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchLookUpPile.Text))
            {
                XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation); 
                return;
           
            }

            if (string.IsNullOrEmpty(TxtQte.Text))
            {
                TxtQte.ErrorText = "Qualité Sortante est obligatoire";
                return;

            }

            Pile P = new Pile();

            GridView view = searchLookUpPile.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Pileselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (Pileselected == null)
            {
                XtraMessageBox.Show("Choisir une pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPile.Focus();
                return;

            }
            else
            {

                int IdPile = Convert.ToInt32(Pileselected);
                P = db.Piles.Find(IdPile);
            }

            int stock = Convert.ToInt32(TxtStock.Text);

            int Qte = Convert.ToInt32(TxtQte.Text);

            if (Qte > P.Capacite || Qte <=0)
            {
                XtraMessageBox.Show("Quantité Sortante est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQte.Text = string.Empty;
                TxtReste.Text = string.Empty;

                return;
            }

            #region Ajouter MVT Stock
            MouvementStock MvtStock = new MouvementStock();

            int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;
            MvtStock.Numero = "SOD" + (lastMvtStock).ToString("D8");
            MvtStock.pile = P;
            MvtStock.Sens = SensStock.Sortie;
            MvtStock.Qualite = P.article;
            MvtStock.QuantiteSOD = Qte;
            MvtStock.QuantiteVendue = 0;
            MvtStock.QuantiteProduite = 0;
            MvtStock.QuantiteAchetee = 0;
            MvtStock.QteSortante = Qte;
           
            MvtStock.Commentaire = TxtCommentaire.Text;
            MvtStock.PrixMouvement = P.PrixMoyen;
            MvtStock.PMP = P.PrixMoyen;
            MvtStock.QuantitePileInitial = stock;
            db.MouvementsStock.Add(MvtStock);
            db.SaveChanges();
            #endregion

            P.Capacite = P.Capacite - Qte;

            if (P.Capacite == 0)
            {
                P.PrixMoyen = 0;
            }
            db.SaveChanges();

            
            MvtStock.QuantitePileFinal = P.Capacite;

            db.SaveChanges();

            XtraMessageBox.Show("Sortie Divers Terminée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
            TxtQte.Text = string.Empty;
            TxtStock.Text = string.Empty;
            TxtReste.Text = string.Empty;
            TxtCommentaire.Text = string.Empty;

           this.Close();

            if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();

            if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();

            if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

            if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();


            if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmTransfertPile>().First().PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

            if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmTransfertPile>().First().PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax && x.article != ArticleVente.Fatoura).ToList();

            if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
            { Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList(); }



            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
            {
                string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();
            }

            if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();
        }
    }
}