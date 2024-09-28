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
    public partial class FrmEntreeDivers : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmEntreeDivers _FrmEntreeDivers;

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;

        public static FrmEntreeDivers InstanceFrmEntreeDivers
        {
            get
            {
                if (_FrmEntreeDivers == null)
                    _FrmEntreeDivers = new FrmEntreeDivers();
                return _FrmEntreeDivers;
            }
        }

        public FrmEntreeDivers()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmEntreeDivers_Load(object sender, EventArgs e)
        {
            pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();
        }

        private void FrmEntreeDivers_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEntreeDivers = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchLookUpPile.Text))
            {
                XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(TxtQuantite.Text))
            {
                TxtQuantite.ErrorText = "Quantité est obligatoire";
                return;

            }
            

            if (string.IsNullOrEmpty(TxtPrix.Text))
            {
                TxtPrix.ErrorText = "Prix est obligatoire";
                return;

            }

            decimal Prix;
            string PrixStr = TxtPrix.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(PrixStr, out Prix);
            Pile P = new Pile();

            GridView view1 = searchLookUpPile.Properties.View;
            int rowHandle1 = view1.FocusedRowHandle;
            string fieldName1 = "Id"; // or other field name  
            object Pileselected = view1.GetRowCellValue(rowHandle1, fieldName1);

            ///Condition existance Pile
            if (Pileselected == null)
            {
                XtraMessageBox.Show("Choisir une Pile ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpPile.Focus();
                return;

            }
            else
            {
                int IdPile = Convert.ToInt32(Pileselected);
                P = db.Piles.Find(IdPile);
              
            }
            int Qte = Convert.ToInt32(TxtQuantite.Text);

            if (Qte <=0)
            {
                XtraMessageBox.Show("Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtQuantite.Text = string.Empty;
                return;

            }

            if(Prix <=0 )
            {

                XtraMessageBox.Show("Prix est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtQuantite.Text = string.Empty;
                return;
            }
      

            if (P.Capacite + Qte > P.CapaciteMax)
            {
                XtraMessageBox.Show("Quantité est Invalide", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;

            }
            else
            {
                #region Ajouter MVT Stock
                MouvementStock MvtStock = new MouvementStock();

                int lastMvtStock = db.MouvementsStock.ToList().Count() + 1;
                MvtStock.Numero = "END" + (lastMvtStock).ToString("D8");
                MvtStock.pile = P;
                MvtStock.Sens = SensStock.Entree;
                MvtStock.Qualite = P.article;
                MvtStock.QuantiteSOD = 0;
                MvtStock.QuantiteVendue = 0;
                MvtStock.QuantiteProduite = 0;
                MvtStock.QuantiteAchetee = 0;
                MvtStock.QteSortante = 0;
                MvtStock.QteEntrante = Qte;
                MvtStock.PrixMouvement = Prix;
                MvtStock.QuantitePileInitial = P.Capacite;
                db.MouvementsStock.Add(MvtStock);
                db.SaveChanges();
                #endregion

                //// Prix Moyen
                int QuantitePileInitial = P.Capacite;

                int QuantitePileFinal = P.Capacite + Qte;

                P.PrixMoyen = Math.Truncate((((Qte * Prix) + (QuantitePileInitial * P.PrixMoyen)) / QuantitePileFinal) * 100000m) / 100000m;
                db.SaveChanges();

                MvtStock.PMP = P.PrixMoyen;
                MvtStock.QuantitePileFinal = QuantitePileFinal;
                db.SaveChanges();

                P.Capacite = QuantitePileFinal;
                db.SaveChanges();


                XtraMessageBox.Show("Entrée Divers Terminée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                searchLookUpPile.EditValue = searchLookUpPile.Properties.NullText;
                TxtQuantite.Text = string.Empty;
                TxtPrix.Text = string.Empty;
          
               this.Close();

                if (Application.OpenForms.OfType<FrmStockHuile>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmStockHuile>().First().mouvementStockBindingSource.DataSource = db.MouvementsStock.ToList();

                if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();

                if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

                if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                {
                   
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

                }



                if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmTransfertPile>().First().PileSortanteBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

                if (Application.OpenForms.OfType<FrmTransfertPile>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmTransfertPile>().First().PileEntranteBindingSource.DataSource = db.Piles.Where(x => x.article != ArticleVente.Fatoura && x.Capacite < x.CapaciteMax).ToList();

                if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                { Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList(); }


                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                {
                    string Qualite = Application.OpenForms.OfType<FrmAchats>().First().comboBoxQualité.Text;
                    Application.OpenForms.OfType<FrmAchats>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.article.ToString().Equals(Qualite) && x.article != ArticleVente.Fatoura).ToList();
                }

                if (Application.OpenForms.OfType<FrmSortieDiversPile>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmSortieDiversPile>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0 && x.article != ArticleVente.Fatoura).ToList();

            }
        }
    }
}