namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplementatySeedignToMainCategTopics : DbMigration
    {
        public override void Up()
        {

            Sql(@"UPDATE dbo.Topics SET MainCategoryId = 1
              where Genre='Music'");
            Sql(@"UPDATE dbo.Topics SET MainCategoryId = 2
              where Genre='Sports'");
            Sql(@"UPDATE dbo.Topics SET MainCategoryId = 3
              where Genre='Trips'");
        }
        
        public override void Down()
        {
        }
    }
}
