using CoreProject_Api.DAL.ApiContext;
using CoreProject_Api.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CoreProject_Api.Controllers
{
    [Route("api/todolist")]
    [ApiController]
    public class TodoListApiController : ControllerBase
    {
        Context context = new Context();

        // GET
        [HttpGet]
        public IActionResult GetTodoList()
        {
            return Ok(context.TodoLists.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTodoListById(int id)
        {
            var value = context.TodoLists.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        // POST
        [HttpPost]
        public IActionResult TodoAdd(TodoListApi todoList)
        {
            context.Add(todoList);
            context.SaveChanges();

            return Created("", todoList);
        }

        // DELETE
        [HttpDelete]
        public IActionResult TodoDelete(int id)
        {
            var value = context.TodoLists.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(value);
                context.SaveChanges();

                return NoContent();
            }
        }

        // UPDATE
        [HttpPut]
        public IActionResult TodoUpdate(TodoListApi todoList)
        {
            var value = context.Find<TodoListApi>(todoList.TodoId);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.Content = todoList.Content;
                value.Status = todoList.Status;

                context.Update(value);
                context.SaveChanges();

                return Ok(value);
            }
        }

    }
}
