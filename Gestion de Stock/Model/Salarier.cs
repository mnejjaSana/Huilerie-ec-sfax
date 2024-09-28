using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Salarier
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public string numero { get; set; }
        public string Tel { get; set; }

        public decimal TotalNombreHeure { get; set; }

        public decimal TotalDeponse { get; set; }

        public ICollection<PointageJournalier> ListepointageSalariers { get; set; }
        

    }
}
