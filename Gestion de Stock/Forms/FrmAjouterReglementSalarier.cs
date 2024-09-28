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
using DevExpress.XtraLayout.Utils;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterReglementSalarier : DevExpress.XtraEditors.XtraForm
    {

        private static FrmAjouterReglementSalarier _FrmAjouterReglementSalarier;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;

        public static FrmAjouterReglementSalarier InstanceFrmAjouterReglementSalarier
        {
            get
            {
                if (_FrmAjouterReglementSalarier == null)
                    _FrmAjouterReglementSalarier = new FrmAjouterReglementSalarier();
                return _FrmAjouterReglementSalarier;
            }
        }
        public FrmAjouterReglementSalarier()
        {
            db = new Model.ApplicationContext();
            InitializeComponent();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }

        private void FrmAjouterReglementSalarier_Load(object sender, EventArgs e)
        {
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            if (ModePaiement != null)
            {
                foreach (var M in ModePaiement)
                {
                    comboBoxModePaiement.Properties.Items.Add(M);
                }

                comboBoxModePaiement.SelectedIndex = 0;
                if (ModePaiement.Count > 0)
                    comboBoxModePaiement.SelectedItem = ModePaiement[0];

            }

        }

        private void FrmAjouterReglementSalarier_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmAjouterReglementSalarier = null;
        }

        private void BtnAjouterReglement_Click(object sender, EventArgs e)
        {
            //Caisse caisse = db.Caisse.Find(1);
            //int id = int.Parse(TxtCodeSalarier.Text);
            //var salarier = db.Salariers.Find(id);

            //decimal MontantRegle;
            //string MontantRegleStr = TxtMontantAPayer.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            //decimal.TryParse(MontantRegleStr, out MontantRegle);

            //decimal Solde;
            //string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            //decimal.TryParse(SoldeStr, out Solde);


            //if (MontantRegle > Solde || MontantRegle <= 0)
            //{
            //    XtraMessageBox.Show("Montant à Payer est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    TxtMontantAPayer.Text = Solde.ToString();
            //    return;

            //}


            //if (MontantRegle > caisse.MontantTotal)
            //{
            //    XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    TxtMontantAPayer.Text = Solde.ToString();
            //    return;

            //}

            //if (comboBoxModePaiement.SelectedItem.ToString().Equals("Chèque"))
            //{
            //    if (string.IsNullOrEmpty(TxtNumCheque.Text))
            //    {
            //        TxtNumCheque.ErrorText = "N° Chéque Obligatoire";
            //        return;

            //    }

            //    if (string.IsNullOrEmpty(TxtBank.Text))
            //    {
            //        TxtBank.ErrorText = "Banque Obligatoire";
            //        return;

            //    }

            //    if (dateEcheance.EditValue == null)
            //    {
            //        dateEcheance.ErrorText = "Date Echeance Obligatoire";
            //        return;

            //    }
            //}




            //salarier.MontantReglé = salarier.MontantReglé + MontantRegle;

            //db.SaveChanges();

            //decimal MontantTotal = salarier.MontantTotal;

            //if (salarier.MontantReglé == MontantTotal && salarier.MontantRestReglé == 0)
            //{
            //    salarier.EtatSalarie = EtatSalarie.Reglee;
            //}

            //else if (MontantRegle == 0 && MontantTotal == salarier.MontantRestReglé)
            //{
            //    salarier.EtatSalarie = EtatSalarie.NonReglee;
            //}


            //else if (salarier.MontantRestReglé < MontantTotal && MontantTotal != 0 && salarier.MontantRestReglé != 0)
            //{
            //    salarier.EtatSalarie = EtatSalarie.PartiellementReglee;
            //}

            //else if (MontantRegle == 0 && MontantTotal == 0)
            //{
            //    salarier.EtatSalarie = EtatSalarie.NonReglee;
            //}


            //db.SaveChanges();

            //// Ajouter Historique paiement salarie
            //#region

            //HistoriquePaiementSalarie hps = new HistoriquePaiementSalarie();
            //hps.Salarie = salarier;
            //hps.MontantRegle = MontantRegle;
            //hps.MontantReglement = salarier.MontantTotal;
            //hps.ResteApayer = salarier.MontantRestReglé;


            //if (comboBoxModePaiement.SelectedItem.ToString().Equals("Espèce"))
            //{
            //    hps.ModeReglement = ModeReglement.Espèce;
            //    hps.Bank = null;
            //    hps.DateEcheance = null;
            //    hps.Coffre = false;
            //}
            //else if (comboBoxModePaiement.SelectedItem.ToString().Equals("Chèque"))
            //{

            //    hps.ModeReglement = ModeReglement.Chèque;

            //    hps.NumCheque = Convert.ToInt32(TxtNumCheque.Text);
            //    hps.Bank = TxtBank.Text;
            //    hps.DateEcheance = dateEcheance.DateTime;
            //    hps.Coffre = true;
            //}

            //db.HistoriquePaiementSalaries.Add(hps);
            //db.SaveChanges();


            //#endregion


            //#region depense
            //// Ajouter Depense

            //if (hps.Coffre == false)
            //{
            //    Depense D = new Depense();
            //    D.Nature = NatureMouvement.Salarié;

            //    D.Montant = MontantRegle;

            //    D.Commentaire = "Paiement Salarié: " + salarier.Intitule;
            //    // D.Source = "Règlement Salarié";

            //    MouvementCaisse mvtCaisse = new MouvementCaisse();
            //    mvtCaisse.MontantSens = MontantRegle * -1;
            //    mvtCaisse.Sens = Sens.Depense;
            //    mvtCaisse.Date = DateTime.Now;
            //    mvtCaisse.Source = "Salarié: " + salarier.Intitule;
            //    Caisse CaisseDb = db.Caisse.Find(1);
            //    if (CaisseDb != null)
            //    {
            //        CaisseDb.MontantTotal = CaisseDb.MontantTotal - MontantRegle;

            //    }
            //    int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
            //    mvtCaisse.Montant = CaisseDb.MontantTotal;
            //    mvtCaisse.Commentaire = "Paiement Salarié : " + salarier.Intitule;
            //    db.Depenses.Add(D);
            //    db.SaveChanges();
            //    mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
            //    mvtCaisse.Salarie = salarier;
            //    db.MouvementsCaisse.Add(mvtCaisse);
            //    db.SaveChanges();

            //    if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
            //        Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.ToList();

            //    if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
            //    {
            //        Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();


            //        if (db.MouvementsCaisse.Count() > 0)
            //        {

            //            List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

            //            MouvementCaisse mvt = ListeMvtCaisse.Last();

            //            Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = mvt.Montant.ToString();

            //        }


            //    }


            //    #endregion

            //}
            //TxtMontantAPayer.Text = string.Empty;
            //TxtNumCheque.Text = string.Empty;
            //TxtBank.Text = string.Empty;
            //dateEcheance.EditValue = null;
            //List<string> ListeModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();
            //comboBoxModePaiement.SelectedItem = ListeModePaiement[0];

            //this.Hide();
            //// update other Form
            ////waiting Form 
            //if (Application.OpenForms.OfType<FrmReglementsalaire>().FirstOrDefault() != null)
            //    Application.OpenForms.OfType<FrmReglementsalaire>().First().salarierBindingSource.DataSource = db.Salariers.ToList();
            //XtraMessageBox.Show("Règlement Ajouté avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            // numero cheque visible si mode paiement cheque
            if (comboBoxModePaiement.SelectedIndex == 1)
            {
                layoutControlItem10.Visibility = LayoutVisibility.Always;
                layoutControlItem12.Visibility = LayoutVisibility.Always;
                layoutControlItem13.Visibility = LayoutVisibility.Always;
            }

            // numero cheque non visible si mode paiement espece
            else if (comboBoxModePaiement.SelectedIndex == 0)
            {
                layoutControlItem10.Visibility = LayoutVisibility.Never;
                layoutControlItem12.Visibility = LayoutVisibility.Never;
                layoutControlItem13.Visibility = LayoutVisibility.Never;
            }
        }
    }
}