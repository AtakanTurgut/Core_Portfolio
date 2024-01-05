using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreProject.Areas.User.ViewComponents.Panel
{
    public class UserFeatureStatistics : ViewComponent
    {
        Context context = new Context();
        private readonly UserManager<ReUser> _userManager;

        public UserFeatureStatistics(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            // Statistics
            ViewBag.Message = context.GenericMessages.Where(u => u.Receiver == values.Email).Count();
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
