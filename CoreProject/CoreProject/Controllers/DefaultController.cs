using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial() 
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult SendMessage() 
        {
            return Redirect("/Default/#contact");
        }

        [HttpPost]
        public ActionResult SendMessage(Message m)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());

            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.Status = true;

            messageManager.TAdd(m);

            return Redirect("/Default/#contact");
        }

    }
}
