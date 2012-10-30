using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class MessageBLL
    {
        public List<MessageInfo> GetList(int pageindex, int pagesize)
        {
            return MessageDAL.GetList(pageindex, pagesize, 0);
        }

        public List<MessageInfo> GetList(int pageindex, int pagesize, int userid)
        {
            return MessageDAL.GetList(pageindex, pagesize, userid);
        }

        public MessageInfo GetItem(int id)
        {
            return MessageDAL.GetItem(id);
        }

        public int AddItem(MessageInfo item)
        {
            return MessageDAL.AddItem(item);
        }

        public int UpdateItem(int id)
        {
            return MessageDAL.UpdateItem(id);
        }

        public int DeleteItem(int id)
        {
            return MessageDAL.DeleteItem(id);
        }

        public int GetCount()
        {
            return MessageDAL.GetCount(0);
        }

        public int GetCount(int userid)
        {
            return MessageDAL.GetCount(userid);
        }
    }
}
