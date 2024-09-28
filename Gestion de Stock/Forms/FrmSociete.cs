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
using System.Data.Entity.Migrations;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmSociete : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmSociete _FrmSociete;
        public static FrmSociete InstanceFrmSociete
        {
            get
            {
                if (_FrmSociete == null)
                    _FrmSociete = new  FrmSociete();
                return _FrmSociete;
            }
        }
        public FrmSociete()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        
        private void BtnValider_Click(object sender, EventArgs e)
        {

            db = new Model.ApplicationContext();
            Societe ste = db.Societe.FirstOrDefault();
            if (ste != null)
            {

               
                ste.Adresse = TxtAdresse.Text;
                ste.Capitale = TxtCapitale.Text;
                ste.CodePostale = TxtCodePostale.Text;
             
                ste.MatriculFiscal = TxtMatriculFiscal.Text;
               
                ste.RaisonSocial = TxtRaisonSociale.Text;
               
                ste.Telephone = txtTelephone.Text;
          
                ste.Ville = TxtVille.Text;

                ste.AchatHuile = CheckHuile.Checked ? true : false;

                ste.AchatBase = CheckBase.Checked ? true : false;

                ste.AchatOlive = CheckOlive.Checked ? true : false;

                ste.Service = CheckService.Checked ? true : false;

               
                ste.Enregister = true;
                db.SaveChanges();
                XtraMessageBox.Show("Enregistrement terminé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAdresse.ReadOnly = true;
                TxtCapitale.ReadOnly = true;
                TxtCodePostale.ReadOnly = true;
                TxtMatriculFiscal.ReadOnly = true;
                TxtRaisonSociale.ReadOnly = true;
                txtTelephone.ReadOnly = true;
                TxtVille.ReadOnly = true;

                if (ste.AchatHuile)
                {
                    CheckHuile.Checked = true;
                }else
                {
                    CheckHuile.Checked = false;
                }

                if (ste.AchatBase)
                {
                    CheckBase.Checked = true;
                }
                else
                {
                    CheckBase.Checked = false;
                }

                if (ste.AchatOlive)
                {
                    CheckOlive.Checked = true;
                }
                else
                {
                    CheckOlive.Checked = false;
                }


                if (ste.Service)
                {
                    CheckService.Checked = true;
                }
                else
                {
                    CheckService.Checked = false;
                }

                CheckHuile.Enabled = false;
                CheckOlive.Enabled = false;
                CheckBase.Enabled = false;
                CheckService.Enabled = false;

                layoutControlItemBtnValider.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().First().Close();



            }


        }

        private void FrmSociete_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmSociete = null;
        }


        private void FrmSociete_Load(object sender, EventArgs e)
        {
            Societe ste = db.Societe.FirstOrDefault();
            if (ste!= null)
            { 
            TxtAdresse.Text = ste.Adresse;
            TxtCapitale.Text = ste.Capitale.ToString();
            txtTelephone.Text = ste.Telephone;
            TxtVille.Text = ste.Ville;
            TxtRaisonSociale.Text = ste.RaisonSocial;
            TxtCodePostale.Text = ste.CodePostale.ToString();
            TxtMatriculFiscal.Text = ste.MatriculFiscal;

                if (ste.AchatHuile)
                {
                    CheckHuile.Checked = true;
                }
                else
                {
                    CheckHuile.Checked = false;
                }

                if (ste.AchatBase)
                {
                    CheckBase.Checked = true;
                }
                else
                {
                    CheckBase.Checked = false;
                }

                if (ste.AchatOlive)
                {
                    CheckOlive.Checked = true;
                }
                else
                {
                    CheckOlive.Checked = false;
                }


                if (ste.Service)
                {
                    CheckService.Checked = true;
                }
                else
                {
                    CheckService.Checked = false;
                }


            }
            if (ste.Enregister)
            {
                TxtAdresse.ReadOnly = true;
                TxtCapitale.ReadOnly = true;
                TxtCodePostale.ReadOnly = true;
                TxtMatriculFiscal.ReadOnly = true;
                TxtRaisonSociale.ReadOnly = true;
                txtTelephone.ReadOnly = true;
                TxtVille.ReadOnly = true;
                
                CheckHuile.Enabled = false;
                CheckOlive.Enabled = false;
                CheckBase.Enabled = false;
                CheckService.Enabled = false;
                layoutControlItemBtnValider.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }
}