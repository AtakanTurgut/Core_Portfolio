using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Feature
{
    public class SubFeatureList : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();

            return View(values);
        }
    }
}
