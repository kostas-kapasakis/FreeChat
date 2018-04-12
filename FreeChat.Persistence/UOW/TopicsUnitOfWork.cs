using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Persistence.Repositories;

namespace FreeChat.Persistence.UOW
{
    public class TopicsUnitOfWork:GenericUnitOfWork,ITopicsUnitOfWork
    {
    
        public TopicsUnitOfWork(FreeChatContext context) : base(context)
        {
            Topics = new TopicRepository(context);
            User = new UserRepository(context);
        }

        public ITopicRepository Topics { get; }
        public IUserRepository User{ get; }
    }
}
