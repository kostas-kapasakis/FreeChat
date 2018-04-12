using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class ProperSeedingInMainCategories : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO[dbo].[MainCategories] ([Id], [Name], [Active], [Topics_Id], [CategoryImage], [CategoryDescription]) VALUES(1, N'Music', 1, NULL, '/Content/images/music.jpg', 'Talk about you favorite artists,albums,concerts\r\nand all upcoming and current music happenings')");
            Sql(
                "INSERT INTO[dbo].[MainCategories] ([Id], [Name], [Active], [Topics_Id], [CategoryImage], [CategoryDescription]) VALUES(2, N'Sports', 1, NULL, '/Content/images/sports.jpg', 'Sports nowadays is always part of the discussion.\r\nImportant matches,championships,altercations\r\ntransfers and many more')");


            Sql(
                "INSERT INTO[dbo].[MainCategories] ([Id], [Name], [Active], [Topics_Id], [CategoryImage], [CategoryDescription]) VALUES(3, N'Trips', 1, NULL, '/Content/images/trips.jpg', 'Share,learn,discovere.Trips are\r\nmore than amazing and necessary to be happy')");

        }

        public override void Down()
        {
        }
    }
}
