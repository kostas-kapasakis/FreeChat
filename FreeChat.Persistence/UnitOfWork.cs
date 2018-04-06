using FreeChat.Core.Contracts.Repositories;
using FreeChat.Persistence.Repositories;

namespace FreeChat.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly FreeChatContext _context;

        public UnitOfWork(FreeChatContext context)
        {
            _context = context;
            Topics = new TopicRepository(_context);
            UserConnection = new UserConnectionRepository(_context);
            User = new UserRepository(_context);

        }

        public ITopicRepository Topics { get; }
        public IUserConnectionRepository UserConnection { get; }
        public IUserRepository User { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
