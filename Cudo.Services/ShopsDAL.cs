using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class ShopsDAL
    {
        private static List<Shop> GetList(string spName, SqlParameter[] paramvalues)
        {
            List<Shop> list = new List<Shop>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Shop item = new Shop();
                    item.ShopId = Convert.ToInt32(dataReader["id"]); ;
                    item.ShopType = Convert.ToInt32(dataReader["shoptype"]);
                    item.ShopName = dataReader["shopname"].ToString();
                    item.ShopPic = dataReader["shoppic"].ToString();
                    item.OpenTime = dataReader["opentime"].ToString();
                    item.Phone = dataReader["phone"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.LimitPrice = Convert.ToDecimal(dataReader["limitprice"]);
                    item.SendPrice = Convert.ToDecimal(dataReader["sendprice"]);
                    item.SendTime = Convert.ToInt32(dataReader["sendtime"]);
                    item.Payment = dataReader["payment"].ToString();
                    item.Hit = Convert.ToInt32(dataReader["hit"]);
                    item.SumPoint = Convert.ToInt32(dataReader["sumpoint"]);
                    item.SumTastePoint = Convert.ToInt32(dataReader["sumtastepoint"]);
                    item.SumMilieuPoint = Convert.ToInt32(dataReader["summilieupoint"]);
                    item.SumServicePoint = Convert.ToInt32(dataReader["sumservicepoint"]);
                    item.SumPerson = Convert.ToInt32(dataReader["sumperson"]);
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

        public static List<Shop> GetList(int pageindex, int pagesize)
        {
            string spName = "cudo_getshoplist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetList(spName, paramvalues);
        }

        public static DataSet GetListByAreaId(int areaid, string rowname)
        {
            string spName = "cudo_getshoplistbyareaid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@areaid",areaid),
                new SqlParameter("@rowname",rowname)
            };
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static DataSet GetListByAreaIdSort(int areaid, string sortType)
        {
            string spName = "cudo_getshoplistbyareaid_order";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@areaid",areaid),
                new SqlParameter("@order_rowname",sortType)
            };
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static DataSet GetListByKeyword(string keyword)
        {
            string spName = "cudo_getshoplistbykeyword";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@keyword","%"+keyword+"%")
            };
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static List<Shop> GetListBydid(int did)
        {
            List<Shop> list = new List<Shop>();
            string spName = "cudo_getshoplistbydid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@did",did)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Shop item = new Shop();
                    item.ShopId = Convert.ToInt32(dataReader["id"]);
                    item.ShopName = dataReader["shopname"].ToString();
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

        public static Shop GetShopItem(int shopid)
        {
            Shop item = null;
            string spName = "cudo_getshopbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",shopid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new Shop();
                    item.ShopId = shopid;
                    item.ShopType = Convert.ToInt32(dataReader["shoptype"]);
                    item.ShopName = dataReader["shopname"].ToString();
                    item.ShopPic = dataReader["shoppic"].ToString();
                    item.OpenTime = dataReader["opentime"].ToString();
                    item.OrderTime = dataReader["ordertime"].ToString();
                    item.Phone = dataReader["phone"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.LimitPrice = Convert.ToDecimal(dataReader["limitprice"]);
                    item.SendPrice = Convert.ToDecimal(dataReader["sendprice"]);
                    item.SendTime = Convert.ToInt32(dataReader["sendtime"]);
                    item.Payment = dataReader["payment"].ToString();
                    item.Intro = dataReader["intro"].ToString();
                    item.Hit = Convert.ToInt32(dataReader["hit"]);
                    item.SumPoint = Convert.ToInt32(dataReader["sumpoint"]);
                    item.SumTastePoint = Convert.ToInt32(dataReader["sumtastepoint"]);
                    item.SumMilieuPoint = Convert.ToInt32(dataReader["summilieupoint"]);
                    item.SumServicePoint = Convert.ToInt32(dataReader["sumservicepoint"]);
                    item.SumPerson = Convert.ToInt32(dataReader["sumperson"]);
                    item.zk = Convert.ToInt32(dataReader["zk"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
                    item.ShopOrder = OrdersDAL.GetCountByShopId(shopid);
                    item.ShopComment = ShopCommentDAL.GetCountByShopId(shopid, 0);
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

        public static int AddShop(Shop ShopItem)
        {
            string spName = "cudo_createshop";
            SqlParameter[] paramvalues = new SqlParameter[] 
            { 
               new SqlParameter("@shoptype",ShopItem.ShopType),
               new SqlParameter("@shopname",ShopItem.ShopName),
               new SqlParameter("@shoppic",ShopItem.ShopPic),
               new SqlParameter("@opentime",ShopItem.OpenTime),
               new SqlParameter("@ordertime",ShopItem.OrderTime),
               new SqlParameter("@phone",ShopItem.Phone),
               new SqlParameter("@address",ShopItem.Address),
               new SqlParameter("@limitprice",ShopItem.LimitPrice),
               new SqlParameter("@sendprice",ShopItem.SendPrice),
               new SqlParameter("@sendtime",ShopItem.SendTime),
               new SqlParameter("@payment",ShopItem.Payment),
               new SqlParameter("@intro",ShopItem.Intro),
               new SqlParameter("@zk",ShopItem.zk)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateShop(Shop ShopItem)
        {
            string spName = "cudo_updateshop";
            SqlParameter[] paramvalues = new SqlParameter[] 
            { 
               new SqlParameter("@shoptype",ShopItem.ShopType),
               new SqlParameter("@shopname",ShopItem.ShopName),
               new SqlParameter("@shoppic",ShopItem.ShopPic),
               new SqlParameter("@opentime",ShopItem.OpenTime),
               new SqlParameter("@ordertime",ShopItem.OrderTime),
               new SqlParameter("@phone",ShopItem.Phone),
               new SqlParameter("@address",ShopItem.Address),
               new SqlParameter("@limitprice",ShopItem.LimitPrice),
               new SqlParameter("@sendprice",ShopItem.SendPrice),
               new SqlParameter("@sendtime",ShopItem.SendTime),
               new SqlParameter("@payment",ShopItem.Payment),
               new SqlParameter("@intro",ShopItem.Intro),
               new SqlParameter("@zk",ShopItem.zk),
               new SqlParameter("@id",ShopItem.ShopId)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateShopHit(int shopid)
        {
            string spName = "cudo_updateshophitbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[] 
            { 
                new SqlParameter("@id",shopid)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int DeleteShop(int shopid)
        {
            string spName = "cudo_deleteshopbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",shopid)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount()
        {
            string spName = "cudo_getshopcount";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName));
        }
        
        public static int CheckShopByShopName(string shopname)
        {
            string spName = "cudo_checkshopbyname";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopname",shopname)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
