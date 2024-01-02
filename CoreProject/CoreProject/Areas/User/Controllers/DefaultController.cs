using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Kullanıcı Alanı";
            ViewBag.v2 = "Duyurular";

            var values = announcementManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id) 
        {
            var value = announcementManager.TGetById(id);

            ViewBag.v1 = "Duyurular";

            return View(value);
        }
    }
}
