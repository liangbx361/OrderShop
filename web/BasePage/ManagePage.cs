using System;
using System.IO;
using System.Text;
using System.Web;
using Cudo.Common;
using Cudo.Business;
using Cudo.Entities;
using System.Web.UI.WebControls;

namespace web
{
    public class ManagePage : System.Web.UI.Page
    {
        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
        }

        void ManagePage_Load(object sender, EventArgs e)
        {
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='logout.aspx'</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session不为Null
            if (Session["admin_userid"] != null && Session["issystem"] != null && Session["Permissions"] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string adminname = Utils.GetCookie("AdminName", "FZtouch"); //解密用户名
                string adminpwd = Utils.GetCookie("AdminPwd", "FZtouch");
                if (adminname != "" && adminpwd != "")
                {
                    adminname = DESEncrypt.Decrypt(adminname); //解密用户名
                    AdminUserBLL bll = new AdminUserBLL();
                    AdminUser item = bll.UserLogin(adminname, adminpwd);
                    if (item != null)
                    {
                        Session["admin_userid"] = item.Id;
                        Session["issystem"] = item.IsSystem;
                        Session["Permissions"] = bll.GetPermissionsByUserID(item.Id);
                        return true;
                    }
                }
            }
            return false;
        }

        protected virtual void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseover", "a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'");
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=a");
            }
        }

        /// <summary>
        /// 遮罩提示窗口
        /// </summary>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        /// <param name="msgtitle">窗口标题</param>
        /// <param name="msgbox">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(int w, int h, string msgtitle, string msgbox, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "jsmsg(" + w + "," + h + ",\"" + msgtitle + "\",\"" + msgbox + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsMsg", msbox);
        }

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptPrint(string msgtitle, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "jsprint(\"" + msgtitle + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox);
        }

        /// <summary>
        /// 跳转提示信息
        /// </summary>
        /// <param name="MsgTitle">信息</param>
        /// <param name="returnUrl">返回地址</param>
        /// <param name="flag">成功或失败（1，0）</param>
        protected void ErrorMsg(string MsgTitle, string returnUrl, int flag)
        {
            Response.Redirect("error.aspx?msg=" + MsgTitle + "&url=" + returnUrl + "&flag=" + flag);
        }

        #region 表单处理
        protected int GetIntValue(string requestName)
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

        protected int GetIntValue(string requestName,int defaultValue)
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

        protected string GetStringValue(string requestName)
        {
            string requestValue = string.Empty;
            if (Request.QueryString[requestName] != null)
            {
                requestValue = Request.QueryString[requestName];
            }
            return requestValue;
        }

        protected string GetStringValue(string requestName, string defaultValue)
        {
            string requestValue = defaultValue;
            if (Request.QueryString[requestName] != null)
            {
                requestValue = Request.QueryString[requestName];
            }
            return requestValue;
        }
        #endregion

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        protected void SaveLogs(string str)
        {
            SystemLogBLL bll = new SystemLogBLL();
            SystemLog model = new SystemLog();
            if (Session["AdminName"] != null)
            {
                model.UserName = Session["AdminName"].ToString();
            }
            model.IpAddress = Utils.GetTrueIPAddress();
            model.LogInfo = str;
            bll.AddLog(model);
        }

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        public void SaveLogs(string username, string str)
        {
            SystemLogBLL bll = new SystemLogBLL();
            SystemLog model = new SystemLog();
            model.UserName = username;
            model.IpAddress = Utils.GetTrueIPAddress();
            model.LogInfo = str;
            bll.AddLog(model);
        }
    }
}