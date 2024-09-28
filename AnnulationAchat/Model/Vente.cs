using AnnulationAchatHuile.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatHuile.Model
{
  public  class Vente
    {
        public Vente()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Numero { get; set; }
      
        public int IdClient { get; set; }
        public string IntituleClient { get; set; }
        public string NumClient { get; set; }

        public DateTime Date { get; set; }
        public string Commentaire { get; set; }
        public string Camion { get; set; }
        public string Adresse { get; set; }
        public string NomChauffeur { get; set; }
        public EtatVente EtatVente { get; set; }

        public string NomEtat {
            get
            {
                if (this.EtatVente == EtatVente.Reglee)
                { return "Réglé"; }

                else if (this.EtatVente == EtatVente.PartiellementReglee)
                { return "Partiellement Réglé"; }

                else return "Non Réglé";
            }
        }

        public decimal TotalHT { get; set; }
        public decimal TotalTTC { get; set; }

        public  List<LigneVente> LigneVentes { get; set; }

        public decimal QteVendue { get; set; }

        public decimal MontantReglement { get; set; }
        public decimal MontantRegle { get; set; }

        public decimal ResteApayer { get { return MontantReglement - MontantRegle; } }
        public ModeReglement ModeReglement { get; set; }
        public string NumeroCheque { get; set; }
        public Nullable<DateTime> DateEcheance { get; set; }
        public string Bank { get; set; }
        public Boolean Coffre { get; set; }



    }
}
