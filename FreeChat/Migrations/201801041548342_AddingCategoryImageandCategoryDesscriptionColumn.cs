namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategoryImageandCategoryDesscriptionColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainCategories", "CategoryImage", c => c.Binary());
            AddColumn("dbo.MainCategories", "CategoryDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainCategories", "CategoryDescription");
            DropColumn("dbo.MainCategories", "CategoryImage");
        }
    }
}
