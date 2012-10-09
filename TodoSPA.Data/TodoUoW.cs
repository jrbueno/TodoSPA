using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TodoSPA.Model;

namespace TodoSPA.Data
{
    public class TodoUoW : ITodoUoW, IDisposable
    {
        private DbContext DbContext { get; set; }
        protected IRepoProvider RepoProvider { get; set; }

        public TodoUoW(IRepoProvider provider)
        {
            DbContext = new TodoDbContext();
            provider.DbContext = DbContext;
            RepoProvider = provider;
        }
        
        public IRepo<Todo> Todos
        {
            get { return RepoProvider.GetRepoForEntityType<Todo>(); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
    }
}
