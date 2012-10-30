using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class ShopAreaDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int AddItem(int shopid, int areaid, int streetid, int districtid)
        {
            string spName = "cudo_createshoparea";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid),
                new SqlParameter("@areaid",areaid),
                new SqlParameter("@sid",streetid),
                new SqlParameter("@did",districtid)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int CheckShopArea(int shopid, int districtid)
        {
            string spName = "cudo_checkshoparea";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid),
                new SqlParameter("@areaid",districtid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static int DeleteItem(int shopid, int areaid)
        {
            string spName = "cudo_deleteshoparea";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid),
                new SqlParameter("@areaid",areaid)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
