namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pmpprod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emplacements", "LastPrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emplacements", "LastPrixMoyen");
        }
    }
}
