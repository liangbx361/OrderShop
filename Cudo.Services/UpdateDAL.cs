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
    }
}
