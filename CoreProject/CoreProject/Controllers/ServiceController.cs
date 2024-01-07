using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";

            var values = serviceManager.TGetList();

            return View(values);
        }

        // GET
        [HttpGet]
        public IActionResult CreateService()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmet Ekle";

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmet Ekle";

            serviceManager.TAdd(service);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.TGetById(id);
            serviceManager.TDelete(value);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmet Güncelle";

            var value = serviceManager.TGetById(id);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult EditService(Service Service)
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmet Güncelle";


            serviceManager.TUpdate(Service);

            return RedirectToAction("Index");
        }

    }
}
