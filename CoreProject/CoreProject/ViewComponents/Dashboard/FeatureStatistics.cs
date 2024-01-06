using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context context = new Context();
        private readonly UserManager<ReUser> _userManager;

        public FeatureStatistics(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.c1 = context.Messages.Where(m => m.Status == true).Count();
            ViewBag.c2 = context.GenericMessages.Where(m => m.Receiver == user.Email).Count();
            ViewBag.c3 = context.Services.Count();
            ViewBag.c4 = context.Testimonials.Count();

            return View();
        }
    }
}
