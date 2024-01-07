using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımda";

            var value = aboutManager.TGetById(1);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult Index(About about)
        {
            ViewBag.v1 = "Hakkımda";
            ViewBag.v2 = "Hakkımda Düzenle";

            aboutManager.TUpdate(about);

            return RedirectToAction("Index");
        }
    }
}
