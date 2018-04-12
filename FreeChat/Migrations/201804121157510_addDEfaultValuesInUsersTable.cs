using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class AddDEfaultValuesInUsersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Role", c => c.String(maxLength: 100, defaultValue: "RegisteredUser"));
            AlterColumn("dbo.Users", "RoomsLeft", c => c.Int(defaultValue: 10));
        }

        public override void Down()
        {
            AlterColumn("dbo.Users", "Role", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "RoomsLeft", c => c.Int());
        }
    }
}
