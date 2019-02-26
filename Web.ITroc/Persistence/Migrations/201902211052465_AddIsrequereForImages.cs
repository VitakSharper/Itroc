namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsrequereForImages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "FileBase64", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "FileBase64", c => c.String());
        }
    }
}
