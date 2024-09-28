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
using Gestion_de_Stock.Repport;
using Gestion_de_Stock.Model;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmEtatCaisse : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;

        private static FrmEtatCaisse _FrmEtatCaisse;

        public static FrmEtatCaisse InstanceFrmEtatCaisse
        {
            get
            {
                if (_FrmEtatCaisse == null)
                    _FrmEtatCaisse = new FrmEtatCaisse();
                return _FrmEtatCaisse;
            }
        }

        public FrmEtatCaisse()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmEtatCaisse_Load(object sender, EventArgs e)
        {
            dateDebut.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        private void FrmEtatCaisse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmEtatCaisse = null;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            Caisse caisse = db.Caisse.FirstOrDefault();

            RapportEtatCaisse RapportCaisse = new RapportEtatCaisse();

            DateTime dateDébut = dateDebut.DateTime;

            DateTime datefin = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            List<MouvementCaisse> ListeMvt = new List<MouvementCaisse>();


            List<MouvementCaisse> ListeMvtAnt = db.MouvementsCaisse.Where(x => x.Date < dateDébut ).ToList();


            Decimal SommeRecette = ListeMvtAnt.Sum(x=> x.Alimentation);

            Decimal SommeDepense= ListeMvtAnt.Sum(x => x.Depense);


            if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                ListeMvt = db.MouvementsCaisse.Where(x => x.Date >= dateDébut).OrderBy(x => x.Date).ToList();

            }
          
            else
            {
                ListeMvt = db.MouvementsCaisse.Where(x => x.Date >= dateDébut && x.Date <= datefin ).OrderBy(x => x.Date).ToList();

            }

            RapportCaisse.Parameters["Du"].Value = dateDébut;

            if (datefin.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                RapportCaisse.Parameters["Au"].Value = DateTime.Now;
            }

            else
            {
                RapportCaisse.Parameters["Au"].Value = datefin;

            }
         

            RapportCaisse.Parameters["DateImpression"].Value = DateTime.Now;

            RapportCaisse.Parameters["SoldeAnterieur"].Value = decimal.Subtract(SommeRecette , SommeDepense);

            RapportCaisse.Parameters["TotalRecette"].Value = ListeMvt.Sum(x => x.Alimentation);

            RapportCaisse.Parameters["TotaleDepense"].Value = ListeMvt.Sum(x => x.Depense);

            RapportCaisse.Parameters["SoldeCaisse"].Value = caisse.MontantTotal;

            RapportCaisse.DataSource = ListeMvt;

            using (ReportPrintTool printTool = new ReportPrintTool(RapportCaisse))
            {
                printTool.ShowPreviewDialog();
           
            }

        }
    }
}