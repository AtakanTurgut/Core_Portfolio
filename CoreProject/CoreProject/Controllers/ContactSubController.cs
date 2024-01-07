using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim Bilgileri";

            var value = contactManager.TGetById(1);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            ViewBag.v1 = "İletişim Bilgileri";
            ViewBag.v2 = "İletişim Bilgileri Düzenle";

            contactManager.TUpdate(contact);

            return RedirectToAction("Index");
        }
    }
}
