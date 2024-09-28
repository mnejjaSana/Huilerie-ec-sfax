using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
    public class VenteOlive
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int ClientId { get; set; }
        public string ClientNumero { get; set; }
        public DateTime Date { get; set; }
        public string Commentaire { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public ArticleAchat ArticleId { get; set; }
        public int EmplacementId { get; set; }
        public int ReferenceId { get; set; }
        public string Camion { get; set; }
        public string Adresse { get; set; }
        public string NomChauffeur { get; set; }
        public int SocieteId { get; set; }
    }
}
