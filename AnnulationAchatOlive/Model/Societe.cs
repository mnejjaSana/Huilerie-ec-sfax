using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{
  public  class Societe
    {
        [Key]
        public int Id { get; set; }
     
        public string RaisonSocial { get; set; }
        public string Capitale { get; set; }
     
        public string CodePostale { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
       
        public string MatriculFiscal { get; set; }
    
        public string Telephone { get; set; }

        public bool Enregister { get; set; }

        public bool AchatBase { get; set; }

        public bool AchatHuile { get; set; }

        public bool AchatOlive { get; set; }

        public bool Service { get; set; }


    }
}
