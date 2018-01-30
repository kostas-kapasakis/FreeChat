namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyToTopicsTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "MainCategoryId", c => c.Long());

            Sql(@"UPDATE dbo.Topics SET MainCategoryId = 1
              where MainCategoryId IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "MainCategoryId");
        }
    }
}
