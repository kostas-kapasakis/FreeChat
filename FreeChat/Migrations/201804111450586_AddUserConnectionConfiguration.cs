using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class AddUserConnectionConfiguration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserConnections", name: "ConnectedUsers_Id", newName: "ConnectedUser_Id");
            RenameColumn(table: "dbo.UserConnections", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserConnections", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserConnections", name: "IX_ConnectedUsers_Id", newName: "IX_ConnectedUser_Id");
            AlterColumn("dbo.MainCategories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.MainCategories", "CategoryDescription", c => c.String(nullable: false, maxLength: 1000));
        }

        public override void Down()
        {
            AlterColumn("dbo.MainCategories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.MainCategories", "Name", c => c.String(nullable: false, maxLength: 255));
            RenameIndex(table: "dbo.UserConnections", name: "IX_ConnectedUser_Id", newName: "IX_ConnectedUsers_Id");
            RenameIndex(table: "dbo.UserConnections", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UserConnections", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserConnections", name: "ConnectedUser_Id", newName: "ConnectedUsers_Id");
        }
    }
}
