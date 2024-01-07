using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Referanslar";

            var values = testimonialManager.TGetList();

            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = testimonialManager.TGetById(id);
            testimonialManager.TDelete(value);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referans Ekle";

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referans Ekle";

            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referans Güncelle";

            var values = testimonialManager.TGetById(id);

            return View(values);
        }

        // POST
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referans Güncelle";

            testimonialManager.TUpdate(testimonial);

            return RedirectToAction("Index");
        }
    }
}
