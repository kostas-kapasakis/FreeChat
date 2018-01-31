namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overrideConventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Topics", "Description", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "Description", c => c.String());
            AlterColumn("dbo.Topics", "Name", c => c.String());
        }
    }
}
