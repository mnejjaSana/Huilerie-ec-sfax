using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class Agriculteur
    {
        [Key]
        public int Id { get; set; }
        public string cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [NotMapped]
        public string FullName { get { return Nom + " " + Prenom; } }
        public string Numero { get; set; }
        public string Tel { get; set; }
        public string Vehicule { get; set; }
        public decimal Solde { get; set; }
        public decimal SoldeAgriculteur { get; set; }
        public decimal SoldeAgriculteurAvecSens { get { return Math.Round( decimal.Multiply( SoldeAgriculteur , -1),3); } }
        public decimal TotalAvances { get; set; }
        public decimal TotalAchats { get; set; }

    }
}
