using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;
using System.Data;

namespace Cudo.Business
{
    public class OrdersBLL
    {
        /// <summary>
        /// 返回订单列表
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagesize">分页大小</param>
        /// <returns></returns>
        public List<OrderInfo> GetList(int pageindex, int pagesize)
        {
            return OrdersDAL.GetList(pageindex, pagesize);
        }

        /// <summary>
        /// 返回用户的订单列表
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public List<OrderInfo> GetListByUserId(int pageindex, int pagesize, int userid)
        {
            return OrdersDAL.GetListByUserId(pageindex, pagesize, userid);
        }

        /// <summary>
        /// 返回店铺的订单列表
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public List<OrderInfo> GetListByShopId(int pageindex, int pagesize, int shopid)
        {
            return OrdersDAL.GetListByShopId(pageindex, pagesize, shopid);
        }

        /// <summary>
        /// 统计每天订单
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataSet GetOrderReportListByShopId(int shopid, string starttime, string endtime)
        {
            return OrdersDAL.GetOrderReportListByShopId(shopid, starttime, endtime);
        }

        public OrderInfo GetOneUserOrder(int userid)
        {
            return OrdersDAL.GetOneUserOrder(userid);
        }

        public OrderInfo GetItem(string orderno)
        {
            return OrdersDAL.GetItem(orderno);
        }

        public int AddItem(OrderInfo item)
        {
            return OrdersDAL.AddItem(item);
        }

        public int UpdateItem(int orderstatus, int id)
        {
            return OrdersDAL.UpdateItem(orderstatus, id);
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public int DeleteItem(int id)
        {
            return OrdersDAL.DeleteItem(id);
        }

        /// <summary>
        /// 根据订单号删除
        /// </summary>
        /// <param name="orderno">订单号</param>
        /// <returns></returns>
        public int DeleteItem(string orderno)
        {
            return OrdersDAL.DeleteItem(orderno);
        }

        public int GetCount()
        {
            return OrdersDAL.GetCount();
        }

        /// <summary>
        /// 返回用户的订单总数
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public int GetCountByUserId(int userid)
        {
            return OrdersDAL.GetCountByUserId(userid);
        }

        public int GetCountByShopId(int shopid)
        {
            return OrdersDAL.GetCountByShopId(shopid);
        }
    }
}
