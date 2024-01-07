using BusinessLayer.Concrete;
using CoreProject.Areas.User.Models;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        GenericMessageManager genericMessageManager = new GenericMessageManager(new EfGenericMessageDal());
        private readonly UserManager<ReUser> _userManager;

        public AdminMessageController(UserManager<ReUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessageListAsync(string param)
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Gelen Mesajlar";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            param = values.Email;

            //ViewBag.ImageUrl = values.ImageUrl;

            var messageList = genericMessageManager.GetListReceiverMessage(param);

            return View(messageList);
        }

        public async Task<IActionResult> SenderMessageListAsync(string param)
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Gönderilen Mesajlar";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            param = values.Email;

            //ViewBag.ImageUrl = values.ImageUrl;

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

            Context context = new Context();
            var userNameSurname = context.Users
                .Where(u => u.Email == message.Receiver)
                .Select(u => u.Name + " " + u.Surname)
                .FirstOrDefault();

            message.ReceiverName = userNameSurname;

            genericMessageManager.TAdd(message);

            return RedirectToAction("SenderMessageList", "AdminMessage");
        }

        // DELETE
        public IActionResult DeleteReceiverMessage(int id)
        {
            var value = genericMessageManager.TGetById(id);
            genericMessageManager.TDelete(value);

            return RedirectToAction("SenderMessageList", "AdminMessage");
        }

        public IActionResult DeleteSenderMessage(int id)
        {
            var value = genericMessageManager.TGetById(id);
            genericMessageManager.TDelete(value);

            return RedirectToAction("SenderMessageList", "AdminMessage");
        }
    }
}
