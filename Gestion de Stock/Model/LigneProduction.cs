using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class LigneProduction
    {
        public int Id { get; set; }
        public decimal QuantiteHuileProduite { get; set; }
        public int NombreSacs { get; set; }
        public DateTime DateFinProd { get; set; }
        public Production prod { get; set;}
        public string AchatId { get; set; }
        public int NuméroBon { get; set; }
       public decimal RendementLignePTotal { get; set; }
     
    }
}
