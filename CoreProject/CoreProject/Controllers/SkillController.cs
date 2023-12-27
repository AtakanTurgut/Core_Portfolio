using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenekler";

            var values = skillManager.TGetList();

            return View(values);
        }

        // GET
        [HttpGet]
        public IActionResult CreateSkill() 
        {
            ViewBag.v1 = "Yetenekler";
            ViewBag.v2 = "Yetenek Ekleme";
  
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            ViewBag.v1 = "Yetenekler";
            ViewBag.v2 = "Yetenek Ekleme";

            skillManager.TAdd(skill);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = skillManager.TGetById(id);
            skillManager.TDelete(value);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Yetenekler";
            ViewBag.v2 = "Yetenek Güncelle";

            var value = skillManager.TGetById(id);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            ViewBag.v1 = "Yetenekler";
            ViewBag.v2 = "Yetenek Güncelle";

            skillManager.TUpdate(skill);

            return RedirectToAction("Index");
        }
    }
}
