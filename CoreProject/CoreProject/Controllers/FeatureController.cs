using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Öne Çıkanlar";

            var value = featureManager.TGetById(1);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            ViewBag.v1 = "Öne Çıkanlar";
            ViewBag.v2 = "Öne Çıkanları Güncelle";

            featureManager.TUpdate(feature);

            return RedirectToAction("Index");
        }
    }
}
