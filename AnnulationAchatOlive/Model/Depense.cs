using AnnulationAchatOlive.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{
    public class Depense
    {
        public Depense()
        {
            DateCreation = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string Numero { get; set; }
        public NatureMouvement Nature { get; set; }
        public virtual Salarier Salarie { get; set; }
        public virtual Agriculteur Agriculteur { get; set; }
        public Decimal Montant { get; set; }
        public string Commentaire { get; set; }
        public string ModePaiement { get; set; }
        public string Tiers { get; set; }
        public string Bank { get; set; }
        public Nullable<DateTime> DateEcheance { get; set; }
        public string NumCheque { get; set; }
        public string CodeTiers { get; set; }

        public int Agriculteur_Id { get; set; }

    }
}
