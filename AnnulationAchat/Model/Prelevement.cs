using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatHuile.Model
{
   public class Prelevement
    {
        public Prelevement()
        {
            Date = DateTime.Now;
        }

        public int id { get; set; }
        public string    Num { get; set; }
        public DateTime Date { get; set; }
        public string Banque{ get; set; }
        public string Commentaire { get; set; }
        public decimal Montant { get; set; }

    }
}
