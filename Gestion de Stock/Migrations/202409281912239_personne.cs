namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personne_Passager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cin = c.String(),
                        FullName = c.String(),
                        Numero = c.String(),
                        Tel = c.String(),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 6),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Achats", "Nom", c => c.String());
            AddColumn("dbo.Achats", "Prenom", c => c.String());
            AddColumn("dbo.Achats", "CIN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achats", "CIN");
            DropColumn("dbo.Achats", "Prenom");
            DropColumn("dbo.Achats", "Nom");
            DropTable("dbo.Personne_Passager");
        }
    }
}
