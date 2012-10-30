using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class UserGroupDAL
    {
        public static List<UserGroup> GetList()
        {
            List<UserGroup> list = new List<UserGroup>();
            string spName = "cudo_getusergrouplist";
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName);
            try
            {
                while (dataReader.Read())
                {
                    UserGroup item = new UserGroup();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.GroupName = dataReader["groupname"].ToString();
                    item.Zk = Convert.ToInt32(dataReader["zk"]);
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

        public static UserGroup GetItemById(int id)
        {
            UserGroup item = null;
            string spName = "cudo_getusergroupbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new UserGroup();
                    item.Id = id;
                    item.GroupName = dataReader["groupname"].ToString();
                    item.Zk = Convert.ToInt32(dataReader["zk"]);
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

        public static int AddItem(UserGroup item)
        {
            string spName = "cudo_createusergroup";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@groupname",item.GroupName),
                new SqlParameter("@zk",item.Zk)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int UpdateItem(UserGroup item)
        {
            string spName = "cudo_updateusergroup";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@groupname",item.GroupName),
                new SqlParameter("@zk",item.Zk),
                new SqlParameter("@id",item.Id)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deleteusergroup";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
