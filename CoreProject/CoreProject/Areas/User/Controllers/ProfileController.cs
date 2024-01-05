using CoreProject.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<ReUser> _userManager;

        public ProfileController(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Profil";
            ViewBag.v2 = "Profili Düzenle";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel model = new UserEditViewModel();
            model.UserName = user.UserName;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;

            model.ImageUrl = user.ImageUrl;

            return View(model);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var ImageName = Guid.NewGuid()  + extension;
                var saveLocation = resource + "/wwwroot/userImage/" + ImageName;

                var stream = new FileStream(saveLocation, FileMode.Create);

                await model.Image.CopyToAsync(stream);

                user.ImageUrl = ImageName;
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            // Change Password
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

    }
}
