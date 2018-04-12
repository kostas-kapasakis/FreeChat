using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class populateForeignKey : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE dbo.Topics SET MainCategory_id = 1
              where Genre='Music'");
            Sql(@"UPDATE dbo.Topics SET MainCategory_id = 2
              where Genre='Sports'");
            Sql(@"UPDATE dbo.Topics SET MainCategory_id = 3
              where Genre='Trips'");
        }

        public override void Down()
        {
        }
    }
}
