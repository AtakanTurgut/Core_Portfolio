using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.ViewComponents.Panel
{
    public class UserProfileCard : ViewComponent
    {
        private readonly UserManager<ReUser> _userManager;

        public UserProfileCard(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.ImageUrl = values.ImageUrl;
            ViewBag.Name = values.Name;
            ViewBag.Surname = values.Surname;
            ViewBag.UserName = values.UserName;
            ViewBag.Email = values.Email;

            return View();
        }
    }
}
