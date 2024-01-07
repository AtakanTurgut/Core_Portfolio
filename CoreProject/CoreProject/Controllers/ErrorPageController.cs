using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
  