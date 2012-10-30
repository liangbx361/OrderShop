using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class RechargeorderBLL
    {
        public List<Rechargeorder> GetList(int pageindex, int pagesize)
        {
            return RechargeorderDAL.GetList(pageindex, pagesize);
        }

        public List<Rechargeorder> GetListByuid(int pageindex, int pagesize, int userid)
        {
            return RechargeorderDAL.GetList(pageindex, pagesize, userid);
        }

        public Rechargeorder GetItem(string orderno)
        {
            return RechargeorderDAL.GetItem(orderno);
        }

        public int AddItem(Rechargeorder item)
        {
            return RechargeorderDAL.AddItem(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderno">支付宝号</param>
        /// <param name="tradeno">交易号</param>
        /// <param name="point">积分</param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public int UpdateItem(string orderno, decimal price,string tradeno, decimal point, int userid)
        {
            return RechargeorderDAL.UpdateItem(orderno, price, tradeno, point, userid);
        }

        public int DeleteItem(string orderno)
        {
            return RechargeorderDAL.DeleteItem(orderno);
        }

        public int GetCount()
        {
            return RechargeorderDAL.GetCount();
        }

        public int GetCount(int userid)
        {
            return RechargeorderDAL.GetCount(userid);
        }
    }
}
