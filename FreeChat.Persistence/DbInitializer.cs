using FreeChat.Core.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FreeChat.Persistence
{
    internal sealed class DbInitializer<T> : DropCreateDatabaseAlways<FreeChatContext>
    {

        protected override void Seed(FreeChatContext context)
        {
            //create and add the users

            var passwordHasher = new PasswordHasher();

            var adminUser = new User
            {
                UserName = "administrator@gmail.com",
                Email = "admiinistrator@gmail.com",
                Active = true,
                RoomsLeft = 1000,
                Role = "Administrator"
            };

            var exampleUser = new User
            {
                UserName = "exampleuser@gmail.com",
                Email = "exampleuser@gmail.com",
                Active = true,
                RoomsLeft = 10,
                Role = "RegisteredUser"
            };

            adminUser.PasswordHash = passwordHasher.HashPassword("Admin!@3");
            adminUser.SecurityStamp = Guid.NewGuid().ToString();

            exampleUser.PasswordHash = passwordHasher.HashPassword("Example!@3");
            exampleUser.SecurityStamp = Guid.NewGuid().ToString();


            context.Users.AddOrUpdate(adminUser);
            context.Users.AddOrUpdate(exampleUser);

            //create and add the roles
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
                context.Roles.AddOrUpdate(role);
            }

            if (context.Users.SingleOrDefault(u => u.UserName == "administrator@gmail.com") != null)
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                manager.AddToRole(adminUser.Id, "Administrator");
            }


            if (!context.Roles.Any(r => r.Name == "RegisteredUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "RegisteredUser" };

                manager.Create(role);
                context.Roles.AddOrUpdate(role);
            }

            if (context.Users.SingleOrDefault(u => u.UserName == "exampleuser@gmail.com") != null)
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                manager.AddToRole(exampleUser.Id, "RegisteredUser");
            }

            //add seed data for main categories
            var mainCategories = new List<MainCategory>
            {
                new MainCategory
                {
                    Id = 1,
                    Name = "Music",
                    Active = true,
                    CategoryImage = "/Content/images/music.jpg",
                    CategoryDescription = "Talk about you favorite artists,albums,concerts and all upcoming and current music happenings."
                },
                new MainCategory
                {
                    Id = 2,
                    Name = "Sports",
                    Active = true,
                    CategoryImage = "/Content/images/sports.jpg",
                    CategoryDescription = "Sports nowadays is always part of the discussion.Important matches,championships,altercations transfers and many more.."
                },
                new MainCategory
                {
                    Id = 3,
                    Name = "Trips",
                    Active = true,
                    CategoryImage = "/Content/images/trips.jpg",
                    CategoryDescription = "Share,learn,discovere.Trips are more than amazing and necessary to be happy."
                },
            };
            mainCategories.ForEach(c => context.MainCategories.AddOrUpdate(c));


            //add seed dat for topics table

            var topics = new List<Topic>
            {
                new Topic
                {
                    Name = "Team Sports",Genre = "Sports",Active = true,DateCreated = new DateTime(DateTime.Now.Year,1,1),DateExpired = new DateTime(DateTime.Now.Year,1,15),Description="What are the benefits of the team sports versous the single sports",MaxClientsOnline = 50,
                    MainCategoryId = 2,UserCreatorId = adminUser.Id
                },
                new Topic
                {
                    Name = "Barcelona vs Real",Genre = "Sports",Active = true,DateCreated = new DateTime(DateTime.Now.Year,1,1),DateExpired = new DateTime(DateTime.Now.Year,1,15),Description="Is the El Classico the best match up in Football?",MaxClientsOnline = 50,
                    MainCategoryId = 2,UserCreatorId = adminUser.Id
                },
                new Topic
                {
                    Name = "Trip Hop",Genre = "Music",Active = true,DateCreated = new DateTime(DateTime.Now.Year,1,1),DateExpired = new DateTime(DateTime.Now.Year,1,15), Description ="Portishead,Archive,Tricky", MaxClientsOnline = 50,
                    MainCategoryId = 1,UserCreatorId = adminUser.Id
                },
                new Topic
                {
                    Name = "Traditional Music",Genre = "Music",Active = true,DateCreated = new DateTime(DateTime.Now.Year,1,1),DateExpired = new DateTime(DateTime.Now.Year,1,15),Description ="Is the traditional music of every country going to fade ? ",MaxClientsOnline = 50,
                    MainCategoryId = 1,UserCreatorId = adminUser.Id
                },
                new Topic
                {
                    Name = "European Countries",Genre = "Trips",Active = true,DateCreated = new DateTime(DateTime.Now.Year,1,1),DateExpired = new DateTime(DateTime.Now.Year,1,15),Description = "What is the best way to explore the culture of every european city ?",MaxClientsOnline = 50,
                    MainCategoryId = 3,UserCreatorId = adminUser.Id
                },
                new Topic
                {
                    Name = "Africa",Genre = "Trips",Active = true,DateCreated = new DateTime(DateTime.Now.Year,1,1),DateExpired = new DateTime(DateTime.Now.Year,1,15),Description = "Is it necessary to travel with groups in Africa ? ",MaxClientsOnline = 50,
                    MainCategoryId = 3,UserCreatorId = adminUser.Id
                },
            };

            topics.ForEach(s => context.Topics.AddOrUpdate(s));



            context.SaveChanges();
        }
    }
}
