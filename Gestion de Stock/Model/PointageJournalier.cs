using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class PointageJournalier
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NombreHeure { get; set; }
        public int IdSalarier { get; set; }
        public  Salarier Salarier { get; set; }
    }
       
}
