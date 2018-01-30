namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refiningForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MainCategories", "Topics_Id", "dbo.Topics");
            DropIndex("dbo.MainCategories", new[] { "Topics_Id" });
            AddColumn("dbo.Topics", "MainCategory_Id", c => c.Byte());
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Topics", "MainCategory_Id");
            AddForeignKey("dbo.Topics", "MainCategory_Id", "dbo.MainCategories", "Id");
            DropColumn("dbo.MainCategories", "Topics_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainCategories", "Topics_Id", c => c.Long());
            DropForeignKey("dbo.Topics", "MainCategory_Id", "dbo.MainCategories");
            DropIndex("dbo.Topics", new[] { "MainCategory_Id" });
            AlterColumn("dbo.Topics", "MainCategoryId", c => c.Long());
            DropColumn("dbo.Topics", "MainCategory_Id");
            CreateIndex("dbo.MainCategories", "Topics_Id");
            AddForeignKey("dbo.MainCategories", "Topics_Id", "dbo.Topics", "Id");
        }
    }
}
