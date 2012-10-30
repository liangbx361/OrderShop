using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web
{
    public partial class modifyaddress2 : System.Web.UI.Page
    {
        AreaBLL abll = new AreaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            //加载街道
            List<Area> list = abll.GetListByidlist("1,2,3,4");
            rpt_streets.DataSource = list;
            rpt_streets.DataBind();
            //加载小区
            string prestr = "";
            foreach (Area item in list)
            {
                prestr += item.Id + ",";
            }
            prestr.Remove(prestr.Length - 1, 1);
            rpt_district.DataSource = abll.GetListByidlist(prestr);
            rpt_district.DataBind();
        }
    }
}
