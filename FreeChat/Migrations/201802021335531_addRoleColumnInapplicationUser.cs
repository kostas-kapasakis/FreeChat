using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class addRoleColumnInapplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Role");
        }
    }
}
