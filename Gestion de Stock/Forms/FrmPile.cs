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
using System.Threading;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmPile : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmPile _FrmPile;

        public static FrmPile InstanceFrmPile
        {
            get
            {
                if (_FrmPile == null)
                    _FrmPile = new FrmPile();
                return _FrmPile;
            }
        }



        public FrmPile()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmPile_Load(object sender, EventArgs e)
        {
            if (db.Piles.Count() > 0)
                pileBindingSource.DataSource = db.Piles.ToList();
        }

        private void FrmPile_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmPile = null;
        }

        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter ....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {

            FormshowNotParent(Forms.FrmAjouterPile.InstanceFrmAjouterPile);
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {

            Pile pile = gridView1.GetFocusedRow() as Pile;
            db = new Model.ApplicationContext();
            if(pile!=null)
            {
                Pile PileDb = db.Piles.Find(pile.Id);

                if (PileDb.Capacite == 0)
                {
                    FormshowNotParent(Forms.FrmModifierPile.InstanceFrmModifierPile);
                    if (Application.OpenForms.OfType<FrmModifierPile>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmModifierPile>().First().TxtId.Text = PileDb.Id.ToString(); ;
                        Application.OpenForms.OfType<FrmModifierPile>().First().TxtIntitule.Text = PileDb.Intitule;
                        Application.OpenForms.OfType<FrmModifierPile>().First().TxtCapaciteMax.Text = PileDb.CapaciteMax.ToString();

                        if ((int)PileDb.article == 1)
                        {
                            Application.OpenForms.OfType<FrmModifierPile>().First().comboBoxTypeHuile.SelectedItem = "Extra";

                        }

                        else if ((int)PileDb.article == 2)
                        {
                            Application.OpenForms.OfType<FrmModifierPile>().First().comboBoxTypeHuile.SelectedItem = "Fatoura";

                        }
                        else if ((int)PileDb.article == 3)
                        {
                            Application.OpenForms.OfType<FrmModifierPile>().First().comboBoxTypeHuile.SelectedItem = "Lampante";

                        }
                        else if ((int)PileDb.article == 4)
                        {
                            Application.OpenForms.OfType<FrmModifierPile>().First().comboBoxTypeHuile.SelectedItem = "Vierge";

                        }
                        else if ((int)PileDb.article == 5)
                        {
                            Application.OpenForms.OfType<FrmModifierPile>().First().comboBoxTypeHuile.SelectedItem = "ExtraVierge";

                        }
                    }
                }
                else
                {

                    XtraMessageBox.Show("Pile Pleine", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Aucune Pile séléctionnée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer cette Pile ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                Pile P = gridView1.GetFocusedRow() as Pile;

                if (P == null)
                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db = new Model.ApplicationContext();

                Pile PileDb = db.Piles.Find(P.Id);
                
                LigneStock LigneStock = db.LignesStock.Where(x => x.pile.Id == PileDb.Id).FirstOrDefault();

                LigneVente PileVente = db.LignesVente.Where(x => x.IdPile == PileDb.Id).FirstOrDefault();

                MouvementStock PileMvmStock = db.MouvementsStock.Where(x => x.pile.Id == PileDb.Id).FirstOrDefault();
                

                if (LigneStock != null || PileVente != null || PileMvmStock != null ||  PileDb.Capacite > 0)

                {
                    XtraMessageBox.Show("Votre demande est non autorisée!", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    db.Piles.Remove(PileDb);
                    db.SaveChanges();

                    /***************************** reload DataGridView ***********************************/
                    pileBindingSource.DataSource = db.Piles.ToList();
                    /***************************** reload DataGridView  ***********************************/
                    XtraMessageBox.Show("Pile Supprimée avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (Application.OpenForms.OfType<FrmProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmProduction>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();

                    if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmMasrafProduction>().First().searchLookUpPile.Properties.DataSource = db.Piles.Where(x => x.CapaciteMax > x.Capacite && x.article != ArticleVente.Fatoura).ToList();


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

                    if (Application.OpenForms.OfType<FrmEntreeDivers>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmEntreeDivers>().First().pileBindingSource.DataSource = db.Piles.Where(x => x.Capacite < x.CapaciteMax).ToList();
                    

                }

            }

            else
            {

                XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            if (db.Piles.Count() > 0)
                pileBindingSource.DataSource = db.Piles.ToList();

        }
    }
}