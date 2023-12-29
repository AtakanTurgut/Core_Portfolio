using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class LastExperiences : ViewComponent
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = experienceManager.TGetList().TakeLast(7).ToList(); ;
            ViewBag.exp = context.Experiences.Count();

            return View(values);
        }
    }
}
