using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public enum SensStockOlive
    {
        Sortie = 0,
        Entree = 1
    }
    public class MouvementStockOlive
    {
        public MouvementStockOlive()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Numero { get; set; }

        public SensStockOlive Sens { get; set; }

        public string Commentaire { get; set; }
        public DateTime Date { get; set; }

        public int QuantiteMasrafInitial { get; set; }
        public int QuantiteMasrafFinal { get; set; }


        public decimal PrixMouvement { get; set; }


        public int QteEntrante { get; set; }

        public int QteSortante { get; set; }

        public virtual Achat Achat { get; set; }

        public virtual Emplacement Emplacement { get; set; }

        public decimal RENDEMENTMVT { get; set; }

        public decimal RENDEMENMOY { get; set; }

        public string Code { get; set; }


        public string Intitulé { get; set; }
    }
}
