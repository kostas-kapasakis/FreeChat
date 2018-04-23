using FreeChat.Core.Models.Domain;
using FreeChat.Persistence;
using System;
using System.Collections.Generic;
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

                var adminUser = new User
                {
                    UserName = "admiinistrator@gmail.com",
                    Email = "admiinistrator@gmail.com",
                    Active = true,
                    RoomsLeft = 1000,
                    Role = "Administrator"
                };
                context.Users.AddOrUpdate(adminUser);


                var mainCategories = new List<MainCategory>
            {
                new MainCategory
                {
                    Name = "Music",
                    Active = true,
                    CategoryImage = "/Content/images/music.jpg",
                    CategoryDescription = "Talk about you favorite artists,albums,concerts and all upcoming and current music happenings."
                },
                new MainCategory
                {
                    Name = "Sports",
                    Active = true,
                    CategoryImage = "/Content/images/sports.jpg",
                    CategoryDescription = "Sports nowadays is always part of the discussion.Important matches,championships,altercations transfers and many more.."
                },
                new MainCategory
                {
                    Name = "Trips",
                    Active = true,
                    CategoryImage = "/Content/images/trips.jpg",
                    CategoryDescription = "Share,learn,discovere.Trips are more than amazing and necessary to be happy."
                },
            };
                mainCategories.ForEach(c => context.MainCategories.AddOrUpdate(c));

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
}
