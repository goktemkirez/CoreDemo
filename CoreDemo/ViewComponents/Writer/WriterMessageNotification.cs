using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            var values = mm.GetInboxListByWriter(1);
            return View(values);
        }
    }
}
