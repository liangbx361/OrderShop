using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class NewsDAL
    {
        private static List<NewInfo> GetNewList(string spName, SqlParameter[] paramvalues)
        {
            List<NewInfo> list = new List<NewInfo>();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                while (dataReader.Read())
                {
                    NewInfo item = new NewInfo();
                    item.Id = Convert.ToInt32(dataReader["id"]);
                    item.ClassId = Convert.ToInt32(dataReader["classid"]);
                    item.NewTitle = dataReader["newtitle"].ToString();
                    item.NewContent = dataReader["newcontent"].ToString();
                    item.ImgSrc = dataReader["imgsrc"].ToString();
                    item.Intro = dataReader["intro"].ToString();
                    item.Author = dataReader["author"].ToString();
                    item.Source = dataReader["source"].ToString();
                    item.Hit = Convert.ToInt32(dataReader["hit"]);
                    item.SortId = Convert.ToInt32(dataReader["sortid"]);
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

        public static List<NewInfo> GetNewList(int pageindex, int pagesize)
        {
            string spName = "cudo_getnewlist";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetNewList(spName, paramvalues);
        }

        public static List<NewInfo> GetNewList(int pageindex, int pagesize,int classid)
        {
            string spName = "cudo_getnewsbyclassid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",classid),
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetNewList(spName, paramvalues);
        }

        public static List<NewInfo> GetNewList(int pageindex, int pagesize,string keywords)
        {
            List<NewInfo> list = new List<NewInfo>();
            string spName = "cudo_getnewsbykeyword";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@keyword","%"+keywords+"%"),
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@pagesize",pagesize)
            };
            return GetNewList(spName, paramvalues);
        }

        public static NewInfo GetNewItem(int id)
        {
            NewInfo item = null;
            string spName = "cudo_getnewbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
            try
            {
                if (dataReader.Read())
                {
                    item = new NewInfo();
                    item.Id = id;
                    item.ClassId = Convert.ToInt32(dataReader["classid"]);
                    item.NewTitle = dataReader["newtitle"].ToString();
                    item.NewContent = dataReader["newcontent"].ToString();
                    item.ImgSrc = dataReader["imgsrc"].ToString();
                    item.Intro = dataReader["intro"].ToString();
                    item.Author = dataReader["author"].ToString();
                    item.Source = dataReader["source"].ToString();
                    item.Hit = Convert.ToInt32(dataReader["hit"]);
                    item.SortId = Convert.ToInt32(dataReader["sortid"]);
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

        public static int AddNew(NewInfo item)
        {
            string spName = "cudo_createnew";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",item.ClassId),
                new SqlParameter("@newtitle",item.NewTitle),
                new SqlParameter("@newcontent",item.NewContent),
                new SqlParameter("@imgsrc",item.ImgSrc),
                new SqlParameter("@intro",item.Intro),
                new SqlParameter("@author",item.Author),
                new SqlParameter("@source",item.Source),
                new SqlParameter("@hit",item.Hit),
                new SqlParameter("@sortid",item.SortId),
                new SqlParameter("@addtime",item.AddTime)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateNew(NewInfo item)
        {
            string spName = "cudo_updatenew";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",item.ClassId),
                new SqlParameter("@newtitle",item.NewTitle),
                new SqlParameter("@newcontent",item.NewContent),
                new SqlParameter("@imgsrc",item.ImgSrc),
                new SqlParameter("@intro",item.Intro),
                new SqlParameter("@author",item.Author),
                new SqlParameter("@source",item.Source),
                new SqlParameter("@hit",item.Hit),
                new SqlParameter("@sortid",item.SortId),
                new SqlParameter("@addtime",item.AddTime),
                new SqlParameter("@id",item.Id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static int UpdateNew(int SortId, int id)
        {
            string sql = "update [cudo_news] set sortid=@sortid where id=@id";
            SqlParameter[] paramValues = new SqlParameter[] { 
                new SqlParameter("@sortid",SortId),
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramValues);
        }

        public static int DeleteNew(int id)
        {
            string spName = "cudo_deletenewbyid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static object GetCount()
        {
            string spName = "cudo_getnewcount";
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName);
        }

        public static object GetCount(string keywords)
        {
            string spName = "cudo_getnewcountbykeyword";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@keyword",keywords)
            };
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }

        public static object GetCountByClassId(int classid)
        {
            string spName = "cudo_getnewcountbyclassid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@classid",classid)
            };
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues);
        }
    }
}
