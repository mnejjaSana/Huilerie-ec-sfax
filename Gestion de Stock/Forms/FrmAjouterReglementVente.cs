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
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Model;
using DevExpress.XtraLayout.Utils;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterReglementVente : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmAjouterReglementVente _FrmAjouterReglementVente;

        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;

        public static FrmAjouterReglementVente InstanceFrmAjouterReglementVente
        {
            get
            {
                if (_FrmAjouterReglementVente == null)
                    _FrmAjouterReglementVente = new FrmAjouterReglementVente();
                return _FrmAjouterReglementVente;
            }
        }

        public FrmAjouterReglementVente()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmAjouterReglementVente_Load(object sender, EventArgs e)
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

        private void FrmAjouterReglementVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterReglementVente = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {           
            int id = int.Parse(TxtNumVente.Text);

            db = new Model.ApplicationContext();

            Vente Vente = db.Vente.Find(id);

            decimal MontantRegle;
            string MontantRegleStr = TxtMTRegle.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantRegleStr, out MontantRegle);

            decimal Solde;
            string SoldeStr = TxtResteAPayer.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);

            if (MontantRegle > Solde || MontantRegle <= 0)
            {
                XtraMessageBox.Show("Montant Encaissé est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMTRegle.Text = Solde.ToString();
                return;

            }

            if (comboBoxModePaiement.SelectedItem.ToString().Equals("Chèque"))
            {
                if (string.IsNullOrEmpty(TxtNumCheque.Text))
                {
                    TxtNumCheque.ErrorText = "N° Chéque Obligatoire";
                    return;

                }

                if (string.IsNullOrEmpty(TxtBank.Text))
                {
                    TxtBank.ErrorText = "Banque Obligatoire";
                    return;

                }

                if (dateEcheance.EditValue == null)
                {
                    dateEcheance.ErrorText = "Date Echeance Obligatoire";
                    return;

                }
            }

            Vente.MontantRegle = decimal.Add(Vente.MontantRegle , MontantRegle);

            decimal MontantTotal = Vente.TotalHT;

            db.SaveChanges();

            if (Vente.MontantRegle == MontantTotal && Vente.ResteApayer == 0)
            {
                Vente.EtatVente = EtatVente.Reglee;
            }

            else if (MontantRegle == 0 && MontantTotal == Vente.ResteApayer)
            {
                Vente.EtatVente = EtatVente.NonReglee;
            }

            else if (Vente.ResteApayer < MontantTotal && MontantTotal != 0 && Vente.ResteApayer != 0)
            {
                Vente.EtatVente = EtatVente.PartiellementReglee;
            }

            else if (MontantRegle == 0 && MontantTotal == 0)
            {
                Vente.EtatVente = EtatVente.NonReglee;
            }

            db.SaveChanges();

            #region  Historique paiement vente
            HistoriquePaiementVente hpv = new HistoriquePaiementVente();
            hpv.IdVente = Vente.Id;
            hpv.IdClient = Vente.IdClient;
            hpv.IntituleClient = Vente.IntituleClient;
            hpv.NumClient = Vente.NumClient;
            hpv.MontantRegle = MontantRegle;
            hpv.MontantReglement = Vente.MontantReglement;
            hpv.ResteApayer = Vente.ResteApayer;
            hpv.NumVente = Vente.Numero;

            if (comboBoxModePaiement.SelectedItem.ToString().Equals("Espèce"))
            {
                hpv.ModeReglement = ModeReglement.Espèce;
                hpv.Coffre = false;
            }
            else if (comboBoxModePaiement.SelectedItem.ToString().Equals("Chèque"))
            {
                hpv.ModeReglement = ModeReglement.Chèque;
                hpv.NumCheque = TxtNumCheque.Text;
                hpv.Coffre = true;
                hpv.DateEcheance = dateEcheance.DateTime;
                hpv.Bank = TxtBank.Text;
            }

            db.HistoriquePaiementVente.Add(hpv);
            db.SaveChanges();
            #endregion 
            #region Alimentation

            if (hpv.Coffre == false)
            {        
                Alimentation A = new Alimentation();
                A.Client = db.Clients.Find(Vente.IdClient);
                A.Source = SourceAlimentation.Vente;
                A.Montant = MontantRegle;
                A.Commentaire = "Encaissement Vente N° " + Vente.Numero;
                db.Alimentations.Add(A);
                db.SaveChanges();
                A.Numero = "E" + (A.Id).ToString("D8");
                db.SaveChanges();

                MouvementCaisse mvtCaisse = new MouvementCaisse();
                mvtCaisse.MontantSens = MontantRegle;
                mvtCaisse.Client = db.Clients.Find(Vente.IdClient);
                mvtCaisse.CodeTiers = Vente.NumClient;
                mvtCaisse.Sens = Sens.Alimentation;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Source = "Client : " + Vente.IntituleClient;
                Caisse CaisseDb = db.Caisse.Find(1);
                if (CaisseDb != null)
                {
                    CaisseDb.MontantTotal = decimal.Add(CaisseDb.MontantTotal, MontantRegle);

                }
                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Montant = CaisseDb.MontantTotal;
             
                mvtCaisse.Commentaire = "Encaissement Vente N° " + Vente.Numero;
                mvtCaisse.Numero = "E" + (lastMouvement).ToString("D8");
                mvtCaisse.Vente = Vente;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();

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
                #endregion
            }

            TxtNumCheque.Text = string.Empty;
            dateEcheance.EditValue = null;
            TxtBank.Text = string.Empty;
            TxtMTRegle.Text = string.Empty;
            List<string> ListeModePaiement = Enum.GetNames(typeof(ModeReglement)).ToList();

            comboBoxModePaiement.SelectedItem = ListeModePaiement[0];

           this.Close();
           
            if (Application.OpenForms.OfType<FrmListeVente>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeVente>().First().venteBindingSource.DataSource = db.Vente.OrderByDescending(x => x.Date).ToList();

            XtraMessageBox.Show("Règlement Ajouté avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBoxModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxModePaiement.SelectedIndex == 1)
            {
                layoutControlItem11.Visibility = LayoutVisibility.Always;
                layoutControlItem12.Visibility = LayoutVisibility.Always;
                layoutControlItem13.Visibility = LayoutVisibility.Always;
            }

            else if (comboBoxModePaiement.SelectedIndex == 0)
            {
                layoutControlItem11.Visibility = LayoutVisibility.Never;
                layoutControlItem12.Visibility = LayoutVisibility.Never;
                layoutControlItem13.Visibility = LayoutVisibility.Never;

            }
        }
    }
}