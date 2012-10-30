using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.admin
{
    public partial class error : System.Web.UI.Page
    {
        protected string url;
        protected string FlagStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {
                url = Server.UrlDecode(Request.QueryString["url"]);
            }
            else
            {
                url = "setting.aspx";
            }
            if (Request.QueryString["flag"] != null)
            {
                GetFlagStr(Request.QueryString["flag"]);
            }
            else
            {
                FlagStr = "！";
            }
            if (!IsPostBack)
            {
                ltlmsg.Text = Request.QueryString["msg"];
            }
        }

        private void GetFlagStr(string obj)
        {
            switch (obj)
            {
                case "0": FlagStr = "×"; break;
                case "1": FlagStr = "√"; break;
                default: FlagStr = "！"; break;
            }
        }
    }
}
