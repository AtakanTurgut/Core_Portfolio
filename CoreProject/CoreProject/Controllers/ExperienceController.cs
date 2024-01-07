using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyimler";
            var values = experienceManager.TGetList();

            return View(values);
        }

        // GET
        [HttpGet]
        public IActionResult CreateExperience() 
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Ekle";

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Ekle";

            experienceManager.TAdd(experience);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = experienceManager.TGetById(id);
            experienceManager.TDelete(value);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Güncelle";

            var value = experienceManager.TGetById(id);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Güncelle";

            experienceManager.TUpdate(experience);

            return RedirectToAction("Index");
        }

    }
}
