using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
  public  class HistoriquePaiementAchats
    {
        public HistoriquePaiementAchats()
        {
            DateCreation = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string NumAchat { get; set; }
        public virtual Agriculteur Founisseur { get; set; }
        public TypeAchat TypeAchat { get; set; }
        public decimal MontantReglement { get; set; }
        public decimal MontantRegle { get; set; }
        public decimal ResteApayer { get; set; }
        public string Commentaire { get; set; }
    }
}
