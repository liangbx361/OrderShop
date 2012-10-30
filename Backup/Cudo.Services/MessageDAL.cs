using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class MessageDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <returns>list</returns>
        public static List<MessageInfo> GetList(int pageindex, int pagesize, int userid)
        {
            List<MessageInfo> list = new List<MessageInfo>();
            string spName = "cudo_getmessagestlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@userid",userid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    MessageInfo item = new MessageInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.Title = dataReader["title"].ToString();
                    item.MsgContent = dataReader["msgcontent"].ToString();
                    item.Status = Convert.ToInt32(dataReader["islook"]);
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

        /// <summary>
        /// 根据ID获取Item
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>MessageInfo</returns>
        public static MessageInfo GetItem(int id)
        {
            MessageInfo item = null;
            string spName = "cudo_getmessagesbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new MessageInfo();
                    item.Id = id;
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.Title = dataReader["title"].ToString();
                    item.MsgContent = dataReader["msgcontent"].ToString();
                    item.Status = Convert.ToInt32(dataReader["islook"]);
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

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item">MessageInfo</param>
        /// <returns></returns>
        public static int AddItem(MessageInfo item)
        {
            string spName = "cudo_createmessages";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@title",item.Title),
                new SqlParameter("@msgcontent",item.MsgContent)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item">MessageInfo</param>
        /// <returns></returns>
        public static int UpdateItem(int id)
        {
            string spName = "cudo_updatemessages";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static int DeleteItem(int id)
        {
            string spName = "cudo_deletemessages";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount(int userid)
        {
            string spName = "cudo_getmessagescount";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
