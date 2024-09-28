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
using DevExpress.XtraSplashScreen;
using Gestion_de_Stock.Model;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;
using System.Globalization;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterPile : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterPile _FrmAjouterPile;



        public static FrmAjouterPile InstanceFrmAjouterPile
        {
            get
            {
                if (_FrmAjouterPile == null)
                    _FrmAjouterPile = new FrmAjouterPile();
                return _FrmAjouterPile;
            }
        }



        public FrmAjouterPile()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAjouterPile_Load(object sender, EventArgs e)
        {   
            
            /***************liste Article***************/
            List<string> ListeArticle = Enum.GetNames(typeof(ArticleVente)).ToList();
            if (ListeArticle != null)
            {
                foreach (var Article in ListeArticle)
                {
                    comboBoxEditArticle.Properties.Items.Add(Article);
                }

                comboBoxEditArticle.SelectedIndex = 0;
                if (ListeArticle.Count > 0)
                    comboBoxEditArticle.SelectedItem = ListeArticle[0];

            }


            TxtIntitule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtCapaciteMax.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
           

        }

        private void FrmAjouterPile_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterPile = null;
        }
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            decimal CapaciteMax;
            string CapaciteMaxStr = TxtCapaciteMax.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(CapaciteMaxStr, out CapaciteMax);

            if (string.IsNullOrEmpty(TxtIntitule.Text))
            {
                TxtIntitule.ErrorText = "Intitulé est obligatoire";
                return;

            }
            if (string.IsNullOrEmpty(TxtCapaciteMax.Text))
            {
                TxtCapaciteMax.ErrorText = "Capacité Max est obligatoire";
                return;

            }
         

            if (comboBoxEditArticle.SelectedItem == null)
            {
                comboBoxEditArticle.ErrorText = "Type Huile est obligatoire";
                return;
            }



         
            //if nom de la pile existe 
            var PileDb = db.Piles.FirstOrDefault(x=>x.Intitule.Equals(TxtIntitule.Text));
            if(PileDb != null)
            {

                XtraMessageBox.Show("Intitulé Existe déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtIntitule.ErrorText = "Intitulé Invalid";
                TxtIntitule.Text = string.Empty;
                return;
            }


            Pile P = new Pile();
            P.Intitule = TxtIntitule.Text;
            P.CapaciteMax = Convert.ToInt32(TxtCapaciteMax.Text);
          

            if (comboBoxEditArticle.SelectedItem.ToString().Equals("Extra"))
            {
                P.article = ArticleVente.Extra;
            }
            else if (comboBoxEditArticle.SelectedItem.ToString().Equals("Lampante"))
            {
                P.article = ArticleVente.Lampante;
            }
            else if (comboBoxEditArticle.SelectedItem.ToString().Equals("Fatoura"))
            {
                P.article = ArticleVente.Fatoura;
            }
            else if (comboBoxEditArticle.SelectedItem.ToString().Equals("Vierge"))
            {
                P.article = ArticleVente.Vierge;
            }
            else if (comboBoxEditArticle.SelectedItem.ToString().Equals("ExtraVierge"))
            {
                P.article = ArticleVente.ExtraVierge;
            }


            db.Piles.Add(P);

            db.SaveChanges();

            P.Numero = "P" + (P.Id).ToString("D8");

            db.SaveChanges();

            XtraMessageBox.Show("Pile Enregistrée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtIntitule.Text = string.Empty;
            TxtCapaciteMax.Text = string.Empty;
            List<string> ListeArticle = Enum.GetNames(typeof(ArticleVente)).ToList();
            comboBoxEditArticle.SelectedIndex = 0;
            comboBoxEditArticle.SelectedItem = ListeArticle[0];
           this.Close();
            

            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();

            //waiting Form 
            if (Application.OpenForms.OfType<FrmPile>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmPile>().First().pileBindingSource.DataSource = db.Piles.ToList();


            //waiting Form 
            if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

            //waiting Form 
            if (Application.OpenForms.OfType<FrmAjouterVente>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterVente>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite > 0).Select(x => new { x.Id, x.Numero, x.Intitule, x.article, x.Capacite, x.PrixMoyen }).ToList();


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

        private void FrmAjouterPile_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = TxtIntitule;
        }
    }
}