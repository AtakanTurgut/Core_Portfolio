using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Dashboard";

            return View();
        }
    }
}
