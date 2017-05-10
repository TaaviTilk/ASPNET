using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Interfaces.Repositories;

namespace Interfaces.UOW
{
    public interface IUOW
    {

        // standard IRepository based repos
        IRepository<Person> People { get; }
        IContactRepository Contacts { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        // get standard repository for type TEntity
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;

        TRepository GetCustomRepository<TRepository>() where TRepository : class;
    }
}
