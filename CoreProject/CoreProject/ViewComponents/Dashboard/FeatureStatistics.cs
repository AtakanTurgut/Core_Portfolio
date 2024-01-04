using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.c1 = context.Messages.Where(m => m.Status == false).Count();
            //ViewBag.c2 = context.UserMessages.Count();
            ViewBag.c3 = context.Services.Count();
            ViewBag.c4 = context.Testimonials.Count();

            return View();
        }
    }
}
