using FreeChat.Core.Contracts.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using FreeChat.Core.Models.Domain;

namespace FreeChat.Persistence.Repositories
{
    public class TopicRepository : GenericRepository<Topics>,ITopicRepository
    {

        public TopicRepository(FreeChatContext context)
            : base(context)
        {
        }

        public override Topics Get(long id)
        {
            return FreeChatContext.Topics.Include(c => c.MainCategory).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Topics> GetActiveTopics()
        {
            return FreeChatContext.Topics.Include(c => c.MainCategory).Where(x => x.Active);
        }

        public IEnumerable<Topics> GetActiveTopicsByGenreId(long id)
        {
            return FreeChatContext.Topics.Include(c => c.MainCategory).Where(x => x.MainCategoryId == id);
        }

        public override void Add(Topics entity)
        {
            var user = FreeChatContext.Users.SingleOrDefault(x => x.Id == entity.UserCreatorId);
            if (user.RoomsLeft == 0)
                return;

            /*if (!_usersService.IsAdmin(user.Id))
                user.RoomsLeft--;*/

            FreeChatContext.Users.Attach(user);
            FreeChatContext.Entry(user).Property(x => x.RoomsLeft).IsModified = true;


            FreeChatContext.Topics.Add(entity);
            FreeChatContext.SaveChanges();
        }

        public bool AddTopic(Topics topic, bool isAdmin)
        {
            var user = FreeChatContext.Users.SingleOrDefault(x => x.Id == topic.UserCreatorId);
            if (user == null || user.RoomsLeft == 0)
                return false;

            if (!isAdmin)
                user.RoomsLeft--;

            FreeChatContext.Users.Attach(user);
            FreeChatContext.Entry(user).Property(x => x.RoomsLeft).IsModified = true;


            FreeChatContext.Topics.Add(topic);
            FreeChatContext.SaveChanges();

            return true;
        }

        public IEnumerable<MainCategories> GetMainCategories()
        {
            return FreeChatContext.MainCategories.Where(x => x.Active);
        }

     
        public int DeleteTopicById(long id)
        {
            var topic = FreeChatContext.Topics.First(x => x.Id == id);

            if (topic == null)
                return -1;

            FreeChatContext.Entry(topic).State = EntityState.Deleted;
            return FreeChatContext.SaveChanges();
        }

        public IEnumerable<Topics> GetUserTopics(string id)
        {
            var topics = FreeChatContext.Topics.Where(x => x.UserCreatorId == id).Where(x => x.Active);

            return topics;
        }

        public int RoomsRemainingForUser(string userId)
        {
            var user = FreeChatContext.Users.FirstOrDefault(u => u.Id == userId);

            return user?.RoomsLeft ?? 0;
        }

        public bool ChangeTopicStatus(long id, bool status)
        {
            var topic = FreeChatContext.Topics.FirstOrDefault(x => x.Id == id);
            if (topic == null)
                return false;

            if (!status)//topic is active so disable it and return current status
            {
                topic.Active = false;
                FreeChatContext.SaveChanges();
                return false;
            }

            topic.Active = true;
            FreeChatContext.SaveChanges();
            return true;

        }

        public FreeChatContext FreeChatContext => Context as FreeChatContext;
    }
}