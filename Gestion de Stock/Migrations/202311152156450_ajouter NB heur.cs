namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterNBheur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointageJournaliers", "NombreHeure", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointageJournaliers", "NombreHeure");
        }
    }
}
