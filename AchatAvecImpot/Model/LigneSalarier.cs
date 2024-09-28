using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
    public class LigneSalarier
    {
        public int Id { get; set; }
        public int SalarierId { get; set; }

        public DateTime Date { get; set; }

        public int NombreHeure { get; set; }

        public int SocieteId { get; set; }
    }
}
