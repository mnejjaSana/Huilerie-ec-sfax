using AnnulationAchatOlive.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{
    public class LigneStock
    {
        public int Id { get; set; }
        public virtual Pile pile { get; set; }
        public DateTime Date { get; set; }
        public int Quantite { get; set; }
        public ArticleVente article { get; set; }
        public virtual Production production { get; set; }
        public int QuantitePileInitial { get; set; }
        public int QuantitePileFinal { get; set; }
    }
}
