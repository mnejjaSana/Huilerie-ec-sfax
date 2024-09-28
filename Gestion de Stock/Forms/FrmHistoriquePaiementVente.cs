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
    public partial class FrmHistoriquePaiementVente : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmHistoriquePaiementVente _FrmHistoriquePaiementVente;
        public static FrmHistoriquePaiementVente InstanceFrmHistoriquePaiementVente
        {
            get
            {
                if (_FrmHistoriquePaiementVente == null)
                    _FrmHistoriquePaiementVente = new FrmHistoriquePaiementVente();
                return _FrmHistoriquePaiementVente;
            }
        }
        public FrmHistoriquePaiementVente()
        {
            InitializeComponent();
        }

        private void FrmHistoriquePaiementVente_Load(object sender, EventArgs e)
        {

        }

        private void FrmHistoriquePaiementVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmHistoriquePaiementVente = null;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}