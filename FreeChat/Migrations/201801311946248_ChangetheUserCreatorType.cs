namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetheUserCreatorType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Topics", new[] { "UserCreator_Id" });
            DropColumn("dbo.Topics", "UserCreatorId");
            RenameColumn(table: "dbo.Topics", name: "UserCreator_Id", newName: "UserCreatorId");
            AlterColumn("dbo.Topics", "UserCreatorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Topics", "UserCreatorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Topics", new[] { "UserCreatorId" });
            AlterColumn("dbo.Topics", "UserCreatorId", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Topics", name: "UserCreatorId", newName: "UserCreator_Id");
            AddColumn("dbo.Topics", "UserCreatorId", c => c.Long(nullable: false));
            CreateIndex("dbo.Topics", "UserCreator_Id");
        }
    }
}
