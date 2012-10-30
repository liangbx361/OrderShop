using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class OrderItemBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderno">订单号</param>
        /// <returns></returns>
        public List<OrderItem> GetList(string orderno)
        {
            return OrderItemDAL.GetList(orderno);
        }

        public int AddItem(OrderItem item)
        {
            return OrderItemDAL.AddItem(item);
        }

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public int DeleteItem(int id)
        {
            return OrderItemDAL.DeleteItem(id);
        }

        public int GetCount(string orderno)
        {
            return OrderItemDAL.GetCount(orderno);
        }
    }
}
