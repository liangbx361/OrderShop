using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class UsersDAL
    {
        public static List<UserInfo> GetShopUserList(int pageindex, int pagesize, string username, string shopname)
        {
            List<UserInfo> list = new List<UserInfo>();
            string spName = "cudo_getshopuserlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@username",username),
                new SqlParameter("@shopname",shopname)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    UserInfo item = new UserInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserGroup = Convert.ToInt32(dataReader["usergroup"]);
                    item.UserName = dataReader["username"].ToString();
                    item.UserPass = dataReader["userpass"].ToString();
                    item.NickName = dataReader["nickname"].ToString();
                    item.Gender = Convert.ToInt32(dataReader["gender"]);
                    item.Birthday = dataReader["birthday"].ToString();
                    item.TotalPoint = Convert.ToDecimal(dataReader["totalpoint"]);
                    item.CurrentPoint = Convert.ToDecimal(dataReader["currentpoint"]);
                    item.UsePoint = Convert.ToDecimal(dataReader["usepoint"]);
                    item.Mobile = dataReader["mobile"].ToString();
                    item.Email = dataReader["email"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.Utype = Convert.ToInt32(dataReader["utype"]);
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.ShopName = dataReader["shopname"].ToString();
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

        public static List<UserInfo> GetUserList(int pageindex, int pagesize,int utype)
        {
            List<UserInfo> list = new List<UserInfo>();
            string spName = "cudo_getuserlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@utype",utype)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    UserInfo item = new UserInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserGroup = Convert.ToInt32(dataReader["usergroup"]);
                    item.UserName = dataReader["username"].ToString();
                    item.UserPass = dataReader["userpass"].ToString();
                    item.NickName = dataReader["nickname"].ToString();
                    item.Gender = Convert.ToInt32(dataReader["gender"]);
                    item.Birthday = dataReader["birthday"].ToString();
                    item.TotalPoint = Convert.ToDecimal(dataReader["totalpoint"]);
                    item.CurrentPoint = Convert.ToDecimal(dataReader["currentpoint"]);
                    item.UsePoint = Convert.ToDecimal(dataReader["usepoint"]);
                    item.SpreadCount = Convert.ToInt32(dataReader["spreadcount"]);
                    item.Mobile = dataReader["mobile"].ToString();
                    item.Email = dataReader["email"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.Utype = Convert.ToInt32(dataReader["utype"]);
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
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

        public static List<UserInfo> GetUserList()
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = "select id,username from [cudo_users] where utype=0";
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql);
            try
            {
                while (dataReader.Read())
                {
                    UserInfo item = new UserInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserName = dataReader["username"].ToString();
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

        public static UserInfo GetUserByID(int userid)
        {
            UserInfo item = null;
            string spName = "cudo_getuserbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",userid)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure,spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new UserInfo();
                    item.Id = userid;
                    item.UserGroup = Convert.ToInt32(dataReader["usergroup"]);
                    item.UserName = dataReader["username"].ToString();
                    item.UserPass = dataReader["userpass"].ToString();
                    item.NickName = dataReader["nickname"].ToString();
                    item.Gender = Convert.ToInt32(dataReader["gender"]);
                    item.Birthday = dataReader["birthday"].ToString();
                    item.TotalPoint = Convert.ToDecimal(dataReader["totalpoint"]);
                    item.CurrentPoint = Convert.ToDecimal(dataReader["currentpoint"]);
                    item.UsePoint = Convert.ToDecimal(dataReader["usepoint"]);
                    item.SpreadCount = Convert.ToInt32(dataReader["spreadcount"]);
                    item.Mobile = dataReader["mobile"].ToString();
                    item.Email = dataReader["email"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.Utype = Convert.ToInt32(dataReader["utype"]);
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
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
        /// 创建用户
        /// </summary>
        /// <param name="Item"></param>
        /// <returns>用户ID</returns>
        public static int AddUser(UserInfo Item)
        {
            string spName = "cudo_createuser";
            SqlParameter[] paramValues = new SqlParameter[] 
            {
                new SqlParameter("@promotionid",Item.PromotionId),
                new SqlParameter("@username",Item.UserName),
                new SqlParameter("@userpass",Item.UserPass),
                new SqlParameter("@nickname",Item.NickName),
                new SqlParameter("@gender",Item.Gender),
                new SqlParameter("@birthday",Item.Birthday),
                new SqlParameter("@mobile",Item.Mobile),
                new SqlParameter("@email",Item.Email),
                new SqlParameter("@address",Item.Address),
                new SqlParameter("@utype",Item.Utype),
                new SqlParameter("@shopid",Item.ShopId),
                new SqlParameter("@point",Item.TotalPoint)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues));
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static int UpdateUser(UserInfo Item)
        {
            string spName = "cudo_updateuser";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@usergroup",Item.UserGroup),
                new SqlParameter("@nickname",Item.NickName),
                new SqlParameter("@gender",Item.Gender),
                new SqlParameter("@birthday",Item.Birthday),
                new SqlParameter("@mobile",Item.Mobile),
                new SqlParameter("@email",Item.Email),
                new SqlParameter("@address",Item.Address),
                new SqlParameter("@id",Item.Id)
            };

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public static int UpdateUser(string password, int userid)
        {
            string spName = "cudo_updateuserpassbyid";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@userpass",password),
                new SqlParameter("@id",userid)
            };

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        /// <summary>
        /// 修改积分
        /// </summary>
        /// <param name="point">积分</param>
        /// <param name="userid">ID</param>
        /// <returns></returns>
        public static int UpdateUser(decimal point, int userid)
        {
            string spName = "cudo_updateuserpointbyid";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@point",point),
                new SqlParameter("@userid",userid)
            };

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        public static int DeleteUser(int userid)
        {
            string spName = "cudo_deleteuserbyid";
            SqlParameter[] paramValues = new SqlParameter[] 
            {
                new SqlParameter("@id",userid)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        public static int CheckUserByUserName(string username)
        {
            string spName = "cudo_checkuserbyusername";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@username",username)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int CheckUserByMobile(string mobile)
        {
            string spName = "cudo_checkuserbymobile";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@mobile",mobile)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int CheckUserByEmail(string email)
        {
            string spName = "cudo_checkuserbyemail";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@email",email)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static UserInfo UserLogin(string UserName, string UserPass)
        {
            UserInfo item = null;
            string spName = "cudo_getuserbyusernameandpass";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@username",UserName),
                new SqlParameter("@userpass", UserPass)
            };

            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new UserInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserGroup = Convert.ToInt32(dataReader["usergroup"]);
                    item.UserName = UserName;
                    item.UserPass = UserPass;
                    item.NickName = dataReader["nickname"].ToString();
                    item.Gender = Convert.ToInt32(dataReader["gender"]);
                    item.Birthday = dataReader["birthday"].ToString();
                    item.TotalPoint = Convert.ToDecimal(dataReader["totalpoint"]);
                    item.CurrentPoint = Convert.ToDecimal(dataReader["currentpoint"]);
                    item.UsePoint = Convert.ToDecimal(dataReader["usepoint"]);
                    item.SpreadCount = Convert.ToInt32(dataReader["spreadcount"]);
                    item.Mobile = dataReader["mobile"].ToString();
                    item.Email = dataReader["email"].ToString();
                    item.Address = dataReader["address"].ToString();
                    item.Utype = Convert.ToInt32(dataReader["utype"]);
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
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

        public static int GetUserCount(int utype)
        {
            string spName = "cudo_getuserscount";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@utype",utype)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int GetUserCount(string username,string shopname)
        {
            string spName = "cudo_getshopuserscount";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@username",username),
                new SqlParameter("@shopname",shopname)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static string GetShopUserMobile(int shopid)
        {
            string spName = "select top 1 mobile from [cudo_users] where shopid=" + shopid;
            object mobile = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, spName);
            return mobile != null ? mobile.ToString() : "";
        }
    }
}
