using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context(); 
            
            var userName = User.Identity?.Name;
            var userMail = c.Users.Where(x => x.UserName == userName)
                .Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
                .FirstOrDefault();

            ViewBag.BlogSayisi = c.Blogs.Count();
            ViewBag.YazarBlogSayisi = c.Blogs.Where(x => x.WriterID == writerID).Count();
            ViewBag.KategoriSayisi = c.Categories.Count();
            return View();
        }
    }
}
