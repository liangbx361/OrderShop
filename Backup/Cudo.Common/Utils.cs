using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Collections;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Specialized;

namespace Cudo.Common
{
    public class Utils
    {
        /// <summary>
        /// 获取历史浏览记录
        /// </summary>
        /// <param name="GoodsID"></param>
        /// <param name="CookiesName"></param>
        public static void GoodsHistory(int GoodsID, string CookiesName)
        {
            //------------------------------------------
            HttpContext context = HttpContext.Current;
            HttpCookie cookie = new HttpCookie(CookiesName);
            cookie = context.Request.Cookies[CookiesName];
            string cookieValue = null;
            if (context.Request.Cookies[CookiesName] == null)
            {
                cookieValue = GoodsID.ToString() + ",";
            }
            else
            {
                cookieValue = cookie.Value;
                cookieValue = cookieValue.Replace(GoodsID + ",", "");
                cookieValue = GoodsID + "," + cookieValue;
            }           
            cookie = new HttpCookie(CookiesName, cookieValue);            
            cookie.Expires = DateTime.Now.AddDays(1);            
            context.Response.Cookies.Add(cookie);
            cookie = context.Request.Cookies[CookiesName];
        }
       
        public static void bindXmlCbx(CheckBoxList cbx, string source, string splitstr)
        {
            string[] strArr = null;
            if (source.Length > 0)
            {
                strArr = source.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArr.Length; i++)
                {
                    strArr[i] = strArr[i].Trim();
                }
            }

            string[] arrtem = new string[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                arrtem[i] = strArr[i].Split(new string[] { splitstr }, StringSplitOptions.RemoveEmptyEntries)[0].ToString().Trim();
            }
            cbx.DataSource = arrtem;
            cbx.DataBind();
        }

        #region ==============取得Ip地址============
        /**/
        /// <summary> 
        /// 取得客户端真实IP。如果有代理则取第一个非内网地址 
        /// </summary> 
        public static string GetTrueIPAddress()
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理 
                if (result.IndexOf(".") == -1)    //没有"."肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有","，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("\"", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];    //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null;    //代理中的内容 非IP，取IP 
                }
            }
            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;
            return result;
        }

        #region bool IsIPAddress(str1) 判断是否是IP格式
        /**/
        /// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str1">待判断的IP地址</param>
        /// <returns>true or false</returns>
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        #endregion

        #endregion

        public static void alert(string msg, string url)
        {
            StringBuilder txt = new StringBuilder();

            txt.Append("<script>");
            txt.Append("alert('" + msg + "');");
            if (url != "")
                txt.Append("window.location.href='" + url + "';");
            else
                txt.Append("history.go(-1);");
            txt.Append("</script>");

            HttpContext.Current.Response.Write(txt.ToString());
            HttpContext.Current.Response.End();
        }
   
        public static string SpaceLength(int u)
        {
            string space = null;
            for (int i = 0; i < u; i++)
            {
                space += "　";
            }
            space += "├";
            return space;
        }

        #region ================截取字符串==================

        public static string CutString(string inputString, int len, string str)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += str;
            return tempString;
        }

        public static string CutString(string inputString, int len)
        {
            return CutString(inputString, len, "");
        }

        #endregion

        #region ================读写Cookie操作==============

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

       
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

       /// <summary>
       /// 读取Cookie
       /// </summary>
       /// <param name="strName"></param>
       /// <returns></returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();

            return "";
        }
        
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return HttpContext.Current.Request.Cookies[strName][key].ToString();

            return "";
        }

        #endregion

        #region ============获得XML文件的路径===============

        /// <summary>
        /// 获得XML文件的路径
        /// </summary>
        /// <param name="xmlName"></param>
        /// <returns></returns>
        public static string GetXmlMapPath(string xmlName)
        {
            return GetMapPath(ConfigurationManager.AppSettings[xmlName].ToString());
        }

        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        #endregion

        #region ================MD5加密算法=================
        public static string MD5Encrypt32(string str)
        {
            return MD5Encrypt(str, 32);
        }
        public static string MD5Encrypt16(string str)
        {
            return MD5Encrypt(str, 16);
        }
        private static string MD5Encrypt(string str, int length)
        {
            if (length != 16 && length != 32) throw new System.ArgumentException("Length参数无效,只能为16位或32位");
            System.Security.Cryptography.MD5CryptoServiceProvider MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] b = MD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            System.Text.StringBuilder StrB = new System.Text.StringBuilder();
            for (int i = 0; i < b.Length; i++)
                StrB.Append(b[i].ToString("x").PadLeft(2, '0'));
            if (length == 16)
                return StrB.ToString(8, 16);
            else
                return StrB.ToString();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="obj">传进参数</param>
        /// <returns>返回加密后的东西</returns>
        public static string MD5(string obj)
        {
            #region MD5加密
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(obj, "md5");
            #endregion
        }

        #endregion

        public static string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(36);
                if (temp != -1 && temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        public static SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sPara = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = HttpContext.Current.Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sPara.Add(requestItem[i], HttpContext.Current.Request.QueryString[requestItem[i]]);
            }

            return sPara;
        }

        public static string CreateLinkStringUrl(SortedDictionary<string, string> sParaTemp)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in sParaTemp)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);
            return prestr.ToString();
        }

        /// <summary>
        /// 除去数组中的空值和签名参数并以字母a到z的顺序排序
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <param name="filterStr">需要过滤的参数</param>
        /// <returns>过滤后的参数组</returns>
        public static SortedDictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre, string filterStr)
        {
            SortedDictionary<string, string> dicArray = new SortedDictionary<string, string>();
            foreach (KeyValuePair<string, string> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != filterStr)
                {
                    dicArray.Add(temp.Key.ToLower(), temp.Value);
                }
            }

            return dicArray;
        }
    }
}
