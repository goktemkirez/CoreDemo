using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        Context c = new Context();

        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userMail = User.Identity?.Name;
            ViewBag.v = userMail;
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName)
                .FirstOrDefault();
            ViewBag.writerName = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            //GTKM: SOLID ezildi, çalış
            //var userName = User.Identity?.Name;
            //var userMail = c.Users.Where(x => x.UserName == userName)
            //    .Select(y => y.Email).FirstOrDefault();
            //var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID)
            //    .FirstOrDefault();
            //var writerValues = wm.TGetById(writerID);
            //return View(writerValues);

            //var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            //var id = c.Users.Where(x => x.Email == userMail).Select(y => y.Id)
            //    .FirstOrDefault();
            //var values = userManager.TGetById(id);

            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Mail = values.Email;
            model.NameSurname = values.NameSurname;
            model.UserName = values.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            //p.WriterImage = "/CoreBlogTema/images/6.jpg";
            //p.WriterStatus = true;
            //WriterValidator wv = new WriterValidator();
            //ValidationResult result = wv.Validate(p);
            //if (result.IsValid)
            //{
            //    wm.TUpdate(p);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach(var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();

            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            values.NameSurname = model.NameSurname;
            values.Email = model.Mail;
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if(p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
