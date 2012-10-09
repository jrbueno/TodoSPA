using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TodoSPA.Model;

namespace TodoSPA.Data
{
    public class SampleData : DropCreateDatabaseIfModelChanges<TodoDbContext>
    {
        protected override void Seed(TodoDbContext context)
        {
            var todos = new List<Todo>
            {
                new Todo { Title = "Test", Description = "Blah"},
                new Todo { Title = "Test2", Description = "Blah"},
                new Todo { Title = "Test3", Description = "Blah"}
            };
            todos.ForEach(t => context.Todos.Add(t));
            context.SaveChanges();
        }
    }
}
