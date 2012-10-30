using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Services
{
    public class ShopCommentDAL
    {
        private static List<ShopComment> GetList(string spName, SqlParameter[] paramvalues)
        {
            List<ShopComment> list = new List<ShopComment>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    ShopComment item = new ShopComment();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.TotalPoint = Convert.ToInt32(dataReader["point"]);
                    item.TastePoint = Convert.ToInt32(dataReader["tastepoint"]);
                    item.MilieuPoint = Convert.ToInt32(dataReader["milieupoint"]);
                    item.ServicePoint = Convert.ToInt32(dataReader["servicepoint"]);
                    item.CommentContent = dataReader["commentcontent"].ToString();
                    item.CheckStatus = Convert.ToInt32(dataReader["checkstatus"]);
                    item.AddTime = Convert.ToDateTime(dataReader["addtime"]);
                    item.ShopName = ShopsDAL.GetShopItem(item.ShopId).ShopName;
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

        public static List<ShopComment> GetShopCommentsByShopId(int pageindex, int pagesize, int shopid, int checkstatus)
        {
            string spName = "cudo_getshopcommentsbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@shopid",shopid),
                new SqlParameter("@checkstatus",checkstatus)
            };
            return GetList(spName, paramvalues);
        }

        public static List<ShopComment> GetShopCommentsByUserId(int pageindex, int pagesize, int userid)
        {
            string spName = "cudo_getshopcommentsbyuserid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@userid",userid)
            };
            return GetList(spName, paramvalues);
        }

        public static ShopComment GetShopComment(int id)
        {
            ShopComment item = new ShopComment();
            string spName = "cudo_getshopcommentbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item.Id = id;
                    item.ShopId = Convert.ToInt32(dataReader["shopid"]);
                    item.UserId = Convert.ToInt32(dataReader["userid"]);
                    item.UserName = dataReader["username"].ToString();
                    item.TotalPoint = Convert.ToInt32(dataReader["point"]);
                    item.TastePoint = Convert.ToInt32(dataReader["tastepoint"]);
                    item.MilieuPoint = Convert.ToInt32(dataReader["milieupoint"]);
                    item.ServicePoint = Convert.ToInt32(dataReader["servicepoint"]);
                    item.CommentContent = dataReader["commentcontent"].ToString();
                    item.CheckStatus = Convert.ToInt32(dataReader["checkstatus"]);
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

        public static int AddShopComment(ShopComment item)
        {
            string spName = "cudo_createshopcomment";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",item.ShopId),
                new SqlParameter("@userid",item.UserId),
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@point",item.TotalPoint),
                new SqlParameter("@tastepoint",item.TastePoint),
                new SqlParameter("@milieupoint",item.MilieuPoint),
                new SqlParameter("@servicepoint",item.ServicePoint),
                new SqlParameter("@commentcontent",item.CommentContent)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateShopComment(int id, int checkstatus)
        {
            string spName = "cudo_updateshopcomment";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@checkstatus",checkstatus),
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int DeleteShopComment(int id)
        {
            string spName = "cudo_deleteshopcommentbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCountByShopId(int shopid, int checkstatus)
        {
            string spName = "cudo_getshopcommentcountbyshopid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@shopid",shopid),
                new SqlParameter("@checkstatus",checkstatus)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }

        public static int GetCountByUserId(int userid)
        {
            string spName = "cudo_getshopcommentcountbyuid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@userid",userid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
