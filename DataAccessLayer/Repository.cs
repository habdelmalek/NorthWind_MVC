using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class

    {
        protected readonly DbContext Context;

        public Repository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return ((DbQuery<TEntity>)Context.Set<TEntity>().AsNoTracking<TEntity>()).AsExpandable();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var result = Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Find(predicate, null);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> selector)
        {
            if (predicate == null)
                predicate = x => true;

            IQueryable<TEntity> q;

            if (selector == null)
            {
                q = ((DbQuery<TEntity>)Context.Set<TEntity>().AsNoTracking<TEntity>()).Where(predicate);
            }
            else
            {
                q = ((DbQuery<TEntity>)Context.Set<TEntity>().AsNoTracking<TEntity>()).Where(predicate).Select(selector);
            }
            return q;
        }

        public void Remove(int id)
        {
            var entity = this.GetById(id);
            Context.Set<TEntity>().Remove(entity);
        }

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>().Where(predicate));
        }
    }
}