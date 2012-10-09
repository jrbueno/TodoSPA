using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoSPA.Model;

namespace TodoSPA.Data
{
    public interface ITodoUoW
    {
        void Commit();

        IRepo<Todo> Todos { get; }
    }
}
