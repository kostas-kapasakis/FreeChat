namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDescriptionColumnInTheTopicsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "Description");
        }
    }
}
