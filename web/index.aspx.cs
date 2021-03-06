﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web
{
    public partial class index : System.Web.UI.Page
    {
        protected UserInfo item;

        protected void Page_Load(object sender, EventArgs e)
        {
            item = Session["cudoUser"] as UserInfo;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (item == null)
            {
                //Utils.alert("进入浏览如需订餐请先登录", "/login.aspx");
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