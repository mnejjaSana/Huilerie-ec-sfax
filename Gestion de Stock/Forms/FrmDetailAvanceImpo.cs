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
    public partial class FrmDetailAvanceImpo : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmDetailAvanceImpo _FrmDetailAvanceImpo;
        public static FrmDetailAvanceImpo InstanceFrmDetailAvanceImpo
        {
            get
            {
                if (_FrmDetailAvanceImpo == null)
                    _FrmDetailAvanceImpo = new FrmDetailAvanceImpo();
                return _FrmDetailAvanceImpo;
            }
        }
        public FrmDetailAvanceImpo()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }
      
    }
}