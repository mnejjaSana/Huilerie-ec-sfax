namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masraf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emplacements", "PrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Emplacements", "ValeurMasraf", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.Emplacements", "Valeur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emplacements", "Valeur", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.Emplacements", "ValeurMasraf");
            DropColumn("dbo.Emplacements", "PrixMoyen");
        }
    }
}
