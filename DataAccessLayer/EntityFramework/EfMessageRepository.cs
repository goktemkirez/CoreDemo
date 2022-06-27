using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository:GenericRepository<RelationalMessage>, IMessageDal
    {

        List<RelationalMessage> IMessageDal.GetMessagesByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.RelationalMessages.Include(x => x.SenderUser)
                    .Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
