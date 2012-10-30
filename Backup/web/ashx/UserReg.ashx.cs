using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Cudo.Business;

namespace web.ashx
{
    /// <summary>
    /// 
    /// </summary>
    public class UserReg : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string strResult = string.Empty;
            string Action = context.Request.QueryString["action"];
            switch (Action)
            {
                case "name":
                    string username = context.Request.QueryString["username"];
                    strResult = CheckUserName(username);
                    break;
                case "mobile":
                    string mobile = context.Request.QueryString["mobile"];
                    strResult = CheckMobile(mobile);
                    break;
                case "email":
                    string email = context.Request.QueryString["email"];
                    strResult = CheckEmail(email);
                    break;
                case"code":
                    string verifycode = context.Request.QueryString["verifycode"];
                    strResult = CheckVerifyCode(context, verifycode);
                    break;
                default: break;
            }
            
            context.Response.ContentType = "text/plain";
            context.Response.Write(strResult);
        }

        private string CheckUserName(string username)
        {
            string strResult = string.Empty;
            int userid = new UsersBLL().CheckUserIDByUserName(username);
            if (userid > 0)
            {
                strResult = "1";
            }
            else
            {
                strResult = "0";
            }
            return strResult;
        }

        protected string CheckMobile(string mobile)
        {
            string strResult = string.Empty;
            int userid = new UsersBLL().CheckUserByMobile(mobile);
            if (userid > 0)
            {
                strResult = "1";
            }
            else
            {
                strResult = "0";
            }
            return strResult;
        }

        protected string CheckEmail(string email)
        {
            string strResult = string.Empty;
            int userid = new UsersBLL().CheckUserByEmail(email);
            if (userid > 0)
            {
                strResult = "1";
            }
            else
            {
                strResult = "0";
            }
            return strResult;
        }

        private string CheckVerifyCode(HttpContext context, string VerifyCode)
        {
            string strResult = string.Empty;
            if (context.Session["Verifycode"].ToString().CompareTo(VerifyCode) != 0)
            {
                strResult = "0";
            }
            else
            {
                strResult = "1";
            }
            return strResult;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
