using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class RechargeorderDAL
    {
        private static List<Rechargeorder> GetList(string spName, SqlParameter[] paramvalues)
        {
            List<Rechargeorder> list = new List<Rechargeorder>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Rechargeorder item = new Rechargeorder();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.OrderNo = dataReader["orderno"].ToString();
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.OrderPrice = Convert.ToDecimal(dataReader["orderprice"]);
                    item.TradeNo = dataReader["tradeno"].ToString();
                    item.Payment = dataReader["payment"].ToString();
                    item.OrderStatus = Convert.ToInt32(dataReader["orderstatus"]);
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

        public static List<Rechargeorder> GetList(int pageindex, int pagesize)
        {
            List<Rechargeorder> list = new List<Rechargeorder>();
            string spName = "cudo_getrechargeorderlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@userid",0)
            };
            return GetList(spName, paramvalues);
        }

        public static List<Rechargeorder> GetList(int pageindex, int pagesize, int userid)
        {
            List<Rechargeorder> list = new List<Rechargeorder>();
            string spName = "cudo_getrechargeorderlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@userid",userid)
            };
            return GetList(spName, paramvalues);
        }

        public static Rechargeorder GetItem(string orderno)
        {
            Rechargeorder item = null;
            string spName = "cudo_getrechargeorderbyorderno";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new Rechargeorder();
                    item.OrderNo = dataReader["orderno"].ToString();
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.OrderPrice = Convert.ToDecimal(dataReader["orderprice"]);
                    item.TradeNo = dataReader["tradeno"].ToString();
                    item.Payment = dataReader["payment"].ToString();
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

        public static int AddItem(Rechargeorder item)
        {
            string spName = "cudo_createrechargeorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",item.OrderNo),
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@orderprice",item.OrderPrice),
                new SqlParameter("@tradeno",item.TradeNo),
                new SqlParameter("@payment",item.Payment)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int UpdateItem(string orderno, decimal price, string tradeno, decimal point, int userid)
        {
            string spName = "cudo_updaterechargeorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno),
                new SqlParameter("@price",price),
                new SqlParameter("@tradeno",tradeno),
                new SqlParameter("@point",point),
                new SqlParameter("@userid",userid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int DeleteItem(string orderno)
        {
            string spName = "cudo_deleterechargeorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@orderno",orderno)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int GetCount()
        {
            string spName = "cudo_getcountrechargeorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",0)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int GetCount(int userid)
        {
            string spName = "cudo_getcountrechargeorder";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
