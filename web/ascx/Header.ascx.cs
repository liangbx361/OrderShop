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
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {        
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            UserInfo item = Session["cudoUser"] as UserInfo;

            if (item == null)
            {
                //Utils.alert("请先登录", "/login.aspx");
                Response.Redirect("/login.aspx");
            }
            else
            {
                string[] addlist = item.Address.Split('|')[0].Split(',');
                
                try
                {
                    int aid = Convert.ToInt32(addlist[0]);
                    Response.Redirect("/shoplist.aspx?aid=" + addlist[0] + "&sid=" + addlist[1] + "&did=" + addlist[2]);
                }
                catch (FormatException ee)
                {
                    Utils.alert("您尚未拥有收餐地址，请先设定一个", "/Users/useraddress.aspx");
                    //Response.Redirect("/setaddress.aspx");
                }
            }
        }
    }
}