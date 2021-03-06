﻿using System;
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
        private int see_pic = 0;
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
                    strResult.Append("<li><span class=\"sl\">" + pitem.ProductName + "</span><span class=\"sr\"><span class=\"price\">￥" + pitem.Price + "</span><a href=\"javascript:;\" onclick=\"AddShoppingCar(" + pitem.Id + ")\">要一份</a></span></li>");
                }
                strResult.Append("</ul>");
            }
            return strResult.ToString();
        }
    }
}
