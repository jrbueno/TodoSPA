using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoSPA.Data;
using TodoSPA.Model;

namespace TodoSPA.Web.Controllers
{
    public abstract class TodoBaseApiController : ApiController
    {
        protected ITodoUoW Uow { get; set; }
    }

    public class TodoController : TodoBaseApiController
    {
        public TodoController(ITodoUoW uow)
        {
            Uow = uow;
        }
        // GET api/todo
        public IEnumerable<Todo> Get()
        {
            Uow.Todos.Add(new Todo { Title= "Test", Description ="blah"});
            Uow.Commit();

            return Uow.Todos.GetAll();
        }

        // GET api/todo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/todo
        public void Post(string value)
        {
        }

        // PUT api/todo/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/todo/5
        public void Delete(int id)
        {
        }
    }
}
