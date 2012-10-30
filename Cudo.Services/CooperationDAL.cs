using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class CooperationDAL
    {
        public static List<Cooperation> GetList(int pageindex, int pagesize)
        {
            List<Cooperation> list = new List<Cooperation>();
            string spName = "cudo_getcooperationlist";
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
                    Cooperation item = new Cooperation();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.ShopName = dataReader["shopname"].ToString();
                    item.UserName = dataReader["username"].ToString();
                    item.Phone = dataReader["phone"].ToString();
                    item.Address = dataReader["address"].ToString();
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

        public static int AddItem(Cooperation item)
        {
            string spName = "cudo_createcooperation";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@shopname",item.ShopName),
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@phone",item.Phone),
                new SqlParameter("@address",item.Address)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deletecooperation";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount()
        {
            string spName = "cudo_getcooperationcount";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName));
        }
    }
}
