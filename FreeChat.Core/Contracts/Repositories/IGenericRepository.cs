using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);

        TEntity Get(long id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
