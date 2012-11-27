using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web
{
    public partial class login : System.Web.UI.Page
    {
        protected WebSet webset = new BasePage().webset;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _username = Utils.GetCookie("UserName", webset.CookieName);
                if (!string.IsNullOrEmpty( _username))
                {
                    username.Value = DESEncrypt.Decrypt(_username);
                    //chkusername.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsersBLL bll = new UsersBLL();
            try
            {
                string _username = username.Value;
                string _password = Utils.MD5Encrypt32(upassword.Value);

                UserInfo item = bll.UserLogin(_username, _password);
                if (item != null)
                {
                    item = bll.UpdateUserGroup(item); 
                    Session["cudoUser"] = item;
                    //if (chkusername.Checked)
                    //{
                    //    Utils.WriteCookie("UserName", webset.CookieName, DESEncrypt.Encrypt(_username));
                    //}

                    string[] addlist = item.Address.Split('|')[0].Split(',');
                    try
                    {
                        int aid = Convert.ToInt32(addlist[0]);
                        Response.Redirect("/shoplist.aspx?aid=" + addlist[0] + "&sid=" + addlist[1] + "&did=" + addlist[2]);
                    }
                    catch (FormatException ee)
                    {
                        Response.Redirect("/setaddress.aspx");
                    }
                }
                else
                {
                    Utils.alert("用户名或密码输入错误!", "login.aspx");
                }
            }
            catch
            {
                Utils.alert("登录失败!", "login.aspx");
            }
        }
    }
}
