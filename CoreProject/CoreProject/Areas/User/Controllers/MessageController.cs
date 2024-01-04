using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        GenericMessageManager genericMessageManager = new GenericMessageManager(new EfGenericMessageDal());
        private readonly UserManager<ReUser> _userManager;

        public MessageController(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        // GET
        public async Task<IActionResult> ReceiverMessage(string param)
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Gelen Mesajlar";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            param = values.Email;

            var messageList = genericMessageManager.GetListReceiverMessage(param);

            return View(messageList);
        }

        public async Task<IActionResult> SenderMessage(string param)
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Gönderilen Mesajlar";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            param = values.Email;

            var messageList = genericMessageManager.GetListSenderMessage(param);

            return View(messageList);
        }

        [HttpGet]
        public IActionResult ReceiverMessageDetails(int id)
        {
            var value = genericMessageManager.TGetById(id);

            ViewBag.v1 = "Mesaj";
            ViewBag.v2 = "Gelen Kutusu";

            return View(value);
        }

        [HttpGet]
        public IActionResult SenderMessageDetails(int id)
        {
            var value = genericMessageManager.TGetById(id);

            ViewBag.v1 = "Mesaj";
            ViewBag.v2 = "Gönderilen Kutusu";

            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            ViewBag.v1 = "Yeni Mesaj";
            ViewBag.v2 = "Yeni Mesaj Gönder";

            return View();
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> SendMessage(GenericMessage message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;

            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            message.SenderName = name;

            genericMessageManager.TAdd(message);

            return Redirect("/User/Message/SenderMessage");
        }

        // DELETE
        public IActionResult DeleteReceiverMessage(int id)
        {
            var value = genericMessageManager.TGetById(id);
            genericMessageManager.TDelete(value);

            return Redirect("/User/Message/ReceiverMessage");
        }

        public IActionResult DeleteSenderMessage(int id)
        {
            var value = genericMessageManager.TGetById(id);
            genericMessageManager.TDelete(value);

            return Redirect("/User/Message/SenderMessage");
        }

    }
}
