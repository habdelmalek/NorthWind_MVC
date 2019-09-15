using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        IQueryable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> selector);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(int id);

        void Remove(Expression<Func<TEntity, bool>> predicate);
    }
}
