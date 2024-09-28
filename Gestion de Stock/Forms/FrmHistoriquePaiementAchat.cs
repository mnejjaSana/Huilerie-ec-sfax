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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmHistoriquePaiementAchat : DevExpress.XtraEditors.XtraForm
    {
        private static FrmHistoriquePaiementAchat _FrmHistoriquePaiementAchat;
        public static FrmHistoriquePaiementAchat InstanceFrmHistoriquePaiementAchat
        {
            get
            {
                if (_FrmHistoriquePaiementAchat == null)
                    _FrmHistoriquePaiementAchat = new FrmHistoriquePaiementAchat();
                return _FrmHistoriquePaiementAchat;
            }
        }
        public FrmHistoriquePaiementAchat()
        {
            InitializeComponent();
        }

        private void FrmHistoriquePaiementAchat_Load(object sender, EventArgs e)
        {

        }

        private void FrmHistoriquePaiementAchat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmHistoriquePaiementAchat = null;
        }
    }
}