using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using Cudo.Entities;
using Cudo.Business;

namespace web.ashx
{
    public class CheckHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string srtResult = string.Empty;
            string action = context.Request.QueryString["action"];
            switch (action)
            {
                case "checkpoint":
                    string limitprice = context.Request.QueryString["limit"];
                    decimal usepoint = decimal.Parse(context.Request.QueryString["usepoint"]);
                    srtResult += CheckUserPoint(context, usepoint, limitprice);
                    break;
                case "checkadd":
                    int shopid = int.Parse(context.Request.QueryString["shopid"]);
                    srtResult += CheckUserAddress(context, shopid);
                    break;
                case "checktime":
                    int shopid2 = int.Parse(context.Request.QueryString["shopid"]);
                    srtResult += CheckShopTime(context, shopid2);
                    break;
                default: break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(srtResult);
        }

        protected string CheckUserAddress(HttpContext context, int shopid)
        {
            string strResult = string.Empty;
            UserInfo item = context.Session["cudoUser"] as UserInfo;
            List<UserAddress> addresslist = new UserAddressBLL().GetList(item.Id);
            string[] addlist = addresslist[0].Address.Split('|');
            if (addresslist[0].UserName.Trim() == "" || addlist[1].Trim() == "")
            {
                strResult = "{\"types\":\"0\",\"adtype\":\"0\",\"msg\":\"请先完善您的地址!\"}";
            }
            else
            {
                UserInfo uinfo = new UsersBLL().GetUserByID(item.Id);
                int result = 0;
                int uaid = Convert.ToInt32(addlist[0].Split(',')[2]); //用户所在楼宇的id（默认）
                int uaid2 = Convert.ToInt32(uinfo.Address.Split('|')[0].Split(',')[2]); //现在
                List<Area> list = new AreaBLL().GetListByShopId(shopid);
                foreach (Area temp in list)
                {
                    if (temp.Id == uaid || temp.Id == uaid2)
                    {
                        result = 1;
                        break;
                    }
                }
                if (result == 0)
                {
                    strResult = "{\"types\":\"0\",\"adtype\":\"1\",\"msg\":\"默认地址不在该餐厅服务范围内，请重选本次送餐地址!\"}";
                }
                else
                {
                    strResult = "{\"types\":\"1\",\"msg\":\"\"}";
                }
            }
            return strResult;
        }

        protected string CheckUserPoint(HttpContext context, decimal usepoint, string limitprice)
        {
            string strResult = string.Empty;
            if (context.Session["ShoppingCart"] != null)
            {
                decimal decSum = 0;
                List<Cart> list = (List<Cart>)context.Session["ShoppingCart"];
                foreach (Cart citem in list)
                {
                    decSum += citem.SumPrice;
                }
                //判断点餐金额与起送价
                if (decSum < Convert.ToDecimal(limitprice))
                {
                    strResult = "{\"types\":\"0\",\"msg\":\"本店" + limitprice + "元起送!\"}";
                }
                else
                {
                    UserInfo item = context.Session["cudoUser"] as UserInfo;
                    if (item.CurrentPoint < usepoint)
                        strResult = "{\"types\":\"0\",\"msg\":\"您的积分不足!请先充值或者直接电话联系商家\"}";
                    else
                        strResult = "{\"types\":\"1\",\"msg\":\"\"}";
                }
            }
            else
            {
                strResult = "{\"types\":\"0\",\"msg\":\"您的餐车无餐品,请先点餐!\"}";
            }
            return strResult;
        }

        protected string CheckShopTime(HttpContext context, int shopid)
        {
            string strResult = string.Empty;
            Shop item = new ShopsBLL().GetShopItem(shopid);
            string[] ordertime = item.OrderTime.Split('|');
            if (ordertime[0].Trim() == "" && ordertime[1].Trim() == "")
            {
                strResult = "{\"types\":\"1\",\"msg\":\"\"}";
            }
            else
            {
                DateTime nowtime = DateTime.Now;
                int result1 = 0, result2 = 0;
                if (ordertime[0].Trim() != "")
                {
                    string[] timelist = ordertime[0].Split('-');
                    if (DateTime.Compare(nowtime, Convert.ToDateTime(timelist[0])) >= 0 && DateTime.Compare(nowtime, Convert.ToDateTime(timelist[1])) <= 0)
                    {
                        //在时间段里面
                        result1 = 1;
                    }
                }
                if (ordertime[1].Trim() != "")
                {
                    string[] timelist = ordertime[1].Split('-');
                    if (DateTime.Compare(nowtime, Convert.ToDateTime(timelist[0])) >= 0 && DateTime.Compare(nowtime, Convert.ToDateTime(timelist[1])) <= 0)
                    {
                        //在时间段里面
                        result2 = 1;
                    }
                }
                if (result1 == 0 && result2 == 0)
                    strResult = "{\"types\":\"0\",\"msg\":\"非网络订餐时段，请自行电话订餐!\"}";
                else
                    strResult = "{\"types\":\"1\",\"msg\":\"\"}";
            }
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
