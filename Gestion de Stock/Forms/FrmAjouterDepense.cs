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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraLayout.Utils;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterDepense : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private static FrmAjouterDepense _FrmDepense;


        public static FrmAjouterDepense InstanceFrmDepense
        {
            get
            {
                if (_FrmDepense == null)
                    _FrmDepense = new FrmAjouterDepense();
                return _FrmDepense;
            }
        }


        public FrmAjouterDepense()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
        }

        private void FrmDepense_Load(object sender, EventArgs e)
        {
            /***********************  Nature Mouvement Liste  ***********************/

            List<string> ListeNatureMVT = Enum.GetNames(typeof(NatureMouvement)).ToList();
            if (ListeNatureMVT != null)
            {
                foreach (var Nature in ListeNatureMVT)
                {
                    if (Nature.Equals("Salarié") || Nature.Equals("Prélèvement") || Nature.Equals("Autre"))
                    {
                        comboBoxNature.Properties.Items.Add(Nature);
                    }

                }

                comboBoxNature.SelectedIndex = 0;
                if (ListeNatureMVT.Count > 0)
                    comboBoxNature.SelectedItem = ListeNatureMVT[0];

            }

            /**********************  Ouvrier Liste************************/
            salarierBindingSource.DataSource = db.Salariers.Select(x => new { x.Id, x.numero, x.Intitule, x.Tel }).ToList();


            ///***********************  Mode  Paiement Liste  ***********************/
            List<string> ModePaiement = Enum.GetNames(typeof(ModeReglement)).Where(item => item != ModeReglement.Traite.ToString()).ToList();
            if (ModePaiement != null)
            {
                foreach (var M in ModePaiement)
                {
                    comboBoxModePaie.Properties.Items.Add(M);
                }

                comboBoxModePaie.SelectedIndex = 0;
                if (ModePaiement.Count > 0)
                    comboBoxModePaie.SelectedItem = ModePaiement[0];

            }


            /***********************  Bnaque Liste  ***********************/
            List<string> ListeBanques = Enum.GetNames(typeof(SourceAlimentation)).ToList();

            if (ListeBanques != null)
            {
                foreach (var Source in ListeBanques)
                {
                    if (Source != "Service" && Source != "Vente")
                    {
                        comboBoxBank.Properties.Items.Add(Source);
                    }

                }

                comboBoxBank.SelectedIndex = 0;
                if (ListeBanques.Count > 0)
                    comboBoxBank.SelectedItem = ListeBanques[0];

            }

            Caisse CaisseDb = db.Caisse.Find(1);

            if (CaisseDb != null)
            {
                TxtSoldeCaisse.Text =  (Math.Truncate(CaisseDb.MontantTotal * 1000m) / 1000m).ToString();

            }



        }

        private void FrmDepense_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDepense = null;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            Depense D = new Depense();

            Salarier S = new Salarier();

            MouvementCaisse mvtCaisse = new MouvementCaisse();

            Coffrecheque Cheque = new Coffrecheque();

            Caisse CaisseDb = db.Caisse.Find(1);

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);

            if (string.IsNullOrEmpty(TxtMontant.Text))
            {
                TxtMontant.ErrorText = "Montant est obligatoire";
                return;

            }




            #region Prelevement
            if (comboBoxNature.SelectedItem.ToString().Equals("Prélèvement"))
            {

                Prelevement prelevement = new Prelevement();
                prelevement.Montant = Montant;
                prelevement.Commentaire = TxtCommentaire.Text;
                prelevement.Date = datePrélèvements.DateTime;

                if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                {
                    prelevement.Banque = SourceAlimentation.Zitouna.ToString();

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                {
                    prelevement.Banque = SourceAlimentation.BH.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                {
                    prelevement.Banque = SourceAlimentation.BNA.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                {
                    prelevement.Banque = SourceAlimentation.UIB.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                {
                    prelevement.Banque = SourceAlimentation.Elbaraka.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                {
                    prelevement.Banque = SourceAlimentation.BIAT.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                {
                    prelevement.Banque = SourceAlimentation.Attijari.ToString(); ;

                }

                db.Prelevements.Add(prelevement);
                db.SaveChanges();
                prelevement.Num = "Prélèvement" + (prelevement.id).ToString("D8");
                db.SaveChanges();


                Depense Dep = new Depense();
                Dep.Bank = prelevement.Banque;

                Dep.DateCreation = prelevement.Date;
                Dep.Montant = prelevement.Montant;
                Dep.Nature = NatureMouvement.Prélèvement;
                Dep.Commentaire = prelevement.Commentaire;
                db.Depenses.Add(Dep);
                db.SaveChanges();

                Dep.Numero = "D" + (Dep.Id).ToString("D8"); ;
                db.SaveChanges();


            }
            #endregion

            #region Ajouter depense espéce


            if (comboBoxModePaie.SelectedItem.ToString().Equals("Espèce"))
            {

                if (Montant > 0)
                {
                    if (CaisseDb.MontantTotal >= Montant)
                    {
                        if (comboBoxNature.SelectedItem.ToString().Equals("Salarié"))
                        {

                            if (string.IsNullOrEmpty(searchLookUpOuvrier.Text))
                            {
                                XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                                return;

                            }
                            GridView view = searchLookUpOuvrier.Properties.View;
                            int rowHandle = view.FocusedRowHandle;
                            string fieldName = "Id"; // or other field name  
                            object SalarierSelected = view.GetRowCellValue(rowHandle, fieldName);
                            if (SalarierSelected == null)
                            {
                                XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                                searchLookUpOuvrier.Focus();
                                return;

                            }
                            else if (SalarierSelected != null)
                            {
                                int IdSalarier = Convert.ToInt32(SalarierSelected);
                                S = db.Salariers.Find(IdSalarier);

                            }
                            D.Nature = NatureMouvement.Salarié;

                            D.Salarie = S;
                            D.Tiers = S.Intitule;
                            D.CodeTiers = S.numero;
                            D.Montant = Montant;
                            D.ModePaiement = "Espèce";
                            D.Commentaire = TxtCommentaire.Text;
                            db.Depenses.Add(D);
                            db.SaveChanges();
                            D.Numero = "D" + (D.Id).ToString("D8");
                            db.SaveChanges();
                        }

                        else if (comboBoxNature.SelectedItem.ToString().Equals("Autre"))
                        {

                            if (string.IsNullOrEmpty(TxtCommentaire.Text))
                            {
                                TxtCommentaire.ErrorText = "Commentaire est obligatoire";
                                return;

                            }

                            D.Nature = NatureMouvement.Autre;
                            D.Montant = Montant;
                            D.ModePaiement = "Espèce";
                            D.Commentaire = TxtCommentaire.Text;
                            db.Depenses.Add(D);
                            db.SaveChanges();
                            D.Numero = "D" + (D.Id).ToString("D8");
                            db.SaveChanges();

                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        TxtMontant.Text = string.Empty;
                        return;

                    }
                }
                else
                {
                    XtraMessageBox.Show("Montant est Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    TxtMontant.Text = string.Empty;
                    return;

                }

            }


            #endregion

            #region Ajouter depense cheque
            if (comboBoxModePaie.SelectedItem.ToString().Equals("Chèque"))
            {
                if (string.IsNullOrEmpty(TxtNumCheque.Text))
                {
                    TxtNumCheque.ErrorText = "N° Chéque Obligatoire";
                    return;

                }


                if (dateEchance.EditValue == null)
                {
                    dateEchance.ErrorText = "Date Echeance Obligatoire";
                    return;

                }

                if (comboBoxNature.SelectedItem.ToString().Equals("Salarié"))
                {

                    if (string.IsNullOrEmpty(searchLookUpOuvrier.Text))
                    {
                        XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        return;

                    }
                    GridView view = searchLookUpOuvrier.Properties.View;
                    int rowHandle = view.FocusedRowHandle;
                    string fieldName = "Id"; // or other field name  
                    object SalarierSelected = view.GetRowCellValue(rowHandle, fieldName);
                    if (SalarierSelected == null)
                    {
                        XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        searchLookUpOuvrier.Focus();
                        return;

                    }
                    else if (SalarierSelected != null)
                    {
                        int IdSalarier = Convert.ToInt32(SalarierSelected);
                        S = db.Salariers.Find(IdSalarier);

                    }

                    D.Nature = NatureMouvement.Salarié;
                    D.Salarie = S;
                    D.Tiers = S.Intitule;
                    D.CodeTiers = S.numero;
                    D.Montant = Montant;
                    D.ModePaiement = "Chèque";
                    D.NumCheque = TxtNumCheque.Text;
                    D.DateEcheance = dateEchance.DateTime;


                    if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                    {
                        D.Bank = SourceAlimentation.Zitouna.ToString();

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                    {
                        D.Bank = SourceAlimentation.BH.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                    {
                        D.Bank = SourceAlimentation.BNA.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                    {
                        D.Bank = SourceAlimentation.UIB.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                    {
                        D.Bank = SourceAlimentation.Elbaraka.ToString(); ;

                    }
                    else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                    {
                        D.Bank = SourceAlimentation.BIAT.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                    {
                        D.Bank = SourceAlimentation.Attijari.ToString(); ;

                    }

                    D.Commentaire = TxtCommentaire.Text;
                    db.Depenses.Add(D);
                    db.SaveChanges();

                    D.Numero = "D" + (D.Id).ToString("D8");
                    db.SaveChanges();
                }
                else if (comboBoxNature.SelectedItem.ToString().Equals("Autre"))
                {
                    D.Nature = NatureMouvement.Autre;
                    D.Montant = Montant;
                    D.ModePaiement = "Chèque";
                    D.NumCheque = TxtNumCheque.Text;
                    D.DateEcheance = dateEchance.DateTime;
                    if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                    {
                        D.Bank = SourceAlimentation.Zitouna.ToString();

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                    {
                        D.Bank = SourceAlimentation.BH.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                    {
                        D.Bank = SourceAlimentation.BNA.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                    {
                        D.Bank = SourceAlimentation.UIB.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                    {
                        D.Bank = SourceAlimentation.Elbaraka.ToString(); ;

                    }
                    else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                    {
                        D.Bank = SourceAlimentation.BIAT.ToString(); ;

                    }

                    else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                    {
                        D.Bank = SourceAlimentation.Attijari.ToString(); ;

                    }
                    D.Commentaire = TxtCommentaire.Text;
                    db.Depenses.Add(D);
                    db.SaveChanges();

                    D.Numero = "D" + (D.Id).ToString("D8");
                    db.SaveChanges();
                    if (string.IsNullOrEmpty(TxtCommentaire.Text))
                    {
                        TxtCommentaire.ErrorText = "Commentaire est obligatoire";
                        return;

                    }

                }
            }


            #endregion

            #region Ajouter cheque dans coffre emis

            if (comboBoxNature.SelectedItem.ToString().Equals("Salarié") && comboBoxModePaie.SelectedIndex == 1)
            {

                if (string.IsNullOrEmpty(searchLookUpOuvrier.Text))
                {
                    XtraMessageBox.Show("Choisir un Salarié", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    return;

                }
                Cheque.Type = "Chèque";
                Cheque.DateCreation = D.DateCreation;
                Cheque.NomSalarier = S.Intitule;
                Cheque.Montant = Montant;
                Cheque.NumCheque = TxtNumCheque.Text;

                if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                {
                    Cheque.Bank = SourceAlimentation.Zitouna.ToString();

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                {
                    Cheque.Bank = SourceAlimentation.BH.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                {
                    Cheque.Bank = SourceAlimentation.BNA.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                {
                    Cheque.Bank = SourceAlimentation.UIB.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                {
                    Cheque.Bank = SourceAlimentation.Elbaraka.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                {
                    Cheque.Bank = SourceAlimentation.BIAT.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                {
                    Cheque.Bank = SourceAlimentation.Attijari.ToString(); ;

                }

                Cheque.DateEcheance = dateEchance.DateTime;
                Cheque.Commentaire = D.Commentaire;
                Cheque.Depense = D;
                db.CoffreCheques.Add(Cheque);
                db.SaveChanges();
            }
            else if (comboBoxNature.SelectedItem.ToString().Equals("Autre") && comboBoxModePaie.SelectedIndex == 1)
            {
                Cheque.Type = "Chèque";
                Cheque.DateCreation = D.DateCreation;
                Cheque.Montant = Montant;
                Cheque.NumCheque = TxtNumCheque.Text;

                if (comboBoxBank.SelectedItem.ToString().Equals("Zitouna"))
                {
                    Cheque.Bank = SourceAlimentation.Zitouna.ToString();

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BH"))
                {
                    Cheque.Bank = SourceAlimentation.BH.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("BNA"))
                {
                    Cheque.Bank = SourceAlimentation.BNA.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("UIB"))
                {
                    Cheque.Bank = SourceAlimentation.UIB.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Elbaraka"))
                {
                    Cheque.Bank = SourceAlimentation.Elbaraka.ToString(); ;

                }
                else if (comboBoxBank.SelectedItem.ToString().Equals("BIAT"))
                {
                    Cheque.Bank = SourceAlimentation.BIAT.ToString(); ;

                }

                else if (comboBoxBank.SelectedItem.ToString().Equals("Attijari"))
                {
                    Cheque.Bank = SourceAlimentation.Attijari.ToString(); ;

                }
                Cheque.DateEcheance = dateEchance.DateTime;
                Cheque.Commentaire = D.Commentaire;
                db.CoffreCheques.Add(Cheque);
                Cheque.Depense = D;
                db.SaveChanges();
            }


            #endregion


            #region Ajouter Mouvement caisse


            if (comboBoxNature.SelectedItem.ToString().Equals("Salarié") && comboBoxModePaie.SelectedIndex == 0)
            {

                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Date = D.DateCreation;
                mvtCaisse.Salarie = D.Salarie;
                mvtCaisse.CodeTiers = D.Salarie.numero;
                mvtCaisse.MontantSens = Montant * -1;
                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Source = "Salarié : " + D.Salarie.Intitule;
                mvtCaisse.NatureDepense = D;
                mvtCaisse.Commentaire = D.Commentaire;

                CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, Montant);
                db.SaveChanges();

                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();

            }

            else if (comboBoxNature.SelectedItem.ToString().Equals("Autre") && comboBoxModePaie.SelectedIndex == 0)
            {
                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Date = D.DateCreation;
                mvtCaisse.MontantSens = Montant * -1;
                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Source = "Autre";
                mvtCaisse.Commentaire = D.Commentaire;
                mvtCaisse.NatureDepense = D;
                CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, Montant);
                db.SaveChanges();

                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();

            }


            #endregion

            if (comboBoxNature.SelectedItem.ToString().Equals("Prélèvement"))
            {
                XtraMessageBox.Show("Prélèvement Enregistré ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                XtraMessageBox.Show("Dépense Enregistrée ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            List<string> ListeNatureMVT = Enum.GetNames(typeof(NatureMouvement)).ToList();
            comboBoxNature.SelectedItem = ListeNatureMVT[0];

            List<string> ListeModePaiement = Enum.GetNames(typeof(ModeReglement)).Where(item => item != ModeReglement.Traite.ToString()).ToList();
            comboBoxModePaie.SelectedItem = ListeModePaiement[0];
            searchLookUpOuvrier.EditValue = searchLookUpOuvrier.Properties.NullText;
            TxtMontant.Text = string.Empty;
            TxtCommentaire.Text = string.Empty;
            List<string> ListeBanques = Enum.GetNames(typeof(SourceAlimentation)).ToList();
            comboBoxBank.SelectedIndex = 0;
            if (ListeBanques.Count > 0)
                comboBoxBank.SelectedItem = ListeBanques[0];

            TxtNumCheque.Text = string.Empty;
            dateEchance.EditValue = null;
            datePrélèvements.DateTime = DateTime.Now;
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
            if (Application.OpenForms.OfType<FrmListeDepenses>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeDepenses>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.ModePaiement.Equals("Espèce")).OrderByDescending(x => x.DateCreation).ToList();


            if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();



            if (Application.OpenForms.OfType<FrmListeDepenseSaison>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeDepenseSaison>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();


            if (Application.OpenForms.OfType<FrmlistePrélèvements>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmlistePrélèvements>().First().prelevementBindingSource.DataSource = db.Prelevements.OrderByDescending(x => x.Date).ToList();


            if (Application.OpenForms.OfType<FrmCoffreChequeEmis>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmCoffreChequeEmis>().First().coffrechequeBindingSource.DataSource = db.CoffreCheques.ToList();



            if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();

                if (db.MouvementsCaisse.Count() > 0)
                {

                    List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                    MouvementCaisse mvt = ListeMvtCaisse.Last();

                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text =  (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                }
            }

            if (Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault() != null)
            {
                List<Salarier> SalarieList = db.Salariers.ToList();
                // depenses salariés
                List<Depense> ListeDepenseSalaries = db.Depenses.Include("Salarie").Where(x => x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList();
                foreach (var sal in SalarieList)
                {
                    var liste = db.PointageJournaliers.Include("Salarier").Where(x => x.Salarier.Id == sal.Id).ToList();
                    sal.TotalNombreHeure = liste.Count > 0 ? db.PointageJournaliers.Include("Salarier").Where(x => x.Salarier.Id == sal.Id).Sum(x => x.NombreHeure) : 0;
                    sal.TotalDeponse = ListeDepenseSalaries.Where(x => x.Salarie.Id == sal.Id && x.Nature == Model.Enumuration.NatureMouvement.Salarié).ToList().Sum(x => x.Montant);
                    db.SaveChanges();
                }

                Application.OpenForms.OfType<FrmSalarier>().FirstOrDefault().salarierBindingSource.DataSource = SalarieList;
            }


        }

        private void TxtMontant_EditValueChanged(object sender, EventArgs e)
        {

            decimal Montant;
            string MontantStr = TxtMontant.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantStr, out Montant);

            Caisse CaisseDb = db.Caisse.Find(1);

            if (CaisseDb != null && comboBoxModePaie.SelectedIndex == 0 && Montant < CaisseDb.MontantTotal && comboBoxNature.SelectedIndex != 1)
            {
                TxtSoldeCaisse.Text = (Math.Truncate(decimal.Subtract(CaisseDb.MontantTotal, Montant) * 1000m) / 1000m).ToString(); 

            }

            else
            {

                TxtSoldeCaisse.Text = (Math.Truncate(CaisseDb.MontantTotal * 1000m) / 1000m).ToString();
            }

        }

        private void comboBoxNature_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxNature.SelectedIndex == 0)
            { // Nature ouvrier

                layoutControlOuvrier.Visibility = LayoutVisibility.Always;
                layoutControlItemPaiement.Visibility = LayoutVisibility.Always;
                Prelevement.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Never;
                layoutControlSoldeCaisse.Visibility = LayoutVisibility.Always;
                comboBoxModePaie.SelectedIndex = 0;

            }
            else if (comboBoxNature.SelectedIndex == 1)
            {// Nature Prelevement
                layoutControlOuvrier.Visibility = LayoutVisibility.Never;
                numCheque.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Always;
                DateEcheance.Visibility = LayoutVisibility.Never;
                layoutControlItemPaiement.Visibility = LayoutVisibility.Never;
                Prelevement.Visibility = LayoutVisibility.Always;
                layoutControlSoldeCaisse.Visibility = LayoutVisibility.Never;
                datePrélèvements.DateTime = DateTime.Now;


            }
            else if (comboBoxNature.SelectedIndex == 2)
            {// Nature Autre
                layoutControlOuvrier.Visibility = LayoutVisibility.Never;
                layoutControlItemPaiement.Visibility = LayoutVisibility.Always;
                Prelevement.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Never;
                layoutControlSoldeCaisse.Visibility = LayoutVisibility.Always;
                comboBoxModePaie.SelectedIndex = 0;

            }

        }

        private void comboBoxModePaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModePaie.SelectedIndex == 1)
            {// cheque
                numCheque.Visibility = LayoutVisibility.Always;
                bank.Visibility = LayoutVisibility.Always;
                DateEcheance.Visibility = LayoutVisibility.Always;
                layoutControlSoldeCaisse.Visibility = LayoutVisibility.Never;

            }

            else if (comboBoxModePaie.SelectedIndex == 0)
            { // espece
                numCheque.Visibility = LayoutVisibility.Never;
                bank.Visibility = LayoutVisibility.Never;
                DateEcheance.Visibility = LayoutVisibility.Never;


            }
        }
    }
}