using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Cudo.Entities;
using Cudo.Business;
using System.Web.SessionState;

namespace web.ashx
{
    /// <summary>
    /// 购物车操作
    /// </summary>
    public class ShoppingCart : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string srtResult = string.Empty;
            string action = context.Request.QueryString["action"];
            int productid = 0;
            int shopid = 0;
            switch (action)
            {
                case "init":
                    shopid = int.Parse(context.Request.QueryString["shopid"]);
                    srtResult += CartLoad(context, shopid);
                    break;
                case "add":
                    productid = int.Parse(context.Request.QueryString["proid"]);
                    shopid = int.Parse(context.Request.QueryString["shopid"]);
                    srtResult += AddCart(context, productid,shopid);
                    break;
                case "change":
                    productid = int.Parse(context.Request.QueryString["proid"]);
                    shopid = int.Parse(context.Request.QueryString["shopid"]);
                    int buynum = int.Parse(context.Request.QueryString["num"]);
                    srtResult += ModifyCart(context, productid, buynum, shopid);
                    break;
                case "delete":
                    productid = int.Parse(context.Request.QueryString["proid"]);
                    shopid = int.Parse(context.Request.QueryString["shopid"]);
                    srtResult += DeleteItem(context, productid, shopid);
                    break;
                case "deleteall":
                    srtResult += DeleteAll(context);
                    break;
                default: break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(srtResult);
        }

        protected string CartLoad(HttpContext context, int shopid)
        {
            string strResult = string.Empty;
            if (context.Session["ShoppingCart"] != null)
            {
                List<Cart> list = (List<Cart>)context.Session["ShoppingCart"];
                if (list[0].ShopID != shopid)
                    list.Clear();
                if (list.Count > 0)
                {
                    decimal decSum = 0;
                    decimal zkSum = 0;
                    int cartCount = 0;
                    strResult += "<div class=\"shopcar_products\" id=\"shop_" + shopid + "\">";
                    foreach (Cart item in list)
                    {
                        decSum += item.SumPrice;
                        cartCount += item.BuyNum;
                        strResult += "<div class=\"car_product\">";
                        strResult += "  <input type='hidden' id='shopId' value='" + item.ShopID + "'>";
                        strResult += "  <input type='hidden' id='productId' value='" + item.ProductID + "'>";
                        strResult += "  <div class=\"u1\"><input type=\"checkbox\" onclick=\"deleteitem(this)\" checked=\"checked\" /></div>";
                        strResult += "  <div class=\"u2\"><span>" + item.ProductName + "</span>￥" + item.Price + "</div> ";
                        strResult += "  <div class=\"u3\"><a href=\"javascript:;\" class=\"btnReduce\" onclick=\"minusitem(this)\"></a> <input type=\"text\" class=\"amount\" id=\"num_"+item.ProductID+"\" value=\""+item.BuyNum+"\" /> <a href=\"javascript:;\" class=\"btnAdd\" onclick=\"additem(this)\"></a> </div>";
                        strResult += "</div>";
                    }
                    zkSum = (decSum * list[0].zk ); //积分 
                    strResult += "</div>";
                    strResult += "<div class=\"shopcar_price\">";
                    strResult += "  <div style=\"float:right;\">获得积分：<span>" + (int)zkSum + "</span>分</div>";
                    strResult += "  <div>金额：<span>" + decSum + "</span>元</div>";
                    strResult += "</div>";
                    strResult += "<div class=\"shopcar_count\"><input type='hidden' id='usepoint' value='" + zkSum + "'>(共<span>" + cartCount + "</span>份)</div>";
                    context.Session["ShoppingCart"] = list;
                }
                else
                {
                    strResult += NoData(context);
                    context.Session["ShoppingCart"] = null;
                }
            }
            else
            {
                strResult += NoData(context);
            }
            return strResult;
        }

        protected string AddCart(HttpContext context, int productid,int shopid)
        {
            string strResult = string.Empty;
            if (context.Session["ShoppingCart"] == null)
            {
                List<Cart> list = new List<Cart>();
                Cart item = new Cart();
                Product ProItem = new ProductsBLL().GetItem(productid);
                item.CartID = 1;
                item.ShopID = shopid;
                item.zk = new ShopsBLL().GetShopZK(shopid);
                item.ProductID = productid;
                item.ProductName = ProItem.ProductName;
                item.Price = ProItem.Price;
                item.BuyNum = 1;
                item.UserID = (context.Session["cudoUser"] as UserInfo).Id;
                list.Add(item);
                context.Session["ShoppingCart"] = list;
                strResult += CartLoad(context, shopid);
            }
            else
            {
                int buynum = 0;
                List<Cart> list = (List<Cart>)context.Session["ShoppingCart"];
                foreach (Cart item in list)
                {
                    if (item.ShopID == shopid && item.ProductID == productid)
                    {
                        buynum = item.BuyNum + 1;
                        break;
                    }
                }
                if (buynum > 0)
                {
                    strResult += ModifyCart(context, productid, buynum, shopid);
                }
                else
                {
                    Cart item = new Cart();
                    Product ProItem = new ProductsBLL().GetItem(productid);
                    item.CartID = list[list.Count - 1].CartID + 1;
                    item.ShopID = shopid;
                    item.zk = new ShopsBLL().GetShopZK(shopid);
                    item.ProductID = productid;
                    item.ProductName = ProItem.ProductName;
                    item.Price = ProItem.Price;
                    item.BuyNum = 1;
                    item.UserID = (context.Session["cudoUser"] as UserInfo).Id;
                    list.Add(item);
                    context.Session["ShoppingCart"] = list;
                    strResult += CartLoad(context, shopid);
                }
            }
            return strResult;
        }

        protected string ModifyCart(HttpContext context, int productid, int buynum, int shopid)
        {
            string strResult = string.Empty;
            if (context.Session["ShoppingCart"] != null)
            {
                List<Cart> list = (List<Cart>)context.Session["ShoppingCart"];
                foreach (Cart item in list)
                {
                    if (item.ShopID == shopid && item.ProductID == productid)
                    {
                        item.BuyNum = buynum;
                        break;
                    }
                }
                context.Session["ShoppingCart"] = list;
                strResult += CartLoad(context, shopid);
            }
            else
            {
                strResult += NoData(context);
                context.Session["ShoppingCart"] = null;
            }
            return strResult;
        }

        protected string DeleteItem(HttpContext context, int productid,int shopid)
        {
            string strResult = string.Empty;
            if (context.Session["ShoppingCart"] != null)
            {
                List<Cart> list = (List<Cart>)context.Session["ShoppingCart"];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ShopID == shopid && list[i].ProductID == productid)
                    {
                        list.Remove(list[i]);
                    }
                }
                if (list.Count > 0)
                {
                    context.Session["ShoppingCart"] = list;
                    strResult += CartLoad(context, shopid);
                }
                else
                {
                    strResult += NoData(context);
                    context.Session["ShoppingCart"] = null;
                }
            }
            else
            {
                strResult += NoData(context);
            }
            return strResult;
        }

        protected string DeleteAll(HttpContext context)
        {
            string strResult = string.Empty;
            context.Session["ShoppingCart"] = null;
            strResult += NoData(context);
            return strResult;
        }

        /// <summary>
        /// 没有数据的时候显示
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected string NoData(HttpContext context)
        {
            string strResult = "";
            return strResult;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
