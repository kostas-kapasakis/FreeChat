namespace FreeChat.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFluentApiModelBuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Topics", "UserCreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.UserConnections", new[] { "User_Id" });
            DropIndex("dbo.Topics", new[] { "UserCreatorId" });
            AlterColumn("dbo.ConnectedUsers", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserConnections", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topics", "Genre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topics", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Topics", "UserCreatorId", c => c.String(nullable: true, maxLength: 128));
            CreateIndex("dbo.UserConnections", "User_Id");
            CreateIndex("dbo.Topics", "UserCreatorId");
            AddForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Topics", "UserCreatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Topics", "UserCreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Topics", new[] { "UserCreatorId" });
            DropIndex("dbo.UserConnections", new[] { "User_Id" });
            AlterColumn("dbo.Topics", "UserCreatorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Topics", "Description", c => c.String());
            AlterColumn("dbo.Topics", "Genre", c => c.String());
            AlterColumn("dbo.Topics", "Name", c => c.String());
            AlterColumn("dbo.UserConnections", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ConnectedUsers", "Username", c => c.String());
            CreateIndex("dbo.Topics", "UserCreatorId");
            CreateIndex("dbo.UserConnections", "User_Id");
            AddForeignKey("dbo.Topics", "UserCreatorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
