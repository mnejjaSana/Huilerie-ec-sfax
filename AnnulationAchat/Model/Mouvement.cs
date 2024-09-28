using AnnulationAchatHuile.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatHuile.Model
{
   
   
   
    public class Mouvement
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Libelle { get; set; }
        public Sens Sens { get; set; }
        public TypeMouvement Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }
        public int UserNo { get; set; }
        public string Tiers { get; set; }

        public int TiersId { get; set; }

        public NatureMouvement Nature { get; set; }

        public int SocieteId { get; set; }

    }
}
