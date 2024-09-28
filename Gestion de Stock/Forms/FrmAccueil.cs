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
using DevExpress.XtraSplashScreen;
using System.Threading;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.XtraReports.Parameters;
using Gestion_de_Stock.Model;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAccueil : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAccueil _FrmAccueil;
        private Model.ApplicationContext db;
        public static FrmAccueil InstanceFrmAccueil
        {
            get
            {
                if (_FrmAccueil == null)
                    _FrmAccueil = new FrmAccueil();
                return _FrmAccueil;
            }
        }
        public FrmAccueil()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }
        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        public void Formshow(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            frm.MdiParent =Application.OpenForms.OfType<MainRibbonForm>().First();
            frm.Show();
            frm.Activate();
        }

        private void FrmAccueil_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAccueil = null;
        }

        private void tileIAPropos_ItemClick(object sender, TileItemEventArgs e)
        {
            //Formshow(Form frm);
            FormshowNotParent(Gestion_de_Stock.Forms.FrmAPropos.InstanceFrmAPropos);
        }

        private void tileIFactures_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmAjouterVente.InstanceFrmAjouterVente);
        }

        private void tileISociete_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSociete.InstanceFrmSociete);
        }

        private void tileIVente_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeVente.InstanceFrmListeVente);
        }

        private void tileIClients_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmClient.InstanceFrmClient); 
        }

        private void tileICaisse_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmMouvementCaisse.InstanceFrmMouvementCaisse);
        }

        private void tileIFrounisseurs_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmFournisseur.InstanceFrmFournisseur);
        }

        private void tileImportClient_ItemClick(object sender, TileItemEventArgs e)
        {
            
        }

        private void tileProduits_ItemClick(object sender, TileItemEventArgs e)
        {
            //Formshow(Gestion_de_Stock.Forms.FrmProduits.InstanceFrmProduit);
         // Formshow(Gestion_de_Stock.Forms.FrmAjouterArticle.InstanceFrmAjouterArticle);
        }

        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            // verification de licence
           //  LicenseInvalideLayout(tileIClients);
            //   AuthorisationdeLayout(tileIClients);

        }
        void LicenseInvalideLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }
        void AuthorisationdeLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }

        private void tileIAchat_ItemClick(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe ste = db.Societe.FirstOrDefault();
            if (!ste.AchatOlive && !ste.AchatHuile && !ste.AchatBase && !ste.Service)

            {
                XtraMessageBox.Show("Merci de choisir les types d'achat dans Société", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Formshow(Gestion_de_Stock.Forms.FrmAchats.InstanceFrmAchats);
            }
        }

        private void TileCreerArticle_ItemClick(object sender, TileItemEventArgs e)
        {
           // Formshow(Gestion_de_Stock.Forms.CreerArticle.InstanceCreerArticle);
        }

        private void tileIJournalAchat_ItemClick(object sender, TileItemEventArgs e)
        {

            Formshow(Gestion_de_Stock.Forms.FrmListeAchats.InstanceFrmListeAchats);
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
           
        }


        private void tileItemListeDevis_ItemClick(object sender, TileItemEventArgs e)
        {
          
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void tileItemProduction_ItemClick(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatBase)
            {
                Formshow(Gestion_de_Stock.Forms.FrmProduction.InstanceFrmProduction);
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmListeProduction.InstanceFrmListeProduction);
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(Gestion_de_Stock.Forms.FrmSalarier.InstanceFrmOuvrier);
        }

        private void tileItem3_ItemClick_1(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            Societe Ste = db.Societe.FirstOrDefault();
            if (Ste.AchatOlive)
            {
                if (db.Chaines.ToList().Count == 0)
                {
                    XtraMessageBox.Show("Merci d'ajouter votre liste de chaines ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Formshow(Forms.FrmMasrafProduction.InstanceFrmMasrafProduction);
                }
            }
            else
            {
                XtraMessageBox.Show("Accès non autorisé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}