using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class CooperationBLL
    {
        public List<Cooperation> GetList(int pageindex, int pagesize)
        {
            return CooperationDAL.GetList(pageindex, pagesize);
        }

        public int AddItem(Cooperation item)
        {
            return CooperationDAL.AddItem(item);
        }

        public int DeleteItem(int id)
        {
            return CooperationDAL.DeleteItem(id);
        }

        public int GetCount()
        {
            return CooperationDAL.GetCount();
        }
    }
}
