using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.UOW
{
    public interface IRepositoryFactory
    {
        // return custom repo factory, if not found - fallback to standard factory
        Func<IDataContext, object> GetRepositoryFactoryForType<T>() where T : class;

        // create custom repo factory, based on interface
        Func<IDataContext, object> GetCustomRepositoryFactory<T>() where T : class;

        // create standard repo factory, based on entity
        Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class;

    }
}
