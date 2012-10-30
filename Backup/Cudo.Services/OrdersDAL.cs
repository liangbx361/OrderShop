using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Services
{
    public class OrdersDAL
    {
        private static List<OrderInfo> GetList(string spName, SqlParameter[] paramvalues)
        {
            List<OrderInfo> list = new List<OrderInfo>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    OrderInfo item = new OrderInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.OrderNo = dataReader["orderno"].ToString();
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.ShopName = dataReader["shopname"].ToString();
                    item.TotalPrice = Convert.ToDecimal(dataReader["totalprice"]);
                    item.OrderPoint = Convert.ToDecimal(dataReader["orderpoint"]);
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.UserTel = dataReader["usertel"].ToString();
                    item.UserAddress = dataReader["useraddress"].ToString();
                    item.AreaId = Convert.ToInt32(dataReader["aid"]);
                    item.Remark = dataReader["remark"].ToString();
                    item.OrderStatus = Convert.ToInt32(dataReader["orderstatus"]);
                    item.PayStatus = Convert.ToInt32(dataReader["paystatus"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
                    list.Add(item);
                }
            }
            catch
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            finally
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            return list;
        }

        public static List<OrderInfo> GetList(int pageindex,int pagesize)
        {
            string spName = "cudo_getorderlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetList(spName, paramvalues);
        }

        public static List<OrderInfo> GetListByUserId(int pageindex, int pagesize,int userid)
        {
            List<OrderInfo> list = new List<OrderInfo>();
            string spName = "cudo_getorderlistbyuid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@userid",userid)
            };
            return GetList(spName, paramvalues);
        }

        public static List<OrderInfo> GetListByShopId(int pageindex, int pagesize, int shopid)
        {
            List<OrderInfo> list = new List<OrderInfo>();
            string spName = "cudo_getorderlistbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@shopid",shopid)
            };
            return GetList(spName, paramvalues);
        }

        public static DataSet GetOrderReportListByShopId(int shopid, string starttime, string endtime)
        {
            string spName = "cudo_orderreportlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid),
                new SqlParameter("@starttime",starttime),
                new SqlParameter("@endtime",endtime)
            };
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure,spName, paramvalues);
        }

        public static OrderInfo GetOneUserOrder(int userid)
        {
            OrderInfo item = null;
            string spName = "cudo_getoneuserorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new OrderInfo();
                    item.OrderNo = dataReader["orderno"].ToString();
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.TotalPrice = Convert.ToDecimal(dataReader["totalprice"]);
                    item.OrderPoint = Convert.ToDecimal(dataReader["orderpoint"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
                }
            }
            catch
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            finally
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            return item;
        }

        public static OrderInfo GetItem(string orderno)
        {
            OrderInfo item = null;
            string spName = "cudo_getorderbyorderno";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    item = new OrderInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.OrderNo = orderno;
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.TotalPrice = Convert.ToDecimal(dataReader["totalprice"]);
                    item.OrderPoint = Convert.ToDecimal(dataReader["orderpoint"]);
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.UserTel = dataReader["usertel"].ToString();
                    item.UserAddress = dataReader["useraddress"].ToString();
                    item.AreaId = Convert.ToInt32(dataReader["aid"]);
                    item.Remark = dataReader["remark"].ToString();
                    item.OrderStatus = Convert.ToInt32(dataReader["orderstatus"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
                }
            }
            catch
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            finally
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            return item;
        }

        public static int AddItem(OrderInfo item)
        {
            string spName = "cudo_createorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",item.OrderNo),
                new SqlParameter("@shopid",item.ShopId),
                new SqlParameter("@totalprice",item.TotalPrice),
                new SqlParameter("@orderpoint",item.OrderPoint),
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@usertel",item.UserTel),
                new SqlParameter("@useraddress",item.UserAddress),
                new SqlParameter("@aid",item.AreaId),
                new SqlParameter("@remark",item.Remark),
                new SqlParameter("@addtime",item.AddTime)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateItem(int orderstatus, int id)
        {
            string spName = "cudo_updateorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderstatus",orderstatus),
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deleteorderbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 根据订单号删除
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static int DeleteItem(string orderno)
        {
            string spName = "cudo_deleteorderbyorderno";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount()
        {
            string spName = "cudo_getordercount";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public static int GetCountByUserId(int userid)
        {
            string spName = "cudo_getordercountbyuid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName,paramvalues));
        }

        public static int GetCountByShopId(int shopid)
        {
            string spName = "cudo_getordercountbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
