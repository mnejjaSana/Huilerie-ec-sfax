namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class steservice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societes", "Service", c => c.Boolean(nullable: false));
            DropColumn("dbo.Societes", "AchatBaseService");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Societes", "AchatBaseService", c => c.Boolean(nullable: false));
            DropColumn("dbo.Societes", "Service");
        }
    }
}
