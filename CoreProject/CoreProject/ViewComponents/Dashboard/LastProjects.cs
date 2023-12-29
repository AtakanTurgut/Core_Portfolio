using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Dashboard
{
    public class LastProjects : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().TakeLast(6).ToList(); ;
            ViewBag.prj = context.Portfolios.Count();

            return View(values);
        }
    }
}
