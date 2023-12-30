using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
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
    }
}
