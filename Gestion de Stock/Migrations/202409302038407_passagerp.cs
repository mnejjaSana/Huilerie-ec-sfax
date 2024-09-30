namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passagerp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personne_PassagerAchat", "Personne_Passager_Id", "dbo.Personne_Passager");
            DropForeignKey("dbo.Personne_PassagerAchat", "Achat_Id", "dbo.Achats");
            DropIndex("dbo.Personne_PassagerAchat", new[] { "Personne_Passager_Id" });
            DropIndex("dbo.Personne_PassagerAchat", new[] { "Achat_Id" });
            AddColumn("dbo.Personne_Passager", "Achat_Id", c => c.Int());
            CreateIndex("dbo.Personne_Passager", "Achat_Id");
            AddForeignKey("dbo.Personne_Passager", "Achat_Id", "dbo.Achats", "Id");
            DropTable("dbo.Personne_PassagerAchat");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Personne_PassagerAchat",
                c => new
                    {
                        Personne_Passager_Id = c.Int(nullable: false),
                        Achat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Personne_Passager_Id, t.Achat_Id });
            
            DropForeignKey("dbo.Personne_Passager", "Achat_Id", "dbo.Achats");
            DropIndex("dbo.Personne_Passager", new[] { "Achat_Id" });
            DropColumn("dbo.Personne_Passager", "Achat_Id");
            CreateIndex("dbo.Personne_PassagerAchat", "Achat_Id");
            CreateIndex("dbo.Personne_PassagerAchat", "Personne_Passager_Id");
            AddForeignKey("dbo.Personne_PassagerAchat", "Achat_Id", "dbo.Achats", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Personne_PassagerAchat", "Personne_Passager_Id", "dbo.Personne_Passager", "Id", cascadeDelete: true);
        }
    }
}
