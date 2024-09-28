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
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using DevExpress.XtraSplashScreen;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmModifierVente : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }

        private static FrmModifierVente _FrmModifierVente;


        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;


        public static FrmModifierVente InstanceFrmModifierVente
        {
            get
            {
                if (_FrmModifierVente == null)
                    _FrmModifierVente = new FrmModifierVente();
                return _FrmModifierVente;
            }
        }


        public FrmModifierVente()
        {
            InitializeComponent();

            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmModifierVente_Load(object sender, EventArgs e)
        {

        }

        private void FrmModifierVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmModifierVente = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(TxtCode.Text);
            Vente VenteDb = db.Vente.Where(x => x.Id == code).FirstOrDefault();
          
                
            decimal TotalCommande;
            string TotalCommandeStr = TxtTotalCommande.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(TotalCommandeStr, out TotalCommande);

            VenteDb.MontantReglement = TotalCommande;

            VenteDb.TotalHT = TotalCommande;

            db.SaveChanges();


            if (VenteDb.MontantRegle == VenteDb.MontantReglement && VenteDb.MontantReglement != 0)
            {
                VenteDb.EtatVente = EtatVente.Reglee;
            }

            else if (VenteDb.MontantRegle == 0 && VenteDb.MontantReglement == VenteDb.ResteApayer)
            {
                VenteDb.EtatVente = EtatVente.NonReglee;
            }


            else if (VenteDb.ResteApayer < VenteDb.MontantReglement && VenteDb.MontantReglement != 0 && VenteDb.ResteApayer != 0)
            {
                VenteDb.EtatVente = EtatVente.PartiellementReglee;
            }

            else if (VenteDb.MontantRegle == 0 && VenteDb.MontantReglement == 0)
            {
                VenteDb.EtatVente = EtatVente.NonReglee;
            }

            db.SaveChanges();

            #region Historique paiement vente

            HistoriquePaiementVente hpv = new HistoriquePaiementVente();
         //   hpv.Client = VenteDb.client;
            hpv.MontantReglement = VenteDb.MontantReglement;
            hpv.MontantRegle = VenteDb.MontantRegle;   
            hpv.ResteApayer = VenteDb.ResteApayer;
            hpv.NumVente = VenteDb.Numero;
            hpv.ModeReglement = VenteDb.ModeReglement;
            hpv.NumCheque = VenteDb.NumeroCheque;
            hpv.Bank = VenteDb.Bank;
            hpv.DateEcheance = VenteDb.DateEcheance;
            hpv.Coffre = VenteDb.Coffre;
            hpv.Commentaire = "Modification Total Commande";
            db.HistoriquePaiementVente.Add(hpv);
            db.SaveChanges();


            #endregion

           this.Close();
            
            TxtCode.Text = string.Empty;
            TxtClient.Text = string.Empty;
            TxtQteVendue.Text = string.Empty;
            TxtTotalCommande.Text = string.Empty;
            TxtAvance.Text = string.Empty;
            TxtSolde.Text = string.Empty;


            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();

            XtraMessageBox.Show("Enregisterment Terminé ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();



        }

        private void TxtTotalCommande_EditValueChanged(object sender, EventArgs e)
        {

            decimal TotalCommande;
            string TotalCommandeStr = TxtTotalCommande.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(TotalCommandeStr, out TotalCommande);

            decimal Avance;
            string AvanceStr = TxtAvance.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(AvanceStr, out Avance);

            TxtSolde.Text = (TotalCommande - Avance).ToString();
        }
    }
}