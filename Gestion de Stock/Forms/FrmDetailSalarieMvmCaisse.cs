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
    public partial class FrmDetailSalarieMvmCaisse : DevExpress.XtraEditors.XtraForm
    {

        private static FrmDetailSalarieMvmCaisse _FrmDetailSalarieMvmCaisse;
        public static FrmDetailSalarieMvmCaisse InstanceFrmDetailSalarieMvmCaisse
        {
            get
            {
                if (_FrmDetailSalarieMvmCaisse == null)
                    _FrmDetailSalarieMvmCaisse = new FrmDetailSalarieMvmCaisse();
                return _FrmDetailSalarieMvmCaisse;
            }
        }
 

        public FrmDetailSalarieMvmCaisse()
        {
            InitializeComponent();
        }

        private void FrmDetailSalarieMvmCaisse_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailSalarieMvmCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailSalarieMvmCaisse = null;
        }
    }
}