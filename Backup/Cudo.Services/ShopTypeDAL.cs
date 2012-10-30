using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class ShopTypeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List数据集</returns>
        public static List<ShopType> GetList()
        {
            List<ShopType> list = new List<ShopType>();
            string spName = "cudo_getshoptypes";
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName);
            try
            {
                while (dataReader.Read())
                {
                    ShopType item = new ShopType();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.TypeName = dataReader["typename"].ToString();
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
        /// <returns></returns>
        public static ShopType GetItem(int id)
        {
            ShopType item = null;
            string spName = "cudo_getshoptypebyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new ShopType();
                    item.Id = id;
                    item.TypeName = dataReader["typename"].ToString();
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
        public static int AddItem(ShopType item)
        {
            string spName = "cudo_createshoptype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@typename",item.TypeName),
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateItem(ShopType item)
        {
            string spName = "cudo_updateshoptype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@typename",item.TypeName),
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
            string spName = "cudo_deleteshoptype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
