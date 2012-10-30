using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class AdminUserDAL
    {
        public static DataSet GetUserList(int pageindex,int pagesize,int IsSystem)
        {
            string sql = string.Empty;
            if (pageindex == 1)
                sql = "select top " + pagesize + " * from [cudo_adminuser] where issystem>=" + IsSystem + " order by id desc";
            else
                sql = "select top " + pagesize + " * from [cudo_adminuser] where issystem>=" + IsSystem + " and id not in(select top " + pagesize * (pageindex - 1) + " id from [cudo_adminuser] where issystem>=" + IsSystem + " order by id desc) order by id desc";
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        public static object GetCount(int IsSystem)
        {
            string sql = "select count(id) from [cudo_adminuser] where issystem>=@issystem";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@issystem",IsSystem)
            };
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString,CommandType.Text,sql,paramvalues);
        }

        public static object GetUserNameById(int UserID)
        {
            string sql = "select username from [cudo_adminuser] where id=" + UserID;
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        public static AdminUser UserLogin(string UserName, string password)
        {
            AdminUser User = new AdminUser();
            string sql = "select id,logintime,lastlogintime,loginip,issystem,addtime from [cudo_adminuser] where username=@UserName and userpwd=@Password";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@Password",password)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paramValues);
            try
            {
                if (dataReader.Read())
                {
                    User.Id = Convert.ToInt32(dataReader["id"]);
                    User.UserName = UserName;
                    User.UserPwd = password;
                    User.LoginTime = Convert.ToDateTime(dataReader["logintime"]);
                    User.LastLoginTime = Convert.ToDateTime(dataReader["lastlogintime"]);
                    User.LoginIP = dataReader["loginip"].ToString();
                    User.IsSystem = Convert.ToInt32(dataReader["issystem"]);
                    User.AddTime = Convert.ToDateTime(dataReader["addtime"]);
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
            return User;
        }

        public static AdminUser GetUserByUserID(int UserID)
        {
            AdminUser User = new AdminUser();
            string sql = "select username,userpwd,logintime,lastlogintime,loginip,issystem,addtime from [cudo_adminuser] where id=" + UserID;
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql);
            try
            {
                if (dataReader.Read())
                {
                    User.UserName = dataReader["username"].ToString();
                    User.UserPwd = dataReader["userpwd"].ToString();
                    User.LoginTime = Convert.ToDateTime(dataReader["logintime"]);
                    User.LastLoginTime = Convert.ToDateTime(dataReader["lastlogintime"]);
                    User.LoginIP = dataReader["loginip"].ToString();
                    User.IsSystem = Convert.ToInt32(dataReader["issystem"]);
                    User.AddTime = Convert.ToDateTime(dataReader["addtime"]);
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
            return User;
        }

        public static int AddAdminUser(AdminUser item)
        {
            string sql = "insert into [cudo_adminuser](username,userpwd,lastlogintime) values(@UserName,@UserPwd,@LastLoginTime) SELECT scope_identity()";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@UserName",item.UserName),
                new SqlParameter("@UserPwd",item.UserPwd),
                new SqlParameter("@LastLoginTime",item.LastLoginTime)
            };
            int UserID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, paramValues));
            return UserID;
        }

        public static int UpdateUser(int UserID, string password, bool flag)
        {
            string sql = "update [cudo_adminuser] set userpwd=@userpwd where id=@id";
            SqlParameter[] paramvalues = new SqlParameter[] 
            {
                new SqlParameter("@userpwd",password),
                new SqlParameter("@id",UserID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramvalues);
        }

        public static int UpdateUser(int UserID, string LoginIP)
        {
            string sql = "update [cudo_adminuser] set lastlogintime=logintime,logintime=@logintime,loginip=@loginip where id=@id";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@logintime",DateTime.Now.ToString()),
                new SqlParameter("@loginip",LoginIP),
                new SqlParameter("@id",UserID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramvalues);
        }

        public static int DeleteUser(int UserID)
        {
            string sql = "delete from [cudo_adminuser] where id=" + UserID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }


        public static object GetPermissionsByUserID(int UserID)
        {
            string sql = "select permissions from [cudo_userrole] where userid=" + UserID;
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        public static int AddUserRole(string Permissions, int UserID)
        {
            string sql = "insert into [cudo_userrole](permissions,userid) values(@permissions,@userid)";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@permissions",Permissions),
                new SqlParameter("@userid",UserID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramvalues);
        }

        public static int UpdateUserRoleByUserID(string Permissions, int UserID)
        {
            string sql = "update [cudo_userrole] set permissions=@permissions where userid=@userid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@permissions",Permissions),
                new SqlParameter("@userid",UserID)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramvalues);
        }

        public static int DeleteUserRoleByUserID(int UserID)
        {
            string sql = "delete from [cudo_userrole] where userid=" + UserID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }
    }
}
