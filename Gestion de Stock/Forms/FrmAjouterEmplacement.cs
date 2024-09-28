using DevExpress.XtraEditors;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterEmplacement : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmAjouterEmplacement _FrmAjouterEmplacement;


        public static FrmAjouterEmplacement InstanceFrmAjouterEmplacement
        {
            get
            {
                if (_FrmAjouterEmplacement == null)
                {
                    _FrmAjouterEmplacement = new FrmAjouterEmplacement();
                }

                return _FrmAjouterEmplacement;
            }
        }
        public FrmAjouterEmplacement()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterEmplacement_Load(object sender, EventArgs e)
        {
            TxtNomEmplacement.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            List<string> ListeTypeOlive = Enum.GetNames(typeof(ArticleAchat)).ToList();
            if (ListeTypeOlive != null)
            {
                foreach (var TypeOlive in ListeTypeOlive)
                {
                    comboBoxEditArticle.Properties.Items.Add(TypeOlive);
                }

                comboBoxEditArticle.SelectedIndex = 0;
                if (ListeTypeOlive.Count > 0)
                {
                    comboBoxEditArticle.SelectedItem = ListeTypeOlive[0];
                }
            }

        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtNomEmplacement.Text))
            {
                TxtNomEmplacement.ErrorText = "Intitulé Emplacement est obligatoire";
                return;

            }

            Emplacement empDB = db.Emplacements.Where(x => x.Intitule.ToUpper().Equals(TxtNomEmplacement.Text.Trim().ToUpper())).FirstOrDefault();

            if (empDB != null)
            {
                XtraMessageBox.Show("Emplacement exist deja", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNomEmplacement.ErrorText = "Emplacement exist deja";
                
                return;
            }
            else
            {
                Emplacement emplacement = new Emplacement();
                emplacement.Intitule = TxtNomEmplacement.Text;
                if (comboBoxEditArticle.Text.Equals("Nchira"))
                {
                    emplacement.Article = ArticleAchat.Nchira;
                }
                else
                {
                    emplacement.Article = ArticleAchat.OliveVif;
                }

                emplacement.Quantite = 0;
                emplacement.PrixMoyen = 0;
                emplacement.RENDEMENMOY = 0;
                emplacement.ValeurMasraf = 0;
                emplacement.LastPrixMoyen = 0;

                db.Emplacements.Add(emplacement);

                db.SaveChanges();
                emplacement.Numero = "EMP" + (emplacement.Id).ToString("D8");
                db.SaveChanges();
                XtraMessageBox.Show("Masraf Enregistré", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNomEmplacement.Text = string.Empty;
                List<string> ListeTypeOlive = Enum.GetNames(typeof(ArticleAchat)).ToList();
                comboBoxEditArticle.SelectedIndex = 0;
                comboBoxEditArticle.SelectedItem = ListeTypeOlive[0];
               
               this.Close();
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


        }

        private void FrmAjouterEmplacement_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterEmplacement = null;
        }
    }
}