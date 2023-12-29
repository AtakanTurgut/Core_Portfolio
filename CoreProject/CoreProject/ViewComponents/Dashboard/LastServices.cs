using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class LastServices : ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList().TakeLast(7).ToList(); ;
            ViewBag.srv = context.Services.Count();

            return View(values);
        }
    }
}
