using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class addUserConfigurations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            AddColumn("dbo.AspNetUserClaims", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "Role", c => c.String(maxLength: 100, defaultValue: "RegisteredUser"));
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "RoomsLeft", c => c.Int(defaultValue: 10));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
            CreateIndex("dbo.AspNetUserClaims", "User_Id");
            CreateIndex("dbo.AspNetUserLogins", "User_Id");
            CreateIndex("dbo.AspNetUserRoles", "User_Id");
            AddForeignKey("dbo.AspNetUserClaims", "User_Id", "Users", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "User_Id", "dbo.Users", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AspNetUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ApplicationUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.ApplicationUsers", "Role", c => c.String());
            DropColumn("dbo.AspNetUserRoles", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUserLogins", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUserClaims", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.ApplicationUsers", "UserName", unique: true, name: "UserNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ApplicationUsers", newName: "AspNetUsers");
        }
    }
}
