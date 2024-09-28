namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chaine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chaines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Intitule = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chaines");
        }
    }
}
