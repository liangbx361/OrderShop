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
            string hotdistrict = new BasePage().webset.HotDistrict;
            if (hotdistrict.IndexOf("|") > -1)
            {
                string strResult = "";
                string[] hotlist = hotdistrict.Split('|');
                foreach (string str in hotlist)
                {
                    strResult += "<a href='search.aspx?keyword=" + Server.UrlEncode(str) + "'>" + str + "</a>&nbsp;&nbsp;";
                }
                L_HotDistrict.Text = strResult;
            }
        }
    }
}