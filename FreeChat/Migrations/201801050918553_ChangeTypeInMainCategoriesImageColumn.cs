namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeInMainCategoriesImageColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MainCategories", "CategoryImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MainCategories", "CategoryImage", c => c.Binary());
        }
    }
}
