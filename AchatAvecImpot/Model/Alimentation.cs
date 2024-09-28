using System;
using AchatAvecImpot.Model.Enumuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
    public class Alimentation
    {
        public Alimentation()
        {
            DateCreation = DateTime.Now;
        }

        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DateCreation { get; set; }
        public SourceAlimentation Source { get; set; }
        public Decimal Montant { get; set; }
        public string Commentaire { get; set; }
        public string Tiers { get; set; }
        public virtual Agriculteur Agriculteur { get; set; }
        public virtual Client Client { get; set; }
    }
}
