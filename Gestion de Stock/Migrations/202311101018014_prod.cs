namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productions", "PUTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.LigneProductions", "valeurLignePTotal");
            DropColumn("dbo.LigneProductions", "PULigneProdTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LigneProductions", "PULigneProdTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.LigneProductions", "valeurLignePTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.Productions", "PUTotal");
        }
    }
}
