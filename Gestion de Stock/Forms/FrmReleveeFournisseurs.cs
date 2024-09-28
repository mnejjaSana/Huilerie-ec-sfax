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
    public partial class FrmReleveeFournisseurs : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db;
        private static FrmReleveeFournisseurs _FrmReleveeFournisseurs;
        public static FrmReleveeFournisseurs InstanceFrmReleveeFournisseurs
        {
            get
            {
                if (_FrmReleveeFournisseurs == null)
                    _FrmReleveeFournisseurs = new FrmReleveeFournisseurs();
                return _FrmReleveeFournisseurs;
            }
        }
        public FrmReleveeFournisseurs()
        {
            InitializeComponent();
        }

        private void FrmReleveeFournisseurs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmReleveeFournisseurs = null;
        }
    }
}