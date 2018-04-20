using FreeChat.Core.Contracts.UOW;
using System.Data.Entity;

namespace FreeChat.Persistence.UOW
{
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        private readonly DbContext _context;

        public GenericUnitOfWork(DbContext context)
        {
            _context = context;
        }

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
