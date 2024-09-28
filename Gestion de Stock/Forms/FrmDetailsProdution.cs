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
    public partial class FrmDetailsProdution : DevExpress.XtraEditors.XtraForm
    {
        private static FrmDetailsProdution _FrmDetailsProdution;
        public static FrmDetailsProdution InstanceDetailsProdution
        {
            get
            {
                if (_FrmDetailsProdution == null)
                    _FrmDetailsProdution = new FrmDetailsProdution();
                return _FrmDetailsProdution;
            }
        }


        public FrmDetailsProdution()
        {
            InitializeComponent();
        }

        private void DetailsProdution_Load(object sender, EventArgs e)
        {

        }

        private void DetailsProdution_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailsProdution = null;
        }
    }
}