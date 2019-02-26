namespace Web.ITroc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsInUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nom", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Prenom", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Prenom");
            DropColumn("dbo.AspNetUsers", "Nom");
        }
    }
}
