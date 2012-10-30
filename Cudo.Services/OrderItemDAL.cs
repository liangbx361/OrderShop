using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class OrderItemDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List数据集</returns>
        public static List<OrderItem> GetList(string orderno)
        {
            List<OrderItem> list = new List<OrderItem>();
            string spName = "cudo_getorderitemlistbyorderno";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName,paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    OrderItem item = new OrderItem();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.OrderNo = orderno;
                    item.ProductId = Convert.ToInt32(dataReader["productid"]);
                    item.ProductName = dataReader["productname"].ToString();
                    item.BuyNum = Convert.ToInt32(dataReader["buynum"]);
                    item.Price = Convert.ToDecimal(dataReader["price"]);
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

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int AddItem(OrderItem item)
        {
            string spName = "cudo_createorderitem";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",item.OrderNo),
                new SqlParameter("@productid",item.ProductId),
                new SqlParameter("@productname",item.ProductName),
                new SqlParameter("@buynum",item.BuyNum),
                new SqlParameter("@price",item.Price)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static int DeleteItem(int id)
        {
            string spName = "cudo_deleteorderitembyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount(string orderno)
        {
            string spName = "cudo_getorderitemcountbyorderno";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
