using System;
using System.Web;
using Cudo.Common;
using Cudo.Business;
using Cudo.Entities;

namespace web
{
    public class BasePage : System.Web.UI.Page
    {
        protected internal WebSet webset;

        public BasePage()
        {
            webset = new WebSetBLL().loadConfig(Utils.GetXmlMapPath("Configpath"));
        }

        public void IsLogin()
        {
            if (!IsMemberLogin())
            {
                Utils.alert("请先登录", "/login.aspx");
            }
        }


        /// <summary>
        /// 判断会员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsMemberLogin()
        {
            //如果Session为Null
            if (Session["cudoUser"] != null)
            {
                return true;
            }

            //else
            //{
            //    //检查Cookies
            //    string username = Utils.GetCookie("UserName", webset.CookieName); //解密用户名
            //    string userpwd = Utils.GetCookie("UserPwd", webset.CookieName);
            //    if (username != "" && userpwd != "")
            //    {
            //        username = DESEncrypt.Decrypt(username); //解密用户名
            //        UsersBLL bll = new UsersBLL();
            //        UserInfo model = new UserInfo();
            //        if ((model = bll.UserLogin(username, userpwd)) != null)
            //        {
            //            Session["UserName"] = model.UserName;
            //            Session["UserID"] = model.Id;
            //            return true;
            //        }
            //    }
            //} 
            return false;
        }

        #region 表单处理
        /// <summary>
        /// 查询字符是否存在
        /// </summary>
        /// <param name="requestName"></param>
        /// <returns></returns>
        public int GetIntValue(string requestName)
        {
            int requestValue = 0;
            if (Request.QueryString[requestName] != null)
            {   
                try
                {
                    requestValue = Convert.ToInt32(Request.QueryString[requestName]);
                }
                catch
                {
                    Response.Redirect("error.html");
                }
            }
            return requestValue;
        }

        public int GetIntValue(string requestName, int defaultValue)
        {
            int requestValue = defaultValue;
            if (Request.QueryString[requestName] != null)
            {
                try
                {
                    requestValue = Convert.ToInt32(Request.QueryString[requestName]);
                }
                catch
                {
                    Response.Redirect("error.html");
                }
            }
            return requestValue;
        }

        public string GetStringValue(string requestName)
        {
            string requestValue = string.Empty;
            if (Request.QueryString[requestName] != null)
            {
                requestValue = Request.QueryString[requestName];
            }
            return requestValue;
        }

        public string GetStringValue(string requestName, string defaultValue)
        {
            string requestValue = defaultValue;
            if (Request.QueryString[requestName] != null)
            {
                requestValue = Request.QueryString[requestName];
            }
            return requestValue;
        }
        #endregion
    }
}