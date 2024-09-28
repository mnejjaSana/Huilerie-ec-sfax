namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterPointagesalarier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salariers", "TotalNombreHeure", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Salariers", "TotalDeponse", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salariers", "TotalDeponse");
            DropColumn("dbo.Salariers", "TotalNombreHeure");
        }
    }
}
