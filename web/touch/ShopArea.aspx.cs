using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class ShopArea : ManagePage
    {
        AreaBLL bll = new AreaBLL();
        private int shopid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = base.GetIntValue("shopid");
            ViewState["shopid"] = shopid;
            if (!IsPostBack)
            {
                PageInit();
                AreaInit();
            }
        }

        private void PageInit()
        {
            rpt_list.DataSource = bll.GetListByShopId(shopid);
            rpt_list.DataBind();
        }

        private void AreaInit()
        {
            ddl_counties.DataSource = bll.GetList(0);
            ddl_counties.DataValueField = "Id";
            ddl_counties.DataTextField = "AreaName";
            ddl_counties.DataBind();
            ddl_counties.Items.Insert(0, new ListItem("-选择区县-", ""));
        }

        protected void ddl_counties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_counties.SelectedIndex != 0)
            {
                ddl_streets.DataSource = bll.GetListByidlist(ddl_counties.SelectedValue);
                ddl_streets.DataValueField = "Id";
                ddl_streets.DataTextField = "AreaName";
                ddl_streets.DataBind();
                ddl_streets.Items.Insert(0, new ListItem("-选择路段-", ""));
                ddl_district.Items.Clear();
            }
        }

        protected void ddl_streets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_streets.SelectedIndex != 0)
            {
                ddl_district.DataSource = bll.GetListByidlist(ddl_streets.SelectedValue);
                ddl_district.DataValueField = "Id";
                ddl_district.DataTextField = "AreaName";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("-请选择小区-", ""));
            }
        }

        protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            new ShopAreaBLL().DeleteItem(Convert.ToInt32(ViewState["shopid"]), Convert.ToInt32(e.CommandArgument));
            PageInit();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int shopid = Convert.ToInt32(ViewState["shopid"]);
            int areaid = Convert.ToInt32(ddl_counties.SelectedValue);
            int sid = Convert.ToInt32(ddl_streets.SelectedValue);
            int did = Convert.ToInt32(ddl_district.SelectedValue);
            if (new ShopAreaBLL().CheckShopArea(shopid, did) > 0)
            {
                l_msg.Text = "<font color='red'>已添加请勿重复操作!</font>";
            }
            else
            {
                new ShopAreaBLL().AddItem(shopid, areaid, sid, did);
                PageInit();
            }
        }
    }
}
