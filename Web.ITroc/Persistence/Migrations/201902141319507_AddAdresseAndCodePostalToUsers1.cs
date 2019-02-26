namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdresseAndCodePostalToUsers1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Adresse", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "CodePostal", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CodePostal");
            DropColumn("dbo.AspNetUsers", "Adresse");
        }
    }
}
