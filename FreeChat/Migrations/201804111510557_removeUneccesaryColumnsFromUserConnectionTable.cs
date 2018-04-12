using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class removeUneccesaryColumnsFromUserConnectionTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserConnections", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.UserConnections", name: "IX_UserId", newName: "IX_User_Id");
            DropColumn("dbo.UserConnections", "ConnectionId");
            DropColumn("dbo.UserConnections", "Username");
        }

        public override void Down()
        {
            AddColumn("dbo.UserConnections", "Username", c => c.String());
            AddColumn("dbo.UserConnections", "ConnectionId", c => c.Long(nullable: false));
            RenameIndex(table: "dbo.UserConnections", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserConnections", name: "User_Id", newName: "UserId");
        }
    }
}
