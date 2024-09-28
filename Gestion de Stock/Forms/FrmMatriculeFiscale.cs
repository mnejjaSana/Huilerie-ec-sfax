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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmMatriculeFiscale : DevExpress.XtraEditors.XtraForm
    {
        private static FrmMatriculeFiscale _FrmMatriculeFiscale;
        public static FrmMatriculeFiscale InstanceFrmMatriculeFiscale
        {
            get
            {
                if (_FrmMatriculeFiscale == null)
                    _FrmMatriculeFiscale = new FrmMatriculeFiscale();
                return _FrmMatriculeFiscale;
            }
        }
        public FrmMatriculeFiscale()
        {
            InitializeComponent();
        }

        private void TxtIdentiteBancaire_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtIdentiteBancaire.EditValue == null)
            {
                TxtCleRib.Text = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(TxtIdentiteBancaire.EditValue.ToString()))
            {
                TxtCleRib.Text = string.Empty;
                return;
            }
            if (TxtIdentiteBancaire.EditValue.ToString().Trim().Length != 18)
            {
                TxtCleRib.Text = string.Empty;
                return;
            }
            TxtCleRib.Text = NumeriqueHelper.GetMatriculeCleRib(TxtIdentiteBancaire.EditValue.ToString());
        }

        private void BtnVerifier_Click(object sender, EventArgs e)
        {
            var result = VerifierMatricule();
            if (result)
            {
                XtraMessageBox.Show("Matricule fiscal est vérifier", "Application Configuration", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Matricule fiscal invalide", "Application Configuration", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private bool VerifierMatricule()
        {
            if (TxtMatriculFiscale.EditValue == null)
            {
                return false;
            }
            return NumeriqueHelper.ValiderMatricule(TxtMatriculFiscale.Text.Trim());
        }

        private void TxTMatriculeGenerator_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtMatricule.EditValue == null)
            {
                txtCle.Text = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(TxtMatricule.EditValue.ToString()))
            {
                txtCle.Text = string.Empty;
                return;
            }
            if (TxtMatricule.EditValue.ToString().Trim().Length != 7)
            {
                txtCle.Text = string.Empty;
                return;
            }
            txtCle.Text = NumeriqueHelper.GetMatriculeCle(TxtMatricule.EditValue.ToString());
        }

        private void FrmMatriculeFiscale_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmMatriculeFiscale = null;
        }
    }
}