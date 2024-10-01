namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personnepassagerinhistoriqueachat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personne_Passager", "HistoriquePaiementAchats_Id", c => c.Int());
            CreateIndex("dbo.Personne_Passager", "HistoriquePaiementAchats_Id");
            AddForeignKey("dbo.Personne_Passager", "HistoriquePaiementAchats_Id", "dbo.HistoriquePaiementAchats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personne_Passager", "HistoriquePaiementAchats_Id", "dbo.HistoriquePaiementAchats");
            DropIndex("dbo.Personne_Passager", new[] { "HistoriquePaiementAchats_Id" });
            DropColumn("dbo.Personne_Passager", "HistoriquePaiementAchats_Id");
        }
    }
}
