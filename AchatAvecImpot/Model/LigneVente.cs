using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
    public class LigneVente
    {
       
        public int Id { get; set; }   
        public int Quantity { get; set; }
        public ArticleVente ArticleVente { get; set; }
        public decimal Remise { get; set; }
        public int TVA { get; set; } = 19;
        [Required]
        public decimal TotalLigneHT { get { return Math.Round(Decimal.Multiply(PrixHT, Quantity) - Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixHT, Quantity), Remise), 100), 3); } }
        [Required]
        public decimal TotalLigneTTC { get { return Math.Round(Decimal.Multiply(PrixHT, Quantity) + Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixHT, Quantity), TVA), 100) - Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixHT, Quantity), Remise), 100), 3); } }
        [Required]
        public decimal PrixHT { get; set; }     
        public Vente Vente { get; set; }
       // public virtual Pile Pile { get; set; }
        public int IdPile { get; set; }
        public string NomPile  { get; set; }
        public int QuantitePileInitial { get; set; }
        public int QuantitePileFinal { get; set; }
        public decimal PrixMoyenPile { get; set; }
    }
}
