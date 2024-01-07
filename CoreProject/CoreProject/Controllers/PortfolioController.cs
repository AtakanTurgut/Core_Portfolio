using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Projeler";

            var values = portfolioManager.TGetList();

            return View(values);
        }

        // GET
        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            ViewBag.v1 = "Projeler";
            ViewBag.v2 = "Proje Ekle";

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            ViewBag.v1 = "Projeler";
            ViewBag.v2 = "Proje Ekle";

            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);

            if (results.IsValid)
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.TGetById(id);
            portfolioManager.TDelete(value);

            return RedirectToAction("Index");
        }

        // GET
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Projeler";
            ViewBag.v2 = "Proje Güncelle";

            var value = portfolioManager.TGetById(id);

            return View(value);
        }

        // POST
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            ViewBag.v1 = "Projeler";
            ViewBag.v2 = "Proje Güncelle";

            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);

            if(results.IsValid) 
            {
                portfolioManager.TUpdate(portfolio);

                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

    }
}
