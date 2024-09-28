using AnnulationAchatOlive.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnulationAchatOlive.Model
{

    public class Achat
    {
        public Achat()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Emplacement_Id {get;set;}
        public DateTime Date { get; set; }
        public virtual Agriculteur Founisseur { get; set; }
        public Nullable<ArticleAchat> TypeOlive { get; set; }
        public TypeAchat TypeAchat { get; set; }

        public string TypeAchatRapport
        {

            get
            {
                if (this.TypeAchat == TypeAchat.Olive )
                { return "Olive"; }

                else if (this.TypeAchat == TypeAchat.Huile || this.TypeAchat == TypeAchat.Base)
                    { return "Huile"; }

                else return "Service";
            }
        }
        public int Founisseur_Id { get; set; }
        public int Pile_Id { get; set; }    
        public int NbSacs { get; set; }
        public decimal Poids { get; set; }
        public decimal PrixLitre { get; set; }
        public decimal QteLitre { get; set; }

        public decimal QteRestStockhuile { get; set; }

        public EtatAchat EtatAchat { get; set; }

        public string NomEtatAchat {

            get {
                if (this.EtatAchat == EtatAchat.Reglee)
                { return "Réglé"; }

                else if (this.EtatAchat == EtatAchat.PartiellementReglee)
                { return "Partiellement Réglé"; }

                else return "Non Réglé";
            }
        }
  
        public decimal MontantRegle { get; set; }

        public decimal ResteApayer { get { return MtAPayeAvecImpo - MontantRegle; } }

        public StatutProduction StatutProd { get; set; }
        public string NuméroBon { get; set; }
        public EtatAvance EtatAvance { get; set; }

        public virtual Pile Pile { get; set; }

        public ArticleVente Qualite { get; set; }

        public int QteHuileAchetee { get; set; }

        public decimal QteHuile { get; set; }

        public string Annulle { get; set; }

        public decimal AvanceAvecAchat { get; set; }

        public Boolean Avance { get; set; }

        public int QteOliveAchetee { get; set; }

        public virtual Emplacement Emplacement { get; set; }

        public decimal Rendement { get; set; }

        public decimal PUOlive { get; set; }

        public decimal PUOliveFinal { get; set; }

        public decimal MontantOpPrev { get; set; }

        public ModeReglement ModeReglement { get; set; }
        public string NumeroCheque { get; set; }
        public Nullable<DateTime> DateEcheance { get; set; }
        public string Banque { get; set; }
        public Boolean Coffre { get; set; }

        public Boolean AvecAmpo { get; set; }

        public decimal MontantReglement { get; set; }//10000

        public decimal MtAdeduire {get;set; } // 100 => 1% de 10000

        public decimal MtAPayeAvecImpo { get; set; }// 9900

        public int QteHORepport {
            get
            {
                int Qte=0;

                if (QteHuileAchetee > 0 && QteOliveAchetee==0)
                {
                    Qte = QteHuileAchetee;
                }
                else if(QteOliveAchetee > 0 && QteHuileAchetee == 0)
                {
                    Qte = QteOliveAchetee;
                }
                else if(this.TypeAchat== TypeAchat.Base)
                {
                    Qte = Convert.ToInt32(this.QteLitre);
                }
                return Qte;
            }
        }

        public string QualiteRepport
        {
            get
            {
                string qualiteReport = "";

                if (TypeOlive== ArticleAchat.Nchira && (TypeAchat== TypeAchat.Olive || TypeAchat == TypeAchat.Base))
                {
                    qualiteReport = "Nchira";
                }
                else if(TypeOlive == ArticleAchat.OliveVif && (TypeAchat == TypeAchat.Olive || TypeAchat == TypeAchat.Base))
                {
                    qualiteReport = "Olive Vif";
                }
                else if (Qualite == ArticleVente.Extra && TypeAchat == TypeAchat.Huile)
                {
                    qualiteReport = "Extra";
                }
                else if (Qualite == ArticleVente.Lampante && TypeAchat == TypeAchat.Huile)
                {
                    qualiteReport = "Lampante";
                }
                else if (Qualite == ArticleVente.Vierge && TypeAchat == TypeAchat.Huile)
                {
                    qualiteReport = "Vierge";
                }
                else if (Qualite == ArticleVente.ExtraVierge && TypeAchat == TypeAchat.Huile)
                {
                    qualiteReport = "ExtraVierge";
                }


                return qualiteReport;
            }
        }

        public decimal PrixUnitaire
        {
            get
            {
                decimal PrixUnitaire = 0m;

                if (TypeOlive == ArticleAchat.Nchira && (TypeAchat == TypeAchat.Olive))
                {
                    PrixUnitaire = PUOliveFinal;
                }
                else if (TypeOlive == ArticleAchat.OliveVif && (TypeAchat == TypeAchat.Olive))
                {
                    PrixUnitaire = PUOliveFinal;
                }
                else if (((Qualite == ArticleVente.Extra || Qualite == ArticleVente.Lampante || Qualite == ArticleVente.Vierge || Qualite == ArticleVente.ExtraVierge) && TypeAchat == TypeAchat.Huile) || TypeAchat == TypeAchat.Base)
                {
                    PrixUnitaire = PrixLitre;
                }
               
                return PrixUnitaire;
            }
        }

    }
}
