using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();

        public IActionResult Inbox()
        {
            var userName = User.Identity?.Name;
            var userMail = c.Users.Where(x => x.UserName == userName)
                .Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity?.Name;
            var userMail = c.Users.Where(x => x.UserName == userName)
                .Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerID);
            return View(values);
        }

        public IActionResult ComposeMessage()
        {
            return View();
        }
    }
}
