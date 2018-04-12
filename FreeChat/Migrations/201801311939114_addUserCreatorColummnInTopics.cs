using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class addUserCreatorColummnInTopics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "UserCreatorId", c => c.Long(nullable: false));
            AddColumn("dbo.Topics", "UserCreator_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Topics", "UserCreator_Id");
            AddForeignKey("dbo.Topics", "UserCreator_Id", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Topics", "UserCreator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Topics", new[] { "UserCreator_Id" });
            DropColumn("dbo.Topics", "UserCreator_Id");
            DropColumn("dbo.Topics", "UserCreatorId");
        }
    }
}
