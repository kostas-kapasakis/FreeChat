namespace FreeChat.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddOnlineUsersColumnInTopicsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.ConnectedUsers",
              c => new
              {
                  Id = c.Long(nullable: false, identity: true),
                  Username = c.String(nullable: false, maxLength: 50),
                  User_Id = c.String(maxLength: 128),
              })
              .PrimaryKey(t => t.Id)
              .ForeignKey("dbo.Users", t => t.User_Id)
              .Index(t => t.User_Id);

            CreateTable(
                "dbo.UserConnections",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ConnectedUserId = c.Long(nullable: false),
                    User_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.ConnectedUsers", t => t.ConnectedUserId, cascadeDelete: true)
                .Index(t => t.ConnectedUserId);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MessageSent = c.String(),
                    DateSent = c.DateTime(nullable: false),
                    User_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            CreateTable(
                    "dbo.UsersInTopics",
                    c => new
                    {
                        UserId = c.Long(nullable: false),
                        TopicId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.TopicId })
                .ForeignKey("dbo.Topics", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.TopicId, cascadeDelete: false)
                .Index(t => t.UserId);

            DropForeignKey("dbo.Topics", "UserCreatorId", "dbo.AspNetUsers");


            DropIndex("dbo.Users", "UserNameIndex");

            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });

            DropIndex("dbo.Topics", new[] { "UserCreatorId" });

            AlterColumn("dbo.Users", "Role", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.MainCategories", "CategoryImage", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Topics", "Genre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topics", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Topics", "UserCreatorId", c => c.String(nullable: false, maxLength: 128));
            // AlterColumn("dbo.Topics", "MainCategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.Topics", "UserCreatorId");
            // CreateIndex("dbo.Topics", "MainCategoryId");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users", "Id");
            //AddForeignKey("dbo.Topics", "MainCategoryId", "dbo.MainCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Topics", "UserCreatorId", "dbo.Users", "Id", cascadeDelete: false);

        }

        public override void Down()
        {
            CreateTable(
                "dbo.UserConnections",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ConnectionId = c.Long(nullable: false),
                    Username = c.String(),
                    User_Id = c.String(maxLength: 128),
                    ConnectedUsers_Id = c.Long(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ConnectedUsers",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Username = c.String(),
                    ApplicationUserId_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            DropForeignKey("dbo.Topics", "UserCreatorId", "dbo.Users");
            DropForeignKey("dbo.Topics", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserConnections", "ConnectedUserId", "dbo.ConnectedUsers");
            DropForeignKey("dbo.ConnectedUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserConnections", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UsersInTopics", "TopicId", "dbo.Users");
            DropForeignKey("dbo.UsersInTopics", "UserId", "dbo.Topics");
            DropIndex("dbo.UsersInTopics", new[] { "TopicId" });
            DropIndex("dbo.UsersInTopics", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.UserConnections", new[] { "ConnectedUserId" });
            DropIndex("dbo.Topics", new[] { "MainCategoryId" });
            DropIndex("dbo.Topics", new[] { "UserCreatorId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.ConnectedUsers", new[] { "User_Id" });
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Byte());
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.Topics", "UserCreatorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Topics", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Topics", "Genre", c => c.String());
            AlterColumn("dbo.MainCategories", "CategoryImage", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.Users", "Role", c => c.String());
            DropTable("dbo.UsersInTopics");
            DropTable("dbo.Messages");
            DropTable("dbo.UserConnections");
            DropTable("dbo.ConnectedUsers");
            RenameColumn(table: "dbo.Topics", name: "MainCategoryId", newName: "MainCategory_Id");
            AddColumn("dbo.Topics", "MainCategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Topics", "MainCategory_Id");
            CreateIndex("dbo.Topics", "UserCreatorId");
            CreateIndex("dbo.UserConnections", "ConnectedUsers_Id");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.Users", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.ConnectedUsers", "ApplicationUserId_Id");
            AddForeignKey("dbo.Topics", "UserCreatorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Topics", "MainCategory_Id", "dbo.MainCategories", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserConnections", "ConnectedUsers_Id", "dbo.ConnectedUsers", "Id");
            AddForeignKey("dbo.UserConnections", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ConnectedUsers", "ApplicationUserId_Id", "dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}
