namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsInAdsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "AdAdresse", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Ads", "AdImgFileName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Ads", "AdTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Ads", "AdDescription", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ads", "AdDescription", c => c.String());
            AlterColumn("dbo.Ads", "AdTitle", c => c.String());
            DropColumn("dbo.Ads", "AdImgFileName");
            DropColumn("dbo.Ads", "AdAdresse");
        }
    }
}
