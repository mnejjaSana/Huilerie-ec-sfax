using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{
   public class RapportVente
    {
    
      
        public Vente vente { get; set; }
        public virtual ICollection<HistoriquePaiementVente> LignesHistoriquePaiementVente { get; set; }


    }
}
