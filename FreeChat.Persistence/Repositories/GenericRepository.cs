using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FreeChat.Core.Contracts.Repositories;

namespace FreeChat.Persistence.Repositories
{
    public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        public virtual TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual TEntity Get(long id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
