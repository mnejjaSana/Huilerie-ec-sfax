namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class montantinitiaavance : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Personne_Passager", name: "HistoriquePaiementAchats_Id", newName: "NumHistoriqueAchat_Id");
            RenameIndex(table: "dbo.Personne_Passager", name: "IX_HistoriquePaiementAchats_Id", newName: "IX_NumHistoriqueAchat_Id");
            AddColumn("dbo.Achats", "MontantInitialAvance", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achats", "MontantInitialAvance");
            RenameIndex(table: "dbo.Personne_Passager", name: "IX_NumHistoriqueAchat_Id", newName: "IX_HistoriquePaiementAchats_Id");
            RenameColumn(table: "dbo.Personne_Passager", name: "NumHistoriqueAchat_Id", newName: "HistoriquePaiementAchats_Id");
        }
    }
}
