using FreeChat.Models;
using FreeChat.Models.Domain;
using FreeChat.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FreeChat.Repositories
{
    public class TopicsRepoRepository : ITopicsRepo
    {
        private readonly ApplicationDbContext _context;

        public TopicsRepoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Topics GetTopicById(long Id)
        {
            return _context.Topics.First(x => x.Id == Id);
        }

        public IEnumerable<Topics> GetActiveTopics()
        {
            return _context.Topics.Where(x => x.Active);
        }

        public IEnumerable<Topics> GetActiveTopicsByGenreId(long id)
        {
            return _context.Topics.Where(x => x.Id == id);
        }

        public bool AddTopic(Topics topic)
        {

            _context.Topics.Add(topic);

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

    }
}