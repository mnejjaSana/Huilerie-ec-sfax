namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class achat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achats", "ModeReglement", c => c.Int(nullable: false));
            AddColumn("dbo.Achats", "NumeroCheque", c => c.String());
            AddColumn("dbo.Achats", "DateEcheance", c => c.DateTime());
            AddColumn("dbo.Achats", "Banque", c => c.String());
            AddColumn("dbo.Achats", "Coffre", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achats", "Coffre");
            DropColumn("dbo.Achats", "Banque");
            DropColumn("dbo.Achats", "DateEcheance");
            DropColumn("dbo.Achats", "NumeroCheque");
            DropColumn("dbo.Achats", "ModeReglement");
        }
    }
}
