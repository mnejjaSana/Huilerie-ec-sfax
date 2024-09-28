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
    public partial class FrmDetailServiceMvmCaisse : DevExpress.XtraEditors.XtraForm
    {
        private static FrmDetailServiceMvmCaisse _FrmDetailAchatMvmCaisse;

        public static FrmDetailServiceMvmCaisse InstanceFrmDetailAchatMvmCaisse
        {
            get
            {
                if (_FrmDetailAchatMvmCaisse == null)
                    _FrmDetailAchatMvmCaisse = new FrmDetailServiceMvmCaisse();
                return _FrmDetailAchatMvmCaisse;
            }
        }
        public FrmDetailServiceMvmCaisse()
        {
            InitializeComponent();
        }

        private void FrmDetailAchatMvmCaisse_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailAchatMvmCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailAchatMvmCaisse = null;
        }
    }
}