using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.admin
{
    public partial class Logout:System.Web.UI.Page
    {
        private WebSet webset = new WebSetBLL().loadConfig(Utils.GetXmlMapPath("Configpath"));
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("AdminName");
            Session.Remove("Permissions");
            Session.Remove("issystem");
            Session.Remove("admin_userid");
            Utils.WriteCookie("AdminName", webset.CookieName, -1440);
            Utils.WriteCookie("AdminPwd", webset.CookieName, -1440);
            Response.Redirect("login.aspx");
        }
    }
}
