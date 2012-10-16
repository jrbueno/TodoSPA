using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace TodoSPA.Data
{
    public interface IRepoProvider
    {
        DbContext DbContext { get; set; }
        IRepo<T> GetRepoForEntityType<T>() where T : class;
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
        void SetRepository<T>(T repository);
    }
}
