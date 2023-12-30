using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class TodoListPanel : ViewComponent
    {
        TodoListManager todoListManager = new TodoListManager(new EFTodoListDal());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = todoListManager.TGetList().TakeLast(7).ToList();
            ViewBag.td = context.TodoLists.Count();

            return View(values);
        }
    }
}
