using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using FreeChat.Core.Contracts.UOW;

namespace FreeChat.Persistence.UOW
{
   public  class GenericUnitOfWork:IGenericUnitOfWork
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
