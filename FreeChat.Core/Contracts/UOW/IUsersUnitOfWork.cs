using FreeChat.Core.Contracts.Repositories;

namespace FreeChat.Core.Contracts.UOW
{
    public interface IUsersUnitOfWork : IGenericUnitOfWork
    {
        IUserRepository User { get; }
    }
}
