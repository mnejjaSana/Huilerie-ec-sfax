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
    public partial class FrmListeChaines : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmListeChaines _FrmListeChaines;

        public static FrmListeChaines InstanceFrmListeChaines
        {
            get
            {
                if (_FrmListeChaines == null)
                    _FrmListeChaines = new FrmListeChaines();
                return _FrmListeChaines;
            }
        }


        public FrmListeChaines()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        public void FormshowNotParent(Form frm)
        {
            frm.Show();
            frm.Activate();
        }
        private void BtnAjouterChaine_Click(object sender, EventArgs e)
        {
            FormshowNotParent(Forms.FrmAjouterChaine.InstanceFrmAjouterChaine);
        }

        private void FrmListeChaines_Load(object sender, EventArgs e)
        {
            if (db.Chaines.Count() > 0)
                chaineBindingSource.DataSource = db.Chaines.ToList();
        }

        private void FrmListeChaines_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeChaines = null;
        }

        private void repositoryBtnSupprimer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            db = new Model.ApplicationContext();
            Chaine Chaine = gridView1.GetFocusedRow() as Chaine;         
            Chaine ChaineDb = db.Chaines.Find(Chaine.Id);
            db.Chaines.Remove(ChaineDb);
            db.SaveChanges();           
            chaineBindingSource.DataSource = db.Chaines.ToList();
            XtraMessageBox.Show("Suppression chaine terminer ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}