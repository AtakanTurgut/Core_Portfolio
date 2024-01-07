using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Mesajlar";

            var values = messageManager.TGetList();

            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = messageManager.TGetById(id);
            messageManager.TDelete(value);

            return RedirectToAction("Index");
        }

        public IActionResult MessageDetails(int id)
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Mesaj Detayları";

            var values = messageManager.TGetById(id);

            return View(values);
        }
    }
}
