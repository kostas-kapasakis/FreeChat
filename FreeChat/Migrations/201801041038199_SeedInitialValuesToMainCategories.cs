namespace FreeChat.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedInitialValuesToMainCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.MainCategories (Id,Name,Active) VALUES(1,'Music',1)");
            Sql("INSERT INTO dbo.MainCategories (Id,Name,Active) VALUES(2,'Sports',1)");
            Sql("INSERT INTO dbo.MainCategories (Id,Name,Active) VALUES(3,'Trips',1)");

        }

        public override void Down()
        {
        }
    }
}
