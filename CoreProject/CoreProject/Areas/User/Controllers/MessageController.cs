using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
