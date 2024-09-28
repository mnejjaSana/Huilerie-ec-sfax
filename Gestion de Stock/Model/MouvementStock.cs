using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public enum SensStock
    {
        Sortie = 0,
        Entree = 1
    }
    public class MouvementStock
    {
        public MouvementStock()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Numero { get; set; }
        public virtual Pile pile { get; set; }

        public int QuantiteProduite { get; set; }
        public int QuantiteAchetee { get; set; }
        public int QuantiteVendue { get; set; }
        public int QuantiteSOD { get; set; }


        public SensStock Sens { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }
        public ArticleVente Qualite { get; set; }
        public int QuantitePileInitial { get; set; }
        public int QuantitePileFinal { get; set; }

      
        public decimal PrixMouvement { get; set; }

        public decimal PMP { get; set; }

        public int QteEntrante { get; set; }
        public int QteSortante { get; set; }

        public virtual Production Prod { get; set; }

        public virtual Achat Achat { get; set; }
        
        public virtual Vente Vente { get; set; }

        public string Code { get; set; }

        public string Intitulé { get; set; }

    }
}
