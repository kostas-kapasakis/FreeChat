using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class AddUserPropertyToUserConnectionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserConnections", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserConnections", "User_Id");
            AddForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserConnections", new[] { "User_Id" });
            DropColumn("dbo.UserConnections", "User_Id");
        }
    }
}
