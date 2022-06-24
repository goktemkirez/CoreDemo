using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetLast3Blog();
        List<Blog> GetBlogsByID(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetListWithCategoryByWriterBm(int id);
        List<Blog> GetBlogListByWriter(int id);
    }
}
