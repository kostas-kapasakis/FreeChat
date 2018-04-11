namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTopicsConfiguration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "MainCategory_Id", "dbo.MainCategories");
            DropIndex("dbo.Topics", new[] { "MainCategory_Id" });
            DropColumn("dbo.Topics", "MainCategoryId");
            RenameColumn(table: "dbo.Topics", name: "MainCategory_Id", newName: "MainCategoryId");
            AlterColumn("dbo.Topics", "Name", c => c.String());
            AlterColumn("dbo.Topics", "Description", c => c.String());
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Topics", "MainCategoryId");
            AddForeignKey("dbo.Topics", "MainCategoryId", "dbo.MainCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "MainCategoryId", "dbo.MainCategories");
            DropIndex("dbo.Topics", new[] { "MainCategoryId" });
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Byte());
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.Topics", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 50));
            RenameColumn(table: "dbo.Topics", name: "MainCategoryId", newName: "MainCategory_Id");
            AddColumn("dbo.Topics", "MainCategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Topics", "MainCategory_Id");
            AddForeignKey("dbo.Topics", "MainCategory_Id", "dbo.MainCategories", "Id");
        }
    }
}
