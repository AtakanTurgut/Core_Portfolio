using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            ViewBag.v1 = "Yazar Alanı";

            return View();
        }

    }
}
