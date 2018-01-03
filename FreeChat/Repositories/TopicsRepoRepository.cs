using FreeChat.Contracts;
using FreeChat.Models;
using FreeChat.Models.Domain;
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

        public IEnumerable<Topics> GetActiveTopicsByGenre(string genre)
        {
            return _context.Topics.Where(x => x.Genre == genre);
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