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
    public partial class FrmUtilisateur : DevExpress.XtraEditors.XtraForm
    {
        private static FrmUtilisateur _FrmUtilisateur;
        public static FrmUtilisateur InstanceFrmUtilisateur
        {
            get
            {
                if (_FrmUtilisateur == null)
                    _FrmUtilisateur = new FrmUtilisateur();
                return _FrmUtilisateur;
            }
        }
        public FrmUtilisateur()
        {
            InitializeComponent();
        }

        private void FrmUtilisateur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmUtilisateur = null;
        }
    }
}