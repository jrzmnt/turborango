namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaEntidadePromocao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promocaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorPromocao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TerminoPromocao = c.DateTime(nullable: false),
                        Restaurante_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_Id)
                .Index(t => t.Restaurante_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promocaos", "Restaurante_Id", "dbo.Restaurantes");
            DropIndex("dbo.Promocaos", new[] { "Restaurante_Id" });
            DropTable("dbo.Promocaos");
        }
    }
}
