namespace FreeChat.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddRoomsLEftColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoomsLeft", c => c.Int(nullable: false, defaultValue: 10));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RoomsLeft");
        }
    }
}
