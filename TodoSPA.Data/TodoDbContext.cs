using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TodoSPA.Model;

namespace TodoSPA.Data
{
    public class TodoDbContext : DbContext
    {
        static TodoDbContext()
        {
            Database.SetInitializer(new SampleData());
        }

        public TodoDbContext() : base(nameOrConnectionString: "TodoSPA"){}

        public DbSet<Todo> Todos { get; set; }
    }
}
