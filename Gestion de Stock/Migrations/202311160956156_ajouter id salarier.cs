namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouteridsalarier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointageJournaliers", "IdSalarier", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointageJournaliers", "IdSalarier");
        }
    }
}
