namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedtheUserCreatorColumn : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE dbo.Topics SET UserCreatorId = '397be1da-6498-44b3-84d6-2804a6f5827f'
              ");
        }
        
        public override void Down()
        {
        }
    }
}
