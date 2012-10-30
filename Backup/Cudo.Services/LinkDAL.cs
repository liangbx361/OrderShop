using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class LinkDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <returns>list</returns>
        public static List<Link> GetLinkList(int pageindex, int pagesize)
        {
            List<Link> list = new List<Link>();
            string spName = "cudo_getlinklist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Link item = new Link();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.LinkName = dataReader["linkname"].ToString();
                    item.LinkUrl = dataReader["linkurl"].ToString();
                    item.SortId = Convert.ToInt32(dataReader["sortid"]);
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
        /// <returns>Link</returns>
        public static Link GetLinkItem(int id)
        {
            Link item = null;
            string spName = "cudo_getlinkbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new Link();
                    item.Id = id;
                    item.LinkName = dataReader["linkname"].ToString();
                    item.LinkUrl = dataReader["linkurl"].ToString();
                    item.SortId = Convert.ToInt32(dataReader["sortid"]);
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
        /// <param name="item"></param>
        /// <returns></returns>
        public static int AddLink(Link item)
        {
            string spName = "cudo_createlink";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@linkname",item.LinkName),
                new SqlParameter("@linkurl",item.LinkUrl),
                new SqlParameter("@sortid",item.SortId)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateLink(Link item)
        {
            string spName = "cudo_updatelink";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@linkname",item.LinkName),
                new SqlParameter("@linkurl",item.LinkUrl),
                new SqlParameter("@sortid",item.SortId),
                new SqlParameter("@id",item.Id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static int DeleteLink(int id)
        {
            string spName = "cudo_deletelinkbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static object GetLinkCount()
        {
            string spName = "cudo_getlinkcount";
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName);
        }
    }
}
