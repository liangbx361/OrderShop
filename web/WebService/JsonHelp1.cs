using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Text;


namespace web.WebService
{
    public class JsonHelp1
    {
        #region dataTable转换成Json格式
        /// <summary>    
        /// dataTable转换成Json格式    
        /// </summary>    
        /// <param name="dt"></param>    
        /// <returns></returns>    
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName.ToString());
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        #endregion dataSet转换成Json格式

        /// <summary>
        /// 格式化成Json字符串
        /// </summary>
        /// <param name="obj">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// 格式化成Json字符串
        /// </summary>
        /// <param name="obj">需要格式化的对象</param>
        /// <param name="recursionDepth">指定序列化的深度</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }
    }
}