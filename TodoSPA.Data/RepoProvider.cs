using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace TodoSPA.Data
{
    public class RepoProvider : IRepoProvider
    {
        private RepoFactories _repoFactories;
        protected Dictionary<Type, object> Repositories { get; private set; }

        public RepoProvider(RepoFactories factory)
        {
            _repoFactories = factory;
            Repositories = new Dictionary<Type, object>();
        }


        public DbContext DbContext { get; set; }

        public IRepo<T> GetRepoForEntityType<T>() where T : class
        {
            return GetRepository<IRepo<T>>(_repoFactories.GetRepoFactoryByEntityType<T>());
        }

        public T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            object repo;
            Repositories.TryGetValue(typeof(T), out repo);
            if (repo != null)
            {
                return (T)repo;
            }
            return MakeRepo<T>(factory, DbContext);
        }

        protected T MakeRepo<T>(Func<DbContext, object> factory, DbContext DbContext)
        {
            var f = factory ?? _repoFactories.GetRepoFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No Factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(DbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }
    }
}
