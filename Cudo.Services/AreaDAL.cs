using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class AreaDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List数据集</returns>
        private static List<Area> GetList(string spName, SqlParameter[] paramvalues)
        {
            List<Area> list = new List<Area>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    Area item = new Area();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.AreaName = dataReader["areaname"].ToString();
                    item.Pid = Convert.ToInt32(dataReader["parentid"]);
                    item.AreaKey = dataReader["areakey"].ToString().Trim();
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

        public static List<Area> GetList()
        {
            string spName = "cudo_getarealist";
            return GetList(spName, null);
        }

        /// <summary>
        /// 根据pid获取列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static List<Area> GetList(int pid)
        {
            string spName = "cudo_getarealistbypid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pid",pid)
            };
            return GetList(spName, paramvalues);
        }

        public static List<Area> GetList(string idlist)
        {
            string spName = "cudo_getarealistbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@idlist",idlist)
            };
            return GetList(spName, paramvalues);
        }

        public static List<Area> GetListByShopId(int shopid)
        {
            string spName = "cudo_getarealistbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid)
            };
            return GetList(spName, paramvalues);
        }

        /// <summary>
        /// 根据ID获取Item
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static Area GetItem(int id)
        {
            Area item = null;
            string spName = "cudo_getareabyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new Area();
                    item.Id = id;
                    item.AreaName = dataReader["areaname"].ToString();
                    item.Pid = Convert.ToInt32(dataReader["parentid"]);
                    item.AreaKey = dataReader["areakey"].ToString();
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
        public static int AddItem(Area item)
        {
            string spName = "cudo_createarea";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@areaname",item.AreaName),
                new SqlParameter("@parentid",item.Pid),
                new SqlParameter("@areakey",item.AreaKey)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateItem(Area item)
        {
            string spName = "cudo_updatearea";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@areaname",item.AreaName),
                new SqlParameter("@parentid",item.Pid),
                new SqlParameter("@areakey",item.AreaKey),
                new SqlParameter("@id",item.Id)
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
            string spName = "cudo_deletearea";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int CheckAreaName(string areaname)
        {
            string spName = "cudo_checkareaname";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@areaname",areaname)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
