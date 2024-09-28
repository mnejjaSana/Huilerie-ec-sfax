using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class MouvementCaisse
    {
          

        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Date { get; set; }
        public Sens Sens { get; set; }
        public string Source { get; set; }
        public string Commentaire { get; set; }
        public decimal MontantSens { get; set; }
        public decimal Alimentation
        {
            get
            {
                if (MontantSens < 0) return 0;
                return MontantSens;
            }
        }
        public decimal Depense
        {
            get
            {
                if (MontantSens > 0) return 0;
                return MontantSens * -1;
            }
        }
        public decimal Montant { get; set; }    
        public virtual Achat Achat { get; set; }
        public virtual Vente Vente { get; set; }
        public virtual Depense  NatureDepense { get; set; }
        public virtual Agriculteur Agriculteur { get; set; }
        public virtual Salarier Salarie { get; set; }
        public virtual Client Client { get; set; }
        public string CodeTiers { get; set; }
    }
}
