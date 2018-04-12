using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    public partial class ChangeAdminRoleColumn : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE dbo.AspNetUsers SET Role = 'Administrator' WHERE Email='Administrator@gmail.com'
              ");

            Sql(@"UPDATE dbo.AspNetUsers SET Role = 'RegisteredUsers' WHERE not  Email ='Administrator@gmail.com'
              ");
        }

        public override void Down()
        {
        }
    }
}
