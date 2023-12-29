using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class LastSkills : ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        Context context = new Context(); 

        public IViewComponentResult Invoke()
        {
            var values = skillManager.TGetList().TakeLast(9).ToList();
            ViewBag.skl = context.Skills.Count();

            return View(values);
        }
    }
}
