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
    public partial class FrmDetailAchatMvmCaissecs : DevExpress.XtraEditors.XtraForm
    {
        private static FrmDetailAchatMvmCaissecs _FrmDetailAchatMvmCaissecs;

        public static FrmDetailAchatMvmCaissecs InstanceFrmDetailAchatMvmCaissecs
        {
            get
            {
                if (_FrmDetailAchatMvmCaissecs == null)
                    _FrmDetailAchatMvmCaissecs = new FrmDetailAchatMvmCaissecs();
                return _FrmDetailAchatMvmCaissecs;
            }
        }

        public FrmDetailAchatMvmCaissecs()
        {
            InitializeComponent();
        }

        private void FrmDetailAchatMvmCaissecs_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailAchatMvmCaissecs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailAchatMvmCaissecs = null;
        }

        
    }
}