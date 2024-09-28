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
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Globalization;
using Gestion_de_Stock.Model;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterAlimentation : DevExpress.XtraEditors.XtraForm
    {
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterAlimentation _FrmAlimentation;
  
      

        public static FrmAjouterAlimentation InstanceFrmAlimentation
        {
            get
            {
                if (_FrmAlimentation == null)
                    _FrmAlimentation = new FrmAjouterAlimentation();
                return _FrmAlimentation;
            }
        }


        public FrmAjouterAlimentation()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAlimentation_Load(object sender, EventArgs e)
        {
            /***********************  Source Liste  ***********************/
            List<string> ListeSourceAlientation = Enum.GetNames(typeof(SourceAlimentation)).ToList();
           
            if (ListeSourceAlientation != null)
            {
                foreach (var Source in ListeSourceAlientation)
                {
                    if (Source != "Service" && Source != "Vente" && Source!="AnnulationAvance")
                    {
                        comboBoxSource.Properties.Items.Add(Source);
                    }
                 
                }

                comboBoxSource.SelectedIndex = 0;
                if (ListeSourceAlientation.Count > 0)
                    comboBoxSource.SelectedItem = ListeSourceAlientation[0];

            }
        }

        private void FrmAlimentation_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAlimentation = null;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);
          

            if (string.IsNullOrEmpty(TxtMontant.Text))
            {
                TxtMontant.ErrorText = "Montant est Obligatoire";
                return;

            }

            if (Montant <= 0)
            {
                XtraMessageBox.Show("Montant est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMontant.ErrorText = "Montant est Invalid";
                return;
            }

            Alimentation A = new Alimentation();
            MouvementCaisse mvtCaisse = new MouvementCaisse();

            A.Montant = Montant;

            if (comboBoxSource.SelectedItem.ToString().Equals("Zitouna"))
            {
                A.Source = SourceAlimentation.Zitouna;
                mvtCaisse.Source = SourceAlimentation.Zitouna.ToString();
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("BH"))
            {
                A.Source = SourceAlimentation.BH;
                mvtCaisse.Source= SourceAlimentation.BH.ToString();
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("BNA"))
            {
                A.Source = SourceAlimentation.BNA;
                mvtCaisse.Source = SourceAlimentation.BNA.ToString();
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("UIB"))
            {
                A.Source = SourceAlimentation.UIB;
                mvtCaisse.Source = SourceAlimentation.UIB.ToString();
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("Elbaraka"))
            {
                A.Source = SourceAlimentation.Elbaraka;
                mvtCaisse.Source = SourceAlimentation.Elbaraka.ToString();
            }
            else if (comboBoxSource.SelectedItem.ToString().Equals("BIAT"))
            {
                A.Source = SourceAlimentation.BIAT;
                mvtCaisse.Source = SourceAlimentation.BIAT.ToString();
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("Attijari"))
            {
                A.Source = SourceAlimentation.Attijari;
                mvtCaisse.Source = SourceAlimentation.Attijari.ToString();
            }
            else if (comboBoxSource.SelectedItem.ToString().Equals("Autre"))
            {
                A.Source = SourceAlimentation.Autre;
                mvtCaisse.Source = SourceAlimentation.Autre.ToString();
            }
            else if (comboBoxSource.SelectedItem.ToString().Equals("Vente"))
            {
                A.Source = SourceAlimentation.Vente;
                mvtCaisse.Source = SourceAlimentation.Vente.ToString();
            }
      
            A.Commentaire = TxtCommentaire.Text;

            mvtCaisse.MontantSens = Montant;

            mvtCaisse.Date = A.DateCreation;

            mvtCaisse.Sens = Sens.Alimentation;
            mvtCaisse.Commentaire = TxtCommentaire.Text;

            Caisse CaisseDb = db.Caisse.Find(1);

            if (CaisseDb != null)
            {
                CaisseDb.MontantTotal = decimal.Add( CaisseDb.MontantTotal ,Montant);

            }

            mvtCaisse.Montant = CaisseDb.MontantTotal;

            db.Alimentations.Add(A);
            db.SaveChanges();

            A.Numero = "E" + (A.Id).ToString("D8");
            db.SaveChanges();

            mvtCaisse.Numero = "E" + (A.Id).ToString("D8");
            db.MouvementsCaisse.Add(mvtCaisse);
            db.SaveChanges();

            XtraMessageBox.Show("Alimentation Enregistrée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<string> ListeSourceAlientation = Enum.GetNames(typeof(SourceAlimentation)).ToList();
      
            comboBoxSource.SelectedIndex = 0;
            if (ListeSourceAlientation.Count > 0)
                comboBoxSource.SelectedItem = ListeSourceAlientation[0];



            TxtMontant.Text = string.Empty;
        

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
            if (Application.OpenForms.OfType<FrmListeAlimentation>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeAlimentation>().First().alimentationBindingSource.DataSource = db.Alimentations.OrderByDescending(x => x.DateCreation).ToList();

            if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();
                

                if (db.MouvementsCaisse.Count() > 0)
                {
               
                    List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                    MouvementCaisse mvt = ListeMvtCaisse.Last();

                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                }
            }

        }

        private void comboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSource.SelectedItem.ToString().Equals("BNA"))
            {
                TxtCommentaire.Text = "Retrait Banque BNA";
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("Zitouna"))
            {
                TxtCommentaire.Text = "Retrait Banque Zitouna";
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("BH"))
            {
                TxtCommentaire.Text = "Retrait Banque BH";
            }

    
            else if (comboBoxSource.SelectedItem.ToString().Equals("UIB"))
            {
                TxtCommentaire.Text = "Retrait Banque UIB";
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("Elbaraka"))
            {
                TxtCommentaire.Text = "Retrait Banque Elbaraka";
            }
            else if (comboBoxSource.SelectedItem.ToString().Equals("BIAT"))
            {
                TxtCommentaire.Text = "Retrait Banque BIAT";
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("Attijari"))
            {
                TxtCommentaire.Text = "Retrait Banque Attijari";
            }

            else if (comboBoxSource.SelectedItem.ToString().Equals("Autre"))
            {
                TxtCommentaire.Text = "";
            }
            else if (comboBoxSource.SelectedItem.ToString().Equals("Vente"))
            {
                TxtCommentaire.Text = "";
            }
        }
    }
}