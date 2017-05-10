using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.MsSql.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        // the context and the dbset we are working with
        protected DbContext RepositoryDbContext { get; set; }
        protected DbSet<TEntity> RepositoryDbSet { get; set; }

        //Constructor, requires dbContext as dependency
        public EFRepository(IDataContext dataContext)
        {
            RepositoryDbContext = dataContext as DbContext ?? throw new ArgumentNullException(paramName: nameof(dataContext));
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>() ?? throw new NullReferenceException(message: $"DbSet for {nameof(TEntity)} not found!");
        }


        public IEnumerable<TEntity> All() => RepositoryDbSet.ToList();

        // TODO: should await in controller?!
        public async Task<IEnumerable<TEntity>> AllAsync() => await RepositoryDbSet.ToListAsync();

        public TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(keyValues: id);
        }

        public Task<TEntity> FindAsync(params object[] id)
        {
            return RepositoryDbSet.FindAsync(keyValues: id);
        }
        public async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await RepositoryDbSet.FindAsync(keyValues: keyValues, cancellationToken: cancellationToken);
        }

        public void Add(TEntity entity)
        {
            if (entity == null) throw new InvalidOperationException(message: "Unable to add a null entity to the repository.");
            RepositoryDbSet.Add(entity: entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null) throw new InvalidOperationException(message: "Unable to add a null entity to the repository.");
            await RepositoryDbSet.AddAsync(entity: entity);
        }

        public TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity: entity).Entity;
        }

        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Attach(entity: entity);
            RepositoryDbContext.Entry(entity: entity).State = EntityState.Deleted;
            RepositoryDbSet.Remove(entity: entity);
        }

        public void Remove(params object[] id)
        {
            Remove(entity: Find(id: id));
        }


        /*
        public void Load()
        {
            DataSet.Load();
        }

        public async Task LoadAsync()
        {
            await DataSet.LoadAsync();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DataSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Any();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DataSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AnyAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DataSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DataSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.CountAsync();
        }

        public IQueryable<TEntity> QueryDataSet(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IQueryable<TEntity> query = DataSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
        */
    }
}
