using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class UserProfitDAL
    {
        public static DataSet GetDataSetList(int userid)
        {
            string spName = "cudo_getprofitlistbyuid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static List<UserProfit> GetList(int pageindex, int pagesize, int reguid)
        {
            List<UserProfit> list = new List<UserProfit>();
            string spName = "cudo_getprofitlistbyreguid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@reguid",reguid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    UserProfit item = new UserProfit();
                    item.id = Convert.ToInt32(dataReader["id"]);
                    item.UserName = dataReader["username"].ToString();
                    item.xftime = Convert.ToDateTime(dataReader["xftime"]);
                    item.xfpoint = Convert.ToDecimal(dataReader["xfpoint"]);
                    item.sypoint = Convert.ToDecimal(dataReader["sypoint"]);
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

        public static int AddItem(UserProfit item)
        {
            string spName = "cudo_createprofit";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",item.userid),
                new SqlParameter("@reguid",item.reguid),
                new SqlParameter("@xftime",item.xftime),
                new SqlParameter("@xfpoint",item.xfpoint),
                new SqlParameter("@sypoint",item.sypoint)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount(int reguid)
        {
            string spName = "cudo_getprofitcountbyreguid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@reguid",reguid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
