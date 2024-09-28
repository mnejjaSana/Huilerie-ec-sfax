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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmPointage : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmPointage _FrmPointage;

        public static FrmPointage InstanceFrmPointage
        {
            get
            {
                if (_FrmPointage == null)
                   _FrmPointage = new FrmPointage();
                return _FrmPointage;
            }
        }



        public FrmPointage()
        {
            db = new Model.ApplicationContext();
            InitializeComponent();
        }

        private void FrmPointage_Load(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            dateEditDatePointage.DateTime = DateTime.Now;
            DateTime currentday = DateTime.Now;
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
                pointageBindingSource.DataSource = ListePointages;
            }        
            else
            {
                List<Salarier> ListSalarier = db.Salariers.ToList();

                foreach(var S in ListSalarier)
                {
                    PointageJournalier Pointage = new PointageJournalier();
                    Pointage.Salarier = S;
                    Pointage.IdSalarier = S.Id;
                    ListePointages.Add(Pointage);
                   
                }
                pointageBindingSource.DataSource = ListePointages;
            }
  

        }

     


      

        private void FrmPointage_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmPointage = null;
        }

        private void BtnEnregsiter_Click(object sender, EventArgs e)
        {
            List<PointageJournalier> ListeGrid = new List<PointageJournalier>();
            int rowHandle = 0;

            while (gridView1.IsValidRowHandle(rowHandle))
            {
                var data = gridView1.GetRow(rowHandle) as PointageJournalier;
                ListeGrid.Add(data);
                rowHandle++;
            }
            if (ListeGrid.Count == 0)
            {
                XtraMessageBox.Show("Merci d'Ajouter la Liste des Salariers", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var currentday = dateEditDatePointage.DateTime;            
             List<PointageJournalier>  pointageDb = db.PointageJournaliers.Where( x=> x.Date.Day == currentday.Day && x.Date.Month == currentday.Month && x.Date.Year == currentday.Year).ToList();
            if (pointageDb.Count==0)
            {
                int rowHandle3 = 0;

                while (gridView1.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView1.GetRow(rowHandle3) as PointageJournalier;                  
                    Salarier SalarierDb = db.Salariers.Find(data.IdSalarier);
                    PointageJournalier P = new PointageJournalier();
                    P.IdSalarier = SalarierDb.Id;
                    P.Date = dateEditDatePointage.DateTime;
                    P.Salarier = SalarierDb;
                    P.NombreHeure = data.NombreHeure;
                    db.PointageJournaliers.Add(P);
                    db.SaveChanges();

                    rowHandle3++;
                }

               

                
            }
            else
            {
                // remouve old pointage
                foreach (var pointage in pointageDb)
                {
                    db.PointageJournaliers.Remove(pointage);
                    db.SaveChanges();
                }
                // save New
                int rowHandle3 = 0;

                while (gridView1.IsValidRowHandle(rowHandle3))
                {
                    var data = gridView1.GetRow(rowHandle3) as PointageJournalier;
                    Salarier SalarierDb = db.Salariers.Find(data.IdSalarier);
                    PointageJournalier P = new PointageJournalier();
                    P.IdSalarier = SalarierDb.Id;
                    P.Date = dateEditDatePointage.DateTime;
                    P.Salarier = SalarierDb;
                    P.NombreHeure = data.NombreHeure;
                    db.PointageJournaliers.Add(P);
                    db.SaveChanges();

                    rowHandle3++;
                }
            }

            XtraMessageBox.Show("Pointage Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            List<PointageJournalier> ListePointages = db.PointageJournaliers.Include("Salarier").Where(x => x.Date.Day == currentday.Day && x.Date.Month == currentday.Month && x.Date.Year == currentday.Year).ToList();
            pointageBindingSource.DataSource = ListePointages;

        }

        private void dateEditDatePointage_EditValueChanged(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            
            DateTime currentday = dateEditDatePointage.DateTime;
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
                pointageBindingSource.DataSource = ListePointages;

            }
            else
            {
                List<Salarier> ListSalarier = db.Salariers.ToList();

                foreach (var S in ListSalarier)
                {
                    PointageJournalier Pointage = new PointageJournalier();
                    Pointage.Salarier = S;
                    Pointage.IdSalarier = S.Id;
                    ListePointages.Add(Pointage);

                }
                pointageBindingSource.DataSource = ListePointages;
            }


        }
    }
}