namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodepostal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Codepostals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cp = c.String(),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ads", "CodePostalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ads", "CodePostalId");
            AddForeignKey("dbo.Ads", "CodePostalId", "dbo.Codepostals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "CodePostalId", "dbo.Codepostals");
            DropIndex("dbo.Ads", new[] { "CodePostalId" });
            DropColumn("dbo.Ads", "CodePostalId");
            DropTable("dbo.Codepostals");
        }
    }
}
