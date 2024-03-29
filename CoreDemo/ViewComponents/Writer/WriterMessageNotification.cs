﻿using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity?.Name;
            var userMail = c.Users.Where(x => x.UserName == userName)
                .Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }
    }
}
