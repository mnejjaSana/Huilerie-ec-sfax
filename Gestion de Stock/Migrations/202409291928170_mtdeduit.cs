namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mtdeduit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoriquePaiementAchats", "AvecAmpoAjouterREG", c => c.Boolean(nullable: false));
            AddColumn("dbo.HistoriquePaiementAchats", "MtAdeduireAjouterREG", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AddColumn("dbo.HistoriquePaiementAchats", "MtAPayeAvecImpoAjouterREG", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistoriquePaiementAchats", "MtAPayeAvecImpoAjouterREG");
            DropColumn("dbo.HistoriquePaiementAchats", "MtAdeduireAjouterREG");
            DropColumn("dbo.HistoriquePaiementAchats", "AvecAmpoAjouterREG");
        }
    }
}
