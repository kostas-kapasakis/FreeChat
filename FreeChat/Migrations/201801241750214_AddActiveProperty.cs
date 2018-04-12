using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class AddActiveProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Active", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Active");
        }
    }
}
