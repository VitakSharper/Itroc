namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnonceId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Images", name: "AnnonceId", newName: "AdId");
            RenameIndex(table: "dbo.Images", name: "IX_AnnonceId", newName: "IX_AdId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Images", name: "IX_AdId", newName: "IX_AnnonceId");
            RenameColumn(table: "dbo.Images", name: "AdId", newName: "AnnonceId");
        }
    }
}
