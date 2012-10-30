using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class NewTypeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List数据集</returns>
        public static List<NewType> GetList()
        {
            List<NewType> list = new List<NewType>();
            string spName = "cudo_getnewtypelist";
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName);
            try
            {
                while (dataReader.Read())
                {
                    NewType item = new NewType();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.ClassName = dataReader["classname"].ToString();
                    item.ParentId = Convert.ToInt32(dataReader["parentid"]);
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
        /// 根据父类ID获取集合
        /// </summary>
        /// <param name="parentid">父类ID</param>
        /// <returns>List数据集</returns>
        public static List<NewType> GetList(int parentid)
        {
            List<NewType> list = new List<NewType>();
            string spName = "cudo_getnewtypesbypid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pid",parentid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    NewType item = new NewType();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.ClassName = dataReader["classname"].ToString();
                    item.ParentId = Convert.ToInt32(dataReader["parentid"]);
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
        /// <returns>NewType</returns>
        public static NewType GetNewTypeItem(int id)
        {
            NewType item = null;
            string spName = "cudo_getnewtypebyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new NewType();
                    item.Id = id;
                    item.ClassName = dataReader["classname"].ToString();
                    item.ParentId = Convert.ToInt32(dataReader["parentid"]);
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
        /// <param name="item">NewType</param>
        /// <returns></returns>
        public static int AddNewType(NewType item)
        {
            string spName = "cudo_createnewtype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classname",item.ClassName),
                new SqlParameter("@parentid",item.ParentId),
                new SqlParameter("@sortid",item.SortId)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item">NewType</param>
        /// <returns></returns>
        public static int UpdateNewType(NewType item)
        {
            string spName = "cudo_updatenewtype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classname",item.ClassName),
                new SqlParameter("@parentid",item.ParentId),
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
        public static int DeleteNewType(int id)
        {
            string spName = "cudo_deletenewtypebyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
