using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatHuile.Model
{
  public  class Client
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Intitule { get; set; }  
        public string Adresse { get; set; }
        public string Tel  { get; set; }
        public string MatriculeFiscale { get; set; }

    }
}
