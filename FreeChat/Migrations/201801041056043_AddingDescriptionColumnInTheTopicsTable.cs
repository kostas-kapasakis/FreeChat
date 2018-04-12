using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
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
