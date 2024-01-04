using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreProject.Areas.User.ViewComponents.Panel
{
    public class UserFeatureStatistics : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            // Statistics
            ViewBag.Message = 0;
            ViewBag.Anno = context.Announcements.Count();

            // Weather Api
            // https://openweathermap.org/api
            string api = "";        // id
            string connection = "";  // address --> &appid=" + api;
            //XDocument document = XDocument.Load(connection);
            //ViewBag.WA = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
