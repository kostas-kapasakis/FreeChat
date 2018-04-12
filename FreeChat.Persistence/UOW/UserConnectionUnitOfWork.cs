using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Persistence.Repositories;

namespace FreeChat.Persistence.UOW
{
    public class UserConnectionUnitOfWork : GenericUnitOfWork, IUserConnectionsUnitOfWork
    {
        public UserConnectionUnitOfWork(FreeChatContext context) : base(context)
        {
            UserConnection = new UserConnectionRepository(context);
        }
        public IUserConnectionRepository UserConnection { get; }
    }
}
