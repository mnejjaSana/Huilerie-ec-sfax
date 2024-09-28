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
using Gestion_de_Stock.Model;

namespace Gestion_de_Stock.Forms
{
    public partial class Coffre : DevExpress.XtraEditors.XtraForm
    {
        private static Coffre _FrmCoffre;
        private Model.ApplicationContext db;
        public static Coffre InstanceFrmCoffre
        {
            get
            {
                if (_FrmCoffre == null)
                    _FrmCoffre = new Coffre();
                return _FrmCoffre;
            }
        }
        public Coffre()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void Coffre_Load(object sender, EventArgs e)
        {

            historiquePaiementVenteBindingSource.DataSource = db.HistoriquePaiementVente.Where(x => x.Coffre == true).ToList();

        }

        private void Coffre_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCoffre = null;
        }


    }
}