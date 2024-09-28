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
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmModifierPile : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierPile _FrmModifierPile;
        public static FrmModifierPile InstanceFrmModifierPile
        {
            get
            {
                if (_FrmModifierPile == null)
                    _FrmModifierPile = new FrmModifierPile();
                return _FrmModifierPile;
            }
        }


        public FrmModifierPile()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierPile_Load(object sender, EventArgs e)
        {
            /***************liste Article***************/
            List<string> ListeArticle = Enum.GetNames(typeof(ArticleVente)).ToList();
            if (ListeArticle != null)
            {
                foreach (var Article in ListeArticle)
                {
                    comboBoxTypeHuile.Properties.Items.Add(Article);
                }

                comboBoxTypeHuile.SelectedIndex = 0;
                if (ListeArticle.Count > 0)
                    comboBoxTypeHuile.SelectedItem = ListeArticle[0];

            }

            TxtIntitule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtCapaciteMax.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

        }

        private void FrmModifierPile_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmModifierPile = null;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
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

            int id = Convert.ToInt16(TxtId.Text);

            Pile PileDb = db.Piles.Find(id);

            if (PileDb == null)
            {
                XtraMessageBox.Show("Echec d'enregisterment", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string NewNom = TxtIntitule.Text;

            Pile PileDbSameNewName = db.Piles.FirstOrDefault(x => x.Id != id && x.Intitule.ToUpper().Equals(NewNom.Trim().ToUpper()));

            if (PileDbSameNewName != null)
            {
                XtraMessageBox.Show("Intitulé Exist déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TxtIntitule.ErrorText = "Intitulé Exist déja";
                return;
            }


            ArticleVente NewarticleVente = ArticleVente.Extra;

            if (comboBoxTypeHuile.SelectedItem.ToString().Equals("Extra"))
            {
                NewarticleVente = ArticleVente.Extra;
            }
            else if (comboBoxTypeHuile.SelectedItem.ToString().Equals("Lampante"))
            {
                NewarticleVente = ArticleVente.Lampante;
            }
            else if (comboBoxTypeHuile.SelectedItem.ToString().Equals("Fatoura"))
            {
                NewarticleVente = ArticleVente.Fatoura;
            }
            else if (comboBoxTypeHuile.SelectedItem.ToString().Equals("Vierge"))
            {
                NewarticleVente = ArticleVente.Vierge;
            }
            else if (comboBoxTypeHuile.SelectedItem.ToString().Equals("ExtraVierge"))
            {
                NewarticleVente = ArticleVente.ExtraVierge;
            }
            

            if (PileDb!=null && PileDbSameNewName==null)

            {
                PileDb.Intitule = NewNom;
                PileDb.article = NewarticleVente;
                PileDb.CapaciteMax = Convert.ToInt32(TxtCapaciteMax.Text);
                db.SaveChanges();

                
                XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();
            }

       
            else
            {
                XtraMessageBox.Show("Echec d'enregisterment", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
    }
}