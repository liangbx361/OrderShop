using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class ProductTypeDAL
    {
        public static List<ProductType> GetList(int shopid)
        {
            List<ProductType> list = new List<ProductType>();
            string spName = "cudo_getproducttypesbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    ProductType item = new ProductType();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.TypeName = dataReader["typename"].ToString();
                    item.ShopId = shopid;
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

        public static ProductType GetItem(int id)
        {
            ProductType item = null;
            string spName = "cudo_getproducttypebyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new ProductType();
                    item.Id = id;
                    item.TypeName = dataReader["typename"].ToString();
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
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

        public static int AddItem(ProductType item)
        {
            string spName = "cudo_createproducttype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",item.ShopId),
                new SqlParameter("@typename",item.TypeName)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateItem(ProductType item)
        {
            string spName = "cudo_updateproducttype";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",item.ShopId),
                new SqlParameter("@typename",item.TypeName),
                new SqlParameter("@id",item.Id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deleteproducttypebyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
