using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class FeedBackDAL
    {
        public static List<FeedBack> GetList(int pageindex, int pagesize)
        {
            List<FeedBack> list = new List<FeedBack>();
            string spName = "cudo_getfeedbacklist";
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
                    FeedBack item = new FeedBack();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.UserName = dataReader["username"].ToString();
                    item.Subject = dataReader["subject"].ToString();
                    item.Content = dataReader["content"].ToString();
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

        public static int AddItem(FeedBack item)
        {
            string spName = "cudo_createfeedback";
            SqlParameter[] paramValues = new SqlParameter[] 
            { 
                new SqlParameter("@username",item.UserName),
                new SqlParameter("@subject",item.Subject),
                new SqlParameter("@content",item.Content)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramValues);
        }

        public static int DeleteItem(int id)
        {
            string spName = "cudo_deletefeedback";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int GetCount()
        {
            string spName = "cudo_getfeedbackcount";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName));
        }
    }
}
