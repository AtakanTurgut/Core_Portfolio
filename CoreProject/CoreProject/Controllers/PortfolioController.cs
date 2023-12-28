using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
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

            portfolioManager.TAdd(portfolio);

            return RedirectToAction("Index");
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

            portfolioManager.TUpdate(portfolio);

            return RedirectToAction("Index");
        }

    }
}
