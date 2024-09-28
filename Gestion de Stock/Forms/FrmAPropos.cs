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
    public partial class FrmAPropos : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAPropos _FrmAPropos;
        public static FrmAPropos InstanceFrmAPropos
        {
            get
            {
                if (_FrmAPropos == null)
                    _FrmAPropos = new FrmAPropos();
                return _FrmAPropos;
            }
        }
        public FrmAPropos()
        {
            InitializeComponent();
            LSfax.Text = "Immeuble SOTEME, Route de Gabes km3, 3052, Sfax-Tunisie";
            LTunis.Text = "Golden Estates Towers, 9ème étage App. A9.8 Centre Urbain Nord, 1080, Tunis-Tunisie";
            LEmail.Text = "contact@groupe-ec.com";
            Ltelephone.Text = "+216 70 033 140";


        }

        private void FrmAPropos_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAPropos = null;
        }

        private void FrmAPropos_Load(object sender, EventArgs e)
        {

        }
    }
}