using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.UOW
{
    public interface IRepositoryProvider
    {
        // get standard repository for type TEntity
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;

        // get custom repository, based on interface
        TReposity GetCustomRepository<TReposity>() where TReposity : class;
    }
}
