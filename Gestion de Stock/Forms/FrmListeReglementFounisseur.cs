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
    public partial class FrmListeReglementFounisseur : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmListeReglementFounisseur _FrmListeReglementFounisseur;
        public static FrmListeReglementFounisseur InstanceFrmListeReglementFounisseur
        {
            get
            {
                if (_FrmListeReglementFounisseur == null)
                    _FrmListeReglementFounisseur = new FrmListeReglementFounisseur();
                return _FrmListeReglementFounisseur;
            }
        }

        public FrmListeReglementFounisseur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeReglementFounisseur_Load(object sender, EventArgs e)
        {
            if (db.Agriculteurs.Count() > 0)
                fournisseurBindingSource.DataSource = db.Agriculteurs.ToList();
            List<Agriculteur> ListFournisseurs = db.Agriculteurs.ToList();
           
        }

        private void FrmListeReglementFounisseur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeReglementFounisseur = null;
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            if (db.Agriculteurs.Count() > 0)
                fournisseurBindingSource.DataSource = db.Agriculteurs.ToList();
            List<Agriculteur> ListFournisseurs = db.Agriculteurs.ToList();
         
        }
    }
}