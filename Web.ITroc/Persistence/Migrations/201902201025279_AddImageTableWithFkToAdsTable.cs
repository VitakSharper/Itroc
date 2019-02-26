namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTableWithFkToAdsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileBase64 = c.String(),
                        Poubelle = c.Boolean(nullable: false),
                        AnnonceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ads", t => t.AnnonceId, cascadeDelete: true)
                .Index(t => t.AnnonceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "AnnonceId", "dbo.Ads");
            DropIndex("dbo.Images", new[] { "AnnonceId" });
            DropTable("dbo.Images");
        }
    }
}
