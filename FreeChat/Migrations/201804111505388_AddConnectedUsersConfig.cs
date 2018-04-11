namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnectedUsersConfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserConnections", "ConnectedUser_Id", "dbo.ConnectedUsers");
            DropIndex("dbo.UserConnections", new[] { "ConnectedUser_Id" });
            RenameColumn(table: "dbo.UserConnections", name: "ConnectedUser_Id", newName: "ConnectedUserId");
            RenameColumn(table: "dbo.ConnectedUsers", name: "ApplicationUserId_Id", newName: "User_Id");
            RenameIndex(table: "dbo.ConnectedUsers", name: "IX_ApplicationUserId_Id", newName: "IX_User_Id");
            AlterColumn("dbo.UserConnections", "ConnectedUserId", c => c.Long(nullable: false));
            AlterColumn("dbo.MainCategories", "CategoryImage", c => c.String(nullable: false, maxLength: 3000));
            CreateIndex("dbo.UserConnections", "ConnectedUserId");
            AddForeignKey("dbo.UserConnections", "ConnectedUserId", "dbo.ConnectedUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserConnections", "ConnectedUserId", "dbo.ConnectedUsers");
            DropIndex("dbo.UserConnections", new[] { "ConnectedUserId" });
            AlterColumn("dbo.MainCategories", "CategoryImage", c => c.String());
            AlterColumn("dbo.UserConnections", "ConnectedUserId", c => c.Long());
            RenameIndex(table: "dbo.ConnectedUsers", name: "IX_User_Id", newName: "IX_ApplicationUserId_Id");
            RenameColumn(table: "dbo.ConnectedUsers", name: "User_Id", newName: "ApplicationUserId_Id");
            RenameColumn(table: "dbo.UserConnections", name: "ConnectedUserId", newName: "ConnectedUser_Id");
            CreateIndex("dbo.UserConnections", "ConnectedUser_Id");
            AddForeignKey("dbo.UserConnections", "ConnectedUser_Id", "dbo.ConnectedUsers", "Id");
        }
    }
}
