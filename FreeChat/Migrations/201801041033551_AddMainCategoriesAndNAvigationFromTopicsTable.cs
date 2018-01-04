namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainCategoriesAndNAvigationFromTopicsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        Topics_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Topics_Id)
                .Index(t => t.Topics_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainCategories", "Topics_Id", "dbo.Topics");
            DropIndex("dbo.MainCategories", new[] { "Topics_Id" });
            DropTable("dbo.MainCategories");
        }
    }
}
