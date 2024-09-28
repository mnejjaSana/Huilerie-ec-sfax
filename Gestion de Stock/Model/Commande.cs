using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Stock.Model
{
   public class Commande
    {
        public Commande()
        {
            DateCreation = DateTime.Now;
        }

        [Key]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Date Creation Commande is required")]
        public DateTime DateCreation { get; set; }
        [Required(ErrorMessage = "Nom Produit Commande is required") ]
        public string NomProduit { get; set; }
        [Required(ErrorMessage = "Prix Produit Commande is required")]
        public decimal PrixProduit { get; set; }

        public int Quantity { get; set; }

        public string TVA { get; set; }

        public decimal Total_Commande { get; set; }

        
        public Client Client { get; set; }

    }
}
