using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Cudo.Entities;

namespace Cudo.Services
{
    public class MenuDAL
    {
        public static DataSet GetMenusBySql(string sql)
        {
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        private static List<MenuInfo> GetMenuList(string spName, SqlParameter[] paramvalues)
        {
            List<MenuInfo> list = new List<MenuInfo>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    MenuInfo item = new MenuInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.MenuName = dataReader["menuname"].ToString();
                    item.ParentId = Convert.ToInt32(dataReader["parentid"]);
                    item.UrlLink = dataReader["urllink"].ToString();
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

        public static List<MenuInfo> GetMenuList(int parentId, int pageindex, int pagesize)
        {
            string spName = "cudo_getmenusbypid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@parentid",parentId),
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetMenuList(spName, paramvalues);
        }

        public static List<MenuInfo> GetMenuList(int pageindex, int pagesize)
        {
            List<MenuInfo> list = new List<MenuInfo>();
            string spName = "cudo_getmenulist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetMenuList(spName, paramvalues);
        }

        public static MenuInfo GetMenuByMenuID(int MenuID)
        {
            string spName = "cudo_getmenubyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",MenuID)
            };
            MenuInfo item = new MenuInfo();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item.Id = MenuID;
                    item.MenuName = dataReader["menuname"].ToString();
                    item.ParentId = Convert.ToInt32(dataReader["parentid"]);
                    item.UrlLink = dataReader["urllink"].ToString();
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
        /// 添加菜单
        /// </summary>
        /// <param name="MenuItem">Menus 实体</param>
        /// <returns></returns>
        public static int AddMenu(MenuInfo MenuItem)
        {
            string spName = "cudo_createmenu";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@menuname",MenuItem.MenuName),
                new SqlParameter("@parentid",MenuItem.ParentId),
                new SqlParameter("@urllink",MenuItem.UrlLink),
                new SqlParameter("@sortid",MenuItem.SortId)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="MenuItem">Menus 实体</param>
        /// <returns></returns>
        public static int UpdateMenu(MenuInfo MenuItem)
        {
            string spName = "cudo_updatemenu";
            SqlParameter[] paramValues = new SqlParameter[] { 
                new SqlParameter("@menuname",MenuItem.MenuName),
                new SqlParameter("@parentid",MenuItem.ParentId),
                new SqlParameter("@urllink",MenuItem.UrlLink),
                new SqlParameter("@sortid",MenuItem.SortId),
                new SqlParameter("@id",MenuItem.Id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        public static int UpdateMenu(int SortId, int MenuID)
        {
            string sql = "update [cudo_menus] set sortid=@sortid where id=@id";
            SqlParameter[] paramValues = new SqlParameter[] { 
                new SqlParameter("@sortid",SortId),
                new SqlParameter("@id",MenuID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramValues);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuID">ID</param>
        /// <returns>受影响行数</returns>
        public static int DeleteMenu(int MenuID)
        {
            string spName = "cudo_deletemenu";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",MenuID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount()
        {
            string spName = "cudo_getmenucount";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName));
        }

        public static int GetCount(int parentid)
        {
            string spName = "cudo_getmenucountbypid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@parentid",parentid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
