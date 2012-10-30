using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class FeedBackBLL
    {
        public List<FeedBack> GetList(int pageindex, int pagesize)
        {
            return FeedBackDAL.GetList(pageindex, pagesize);
        }

        public int AddItem(FeedBack item)
        {
            return FeedBackDAL.AddItem(item);
        }

        public int DeleteItem(int id)
        {
            return FeedBackDAL.DeleteItem(id);
        }

        public int GetCount()
        {
            return FeedBackDAL.GetCount();
        }
    }
}
