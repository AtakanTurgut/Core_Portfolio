using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class AnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());   

        public IActionResult Index()
        {
            ViewBag.v1 = "Duyurular";
            var values = announcementManager.TGetList();

            return View(values);
        }

        // GET
        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            ViewBag.v1 = "Duyurular";
            ViewBag.v2 = "Duyuru Ekle";

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreateAnnouncement(Announcement announcement)
        {
            ViewBag.v1 = "Duyurular";
            ViewBag.v2 = "Duyuru Ekle";

            announcement.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            announcementManager.TAdd(announcement);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = announcementManager.TGetById(id);
            announcementManager.TDelete(value);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            ViewBag.v1 = "Duyurular";
            ViewBag.v2 = "Duyuru Güncelle";

            var value = announcementManager.TGetById(id);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            ViewBag.v1 = "Duyurular";
            ViewBag.v2 = "Duyuru Güncelle";

            announcement.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            announcementManager.TUpdate(announcement);

            return RedirectToAction("Index");
        }

    }
}
