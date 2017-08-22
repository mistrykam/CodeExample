using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public interface IRepository<TKey, TEntity> where TEntity : class
    {
        // Get Entity
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // Add Entity
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Remove Entity
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
    }

    public interface IUnitOfWork
    {
        void Commit();
    }
}
