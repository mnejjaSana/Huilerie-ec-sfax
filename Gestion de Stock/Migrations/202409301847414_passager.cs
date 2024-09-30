namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passager : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personne_PassagerAchat",
                c => new
                    {
                        Personne_Passager_Id = c.Int(nullable: false),
                        Achat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Personne_Passager_Id, t.Achat_Id })
                .ForeignKey("dbo.Personne_Passager", t => t.Personne_Passager_Id, cascadeDelete: true)
                .ForeignKey("dbo.Achats", t => t.Achat_Id, cascadeDelete: true)
                .Index(t => t.Personne_Passager_Id)
                .Index(t => t.Achat_Id);
            
            DropColumn("dbo.Achats", "Nom");
            DropColumn("dbo.Achats", "Prenom");
            DropColumn("dbo.Achats", "CIN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achats", "CIN", c => c.String());
            AddColumn("dbo.Achats", "Prenom", c => c.String());
            AddColumn("dbo.Achats", "Nom", c => c.String());
            DropForeignKey("dbo.Personne_PassagerAchat", "Achat_Id", "dbo.Achats");
            DropForeignKey("dbo.Personne_PassagerAchat", "Personne_Passager_Id", "dbo.Personne_Passager");
            DropIndex("dbo.Personne_PassagerAchat", new[] { "Achat_Id" });
            DropIndex("dbo.Personne_PassagerAchat", new[] { "Personne_Passager_Id" });
            DropTable("dbo.Personne_PassagerAchat");
        }
    }
}
