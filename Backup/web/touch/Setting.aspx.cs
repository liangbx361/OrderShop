using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Cudo.Common;
using Cudo.Entities;
using Cudo.Business;

namespace web.admin
{
    public partial class Setting : ManagePage
    {
        private WebSet webset = new WebSetBLL().loadConfig(Utils.GetXmlMapPath("Configpath"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PageInit();
                SetValue();
            }
        }

        /// <summary>
        /// 弹出提示框
        /// </summary>
        private void PageInit()
        {
            if (Session["admin_show"] != null && Session["admin_show"].ToString() == "1")
            {
                AdminUser User = new AdminUserBLL().GetUserByUserID(Convert.ToInt32(Session["admin_userid"]));
                if (User!=null)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("<script type=\"text/javascript\">");
                    sql.Append("$(document).ready(function() {$.messager.show({");
                    sql.Append("title: '提示信息',msg: '" + User.UserName + "，欢迎您的登录<br/>上次登录时间：" + User.LastLoginTime + "',");
                    sql.Append("timeout: 5000,showType: 'slide'");
                    sql.Append("});});");
                    sql.Append("</script>");
                    ltl_script.Text = sql.ToString();
                }
                Session.Remove("admin_show");
            }
        }

        /// <summary>
        /// 读取信息
        /// </summary>
        protected void SetValue()
        {
            txtname.Value = webset.WebName;
            txtemail.Value = webset.WebEmail;
            txttel.Value = webset.WebTel;
            txtfax.Value = webset.WebFax;
            txtkey.Value = webset.WebKeywords;
            txtdesc.Value = webset.WebDescription;
            txtcopyright.Value = webset.WebCopyright;
            txt_email_smtp.Value = webset.SmtpServer;
            txt_password.Value = webset.EmailLoginPass;
            txthotdistrict.Value = webset.HotDistrict;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                WebSet item = new WebSet();
                item.WebName = txtname.Value;
                item.WebEmail = txtemail.Value;
                item.WebKeywords = txtkey.Value;
                item.WebDescription = txtdesc.Value;
                item.WebCopyright = txtcopyright.Value;
                item.WebTel = txttel.Value;
                item.WebFax = txtfax.Value;
                item.WebAddress = webset.WebAddress;
                item.Logo = webset.Logo;
                item.WebUrl = webset.WebUrl;
                item.EmailLoginName = txtemail.Value;
                item.EmailLoginPass = txt_password.Value != "" ? txt_password.Value : item.EmailLoginPass;
                item.SmtpServer = txt_email_smtp.Value;
                item.CookieName = webset.CookieName;
                item.ServiceQQ = webset.ServiceQQ;
                item.HotDistrict = txthotdistrict.Value;
                new WebSetBLL().saveConifg(item, Utils.GetXmlMapPath("Configpath"));
                base.JscriptPrint("系统设置成功！", "setting.aspx", "Success");
            }
            catch
            {
                base.JscriptMsg(350, 280, "错误提示", "<b>文件写入失败！</b>请检查是否有写入权限，如果没有，请联系管理员开启写入该文件的权限！", "setting.aspx", "Error");
            }
        }
    }
}
