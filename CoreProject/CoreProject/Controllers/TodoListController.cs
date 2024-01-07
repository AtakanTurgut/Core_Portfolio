using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TodoListController : Controller
    {
        TodoListManager todoListManager = new TodoListManager(new EFTodoListDal());

        public IActionResult DeleteTodoList(int id)
        {
            var value = todoListManager.TGetById(id);
            todoListManager.TDelete(value);

            return RedirectToAction("Index", "Dashboard");
        }

        // GET
        [HttpGet]
        public IActionResult CreateTodoList()
        {
            return RedirectToAction("Index", "Dashboard");
        }

        // POST
        [HttpPost]
        public IActionResult CreateTodoList([FromForm]TodoList todoList)
        {
            todoListManager.TAdd(todoList);

            return RedirectToAction("Index", "Dashboard");
        }

        // GET
        [HttpGet]
        public IActionResult EditTodoList(int id)
        {
            var value = todoListManager.TGetById(id);

            return RedirectToAction("Index", "Dashboard", value);
        }

        // POST
        [HttpPost]
        public IActionResult EditTodoList(TodoList todoList)
        {
            todoListManager.TUpdate(todoList);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
