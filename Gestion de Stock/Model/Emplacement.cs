using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Emplacement
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Intitule { get; set; }
        public int Quantite { get; set; }
        public ArticleAchat Article { get; set; }
        public decimal RENDEMENMOY { get; set; } = 0;
        public decimal PrixMoyen { get; set; }

        public decimal ValeurMasraf { get; set; }

        public decimal LastPrixMoyen { get; set; }

        public decimal Huile { get { return  (Quantite * RENDEMENMOY)/100; } }
    }
}
