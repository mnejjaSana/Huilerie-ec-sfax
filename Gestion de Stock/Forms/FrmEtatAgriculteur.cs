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
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using System.Globalization;
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatAgriculteur : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatAgriculteur _FrmEtatAgriculteur;

        public static FrmEtatAgriculteur InstanceFrmEtatAgriculteur
        {
            get
            {
                if (_FrmEtatAgriculteur == null)
                    _FrmEtatAgriculteur = new FrmEtatAgriculteur();
                return _FrmEtatAgriculteur;
            }
        }
        public FrmEtatAgriculteur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmEtatAgriculteur_Load(object sender, EventArgs e)
        {
            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }
                agriculteurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id,  x.Numero,x.FullName, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();
                
            }
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0); 
        }

        private void FrmEtatAgriculteur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatAgriculteur = null;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {

            db = new Model.ApplicationContext();
            List<Agriculteur> ListAgriculteurs = new List<Agriculteur>();
            if (db.Agriculteurs.Count() > 0)
            {

                ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats1.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats1.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }
          
            }




       

            DateTime DateMin = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1); 

            Agriculteur Agr = new Agriculteur();


            List<Achat> ListeAchats = new List<Achat>();

            List<Achat> Tous= new List<Achat>();
            List<Achat> Regle = new List<Achat>();
            List<Achat> NonRegle = new List<Achat>();

            GridView view = searchLookUpAgriculteur.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Agriculteurselected = view.GetRowCellValue(rowHandle, fieldName);
        
            if (Agriculteurselected == null && !checkAgriculteurs.Checked)
            {
                XtraMessageBox.Show("Choisir un Agriculteur ", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                searchLookUpAgriculteur.Focus();
                return;

            }

            else if (Agriculteurselected != null && !checkAgriculteurs.Checked)
            {

                int IdAgr = Convert.ToInt32(Agriculteurselected);

                Agr = ListAgriculteurs.FirstOrDefault(x=>x.Id==IdAgr);

                RapportEtatAgriculteur RapportEtatAgriculteur = new RapportEtatAgriculteur();

                List<Achat> AchatAnterieur = db.Achats.Where(x => x.Date < DateMin && x.Founisseur.Id == Agr.Id && (x.TypeAchat == TypeAchat.Base|| x.TypeAchat == TypeAchat.Huile || x.TypeAchat== TypeAchat.Olive) && x.EtatAchat!=EtatAchat.Reglee).ToList();

                decimal deduitAnterieur = AchatAnterieur.Sum(x => x.MtAdeduire);

                decimal resteApayer = AchatAnterieur.Sum(x => x.ResteApayer);

                Decimal SoldeAnterieur = decimal.Subtract(resteApayer, deduitAnterieur);

                RapportEtatAgriculteur.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatAgriculteur.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatAgriculteur.Parameters["Au"].Value = DateTime.Now;
                }
                else
                {
                    RapportEtatAgriculteur.Parameters["Au"].Value = datefin;
                }
                /////// Totale avance

                List<Achat> ListeAvances = db.Achats.Where(x => x.TypeAchat == TypeAchat.Avance && x.Founisseur.Id == Agr.Id).ToList();

                RapportEtatAgriculteur.Parameters["DateImpression"].Value = DateTime.Now;

                RapportEtatAgriculteur.Parameters["TotalAvances"].Value = Agr.TotalAvances;

                RapportEtatAgriculteur.Parameters["TotalAchats"].Value = Agr.TotalAchats;

                List<Achat> ListeAchats1 = db.Achats.Where(x => x.Founisseur.Id == Agr.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();

                RapportEtatAgriculteur.Parameters["TotalImpo"].Value = ListeAchats1.Sum(x => x.MtAdeduire);

                RapportEtatAgriculteur.Parameters["SoldeAgriculteur"].Value = Agr.SoldeAgriculteur;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    Tous = db.Achats.Where(x => x.Date >= DateMin && x.Founisseur.Id == Agr.Id && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    Regle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.Date >= DateMin && x.Founisseur.Id == Agr.Id && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.Date >= DateMin && x.Founisseur.Id == Agr.Id && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                }
              
                else
                {
                    Tous = db.Achats.Where(x => x.Founisseur.Id == Agr.Id && x.Date >= DateMin && x.Date <= datefin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    Regle = db.Achats.Where(x => x.Founisseur.Id == Agr.Id && x.EtatAchat == EtatAchat.Reglee && x.Date >= DateMin && x.Date <= datefin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Achats.Where(x => x.Founisseur.Id == Agr.Id && x.EtatAchat != EtatAchat.Reglee && x.Date >= DateMin && x.Date <= datefin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                }


                if (radioBtnTous.Checked)
                {
                    ListeAchats = Tous;


                    RapportEtatAgriculteur.Parameters["QteHuileTotale"].Value = ListeAchats.Sum(x => x.QteHuile);

                    RapportEtatAgriculteur.Parameters["TotalMtOp"].Value = ListeAchats.Sum(x => x.MontantReglement);

                    RapportEtatAgriculteur.Parameters["TotalAvance"].Value = ListeAchats.Sum(x => x.MontantRegle);

                    RapportEtatAgriculteur.Parameters["TotalSolde"].Value = ListeAchats.Sum(x => x.ResteApayer);

                    RapportEtatAgriculteur.Parameters["SoldeTotale"].Value = Agr.SoldeAgriculteurAvecSens;

                    RapportEtatAgriculteur.DataSource = ListeAchats;

                    using (ReportPrintTool printTool = new ReportPrintTool(RapportEtatAgriculteur))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }


                }

                else if (radioBtnRegle.Checked)
                {
                    ListeAchats = Regle;

                    RapportEtatAgriculteur.DataSource = ListeAchats;


                    RapportEtatAgriculteur.Parameters["QteHuileTotale"].Value = ListeAchats.Sum(x => x.QteHuile);

                    RapportEtatAgriculteur.Parameters["TotalMtOp"].Value = ListeAchats.Sum(x => x.MontantReglement);

                    RapportEtatAgriculteur.Parameters["TotalAvance"].Value = ListeAchats.Sum(x => x.MontantRegle);

                    RapportEtatAgriculteur.Parameters["TotalSolde"].Value = ListeAchats.Sum(x => x.ResteApayer);

                    RapportEtatAgriculteur.Parameters["SoldeTotale"].Value = Agr.SoldeAgriculteurAvecSens;

                    using (ReportPrintTool printTool = new ReportPrintTool(RapportEtatAgriculteur))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }
                }

                else if (radioBtnNonRegle.Checked)
                {
                    ListeAchats = NonRegle;

                    RapportEtatAgriculteur.DataSource = ListeAchats;


                    RapportEtatAgriculteur.Parameters["QteHuileTotale"].Value = ListeAchats.Sum(x => x.QteHuile);

                    RapportEtatAgriculteur.Parameters["TotalMtOp"].Value = ListeAchats.Sum(x => x.MontantReglement);

                    RapportEtatAgriculteur.Parameters["TotalAvance"].Value = ListeAchats.Sum(x => x.MontantRegle);

                    RapportEtatAgriculteur.Parameters["TotalSolde"].Value = ListeAchats.Sum(x => x.ResteApayer);

                    RapportEtatAgriculteur.Parameters["SoldeTotale"].Value = Agr.SoldeAgriculteurAvecSens;

                    using (ReportPrintTool printTool = new ReportPrintTool(RapportEtatAgriculteur))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }

            }

            else if (Agriculteurselected == null && checkAgriculteurs.Checked)
            {
                RapportEtatTousAgriculteur RapportEtatAgriculteurs = new RapportEtatTousAgriculteur();

                List<Agriculteur> ListeAgriculteurs = db.Agriculteurs.ToList();

      
                decimal SoldeAgriculteurs = ListeAgriculteurs.Sum(x => x.SoldeAgriculteurAvecSens);
                
                RapportEtatAgriculteurs.Parameters["SoldeTotale"].Value = SoldeAgriculteurs;

                List<Achat> AchatAnterieur = db.Achats.Where(x => x.Date < DateMin && (x.TypeAchat == TypeAchat.Base || x.TypeAchat == TypeAchat.Huile) && x.EtatAchat != EtatAchat.Reglee).ToList();

                Decimal SoldeAnterieur = AchatAnterieur.Sum(x => x.ResteApayer);

                RapportEtatAgriculteurs.Parameters["DateImpression"].Value = DateTime.Now;

                RapportEtatAgriculteurs.Parameters["SoldeAnterieur"].Value = SoldeAnterieur;

                RapportEtatAgriculteurs.Parameters["Du"].Value = DateMin;

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    RapportEtatAgriculteurs.Parameters["Au"].Value = DateTime.Now;
                }
                else
                {
                    RapportEtatAgriculteurs.Parameters["Au"].Value = datefin;
                }
               

                if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
                {
                    Tous = db.Achats.Where(x => x.Date >= DateMin && x.TypeAchat !=TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    Regle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.Date >= DateMin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.Date >= DateMin && x.TypeAchat !=TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                }      

                else
                {
                    Tous = db.Achats.Where(x => x.Date >= DateMin && x.Date <= datefin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    Regle = db.Achats.Where(x => x.EtatAchat == EtatAchat.Reglee && x.Date >= DateMin && x.Date <= datefin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                    NonRegle = db.Achats.Where(x => x.EtatAchat != EtatAchat.Reglee && x.Date >= DateMin && x.Date <= datefin && x.TypeAchat != TypeAchat.Service && x.TypeAchat != TypeAchat.Avance).OrderBy(x => x.Date).ToList();

                }

             
                if (radioBtnTous.Checked)
                {
                    ListeAchats = Tous;


                    RapportEtatAgriculteurs.Parameters["QteHuileTotale"].Value = ListeAchats.Sum(x => x.QteHuile);

                    RapportEtatAgriculteurs.Parameters["TotalMtOp"].Value = ListeAchats.Sum(x => x.MontantReglement);

                    RapportEtatAgriculteurs.Parameters["TotalAvance"].Value = ListeAchats.Sum(x => x.MontantRegle);

                    RapportEtatAgriculteurs.Parameters["TotalSolde"].Value = ListeAchats.Sum(x => x.ResteApayer);


                    RapportEtatAgriculteurs.DataSource = ListeAchats;

                    using (ReportPrintTool printTool = new ReportPrintTool(RapportEtatAgriculteurs))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }

                }

                else if (radioBtnRegle.Checked)
                {
                    ListeAchats = Regle;

                    RapportEtatAgriculteurs.DataSource = ListeAchats;


                    RapportEtatAgriculteurs.Parameters["QteHuileTotale"].Value = ListeAchats.Sum(x => x.QteHuile);

                    RapportEtatAgriculteurs.Parameters["TotalMtOp"].Value = ListeAchats.Sum(x => x.MontantReglement);

                    RapportEtatAgriculteurs.Parameters["TotalAvance"].Value = ListeAchats.Sum(x => x.MontantRegle);

                    RapportEtatAgriculteurs.Parameters["TotalSolde"].Value = ListeAchats.Sum(x => x.ResteApayer);
                    using (ReportPrintTool printTool = new ReportPrintTool(RapportEtatAgriculteurs))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }
                }

                else if (radioBtnNonRegle.Checked)
                {
                    ListeAchats = NonRegle;

                    RapportEtatAgriculteurs.DataSource = ListeAchats;


                    RapportEtatAgriculteurs.Parameters["QteHuileTotale"].Value = ListeAchats.Sum(x => x.QteHuile);

                    RapportEtatAgriculteurs.Parameters["TotalMtOp"].Value = ListeAchats.Sum(x => x.MontantReglement);

                    RapportEtatAgriculteurs.Parameters["TotalAvance"].Value = ListeAchats.Sum(x => x.MontantRegle);

                    RapportEtatAgriculteurs.Parameters["TotalSolde"].Value = ListeAchats.Sum(x => x.ResteApayer);
                    using (ReportPrintTool printTool = new ReportPrintTool(RapportEtatAgriculteurs))
                    {
                        printTool.ShowPreviewDialog();
                   
                    }
                }

                else
                {
                    XtraMessageBox.Show("Choisir une situation", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }
            }
        }

        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {

            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkAgriculteurs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAgriculteurs.Checked)
            {
                searchLookUpAgriculteur.ReadOnly = true;

            }

            else
            {
                searchLookUpAgriculteur.ReadOnly = false;
            }
        }

        private void searchLookUpAgriculteur_EditValueChanged(object sender, EventArgs e)
        {
            checkAgriculteurs.ReadOnly = true;
        }

       
    }
}