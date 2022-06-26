using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.BlogSayisi = c.Blogs.Count();
            ViewBag.YazarBlogSayisi = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.KategoriSayisi = c.Categories.Count();
            return View();
        }
    }
}
