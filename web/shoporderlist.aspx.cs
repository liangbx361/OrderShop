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
    public partial class shoporderlist : BasePage
    {
        protected Shop item = new Shop();
        private int shopid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = base.GetIntValue("shopid");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            hidden_shopid.Value = shopid.ToString();
            item = new ShopsBLL().GetShopItem(shopid);
            OrderInit();
        }

        private void OrderInit()
        {
            OrdersBLL bll = new OrdersBLL();
            WebPager.RecordCount = bll.GetCountByShopId(shopid);
            rpt_orderlist.DataSource = bll.GetListByShopId(WebPager.CurrentPageIndex, WebPager.PageSize, shopid);
            rpt_orderlist.DataBind();
        }

        protected string GetUserName(object uid)
        {
            return new UsersBLL().GetUserNameByuid(Convert.ToInt32(uid));
        }

        protected int GetOrderCount(string orderno)
        {
            return new OrderItemBLL().GetCount(orderno);
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            OrderInit();
        }
    }
}
