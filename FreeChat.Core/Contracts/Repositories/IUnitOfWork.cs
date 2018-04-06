using System;
using System.Collections.Generic;
using System.Text;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        ITopicRepository Topics { get; }
        IUserConnectionRepository UserConnection { get; }
        IUserRepository User { get; }

        int Complete();
    }
}
