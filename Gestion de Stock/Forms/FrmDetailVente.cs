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
    public partial class FrmDetailVente : DevExpress.XtraEditors.XtraForm
    {
        private static FrmDetailVente _FrmDetailVente;
        public static FrmDetailVente InstanceFrmDetailVente
        {
            get
            {
                if (_FrmDetailVente == null)
                    _FrmDetailVente = new FrmDetailVente();
                return _FrmDetailVente;
            }
        }
        public FrmDetailVente()
        {
            InitializeComponent();
        }

        private void FrmDetailVente_Load(object sender, EventArgs e)
        {

        }

        private void FrmDetailVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailVente = null;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}