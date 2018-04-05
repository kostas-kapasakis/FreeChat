using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
