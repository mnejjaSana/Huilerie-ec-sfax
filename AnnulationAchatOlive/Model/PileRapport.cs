using AnnulationAchatOlive.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{
  public  class PileRapport
    {
        public string Intitule { get; set; }
     
        public ArticleVente article { get; set; }

        public int Capacite { get; set; }
     
        public decimal PrixMoyen { get; set; }

        public decimal Valeur {  get { return Math.Truncate(decimal.Divide(decimal.Multiply(PrixMoyen, Capacite),1000) * 100000m) / 100000m; } }

    }
}
