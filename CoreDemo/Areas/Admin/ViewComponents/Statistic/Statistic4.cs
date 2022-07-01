using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = c.Admins.Where(x => x.AdminID == 1)
                .Select(y => y.Name).FirstOrDefault();
            ViewBag.adminImage = c.Admins.Where(x => x.AdminID == 1)
                .Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.adminDescription = c.Admins.Where(x => x.AdminID == 1)
                .Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
