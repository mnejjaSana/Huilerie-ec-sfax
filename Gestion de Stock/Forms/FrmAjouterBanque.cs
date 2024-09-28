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
    public partial class FrmAjouterBanque : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }

        private static FrmAjouterBanque _FrmAjouterBanque;

        public static FrmAjouterBanque InstanceFrmAjouterBanque
        {
            get
            {
                if (_FrmAjouterBanque == null)
                    _FrmAjouterBanque = new FrmAjouterBanque();
                return _FrmAjouterBanque;
            }
        }

        public FrmAjouterBanque()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterBanque_Load(object sender, EventArgs e)
        {

        }

        private void FrmAjouterBanque_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterBanque = null;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtIntitule.Text))
            {
                TxtIntitule.ErrorText = "Intitulé est obligatoire";
                return;

            }

            if (string.IsNullOrEmpty(TxtRib.Text))
            {
                TxtRib.ErrorText = "Numéro RIB est obligatoire";
                return;

            }

            if (string.IsNullOrEmpty(TxtAdresse.Text))
            {
                TxtAdresse.ErrorText = "Adresse est obligatoire";
                return;

            }

            if (TxtRib.Text.Length < 20)
            {
                XtraMessageBox.Show("Numéro RIB est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Banque BnaqueBD = db.Banques.FirstOrDefault(a => a.NumRIB.Equals(TxtRib.Text));


            if (BnaqueBD  != null)
            {
                TxtRib.ErrorText = "Numéro RIB existe déja";
                XtraMessageBox.Show("Numéro RIB existe déja ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Banque Banque = new Banque();

            Banque.Intitule = TxtIntitule.Text;
            Banque.NumRIB = TxtRib.Text;
            Banque.Adresse = TxtAdresse.Text;

            db.Banques.Add(Banque);
            db.SaveChanges();

            Banque.Numero = "Bq" + (Banque.Id).ToString("D8");
            db.SaveChanges();


        }
    }
}