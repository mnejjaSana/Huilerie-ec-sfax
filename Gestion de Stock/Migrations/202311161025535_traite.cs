namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class traite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coffrecheques", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coffrecheques", "Type");
        }
    }
}
