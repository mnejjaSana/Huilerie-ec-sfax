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
    public partial class FrmCoffreChequeEmis : DevExpress.XtraEditors.XtraForm
    {
        private static FrmCoffreChequeEmis _FrmCoffreChequeEmis;
        private Model.ApplicationContext db;
        public static FrmCoffreChequeEmis InstanceFrmCoffreChequeEmis
        {
            get
            {
                if (_FrmCoffreChequeEmis == null)
                    _FrmCoffreChequeEmis = new FrmCoffreChequeEmis();
                return _FrmCoffreChequeEmis;
            }
        }

        public FrmCoffreChequeEmis()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmCoffreChequeSalarie_Load(object sender, EventArgs e)
        {
            coffrechequeBindingSource.DataSource = db.CoffreCheques.ToList();
        }

        private void FrmCoffreChequeSalarie_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCoffreChequeEmis = null;
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {

        }
    }
}