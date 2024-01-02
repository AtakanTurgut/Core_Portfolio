
using BusinessLayer.Concrete;
using CoreProject.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ReUser> _userManager;

        public RegisterController(UserManager<ReUser> userManager)
        {
            this._userManager = userManager;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            ReUser reUser = new ReUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Mail,
                UserName = model.UserName,
                ImageUrl = model.ImageUrl
            };

            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(reUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }            

            return View(model);
        }
    }
}
//123456Aa+