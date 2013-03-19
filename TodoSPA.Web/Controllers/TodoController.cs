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
            return Uow.Todos.GetAll().OrderBy(t => t.CreatedOn);
        }

        // GET api/todo/5
        public Todo Get(int id)
        {           
            return Uow.Todos.GetById(id);
        }

        public HttpResponseMessage Post(Todo item)
        {
            Uow.Todos.Add(item);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, item);
            response.Headers.Location = new Uri(Url.Link(RouteConfig.ControllerAndId, new { id = item.Id}));

            return response;
        }


        // Updates a todo item
        public HttpResponseMessage Put(Todo item)
        {
            Uow.Todos.Update(item);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }        
    }
}
