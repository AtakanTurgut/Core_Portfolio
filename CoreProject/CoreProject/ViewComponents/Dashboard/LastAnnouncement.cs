using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class LastAnnouncement : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = announcementManager.TGetList().TakeLast(5).ToList(); ;
            ViewBag.ann = context.Announcements.Count();

            return View(values);
        }

    }
}
