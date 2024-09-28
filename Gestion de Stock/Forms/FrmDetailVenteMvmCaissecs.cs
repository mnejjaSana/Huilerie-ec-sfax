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
    public partial class FrmDetailVenteMvmCaissecs : DevExpress.XtraEditors.XtraForm
    {
        private static FrmDetailVenteMvmCaissecs _FrmDetailVenteMvmCaissecs;
        public static FrmDetailVenteMvmCaissecs InstanceFrmDetailVenteMvmCaissecs
        {
            get
            {
                if (_FrmDetailVenteMvmCaissecs == null)
                    _FrmDetailVenteMvmCaissecs = new FrmDetailVenteMvmCaissecs();
                return _FrmDetailVenteMvmCaissecs;
            }
        }


        public FrmDetailVenteMvmCaissecs()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDetailVenteMvmCaissecs_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailVenteMvmCaissecs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailVenteMvmCaissecs = null;
        }
    }
}