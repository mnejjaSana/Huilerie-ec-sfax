using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class Personne_Passager
    {
        [Key]
        public int Id { get; set; }
        public string cin { get; set; }
 
        public string FullName { get; set; }
       
        public string Numero { get; set; }
        public string Tel { get; set; }
      
        public decimal MontantReglement { get; set; }
      
    }
}
