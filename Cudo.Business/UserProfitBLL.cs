using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class UserProfitBLL
    {
        public DataSet GetDataSetList(int userid)
        {
            return UserProfitDAL.GetDataSetList(userid);
        }

        public List<UserProfit> GetList(int pageindex, int pagesize, int reguid)
        {
            return UserProfitDAL.GetList(pageindex, pagesize, reguid);
        }

        public int AddItem(UserProfit item)
        {
            return UserProfitDAL.AddItem(item);
        }

        public int GetCount(int reguid)
        {
            return UserProfitDAL.GetCount(reguid);
        }
    }
}
