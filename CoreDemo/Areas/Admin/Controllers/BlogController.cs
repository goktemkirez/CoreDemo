using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        /// <summary>
        /// Static Excel Export Örneği
        /// </summary>
        public IActionResult ExportStaticExcelBlogList()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach(var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.ExcelBlogID;
                    workSheet.Cell(blogRowCount, 2).Value = item.ExcelBlogName;
                    blogRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bloglar1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>
            {
                new BlogModel{ExcelBlogID = 1, ExcelBlogName="Test"},
                new BlogModel{ExcelBlogID = 2, ExcelBlogName="Tesla araçları"},
                new BlogModel{ExcelBlogID = 3, ExcelBlogName="2022 olimpiyatları"}
            };
            return blogList;
        }

        /// <summary>
        /// Dinamik Excel Export Örneği
        /// </summary>
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.ExcelBlogID;
                    workSheet.Cell(blogRowCount, 2).Value = item.ExcelBlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bloglar1.xlsx");
                }
            }
        }
        public List<NewBlogModel> BlogTitleList()
        {
            List<NewBlogModel> blogModel = new List<NewBlogModel>();
            using (var c = new Context())
            {
                blogModel = c.Blogs.Select(x => new NewBlogModel
                {
                    ExcelBlogID = x.BlogID,
                    ExcelBlogName = x.BlogTitle
                }).ToList();
            }
            return blogModel;
        }

        /// <summary>
        /// View
        /// </summary>
        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
