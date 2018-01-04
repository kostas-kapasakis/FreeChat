namespace FreeChat.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedTheNewColumnInMAinCategoriesTable : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO dbo.MainCategories (CategoryDescription,CategoryImage) VALUES(" +
                "'Talk about you favorite artists,albums,concerts and  all upcoming and current music happenings'," +
                "'~/Content/images/music.jpg') WHERE Name='Music'");

            Sql("INSERT INTO dbo.MainCategories (CategoryDescription,CategoryImage) VALUES(" +
                "'Sports nowadays is always part of the discussion.Important matches, championships, altercations transfers and many more..','~/Content/images/sports.jpg') WHERE Name='Sports'");

            Sql("INSERT INTO dbo.MainCategories (CategoryDescription,CategoryImage) VALUES(" +
                "'Share,learn,discover.Trips are more than amazing and necessary to be happy','~/Content/images/trips.jpg') WHERE Name='Trips'");
        }

        public override void Down()
        {
        }
    }
}
