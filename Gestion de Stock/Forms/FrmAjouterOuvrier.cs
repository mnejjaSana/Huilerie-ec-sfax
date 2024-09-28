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
    public partial class FrmAjouterOuvrier : DevExpress.XtraEditors.XtraForm
    {

        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterOuvrier _FrmAjouterOuvrier;

        public static FrmAjouterOuvrier InstanceFrmAjouterOuvrier
        {
            get
            {
                if (_FrmAjouterOuvrier == null)
                    _FrmAjouterOuvrier = new FrmAjouterOuvrier();
                return _FrmAjouterOuvrier;
            }
        }


        public FrmAjouterOuvrier()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAjouterOuvrier_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterOuvrier = null;

        }

        private void FrmAjouterOuvrier_Load(object sender, EventArgs e)
        {
            TxtIntitule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtTelephone.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;




        }

        private void btnAjouterOuvrier_Click(object sender, EventArgs e)
        {

            // initialiser l'allignement des icons des erreurs provider



            if (string.IsNullOrEmpty(TxtIntitule.Text))
            {
                TxtIntitule.ErrorText = "Intitulé est obligatoire";
                return;

            }

            if (string.IsNullOrEmpty(TxtTelephone.Text))
            {
                TxtTelephone.ErrorText = "Téléphone est obligatoire";
                return;

            }

            
                Salarier SalarierBD = db.Salariers.SingleOrDefault(a => a.Tel.Equals(TxtTelephone.Text));


            if (SalarierBD != null)
            {
                TxtTelephone.ErrorText = "Téléphone existe déja";
                XtraMessageBox.Show("Téléphone existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }





            Salarier Sa = new Salarier();


            Sa.Intitule = TxtIntitule.Text;

            Sa.Tel = TxtTelephone.Text;

            db.Salariers.Add(Sa);
            db.SaveChanges();

            Sa.numero = "S" + (Sa.Id).ToString("D8");
            db.SaveChanges();
            XtraMessageBox.Show("Salarié Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtIntitule.Text = string.Empty;
            TxtTelephone.Text = string.Empty;

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


            if (Application.OpenForms.OfType<FrmAjouterDepense>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAjouterDepense>().First().salarierBindingSource.DataSource = db.Salariers.ToList();

        }
    }
}