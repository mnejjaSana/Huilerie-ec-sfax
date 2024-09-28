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
    public partial class FrmAjouterChaine : DevExpress.XtraEditors.XtraForm
    {
        

        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmAjouterChaine _FrmAjouterChaine;

        public static FrmAjouterChaine InstanceFrmAjouterChaine
        {
            get
            {
                if (_FrmAjouterChaine == null)
                    _FrmAjouterChaine = new FrmAjouterChaine();
                return _FrmAjouterChaine;
            }
        }

        public FrmAjouterChaine()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmAjouterChaine_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtIntitule.Text))
            {
                TxtIntitule.ErrorText = "Intitulé est obligatoire";
                return;

            }

            Chaine chaine = new Chaine();
            chaine.Intitule = TxtIntitule.Text;

            db.Chaines.Add(chaine);
            db.SaveChanges();

            chaine.Numero = "CH" + chaine.Id.ToString("D8");
            db.SaveChanges();
            XtraMessageBox.Show("Chaine Enregistrée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtIntitule.Text = string.Empty;
           this.Close();

            if (Application.OpenForms.OfType<FrmListeChaines>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeChaines>().First().chaineBindingSource.DataSource = db.Chaines.ToList();

        }

        private void FrmAjouterChaine_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterChaine = null;
        }
    }
}