using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class FavoritesDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List数据集</returns>
        public static List<Favorites> GetList(int pageindex, int pagesize, int userid)
        {
            List<Favorites> list = new List<Favorites>();
            string spName = "cudo_getfavoritelist";
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
                    Favorites item = new Favorites();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserId = userid;
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.ShopName = dataReader["shopname"].ToString();
                    item.ShopPic = dataReader["shoppic"].ToString();
                    item.Hit = Convert.ToInt32(dataReader["hit"]);
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
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int AddItem(Favorites item)
        {
            string spName = "cudo_createfavorite";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@shopid",item.ShopId)
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
            string spName = "cudo_deletefavorite";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount(int userid)
        {
            string spName = "cudo_getfavoritecountbyuid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName,paramvalues));
        }
    }
}
