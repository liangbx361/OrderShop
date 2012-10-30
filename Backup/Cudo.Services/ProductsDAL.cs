using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class ProductsDAL
    {
        private static List<Product> GetList(string spName, SqlParameter[] paramvalues)
        {
            List<Product> list = new List<Product>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Product item = new Product();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.TypeId = Convert.ToInt32(dataReader["typeid"]);
                    item.ProductName = dataReader["productname"].ToString();
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.ImgSrc = dataReader["imgsrc"].ToString();
                    item.Price = Convert.ToDecimal(dataReader["price"]);
                    item.Price2 = Convert.ToDecimal(dataReader["price2"]);
                    item.SortId = Convert.ToInt32(dataReader["sortid"]);
                    item.SellStatus = Convert.ToInt32(dataReader["sellstatus"]);
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

        public static List<Product> GetList(int pageindex, int pagesize)
        {
            string spName = "cudo_getproductlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetList(spName, paramvalues);
        }

        public static List<Product> GetList(int pageindex, int pagesize,int shopid)
        {
            string spName = "cudo_getproductlistbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@shopid",shopid)
            };
            return GetList(spName, paramvalues);
        }

        public static List<Product> GetListByTypeAndShop(int typeid, int shopid)
        {
            string spName = "cudo_getproductsbytypeidandshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@typeid",typeid),
                new SqlParameter("@shopid",shopid)
            };
            return GetList(spName, paramvalues);
        }

        public static Product GetItem(int id)
        {
            Product item = null;
            string spName = "cudo_getproductbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new Product();
                    item.Id = id;
                    item.TypeId = Convert.ToInt32(dataReader["typeid"]);
                    item.ProductName = dataReader["productname"].ToString();
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.ImgSrc = dataReader["imgsrc"].ToString();
                    item.Price = Convert.ToDecimal(dataReader["price"]);
                    item.Price2 = Convert.ToDecimal(dataReader["price2"]);
                    item.SortId = Convert.ToInt32(dataReader["sortid"]); ;
                    item.SellStatus = Convert.ToInt32(dataReader["sellstatus"]);
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

        public static int AddItem(Product item)
        {
            string spName = "cudo_createproduct";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@typeid",item.TypeId),
                new SqlParameter("@productname",item.ProductName),
                new SqlParameter("@shopid",item.ShopId),
                new SqlParameter("@imgsrc",item.ImgSrc),
                new SqlParameter("@price",item.Price),
                new SqlParameter("@price2",item.Price2),
                new SqlParameter("@sortid",item.SortId),
                new SqlParameter("@sellstatus",item.SellStatus)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateItem(Product item)
        {
            string spName = "cudo_updateproduct";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@typeid",item.TypeId),
                new SqlParameter("@productname",item.ProductName),
                new SqlParameter("@shopid",item.ShopId),
                new SqlParameter("@imgsrc",item.ImgSrc),
                new SqlParameter("@price",item.Price),
                new SqlParameter("@price2",item.Price2),
                new SqlParameter("@sortid",item.SortId),
                new SqlParameter("@sellstatus",item.SellStatus),
                new SqlParameter("@id",item.Id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deleteproductbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount()
        {
            string spName = "cudo_getproductscount";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public static int GetCount(int shopid)
        {
            string spName = "cudo_getproductscountbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int CheckProductName(int shopid, string proname)
        {
            string sql = "select top 1 id from [cudo_products] where productname=@proname and shopid=@shopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@proname",proname),
                new SqlParameter("@shopid",shopid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, paramvalues));
        }
    }
}
