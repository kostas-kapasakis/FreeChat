using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class AddMainCategoriesFluentConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MainCategories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.MainCategories", "CategoryDescription", c => c.String(nullable: false, maxLength: 1000));
        }

        public override void Down()
        {
            AlterColumn("dbo.MainCategories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.MainCategories", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
