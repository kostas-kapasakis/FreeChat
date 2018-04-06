

using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Persistence.Repositories;

namespace FreeChat.Persistence.UOW
{
    public class UserUnitOfWork:GenericUnitOfWork,IUsersUnitOfWork
    {
        public UserUnitOfWork(FreeChatContext context):base (context)
        {
            User = new UserRepository(context);
        }
        public IUserRepository User { get; }

    }
}
