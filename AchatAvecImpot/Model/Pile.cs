using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
    public class Pile
    {
        [Key]
        public int Id { get; set; }
        public string Intitule { get; set; }
        public string Numero { get; set; }
        public ArticleVente article { get; set; }
        public int CapaciteMax { get; set; }
        public int Capacite { get; set; }
        public int CapaciteVide { get { return CapaciteMax - Capacite; } }
        public decimal PrixMoyen { get; set; }

      


    }
}
