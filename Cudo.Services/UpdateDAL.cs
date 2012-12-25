using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Cudo.Entities;

namespace Cudo.Services
{
    public class UpdateDAL
    {
        public static AndroidVersionInfo getAndroidVersion()
        {
            AndroidVersionInfo versionInfo = new AndroidVersionInfo();
            string sql = "select * from [android_client_version] where id=1";
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql);

            try
            {
                while (dataReader.Read())
                {
                    versionInfo.Id = Convert.ToInt32(dataReader["id"]);
                    versionInfo.Name = dataReader["name"].ToString();
                    versionInfo.VersionCode = Convert.ToInt32(dataReader["versioncode"]);
                    versionInfo.VersionName = dataReader["versionname"].ToString();
                    versionInfo.Src = dataReader["src"].ToString();
                    versionInfo.Introduction = dataReader["introduction"].ToString();
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

            return versionInfo;
        }

        public static int UpdateAndroidVersion(AndroidVersionInfo versionInfo)
        {
            string sql = "update [android_client_version] set name=@name, versioncode=@versioncode, versionname=@versionname, src=@src, introduction=@introduction where id=1";
            SqlParameter[] paramvalues = new SqlParameter[] 
            {
                new SqlParameter("@name",versionInfo.Name),
                new SqlParameter("@versioncode",versionInfo.VersionCode),
                new SqlParameter("@versionname",versionInfo.VersionName),
                new SqlParameter("@src",versionInfo.Src),
                new SqlParameter("@introduction",versionInfo.Introduction),
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramvalues);
        }
    }
}
