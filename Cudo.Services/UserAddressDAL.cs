using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class UserAddressDAL
    {
        public static List<UserAddress> GetList(int userid)
        {
            List<UserAddress> list = new List<UserAddress>();
            string spName = "cudo_getuseraddresslistbyuserid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    UserAddress item = new UserAddress();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserId = userid;
                    item.UserName = dataReader["username"].ToString();
                    item.Mobile = dataReader["mobile"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.IsDefault = Convert.ToInt32(dataReader["isdefault"]);
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

        public static UserAddress GetItemByID(int id)
        {
            UserAddress item = null;
            string spName = "cudo_getaddressbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new UserAddress();
                    item.Id = id;
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.Mobile = dataReader["mobile"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.IsDefault = Convert.ToInt32(dataReader["isdefault"]);
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

        public static int AddItem(UserAddress item)
        {
            string spName = "cudo_createuseraddress";
            SqlParameter[] paramvalues = new SqlParameter[] 
            { 
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@mobile",item.Mobile),
                new SqlParameter("@address",item.Address),
                new SqlParameter("@isdefault",item.IsDefault)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateItem(UserAddress item)
        {
            string spName = "cudo_updateuseraddress";
            SqlParameter[] paramvalues = new SqlParameter[] 
            { 
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@mobile",item.Mobile),
                new SqlParameter("@address",item.Address),
                new SqlParameter("@isdefault",item.IsDefault),
                new SqlParameter("@id",item.Id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deleteuseraddress";
            SqlParameter[] paramvalues = new SqlParameter[] 
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
