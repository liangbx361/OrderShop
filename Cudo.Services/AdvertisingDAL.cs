using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class AdvertisingDAL
    {
        public static DataSet GetDataSetList(int classid)
        {
            string spName = "cudo_getadvertlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",classid)
            };
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static List<Advertising> GetAdvertList(int classid)
        {
            string spName = "cudo_getadvertlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",classid)
            };
            List<Advertising> list = new List<Advertising>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Advertising item = new Advertising();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.ClassId = Convert.ToInt32(dataReader["classid"]);
                    item.AdvertName = dataReader["advertname"].ToString();
                    item.AdvertPic = dataReader["advertpic"].ToString();
                    item.AdvertLink = dataReader["advertlink"].ToString();
                    item.SortId = Convert.ToInt32(dataReader["sortid"]);
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
        /// <returns>Advertising</returns>
        public static Advertising GetAdvertItem(int id)
        {
            Advertising item = null;
            string spName = "cudo_getadvertbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new Advertising();
                    item.Id = id;
                    item.ClassId = Convert.ToInt32(dataReader["classid"]);
                    item.AdvertName = dataReader["advertname"].ToString();
                    item.AdvertPic = dataReader["advertpic"].ToString();
                    item.AdvertLink = dataReader["advertlink"].ToString();
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
        /// <param name="item">Advertising</param>
        /// <returns></returns>
        public static int AddAdvert(Advertising item)
        {
            string spName = "cudo_createadvert";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",item.ClassId),
                new SqlParameter("@advertname",item.AdvertName),
                new SqlParameter("@advertpic",item.AdvertPic),
                new SqlParameter("@advertlink",item.AdvertLink),
                new SqlParameter("@sortid",item.SortId)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item">Advertising</param>
        /// <returns></returns>
        public static int UpdateAdvert(Advertising item)
        {
            string spName = "cudo_updateadvert";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",item.ClassId),
                new SqlParameter("@advertname",item.AdvertName),
                new SqlParameter("@advertpic",item.AdvertPic),
                new SqlParameter("@advertlink",item.AdvertLink),
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
        public static int DeleteAdvert(int id)
        {
            string spName = "cudo_deleteadvert";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
