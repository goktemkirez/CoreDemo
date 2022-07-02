using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string temperatureCity = "İstanbul";
            string apiKey = "647a4fab9e55da2d1041b2b1cd6ea317";
            string apiConnection = "https://api.openweathermap.org/data/2.5/weather?q=" + 
                temperatureCity + "&mode=xml&" +
                "lang=tr&units=metric&appid=" + apiKey;
            XDocument document = XDocument.Load(apiConnection);
            ViewBag.tempCity = temperatureCity;
            ViewBag.temp = document.Descendants("temperature").ElementAt(0)
                .Attributes("value").FirstOrDefault().Value;
            return View();
        }
    }
}
