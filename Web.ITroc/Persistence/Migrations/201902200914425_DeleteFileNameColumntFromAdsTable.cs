namespace Web.ITroc.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeleteFileNameColumntFromAdsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ads", "AdImgFileName");
        }

        public override void Down()
        {
            AddColumn("dbo.Ads", "AdImgFileName", c => c.String(nullable: false));
        }
    }
}
