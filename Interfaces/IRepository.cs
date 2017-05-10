using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        // gett all records in table
        //IQueryable<T> All { get; }
        IEnumerable<TEntity> All();

        Task<IEnumerable<TEntity>> AllAsync();

        //TODO: includes, filter, order

        //TODO: getPage


        /* we should not let sql expression building leak out of repo
         * repo should only output pure data
        bool Any(Expression<Func<TEntity, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);

        int Count(Expression<Func<TEntity, bool>> filter = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

        void Load();
        Task LoadAsync();
        */

        // get all records with filter
        //IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        //List<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Find(params object[] id);
        Task<TEntity> FindAsync(params object[] id);
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(params object[] id);
    }
}
