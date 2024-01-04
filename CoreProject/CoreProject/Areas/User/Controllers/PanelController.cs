using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    [Area("User")]
    public class PanelController : Controller
    {
        private readonly UserManager<ReUser> _userManager;

        public PanelController(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Kullanıcı";
            ViewBag.v2 = "Panel";

            return View();
        }
    }
}
