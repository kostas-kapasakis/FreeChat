namespace FreeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDomainModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectedUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        ApplicationUserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId_Id)
                .Index(t => t.ApplicationUserId_Id);
            
            CreateTable(
                "dbo.UserConnections",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConnectionId = c.Long(nullable: false),
                        Username = c.String(),
                        ConnectedUsers_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConnectedUsers", t => t.ConnectedUsers_Id)
                .Index(t => t.ConnectedUsers_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateExpired = c.DateTime(nullable: false),
                        MaxClientsOnline = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserConnections", "ConnectedUsers_Id", "dbo.ConnectedUsers");
            DropForeignKey("dbo.ConnectedUsers", "ApplicationUserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserConnections", new[] { "ConnectedUsers_Id" });
            DropIndex("dbo.ConnectedUsers", new[] { "ApplicationUserId_Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.UserConnections");
            DropTable("dbo.ConnectedUsers");
        }
    }
}
