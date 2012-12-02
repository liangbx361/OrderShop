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

        protected void shopInof_onClick(object sender, EventArgs e)
        {
            UserInfo item = Session["cudoUser"] as UserInfo;

            if (item == null)
            {
                Response.Redirect("/shoplist.aspx");
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
                    Response.Redirect("/error.html");
                }
            }
        }
    }
}
