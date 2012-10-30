using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.ascx
{
    public partial class UserLeft : System.Web.UI.UserControl
    {
        protected string goshopurl = "shoplist.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserInfo uinfo = Session["cudoUser"] as UserInfo;
                List<UserAddress> addresslist = new UserAddressBLL().GetList(uinfo.Id);
                if (addresslist[0].Address.Split('|')[1] != "")
                {
                    string[] addlist = addresslist[0].Address.Split('|')[0].Split(',');
                    goshopurl = "shoplist.aspx?aid=" + addlist[0] + "&sid=" + addlist[1] + "&did=" + addlist[2];
                }
            }
        }
    }
}