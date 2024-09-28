using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
  
    public class Production
    {
       public Production()
        {
            DateProd = DateTime.Now;
            DateFinProd= DateTime.Now.AddMinutes(2);
            DateOperation= DateTime.Now;
        }


        public int Id { get; set; }
        public DateTime DateOperation { get; set; }
        public string NumeroProduction { get; set; }
        public virtual Achat Achat { get; set; }
        public string NumeroAchat
        {
            get { return this.Achat.Numero; }
        }
        public string Agriculteur
        {
            get { return this.Achat.Founisseur.FullName; }
        }
        public string NuméroBon { get; set; }
        public DateTime DateProd { get; set; }
        public DateTime DateFinProd { get; set; }
        public string dureeProduction { get; set; }
        public chaine Machine { get; set; }
        public StatutProduction StatutProd { get; set; }
        public decimal QuantiteHuile { get; set; }    
        public List<LigneProduction> LigneProductions { get; set; }
        public List<LigneStock> LignesStock { get; set; }
        public TypeAchat TypeAchat { get; set; }
        public virtual Emplacement Emplacement { get; set; }

        public decimal RendementReel { get; set; }
        public decimal RendementMoyenPrevu { get; set; }
        public string QuantiteOlive { get; set; }

        public decimal PUTotal { get; set; }



    }
}
