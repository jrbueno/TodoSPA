using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace TodoSPA.Data
{
    public class EFRepo<T> : IRepo<T> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public EFRepo(DbContext dbcontext)
        {
            if (dbcontext == null)
                throw new ArgumentException("DbContext");
            DbContext = dbcontext;
            DbSet = DbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity);
        }
    }
}
