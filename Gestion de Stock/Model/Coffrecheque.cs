using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Coffrecheque
    {
        public int Id {get; set;}
        public DateTime DateCreation { get; set; }

        public string NumVente { get; set; }

        public string NomSalarier { get; set; }

        public virtual Client Client { get; set; }

        public decimal Montant { get; set; }

        public string NumCheque { get; set; }

        public string Bank { get; set; }

        public Nullable<DateTime> DateEcheance { get; set; }

        public string Commentaire { get; set; }

        public virtual Depense Depense { get; set; }

        public string Type { get; set; } // traite ou cheque

    }
}
