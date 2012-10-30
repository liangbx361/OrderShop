using System;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class SystemLogDAL
    {
        /// <summary>
        /// 添加日记
        /// </summary>
        /// <param name="LogItem"></param>
        /// <returns></returns>
        public static int AddLog(SystemLog LogItem)
        {
            string spName = "cudo_createlog";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@UserName",LogItem.UserName),
                new SqlParameter("@IpAddress",LogItem.IpAddress),
                new SqlParameter("@LogInfo",LogItem.LogInfo)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, param);
        }

        /// <summary>
        /// 删除日记
        /// </summary>
        /// <param name="LogID">ID</param>
        /// <returns>受影响行数</returns>
        public static int DeleteLog(object LogID)
        {
            string spName = "cudo_deletelog";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@logid",LogID),
                new SqlParameter("@ListID","")
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, param);
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public static void ClearLog()
        {
            string spName = "cudo_deletelog";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@logid",0),
                new SqlParameter("@ListID","")
            };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName,param);
        }

        /// <summary>
        /// 根据ID集合删除日记
        /// </summary>
        /// <param name="ListID">ID集合</param>
        /// <returns>受影响行数</returns>
        public static int DeleteLogByIdList(string ListID)
        {
            string spName = "cudo_deletelog";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@logid",0),
                new SqlParameter("@ListID",ListID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, param);
        }
    }
}
