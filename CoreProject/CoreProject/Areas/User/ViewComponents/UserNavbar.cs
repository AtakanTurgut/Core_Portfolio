using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.ViewComponents
{
    public class UserNavbar : ViewComponent
    {
        private readonly UserManager<ReUser> _userManager;

        public UserNavbar(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.Name = values.Name;
            ViewBag.Surname = values.Surname;
            ViewBag.ImageUrl = values.ImageUrl;

            return View(); 
        }
    }
}
