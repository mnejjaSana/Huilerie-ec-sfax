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
    public partial class FrmClotureCaisse : DevExpress.XtraEditors.XtraForm
    {

        private static FrmClotureCaisse _FrmClotureCaisse;

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;


        public static FrmClotureCaisse InstanceFrmClotureCaisse
        {
            get
            {
                if (_FrmClotureCaisse == null)
                    _FrmClotureCaisse = new FrmClotureCaisse();
                return _FrmClotureCaisse;
            }
        }


        public FrmClotureCaisse()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmClotureCaisse_Load(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Caisse CaisseDb = db.Caisse.Find(1);

            if (CaisseDb != null)
            {
                TxtMontantCaisse.Text = (Math.Truncate(CaisseDb.MontantTotal * 1000m) / 1000m).ToString();

            }

        }

        private void FrmClotureCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmClotureCaisse = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMontantCloture.Text))
            {
                TxtMontantCloture.ErrorText = "Montant est obligatoire";
                return;

            }

            db = new Model.ApplicationContext();

            Caisse CaisseDb = db.Caisse.Find(1);

            decimal MontantCaisse;
            string MontantCaisseStr = TxtMontantCaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantCaisseStr, out MontantCaisse);

            decimal MontantCloture;
            string MontantClotureStr = TxtMontantCloture.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantClotureStr, out MontantCloture);

            if (MontantCloture > MontantCaisse || MontantCloture <= 0)
            {
                XtraMessageBox.Show("Montant Clôture est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMontantCloture.Text = string.Empty;
                 TxtSolde.Text = string.Empty;

                return;
            }

            else
            {
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal =decimal.Subtract( MontantCaisse, MontantCloture);

                    db.SaveChanges();

                    #region ajouter depense

                    Depense D = new Depense();
                    D.DateCreation = DateTime.Now;
                    D.Montant = MontantCloture;

                    D.Nature = NatureMouvement.ClôtureCaisse;
                    D.Commentaire = "Clôture Caisse";

                    db.Depenses.Add(D);
                    db.SaveChanges();
                    D.Numero = "D" + D.Id.ToString("D8");
                    db.SaveChanges();
                    #endregion

                    #region ajouter mvt caisse
                    MouvementCaisse mvtCaisse = new MouvementCaisse();
                    mvtCaisse.Source = "Admin";
                    mvtCaisse.MontantSens = MontantCloture * -1;
                    mvtCaisse.Date = D.DateCreation;
                    mvtCaisse.Sens = Sens.Depense;
                    mvtCaisse.Commentaire = "Clôture Caisse";
                    mvtCaisse.Montant = CaisseDb.MontantTotal;
                    mvtCaisse.NatureDepense = D;
                    db.MouvementsCaisse.Add(mvtCaisse);
                    db.SaveChanges();
                    int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                    mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                    db.SaveChanges();
                    #endregion


                    XtraMessageBox.Show("Caisse Clôturée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   this.Close();
                    TxtMontantCaisse.Text = CaisseDb.MontantTotal.ToString();
                    TxtMontantCloture.Text = string.Empty;
                    TxtSolde.Text = string.Empty;

                    // waiting Form
                    //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
                    //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter .....");
                    //for (int i = 0; i < 100; i++)
                    //{
                    //    Thread.Sleep(10);
                    //}
                    //SplashScreenManager.CloseForm();

                    if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                        Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.ToList();

                    if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                    {
                        Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
                    }

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

            }

        }

        private void TxtMontantCloture_EditValueChanged(object sender, EventArgs e)
        {

            decimal MontantCaisse;
            string MontantCaisseStr = TxtMontantCaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantCaisseStr, out MontantCaisse);

            decimal MontantCloture;
            string MontantClotureStr = TxtMontantCloture.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantClotureStr, out MontantCloture);


            TxtSolde.Text = (MontantCaisse - MontantCloture).ToString();
        }
    }
}