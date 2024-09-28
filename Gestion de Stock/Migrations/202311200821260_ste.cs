namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societes", "AchatBase", c => c.Boolean(nullable: false));
            AddColumn("dbo.Societes", "AchatHuile", c => c.Boolean(nullable: false));
            AddColumn("dbo.Societes", "AchatOlive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Societes", "AchatBaseService", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Societes", "AchatBaseService");
            DropColumn("dbo.Societes", "AchatOlive");
            DropColumn("dbo.Societes", "AchatHuile");
            DropColumn("dbo.Societes", "AchatBase");
        }
    }
}
