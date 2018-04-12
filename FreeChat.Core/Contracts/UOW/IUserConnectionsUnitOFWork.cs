using FreeChat.Core.Contracts.Repositories;

namespace FreeChat.Core.Contracts.UOW
{
    public interface IUserConnectionsUnitOfWork:IGenericUnitOfWork
    {
        IUserConnectionRepository UserConnection { get; }
    }
}
