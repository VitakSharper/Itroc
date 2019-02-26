namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVilleToUsersIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Ville", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Ville");
        }
    }
}
