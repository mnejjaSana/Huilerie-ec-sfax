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
    public partial class FrmModifierOuvrier : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmModifierOuvrier _FrmModifierOuvrier;
        public static FrmModifierOuvrier InstanceFrmModifierOuvrier
        {
            get
            {
                if (_FrmModifierOuvrier == null)
                    _FrmModifierOuvrier = new FrmModifierOuvrier();
                return _FrmModifierOuvrier;
            }
        }

        public FrmModifierOuvrier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmModifierOuvrier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierOuvrier = null;

        }

        private void Enregister(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(TxtNumero.Text);
            Salarier SalarieDb = db.Salariers.Find(id);

            Salarier SalarierBD = db.Salariers.Where(x => x.Id != SalarieDb.Id).SingleOrDefault(a => a.Tel.Equals(TxtTel.Text));


            if (SalarierBD != null)
            {
                TxtTel.ErrorText = "Téléphone existe déja";
                XtraMessageBox.Show("Téléphone existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         

            if (SalarieDb != null)
            {

                SalarieDb.Id = Convert.ToInt32(TxtNumero.Text);
                SalarieDb.Intitule = TxtIntitule.Text;
                SalarieDb.Tel = TxtTel.Text;
           
             
                db.SaveChanges();

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
                if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
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

                    Application.OpenForms.OfType<FrmSalarier>().First().salarierBindingSource.DataSource = SalarieList;
                }
                if (Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault().salarierBindingSource.DataSource = db.Salariers.ToList();

                XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Echec d'enregisterment  ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmModifierOuvrier_Load(object sender, EventArgs e)
        {

        }
    }
}