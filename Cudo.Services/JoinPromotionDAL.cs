using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cudo.Entities;

namespace Cudo.Services
{
    public class JoinPromotionDAL
    {
        public static int GetUserIdByReguid(int reguid)
        {
            string spName = "cudo_getuidbyreguid";
            SqlParameter[] paramvalues = new SqlParameter[]
            {
                new SqlParameter("@reguid",reguid)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, spName, paramvalues));
        }
    }
}
