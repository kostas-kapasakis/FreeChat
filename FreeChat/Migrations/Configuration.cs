using FreeChat.Persistence;
using System.Data.Entity.Migrations;

namespace FreeChat.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FreeChatContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FreeChatContext context)
        {
            {
                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.

            }
        }
    }
}
