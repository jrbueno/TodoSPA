using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace TodoSPA.Data
{
    public class RepoFactories
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repofactories;

        public RepoFactories()
        {
            _repofactories = GetRepoFactories();
        }

        public RepoFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repofactories = factories;
        }

        private IDictionary<Type, Func<DbContext, object>> GetRepoFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>();
        }

        public Func<DbContext, object> GetRepoFactory<T>()
        {
            Func<DbContext, object> factory;
            _repofactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        protected virtual Func<DbContext, object> DefaultEntityRepoFactory<T>() where T : class
        {
            return dbcontext => new EFRepo<T>(dbcontext);
        }

        public Func<DbContext, object> GetRepoFactoryByEntityType<T>() where T : class
        {
            return GetRepoFactory<T>() ?? DefaultEntityRepoFactory<T>();
        }
    }
}
