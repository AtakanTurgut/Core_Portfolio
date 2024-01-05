using CoreProject.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ReUser> _signInManager;

        public LoginController(SignInManager<ReUser> signInManager)
        {
            _signInManager = signInManager;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Default", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
                }
            }

            return View();
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "User");
        }
    }
}
