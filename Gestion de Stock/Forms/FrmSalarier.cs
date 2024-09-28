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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSalarier : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmSalarier _FrmOuvrier;
        internal object salarieBindingSource;

        public static FrmSalarier InstanceFrmOuvrier
        {
            get
            {
                if (_FrmOuvrier == null)
                    _FrmOuvrier = new FrmSalarier();
                return _FrmOuvrier;
            }
        }

        public FrmSalarier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
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

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez vous supprimer ce salarié ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {

                Salarier S = gridView1.GetFocusedRow() as Salarier;
                if (S == null)
                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Salarier SalarierDb = db.Salariers.Find(S.Id);

                Depense DepSal = db.Depenses.Where(x => x.Salarie.Id == SalarierDb.Id).FirstOrDefault();

                if (DepSal != null || SalarierDb.TotalNombreHeure>0)

                {
                    XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    db.Salariers.Remove(SalarierDb);

                   var PointageS = db.PointageJournaliers.Where(x => x.Salarier.Id == SalarierDb.Id).FirstOrDefault();
                    if (PointageS != null)
                    { db.PointageJournaliers.Remove(PointageS); }
                    db.SaveChanges();


                    /***************************** reload DataGridView ***********************************/
                    salarierBindingSource.DataSource = db.Salariers.ToList();



                    if (Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault().salarierBindingSource.DataSource = db.Salariers.ToList();
                    /***************************** reload pointage  ***********************************/
                    if (Application.OpenForms.OfType<FrmPointage>().FirstOrDefault() != null)
                    {
                        DateTime currentday = Application.OpenForms.OfType<FrmPointage>().First().dateEditDatePointage.DateTime;
                        List<PointageJournalier> ListePointages = db.PointageJournaliers.Include("Salarier").Where(x => x.Date.Day == currentday.Day && x.Date.Month == currentday.Month && x.Date.Year == currentday.Year).ToList();
                        if (ListePointages.Count != 0)
                        {
                            List<Salarier> ListSalarier = db.Salariers.ToList();
                            foreach (var sal in ListSalarier)
                            {
                                var Existe = ListePointages.Where(x => x.IdSalarier == sal.Id).FirstOrDefault();
                                if (Existe == null)
                                {
                                    ListePointages.Add(new PointageJournalier { Date = currentday, IdSalarier = sal.Id, NombreHeure = 0, Salarier = sal });
                                }
                            }
                            Application.OpenForms.OfType<FrmPointage>().First().pointageBindingSource.DataSource = ListePointages;

                        }
                        else
                        {
                            List<Salarier> ListSalarier = db.Salariers.ToList();

                            foreach (var Sal in ListSalarier)
                            {
                                PointageJournalier Pointage = new PointageJournalier();
                                Pointage.Salarier = Sal;
                                Pointage.IdSalarier = Sal.Id;
                                ListePointages.Add(Pointage);

                            }
                            Application.OpenForms.OfType<FrmPointage>().First().pointageBindingSource.DataSource = ListePointages;
                        }
                        

                    }
                    

                    /***************************** reload DataGridView  ***********************************/
                    XtraMessageBox.Show("Salarié Supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

                XtraMessageBox.Show("Echec de Suppression ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOuvrier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmOuvrier = null;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterOuvrier.InstanceFrmAjouterOuvrier);
        }

        private void FrmOuvrier_Load(object sender, EventArgs e)
        {
            List<Salarier> SalarieList = db.Salariers.ToList();
            // depenses salariés
            List<Depense> ListeDepenseSalaries = db.Depenses.Include("Salarie").Where(x => x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList();
            foreach (var S in SalarieList)
            {
                var liste = db.PointageJournaliers.Include("Salarier").Where(x => x.Salarier.Id == S.Id).ToList();
                S.TotalNombreHeure = liste.Count > 0 ? db.PointageJournaliers.Include("Salarier").Where(x => x.Salarier.Id == S.Id).Sum(x => x.NombreHeure) : 0;
                S.TotalDeponse = ListeDepenseSalaries.Where(x => x.Salarie.Id == S.Id && x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList().Sum(x => x.Montant);
            }

            salarierBindingSource.DataSource = SalarieList;

        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            Salarier S = gridView1.GetFocusedRow() as Salarier;

            if(S!=null)
            {
                db = new Model.ApplicationContext();
                Salarier SalarieDb = db.Salariers.Find(S.Id);


                FormshowNotParent(Forms.FrmModifierOuvrier.InstanceFrmModifierOuvrier);
                if (Application.OpenForms.OfType<FrmModifierOuvrier>().FirstOrDefault() != null)
                {
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtNumero.Text = SalarieDb.Id.ToString();
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtIntitule.Text = SalarieDb.Intitule.ToString();
                    Application.OpenForms.OfType<FrmModifierOuvrier>().First().TxtTel.Text = SalarieDb.Tel.ToString();

                }

            }
            else
            {
                XtraMessageBox.Show("Aucun salarié séléctionné", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            List<Salarier> SalarieList = db.Salariers.ToList();
            // depenses salariés
            List<Depense> ListeDepenseSalaries = db.Depenses.Include("Salarie").Where(x => x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList();
            foreach (var S in SalarieList)
            {
                var liste = db.PointageJournaliers.Include("Salarier").Where(x => x.Salarier.Id == S.Id).ToList();
                S.TotalNombreHeure = liste.Count > 0 ? db.PointageJournaliers.Include("Salarier").Where(x => x.Salarier.Id == S.Id).Sum(x => x.NombreHeure) : 0;
                S.TotalDeponse = ListeDepenseSalaries.Where(x => x.Salarie.Id == S.Id && x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList().Sum(x => x.Montant);
            }

            salarierBindingSource.DataSource = SalarieList;

        }
    }
}