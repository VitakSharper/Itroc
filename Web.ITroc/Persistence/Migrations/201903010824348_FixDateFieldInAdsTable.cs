namespace Web.ITroc.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class FixDateFieldInAdsTable : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Ads", "AdCreate", c => c.DateTime(nullable: false));
			Sql("update ads set AdCreate=AdCeate");
			DropColumn("dbo.Ads", "AdCeate");
		}

		public override void Down()
		{
			AddColumn("dbo.Ads", "AdCeate", c => c.DateTime(nullable: false));
			DropColumn("dbo.Ads", "AdCreate");
		}
	}
}
