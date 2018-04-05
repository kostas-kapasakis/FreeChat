using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using FreeChat.Core.Models.Domain;

namespace FreeChat.Persistence.Repositories
{
    public class TopicsRepoRepository : ITopicsRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsersService _usersService;

        public TopicsRepoRepository(ApplicationDbContext context, IUsersService usersService)
        {
            _context = context;
            _usersService = usersService;
        }

        public Topics GetTopicById(long Id)
        {
            return _context.Topics.Include(c => c.MainCategory).FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Topics> GetActiveTopics()
        {
            return _context.Topics.Include(c => c.MainCategory).Where(x => x.Active);
        }

        public IEnumerable<Topics> GetActiveTopicsByGenreId(long id)
        {
            return _context.Topics.Include(c => c.MainCategory).Where(x => x.MainCategoryId == id);
        }

        public bool AddTopic(Topics topic)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == topic.UserCreatorId);
            if (user == null || user.RoomsLeft == 0)
                return false;

            if (!_usersService.IsAdmin(user.Id))
                user.RoomsLeft--;

            _context.Users.Attach(user);
            _context.Entry(user).Property(x => x.RoomsLeft).IsModified = true;


            _context.Topics.Add(topic);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<MainCategories> GetMainCategories()
        {
            return _context.MainCategories.Where(x => x.Active);
        }

        public int DeleteTopicById(long Id)
        {
            var topic = _context.Topics.First(x => x.Id == Id);

            if (topic == null)
                return -1;

            _context.Entry(topic).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public IEnumerable<Topics> GetUserTopics(string id)
        {
            var topics = _context.Topics.Where(x => x.UserCreatorId == id).Where(x => x.Active);

            return topics;
        }

        public int RoomsRemainingForUser(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            return user?.RoomsLeft ?? 0;
        }

        public IEnumerable<Topics> GetTopicsFull()
        {
            return _context.Topics;
        }

        public bool ChangeTopicStatus(long id, bool status)
        {
            var topic = _context.Topics.FirstOrDefault(x => x.Id == id);
            if (topic == null)
                return false;

            if (!status)//topic is active so disable it and return current status
            {
                topic.Active = false;
                _context.SaveChanges();
                return false;
            }

            topic.Active = true;
            _context.SaveChanges();
            return true;

        }

 
    }
}