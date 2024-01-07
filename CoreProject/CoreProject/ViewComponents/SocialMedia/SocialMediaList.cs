using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IViewComponentResult Invoke()
        {
            var values = socialMediaManager.TGetList();

            return View(values);
        }
    }
}
