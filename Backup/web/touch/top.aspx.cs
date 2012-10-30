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
    public partial class top : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected string GetMenu()
        {
            //读取权限
            string Permissions = Session["Permissions"].ToString();
            StringBuilder str = new StringBuilder();
            List<MenuInfo> list = new MenuBLL().GetMenuList(0);
            foreach (MenuInfo item in list)
            {
                if (Session["issystem"].ToString().Trim() == "-2")
                {
                    str.Append("<a href='leftmenu.aspx?pid=" + item.Id + "' target=\"leftmenu\">" + item.MenuName + "</a>|");
                }
                else
                {
                    if (Permissions.IndexOf("," + item.Id + ",") >= 0)
                        str.Append("<a href='leftmenu.aspx?pid=" + item.Id + "' target=\"leftmenu\">" + item.MenuName + "</a>|");
                }
            }
            return str.ToString();
        }
    }
}
