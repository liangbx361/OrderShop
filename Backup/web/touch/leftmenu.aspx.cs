using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Cudo.Entities;
using Cudo.Business;

namespace web.admin
{
    public partial class leftmenu : ManagePage
    {
        private string id = string.Empty;
        private int pid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pid = base.GetIntValue("pid", 1);
        }

        protected string GetMenu()
        {
            MenuBLL mBLL =  new MenuBLL();
            
            //读取权限
            string Permissions = Session["Permissions"].ToString();
            StringBuilder text = new StringBuilder();
            text.Append("<ul>");
            List<MenuInfo> list = mBLL.GetMenuList(pid);
            text.Append("<a class=\"menu_title\" href=\"#\"><span class=\"ico1\">" + mBLL.GetMenuNameById(pid) + "</span></a>\r\n");
            text.Append("<div class=\"sec_menu\">");
            foreach (MenuInfo item in list)
            {
                if (Session["issystem"].ToString().Trim() == "-2")
                {
                    text.Append("<a href='" + item.UrlLink + "' target=\"main\">" + item.MenuName + "</a>\r\n");
                }
                else
                {
                    if (Permissions.IndexOf("," + item.Id + ",") >= 0)
                    {
                        text.Append("<a href='" + item.UrlLink + "' target=\"main\">" + item.MenuName + "</a>\r\n");
                    }
                }
            }
            text.Append("</div>\r\n");
            text.Append("<div class=\"menu_title\" style=\"height:19px;line-height:19px;\"></div>");
            return text.ToString();
        }
    }
}
