using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Orçun"
                },
                new UserComment {
                    ID = 2,
                    Username = "Göktem"
                }
            };
            return View(commentValues);
        }
    }
}
