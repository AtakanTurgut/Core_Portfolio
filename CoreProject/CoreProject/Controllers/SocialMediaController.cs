using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Sosyal Medyalar";
            var values = socialMediaManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            ViewBag.v1 = "Sosyal Medyalar";
            ViewBag.v2 = "Sosyal Medya Ekle";

            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            ViewBag.v1 = "Sosyal Medyalar";
            ViewBag.v2 = "Sosyal Medya Ekle";

            socialMedia.Status = true;

            socialMediaManager.TAdd(socialMedia);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id) 
        {
            var values = socialMediaManager.TGetById(id);
            socialMediaManager.TDelete(values);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            ViewBag.v1 = "Sosyal Medyalar";
            ViewBag.v2 = "Sosyal Medya Güncelle";

            var values = socialMediaManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            ViewBag.v1 = "Sosyal Medyalar";
            ViewBag.v2 = "Sosyal Medya Güncelle";

            socialMediaManager.TUpdate(socialMedia);

            return RedirectToAction("Index");
        }

    }
}
