using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.Shops
{
    public partial class takeawayinfo : BasePage
    {
        AreaBLL bll = new AreaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            Shop shopitem = new ShopsBLL().GetShopItem(item.ShopId);
            if (shopitem != null)
            {
                string[] ordertime = shopitem.OrderTime.Split('|');
                opentime.Value = shopitem.OpenTime;
                amtime.Value = ordertime[0];
                pmtime.Value = ordertime[1];
                sendlimitprice.Value = shopitem.LimitPrice.ToString();
                sendprice.Value = shopitem.SendPrice.ToString();
                sendtime.Value = shopitem.SendTime.ToString();
            }

            rpt_shoparealist.DataSource = bll.GetListByShopId(item.ShopId);
            rpt_shoparealist.DataBind();

            AreaInit();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            int areaid = int.Parse(ddl_counties.SelectedValue);
            int sid = int.Parse(ddl_streets.SelectedValue);
            int did = int.Parse(ddl_district.SelectedValue);
            if (new ShopAreaBLL().CheckShopArea(item.ShopId, did) > 0)
            {
                Utils.alert("已添加请勿重复操作!", "takeawayinfo.aspx");
            }
            else
            {
                new ShopAreaBLL().AddItem(item.ShopId, areaid, sid, did);
                PageInit();
            }
        }
    }
}
