using FreeChat.Core.Contracts.Repositories;

namespace FreeChat.Core.Contracts.UOW
{
    public interface ITopicsUnitOfWork : IGenericUnitOfWork
    {
        ITopicRepository Topics { get; }

        IUserRepository User { get; }
    }
}
