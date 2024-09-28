using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmTransfertEmplacement : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;

        private static FrmTransfertEmplacement _FrmTransfertEmplacement;

        public static FrmTransfertEmplacement InstanceFrmTransfertEmplacement
        {
            get
            {
                if (_FrmTransfertEmplacement == null)
                {
                    _FrmTransfertEmplacement = new FrmTransfertEmplacement();
                }

                return _FrmTransfertEmplacement;
            }
        }

        public FrmTransfertEmplacement()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmTransfertEmplacement_Load(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            emplacementSortantBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

            emplacementEntrantBindingSource.DataSource = db.Emplacements.AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

        }

        private void FrmTransfertEmplacement_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmTransfertEmplacement = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();

            if (string.IsNullOrEmpty(MasrafSortant.Text))
            {
                XtraMessageBox.Show("Choisir un emplacement Sortant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(MasrafEntrant.Text))
            {
                XtraMessageBox.Show("Choisir un emplacement Entrant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(TxtQteOlive.Text))
            {
                TxtQteOlive.ErrorText = "Quantité obligatoire";
                XtraMessageBox.Show("Quantité Olive est obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int QteOlive = int.Parse(TxtQteOlive.Text);

            int QteStockEmpSortantActuel= int.Parse(TxtStockMasrafSoratnt.Text);

            if (QteOlive <= 0 || QteOlive> QteStockEmpSortantActuel)
            {
                XtraMessageBox.Show("Quantité Olive est Invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQteOlive.Text = string.Empty;
                return;
            }

            Emplacement EmpSortant = new Emplacement();
            Emplacement EmpEntrant = new Emplacement();
        
            int stockEmpSortant = 0;
            int stockEmpEntrant = 0;

            // masraf sortant
            GridView view = MasrafSortant.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object masrafselected = view.GetRowCellValue(rowHandle, fieldName);
            if (masrafselected == null)
            {
                XtraMessageBox.Show("Choisir un emplacement Sortant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                MasrafSortant.Focus();

                return;
            }
            else
            {
                int IdMasraf = Convert.ToInt32(masrafselected);
                EmpSortant = db.Emplacements.Find(IdMasraf);
                stockEmpSortant = EmpSortant.Quantite;
            }

            // entrant
           
            GridView view1 = MasrafEntrant.Properties.View;
            int rowHandle1 = view1.FocusedRowHandle;
            string fieldName1 = "Id"; // or other field name  
            object MasrafselectedEntrant = view1.GetRowCellValue(rowHandle1, fieldName1);
            if (MasrafselectedEntrant != null)
            {
                int IdMasraf = Convert.ToInt32(MasrafselectedEntrant);
                EmpEntrant = db.Emplacements.Find(IdMasraf);
                stockEmpEntrant = EmpEntrant.Quantite;
            }
            else
            {
                XtraMessageBox.Show("Choisir un emplacement Entrant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                MasrafEntrant.Focus();
                return;

            }


            //  masraf entrant

            int QteEmpEntrantInitial = stockEmpEntrant;
            int QteEmpEntrantFinal = QteEmpEntrantInitial + QteOlive;
            decimal PrixMouvementEntrant = EmpEntrant.PrixMoyen;
            decimal RENDEMENTMVTEntrant = EmpEntrant.RENDEMENMOY;

            if (EmpEntrant.Quantite == 0)
            {
                EmpEntrant.RENDEMENMOY = EmpSortant.RENDEMENMOY;
            }
            else
            {
                // // =((C3*D3)+(E2*F2))/E3
                // mouvementStockOlive.RENDEMENMOY = Math.Truncate((((A.QteOliveAchetee * RendementMov) + (mouvementStockOlive.QuantiteMasrafInitial * Emplace.RENDEMENMOY)) / mouvementStockOlive.QuantiteMasrafFinal) * 100000m) / 100000m;
                EmpEntrant.RENDEMENMOY = Math.Truncate((((EmpSortant.RENDEMENMOY * QteOlive) + (QteEmpEntrantInitial * EmpEntrant.RENDEMENMOY)) / QteEmpEntrantFinal) * 100000m) / 100000m; 
            }

            EmpEntrant.Quantite = QteEmpEntrantFinal;

            EmpEntrant.PrixMoyen = Math.Truncate((((EmpSortant.PrixMoyen * QteOlive) + (QteEmpEntrantInitial * EmpEntrant.PrixMoyen)) / QteEmpEntrantFinal) * 100000m) / 100000m;

            EmpEntrant.LastPrixMoyen = EmpEntrant.PrixMoyen;

            EmpEntrant.ValeurMasraf = decimal.Multiply(EmpEntrant.PrixMoyen, QteEmpEntrantFinal);

           

            db.SaveChanges();

            #region Ajouter Mouvement Olive entrant

            //decimal RendementMov;
            //string RendementMovStr = TxtRendement.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            //decimal.TryParse(RendementMovStr, out RendementMov);

            MouvementStockOlive mouvementStockOlive = new MouvementStockOlive();
            mouvementStockOlive.Sens = SensStockOlive.Entree;
            int lastMvtStock1 = db.MouvementStockOlive.ToList().Count() + 1;
            mouvementStockOlive.Commentaire = "TRF" + lastMvtStock1.ToString("D8");
            mouvementStockOlive.QuantiteMasrafInitial = QteEmpEntrantInitial;
            mouvementStockOlive.QuantiteMasrafFinal = QteEmpEntrantFinal;
            // *****************************///
            mouvementStockOlive.Code = "";

            mouvementStockOlive.PrixMouvement = PrixMouvementEntrant;

            mouvementStockOlive.RENDEMENTMVT = RENDEMENTMVTEntrant;

            mouvementStockOlive.RENDEMENMOY = RENDEMENTMVTEntrant;

            mouvementStockOlive.Intitulé = "";
          
            mouvementStockOlive.QteEntrante = QteOlive;

            mouvementStockOlive.Emplacement = EmpEntrant;

            mouvementStockOlive.QteSortante = 0;

            db.MouvementStockOlive.Add(mouvementStockOlive);
            db.SaveChanges();
            mouvementStockOlive.Numero = "MOVENT" + (mouvementStockOlive.Id).ToString("D8");
            db.SaveChanges();

            ////////////**************///////////////
            //  Emplace.RENDEMENMOY = mouvementStockOlive.RENDEMENMOY;

            ////////////**************///////////////
            db.SaveChanges();
           
            #endregion

            // emp sortante

            #region Ajouter Mouvement Olive 
            MouvementStockOlive mouvementStockOliveSoratnt = new MouvementStockOlive();
            mouvementStockOliveSoratnt.Sens = SensStockOlive.Sortie;

            mouvementStockOliveSoratnt.Emplacement = EmpSortant;


            mouvementStockOliveSoratnt.Commentaire = "Transfert de " + EmpSortant.Intitule + " Vers " + EmpEntrant.Intitule;
            mouvementStockOliveSoratnt.QuantiteMasrafInitial = stockEmpSortant;
            mouvementStockOliveSoratnt.QuantiteMasrafFinal = stockEmpSortant - QteOlive;
            if (mouvementStockOliveSoratnt.QuantiteMasrafFinal == 0)
            {
                mouvementStockOliveSoratnt.RENDEMENMOY = 0;

            }
            else
            {
                mouvementStockOliveSoratnt.RENDEMENMOY = EmpSortant.RENDEMENMOY;

                mouvementStockOliveSoratnt.RENDEMENTMVT = EmpSortant.RENDEMENMOY;
            }

            mouvementStockOliveSoratnt.PrixMouvement = EmpSortant.LastPrixMoyen;
            mouvementStockOliveSoratnt.QteEntrante = 0;
            mouvementStockOliveSoratnt.QteSortante = QteOlive;

            mouvementStockOliveSoratnt.Code = "";
            mouvementStockOliveSoratnt.Intitulé = "";
            db.MouvementStockOlive.Add(mouvementStockOliveSoratnt);
            db.SaveChanges();
            mouvementStockOliveSoratnt.Numero = "MOVENT" + (mouvementStockOliveSoratnt.Id).ToString("D8");
            db.SaveChanges();
            
         
            #endregion

            EmpSortant.Quantite = stockEmpSortant - QteOlive;

            EmpSortant.ValeurMasraf = decimal.Multiply(EmpSortant.PrixMoyen, EmpSortant.Quantite);


            db.SaveChanges();

            if (EmpSortant.Quantite == 0)
            {
                EmpSortant.LastPrixMoyen = EmpSortant.PrixMoyen;
                EmpSortant.RENDEMENMOY = 0;
                EmpSortant.ValeurMasraf = 0;
                EmpSortant.PrixMoyen = 0;

                db.SaveChanges();
            }


            mouvementStockOliveSoratnt.QuantiteMasrafFinal = EmpSortant.Quantite;

            db.SaveChanges();


            XtraMessageBox.Show("Transfert Emplacement Terminé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MasrafEntrant.EditValue = MasrafEntrant.Properties.NullText;
            MasrafSortant.EditValue = MasrafSortant.Properties.NullText;

            TxtQteOlive.Text = string.Empty;
            TxtPrixMoyen.Text = string.Empty;
            TxtValeur.Text = string.Empty;
            TxtRendement.Text = string.Empty;
            TxtStockMasrafSoratnt.Text = string.Empty;

            if (Application.OpenForms.OfType<FrmMasrafProduction>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMasrafProduction>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

                Application.OpenForms.OfType<FrmMasrafProduction>().First().searchlookupMasraf.Properties.DataSource = db.Emplacements.Where(x => x.Quantite > 0).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
            }

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
            {

                if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("Nchira"))
                {
                    Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.Nchira).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();
                }

                else if (Application.OpenForms.OfType<FrmAchats>().First().comboBoxTypeOlive.SelectedItem.Equals("OliveVif"))
                {
                    Application.OpenForms.OfType<FrmAchats>().First().emplacementBindingSource.DataSource = db.Emplacements.Where(x => x.Article == ArticleAchat.OliveVif).AsEnumerable().Select(x => new { x.Id, x.Numero, x.Intitule, x.Quantite, x.Article, RENDEMENMOY = Math.Truncate(x.RENDEMENMOY * 1000m) / 1000m, ValeurMasraf = Math.Truncate(x.ValeurMasraf * 1000m) / 1000m }).ToList();

                }
               
            }


            if (Application.OpenForms.OfType<FrmEmplacement>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmEmplacement>().First().emplacementBindingSource.DataSource = db.Emplacements.ToList();
            }


            if (Application.OpenForms.OfType<FrmMouvementStockOlive>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMouvementStockOlive>().First().mouvementStockOliveBindingSource.DataSource = db.MouvementStockOlive.ToList();
            }
            this.Close();


        }

        private void MasrafSortant_EditValueChanged(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            // PileSortante
            GridView view = MasrafSortant.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object masrafselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (masrafselected != null)
            {
                int IdMasraf = Convert.ToInt32(masrafselected);
                var MasrafSortant = db.Emplacements.Find(IdMasraf);
                TxtPrixMoyen.Text = (Math.Truncate(MasrafSortant.PrixMoyen * 1000m) / 1000m).ToString();
                TxtRendement.Text = (Math.Truncate(MasrafSortant.RENDEMENMOY * 1000m) / 1000m).ToString();
                TxtValeur.Text = (Math.Truncate(MasrafSortant.ValeurMasraf * 1000m) / 1000m).ToString();
                TxtStockMasrafSoratnt.Text = MasrafSortant.Quantite.ToString();

            }
        }

        private void MasrafEntrant_EditValueChanged(object sender, EventArgs e)
        {
            // PileSortante
            db = new Model.ApplicationContext();
            Emplacement empSortant = new Emplacement();

            GridView view = MasrafSortant.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "Id"; // or other field name  
            object Masrafselected = view.GetRowCellValue(rowHandle, fieldName);
            ///Condition existance Pile
            if (Masrafselected != null)
            {
                int IdMasraf = Convert.ToInt32(Masrafselected);
                empSortant = db.Emplacements.Find(IdMasraf);

            }
            else
            {
                XtraMessageBox.Show("Choisir Empalcement Sortant", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MasrafEntrant.EditValue = MasrafEntrant.Properties.NullText;
                return;
            }

            // PileEntrante

            Emplacement empEntrant = new Emplacement();
            GridView view1 = MasrafEntrant.Properties.View;
            int rowHandle1 = view1.FocusedRowHandle;
            string fieldName1 = "Id"; // or other field name  
            object MasrafselectedEntrant = view1.GetRowCellValue(rowHandle1, fieldName1);
            if (MasrafselectedEntrant != null)
            {
                int IdMasraf = Convert.ToInt32(MasrafselectedEntrant);
                empEntrant = db.Emplacements.Find(IdMasraf);

            }

            if (empSortant.Id == empEntrant.Id)
            {
                XtraMessageBox.Show("Emplacement Entrant est Invalid", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MasrafEntrant.EditValue = MasrafEntrant.Properties.NullText;
                return;

            }
        }
    }
}