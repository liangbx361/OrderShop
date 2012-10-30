using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Common;
using Cudo.Entities;
using Cudo.Business;

namespace web.admin
{
    public partial class Login : System.Web.UI.Page
    {
        private WebSet webset = new WebSetBLL().loadConfig(Utils.GetXmlMapPath("Configpath"));
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string UserName = Filter.AllFilter(txt_loginName.Value);//用户名
            string Password = Filter.AllFilter(txt_loginPwd.Value);//密码
            string code = Filter.AllFilter(txt_code.Value); //验证码

            if (string.Compare(Request.Cookies["checkcode"].Value, code, true) != 0)
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "alert('验证码输入错误!')",true);
                return;
            }
            else
            {
                string UserPwd = Utils.MD5Encrypt32((Utils.MD5Encrypt32(Utils.MD5Encrypt32(Password))));//加密
                if (UserLogin(UserName, UserPwd))
                {
                    Response.Redirect("main.html");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "alert('用户名或密码输入错误!')", true);
                }
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPwd">密码</param>
        /// <returns>登录是否成功</returns>
        private bool UserLogin(string UserName, string UserPwd)
        {
            AdminUserBLL UserBiz = new AdminUserBLL();
            AdminUser item = UserBiz.UserLogin(UserName, UserPwd);
            if (item != null)
            {
                Session["AdminName"] = UserName;
                Session["admin_userid"] = item.Id;
                Session["admin_show"] = 1;
                Session["issystem"] = item.IsSystem;
                Session["Permissions"] = UserBiz.GetPermissionsByUserID(item.Id);
                UserBiz.UpdateUser(item.Id, Utils.GetTrueIPAddress());
                //写入Cookies
                Utils.WriteCookie("AdminName", "FZtouch", DESEncrypt.Encrypt(UserName));
                Utils.WriteCookie("AdminPwd", "FZtouch", UserPwd);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
