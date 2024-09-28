using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
    public class HistoriquePaiementSalarie
    {
        public HistoriquePaiementSalarie()
        {
            DateCreation = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public virtual Salarier Salarie { get; set; }
       
        public ModeReglement ModeReglement { get; set; }
        public decimal MontantReglement { get; set; }
        public decimal MontantRegle { get; set; }
        public decimal ResteApayer { get; set; }
        public int NumCheque { get; set; }
        public Nullable<DateTime> DateEcheance { get; set; }
        public string Bank { get; set; }
        public Boolean Coffre { get; set; }

    }
}
