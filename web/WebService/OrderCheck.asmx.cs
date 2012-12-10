using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.IO;

using Cudo.Business;
using Cudo.Common;
using Cudo.Entities;

namespace web.WebService
{
    /// <summary>
    /// OrderCheck 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "", Name = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class OrderCheck : System.Web.Services.WebService
    {
        /// <summary>
        /// 生成用户订单
        /// </summary>
        /// <param name="orderMesage"></param>
        /// <returns></returns>
        [WebMethod]
        public string generateOrder(string orderMesage)
        {
            JObject orderObject = JObject.Parse(orderMesage);

            JArray dishArray = orderObject["dishArray"] as JArray;

            StringBuilder str = new StringBuilder();  //餐品内容
            OrderInfo orderinfoitem = new OrderInfo();
            string orderno = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10, 100);

            for (int i = 0; i < dishArray.Count; i++)
            {
                JObject dishObject = JObject.Parse(dishArray[i].ToString());
                OrderItem oitem = new OrderItem();
                oitem.OrderNo = orderno;
                oitem.ProductId = Convert.ToInt32(dishObject["productId"].ToString());
                oitem.ProductName = dishObject["dishName"].ToString().Replace("\"", "");
                oitem.BuyNum = Convert.ToInt32(dishObject["orderNum"].ToString());
                oitem.Price = Convert.ToDecimal(dishObject["oldPrice"].ToString());
                new OrderItemBLL().AddItem(oitem); //将点的套餐保存在数据库中

                str.Append(oitem.ProductName + "(" + oitem.BuyNum + ") ");
            }

            orderinfoitem.OrderNo = orderno;
            orderinfoitem.ShopId = Convert.ToInt32(orderObject["shopId"].ToString());
            orderinfoitem.UserId = Convert.ToInt32(orderObject["userId"].ToString());
            orderinfoitem.OrderPoint = Convert.ToDecimal(orderObject["orderPoint"].ToString());
            orderinfoitem.TotalPrice = Convert.ToDecimal(orderObject["totalNewPrice"].ToString());
            orderinfoitem.UserTel = orderObject["userTel"].ToString().Replace("\"", "");
            orderinfoitem.UserName = orderObject["userName"].ToString().Replace("\"", "");
            orderinfoitem.UserAddress = orderObject["userAddress"].ToString().Replace("\"", "");
            orderinfoitem.AreaId = Convert.ToInt32(orderObject["areaId"].ToString());
            orderinfoitem.Remark = orderObject["remark"].ToString().Replace("\"", "");
            orderinfoitem.AddTime = DateTime.Now;

            if (new OrdersBLL().AddItem(orderinfoitem) > 0)
            {
                ModifyTGPoint(orderinfoitem.UserId, orderinfoitem.OrderPoint, orderinfoitem.AddTime);
                //FastSendToShop(orderinfoitem.ShopId, orderinfoitem.TotalPrice.ToString(), str.ToString(), orderinfoitem.Remark, orderinfoitem.UserAddress, orderinfoitem.UserName, orderinfoitem.UserTel);
                return "ok";
            }
            else return "false";
        }

        /// <summary>
        /// 更新推广会员的积分
        /// </summary>
        /// <param name="reguid">id</param>
        /// <param name="point">消费积分</param>
        /// <param name="xftime">消费时间</param>
        private void ModifyTGPoint(int reguid, decimal point, DateTime xftime)
        {
            int userid = new JoinPromotionBLL().GetUserIdByReguid(reguid);
            if (userid > 0)
            {
                UsersBLL ubll = new UsersBLL();
                UserInfo item = ubll.GetUserByID(userid);
                int zk = new UserGroupBLL().GetItemById(item.UserGroup).Zk; //会员折扣

                decimal upoint = zk * point / 100; //折扣%*积分
                //ubll.UpdatePoint(upoint, userid);

                #region ===添加消费记录===
                UserProfit upitem = new UserProfit();
                upitem.reguid = reguid;
                upitem.userid = userid;
                upitem.xfpoint = point;
                upitem.sypoint = upoint;
                upitem.xftime = xftime;
                new UserProfitBLL().AddItem(upitem);
                #endregion
            }
        }

        /// <summary>
        /// 发送短信（商户）
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="totalprice"></param>
        /// <param name="itemstr"></param>
        private void FastSendToShop(int shopid, string totalprice, string itemstr, string remark, string address, string name, string phone)
        {
            UsersBLL ubll = new UsersBLL();
            string mobile = ubll.GetShopUserMobile(shopid);
            if (!string.IsNullOrEmpty(mobile))
            {
                string contentstr = Server.UrlEncode(address + "；" + itemstr + "；合" + totalprice + "元；" + name + "：" + phone + "；送达时间：" + remark);
                string sendurl = "http://www.ums86.com:8899/sms/Api/Send.do?SpCode=001418&LoginName=fz_lx&Password=lx6856&MessageContent=" + contentstr + "&UserNumber=" + mobile + "&SerialNumber=&ScheduleTime=&f=1";

                GetHtmlFromUrl(sendurl);
            }
        }

        /// <summary>
        /// 短信接口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }
    }
}
