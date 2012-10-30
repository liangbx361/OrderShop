/********************************************
 * Create By：WG0290
 * Create Time：2009-5-30 11:29:54 
 * Function：字符串过滤器
 * Modify Course：
 * 2009-5-30 11:29:54 WG0290 创建文件
 
 *******************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cudo.Common
{
    public class Filter : System.Web.UI.Page
    {
        /// <summary>
        /// 字符串过滤(Html、JavaScript、Sql过滤)
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string AllFilter(string inputString)
        {
            string outPutString = inputString;
            outPutString = HtmlFilter(outPutString);
            outPutString = JavaScriptFilter(outPutString);
            outPutString = SqlFilter(outPutString);
            return outPutString;
        }

        #region Html过滤器
        /// <summary>
        /// Html字符串过滤
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string HtmlFilter(string inputString)
        {
            return HtmlFilter(inputString, false);
        }
        /// <summary>
        /// Html字符串过滤
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns></returns>
        public static string HtmlFilter(string inputString, bool isKillHtmlTag)
        {
            string outPutString = inputString;
            if (string.IsNullOrEmpty(outPutString))
                return outPutString;
            outPutString = Regex.Replace(outPutString, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<head[^>]*?>.*?</head>", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<title[^>]*?>.*?</title>", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<`~!.?:^&|", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<img .*?/>", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<img .*?>", "", RegexOptions.IgnoreCase);
            if (isKillHtmlTag)
            {
                outPutString = Regex.Replace(outPutString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                outPutString = Regex.Replace(outPutString, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                outPutString = outPutString.Replace("<", "");
                outPutString = outPutString.Replace(">", "");
                outPutString = outPutString.Replace("\r\n", "");
            }
            else
            {
                outPutString = outPutString.Replace("\r\n", "<br/>");
            }
            outPutString = Regex.Replace(outPutString, @"-->", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"<!--.*", "", RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            outPutString = Regex.Replace(outPutString, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);
            return outPutString;
        }

        ///   <summary>
        ///   移除HTML标签
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string RemoveHTMLTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]+>", "");
        }

        #endregion

        #region JavaScript过滤器
        /// <summary>
        /// JavaScript字符串过滤
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns></returns>
        public static string JavaScriptFilter(string inputString)
        {
            string outPutString = inputString;
            outPutString = Regex.Replace(outPutString, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //未完整，待补充
            return outPutString;
        }
        #endregion

        #region Sql过滤器
        /// <summary>
        /// Sql字符串过滤
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns></returns>
        public static string SqlFilter(string inputString)
        {
            string outPutString = inputString;
            outPutString = outPutString.Replace("Exec", "");
            outPutString = outPutString.Replace("Execute", "");
            outPutString = outPutString.Replace("Alert", "");
            outPutString = outPutString.Replace("Insert", "");
            outPutString = outPutString.Replace("Update", "");
            outPutString = outPutString.Replace("#", "");
            outPutString = outPutString.Replace("&", "");
            outPutString = outPutString.Replace("'", "");
            outPutString = outPutString.Replace("+", "");
            //outPutString = outPutString.Replace(",", "");
            //去除系统存储过程或扩展存储过程关键字
            outPutString = outPutString.Replace("xp_", "x p_");
            outPutString = outPutString.Replace("sp_", "s p_");
            //防止16进制注入
            outPutString = outPutString.Replace("0x", "0 x");
            outPutString = outPutString.Replace(@"-->", "");
            outPutString = outPutString.Replace(@"<!--.*", "");
            return outPutString;
        }

        /// <summary>
        ///SQL注入过滤
        /// </summary>albumid
        /// <param name="InText">要过滤的字符串</param>
        /// <returns>如果参数存在不安全字符，则返回true</returns>
        public static bool SqlFilter2(string InText)
        {
            string word = "and|exec|insert|select|delete|update|chr|master|or|truncate|char|declare|join|'";
            if (InText == null)
                return false;
            foreach (string str_t in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(str_t + " ") > -1) || (InText.ToLower().IndexOf(" " + str_t) > -1) || (InText.ToLower().IndexOf(str_t) > -1))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
