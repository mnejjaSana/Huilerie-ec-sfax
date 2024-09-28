using AnnulationAchatOlive.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{
   public class HistoriquePaiementVente
    {
        public HistoriquePaiementVente()
        {
            DateCreation = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string NumVente { get; set; }
        public int IdVente { get; set; }
        public int IdClient { get; set; }
        public string IntituleClient { get; set; }
       public string NumClient { get; set; }

        public ModeReglement ModeReglement { get; set; }
        public decimal MontantReglement { get; set; }
        public decimal MontantRegle { get; set; }
        public decimal ResteApayer { get; set; }
        public string NumCheque { get; set; }
        public Nullable<DateTime> DateEcheance { get; set; }
        public string Bank { get; set; }
        public Boolean Coffre { get; set; }
        public string Commentaire { get; set; }

    }
}
