namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class impo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achats", "AvecAmpo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Achats", "MtAdeduire", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.Achats", "MtAPayeAvecImpo", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achats", "MtAPayeAvecImpo");
            DropColumn("dbo.Achats", "MtAdeduire");
            DropColumn("dbo.Achats", "AvecAmpo");
        }
    }
}
