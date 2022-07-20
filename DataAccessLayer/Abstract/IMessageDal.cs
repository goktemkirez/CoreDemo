﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<RelationalMessage>
    {
        List<RelationalMessage> GetMessagesByWriter(int id);
        List<RelationalMessage> GetSendBoxByWriter(int id);
    }
}
