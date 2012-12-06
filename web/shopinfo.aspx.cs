using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Cudo.Entities;
using Cudo.Business;

namespace web
{
    public partial class shopinfo : BasePage
    {
        ShopsBLL bll = new ShopsBLL();
        protected Shop item = new Shop();
        protected int shopid = 0;
        protected int see_pic = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = base.GetIntValue("shopid");
            see_pic = base.GetIntValue("see_pic");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            hidden_shopid.Value = shopid.ToString();

            item = bll.GetShopItem(shopid);
            bll.UpdateShopHit(shopid);

            rpt_typelist.DataSource = new ProductTypeBLL().GetListByShopId(shopid);
            rpt_typelist.DataBind();

            rpt_tyleprolist.DataSource = rpt_typelist.DataSource;
            rpt_tyleprolist.DataBind();
        }

        protected string GetProductByTypeId(object typeid)
        {
            StringBuilder strResult = new StringBuilder();
            List<Product> list = new ProductsBLL().GetListByTypeAndShop(Convert.ToInt32(typeid),shopid);
            // 显示图片
            if (see_pic == 1)
            {
                strResult.Append("<ul class=\"cdlist\">");
                foreach (Product pitem in list)
                {
                    strResult.Append("<li class=\"pline\"><img src=\"" + pitem.ImgSrc + "\" title=\"" + pitem.ProductName + "\" />");
                    strResult.Append("<div class=\"price\">" + pitem.ProductName + "<br />￥" + pitem.Price + "</div>");
                    strResult.Append("<a href=\"javascript:;\" onclick=\"AddShoppingCar(" + pitem.Id + ")\">要一份</a>");
                    strResult.Append("</li>");
                }
                strResult.Append("</ul>");
            }
            else
            {
                strResult.Append("<ul class=\"cdlist2\">");
                foreach (Product pitem in list)
                {
                    strResult.Append("<li>");
                    strResult.Append("<span class=\"sl\">" + pitem.ProductName + "</span>");
                    strResult.Append("<span class=\"sr\">");
                    //strResult.Append("<img src=\"/images/yj_tu.gif\"/>");
                    strResult.Append("<S class=\"price\">￥" + pitem.Price + "</S>");
                    //strResult.Append("<img src=\"/images/hy_tu.gif\"/>");
                    strResult.Append("<span class=\"price2\" color=#ffff>￥" + (pitem.Price - (pitem.Price * item.zk / 100)) + "</span>");
                    strResult.Append("<a href=\"javascript:;\" onclick=\"AddShoppingCar(" + pitem.Id + ")\">要一份</a></span>");
                    strResult.Append("</li>");
                }
                strResult.Append("</ul>");
            }
            return strResult.ToString();
        }

        protected void shopInof_onClick(object sender, EventArgs e)
        {
            UserInfo item = Session["cudoUser"] as UserInfo;

            if (item == null)
            {
                Response.Redirect("/BrowseShop.aspx");
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
