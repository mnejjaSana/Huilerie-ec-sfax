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
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmModifierMasraf : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmModifierMasraf _FrmModifierMasraf;
        public static FrmModifierMasraf InstanceFrmModifierMasraf
        {
            get
            {
                if (_FrmModifierMasraf == null)
                    _FrmModifierMasraf = new FrmModifierMasraf();
                return _FrmModifierMasraf;
            }
        }

        public FrmModifierMasraf()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierMasraf_Load(object sender, EventArgs e)
        {
            TxtIntitule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

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
        }

        private void FrmModifierMasraf_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierMasraf = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtIntitule.Text))
            {
                TxtIntitule.ErrorText = "Intitulé est obligatoire";
                return;

            }

           

            int id = Convert.ToInt16(TxtId.Text);

            Emplacement empDb = db.Emplacements.Find(id);

            if (empDb == null)
            {
                XtraMessageBox.Show("Echec d'enregisterment", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string NewNom = TxtIntitule.Text;

            Emplacement empDbSameNewName = db.Emplacements.FirstOrDefault(x => x.Id != id && x.Intitule.ToUpper().Equals(NewNom.Trim().ToUpper()));

            if (empDbSameNewName != null)
            {
                XtraMessageBox.Show("Intitulé Exist déja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TxtIntitule.ErrorText = "Intitulé Exist déja";
                return;
            }


            ArticleAchat NewArticleAchat = ArticleAchat.OliveVif;

            if (comboBoxTypeOlive.SelectedItem.ToString().Equals("OliveVif"))
            {
                NewArticleAchat = ArticleAchat.OliveVif;
            }
            else if (comboBoxTypeOlive.SelectedItem.ToString().Equals("Nchira"))
            {
                NewArticleAchat = ArticleAchat.Nchira;
            }

            if (empDb != null && empDbSameNewName == null)

            {
                empDb.Intitule = NewNom;
                empDb.Article = NewArticleAchat;

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

                if (Application.OpenForms.OfType<FrmTransfertEmplacement>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmTransfertEmplacement>().First().emplacementEntrantBindingSource.DataSource = db.Emplacements.AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                }


            }
            else
            {
                XtraMessageBox.Show("Echec d'enregisterment", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}