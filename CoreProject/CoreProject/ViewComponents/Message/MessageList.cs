using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Message
{
    public class MessageList : ViewComponent
    {
        UserMessageManager userMessageManager = new UserMessageManager(new EfUserMessageDal());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = userMessageManager.GetUserMessagesWithUserService().TakeLast(6).ToList();
            ViewBag.msg = context.UserMessages.Count();

            return View(values);
        }
    }
}
