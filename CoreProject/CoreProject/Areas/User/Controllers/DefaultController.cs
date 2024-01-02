using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    public class DefaultController : Controller
    {
        [Area("User")]
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.v1 = "Kullanıcı Alanı";

            return View();
        }

    }
}
