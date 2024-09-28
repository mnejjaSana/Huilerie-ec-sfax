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
    public partial class FrmHistoriquePaiementSalarie : DevExpress.XtraEditors.XtraForm
    {
        private static FrmHistoriquePaiementSalarie  _FrmHistoriquePaiementSalarie ;
        public static FrmHistoriquePaiementSalarie  InstanceFrmHistoriquePaiementSalarie 
        {
            get
            {
                if (_FrmHistoriquePaiementSalarie  == null)
                    _FrmHistoriquePaiementSalarie  = new FrmHistoriquePaiementSalarie ();
                return _FrmHistoriquePaiementSalarie ;
            }
        }

        public FrmHistoriquePaiementSalarie()
        {
            InitializeComponent();
        }

        private void FrmHistoriquePaiementSalarie_Load(object sender, EventArgs e)
        {

        }

        private void FrmHistoriquePaiementSalarie_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmHistoriquePaiementSalarie = null;
        }
    }
}