using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Model
{
   public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }

        public int SocieteId { get; set; }


    }
}
