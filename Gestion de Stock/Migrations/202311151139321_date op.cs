namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productions", "DateOperation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productions", "DateOperation");
        }
    }
}
