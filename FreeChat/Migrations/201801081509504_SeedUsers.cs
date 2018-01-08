namespace FreeChat.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'397be1da-6498-44b3-84d6-2804a6f5827f', N'Administrator@gmail.com', 0, N'AHXD9hXOd30uIQw11LwcqftUdQjDvFsVT9GAzzIUkX8oVuneWnghSYKEpe3nXINSdw==', N'2d432dff-25ab-4c27-a6dd-7837bc929e87', NULL, 0, 0, NULL, 1, 0, N'Administrator@gmail.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0f4bb9a8-20c8-4c52-b034-14a82111f531', N'Administrator')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'397be1da-6498-44b3-84d6-2804a6f5827f', N'0f4bb9a8-20c8-4c52-b034-14a82111f531')");
        }

        public override void Down()
        {

        }
    }
}
