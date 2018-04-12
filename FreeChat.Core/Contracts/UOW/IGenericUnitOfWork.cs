using System;

namespace FreeChat.Core.Contracts.UOW
{
    public interface IGenericUnitOfWork : IDisposable
    {
        int Complete();
    }

}
