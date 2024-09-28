using Gestion_de_Stock.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());
            Database.CommandTimeout = 0;
          //  this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 6));
        }
        public DbSet<Personne_Passager> PersonnePassagers { get; set; }
        
        public DbSet<Utilisateur> Utilisateurs { get; set; }        

        public DbSet<Agriculteur> Agriculteurs { get; set; }
        public DbSet<Emplacement> Emplacements { get; set; }
        public DbSet<Mouvement> Mouvements { get; set; }
        public DbSet<Pile> Piles { get; set; }
        public DbSet<Achat> Achats { get; set; }
      //  public DbSet<Reference> References { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Salarier> Salariers { get; set; }
        public DbSet<LigneSalarier> LigneSalariers { get; set; }
        public DbSet<LigneProduction> LigneProductions { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<LigneVente> LignesVente { get; set; }
        public DbSet<Vente> Vente { get; set; }
        public DbSet<VenteOlive> VenteOlive { get; set; }
        public DbSet<Societe> Societe { get; set; }

        public DbSet<MouvementStock> MouvementsStock { get; set; }
        public DbSet<Alimentation> Alimentations { get; set; }
        public DbSet<Depense> Depenses { get; set; }
        public DbSet<MouvementCaisse> MouvementsCaisse { get; set; }
        public DbSet<Caisse> Caisse { get; set; }
        public DbSet<LigneStock> LignesStock { get; set; }

        public DbSet<HistoriquePaiementVente> HistoriquePaiementVente { get; set; }
        public DbSet<HistoriquePaiementAchats> HistoriquePaiementAchats { get; set; }

        public DbSet<HistoriquePaiementSalarie> HistoriquePaiementSalaries { get; set; }


        public DbSet<Coffrecheque> CoffreCheques { get; set; }

        public DbSet<Prelevement> Prelevements { get; set; }

        public DbSet<Affaire> Affaires { get; set; }

        public DbSet<Banque> Banques { get; set; }
        public DbSet<MouvementStockOlive> MouvementStockOlive { get; set; }
        public DbSet<Chaine> Chaines { get; set; }
        public DbSet<PointageJournalier> PointageJournaliers { get; set; }
        


    }
}
