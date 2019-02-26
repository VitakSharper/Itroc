namespace Web.ITroc.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateVille : DbMigration
    {
        public override void Up()
        {
            Sql("update AspNetUsers set Ville='Fontainebleau' where UserName='user1@itroc.com'");
            Sql("update AspNetUsers set Ville='Vaux le Penil' where UserName='admin@itroc.com'");
        }

        public override void Down()
        {
        }
    }
}
