using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<RelationalMessage> GetList()
        {
            return _messageDal.GetListAll();
        }

        public List<RelationalMessage> GetInboxListByWriter(int id)
        {
            return _messageDal.GetMessagesByWriter(id);
        }

        public void TAdd(RelationalMessage t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(RelationalMessage t)
        {
            throw new NotImplementedException();
        }

        public RelationalMessage TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TUpdate(RelationalMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
