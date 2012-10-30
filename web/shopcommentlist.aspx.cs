using System;
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
    public partial class shopcommentlist : BasePage
    {
        ShopCommentBLL bll = new ShopCommentBLL();
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
            ShopCommentInit();
        }

        private void ShopCommentInit()
        {
            WebPager.RecordCount = bll.GetCountByShopId(shopid);
            rpt_list.DataSource = bll.GetShopCommentsByShopId(WebPager.CurrentPageIndex, WebPager.PageSize, shopid);
            rpt_list.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            ShopCommentInit();
        }
    }
}
