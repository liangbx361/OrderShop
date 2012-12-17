using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;
using System.Net;
using System.IO;
using System.Text;

namespace web
{
    public partial class shoppingsure : BasePage
    {
        UsersBLL ubll = new UsersBLL();
        protected int shopid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            decimal decSum = 0;
            if (Session["ShoppingCart"] != null)
            {
                List<Cart> list = (List<Cart>)Session["ShoppingCart"];
                shopid = list[0].ShopID;
                Shop shopinfo = new ShopsBLL().GetShopItem(list[0].ShopID);
                L_ShopName.Text = shopinfo.ShopName;
                hiddenshoptel.Value = shopinfo.Phone;

                foreach (Cart item in list)
                {
                    decSum += item.SumPrice;
                }
                //绑定购物车
                rpt_list.DataSource = list;
                rpt_list.DataBind();

                //UserInfo uinfo = ubll.GetUserByID(list[0].UserID);
                UserInfo uinfo = Session["cudoUser"] as UserInfo;
                UserAddress userAddress = Session["selectAddress"] as UserAddress;
                L_Mobile.Text = uinfo.Mobile;
                L_Name.Text = userAddress.UserName;
                hiddenaid.Value = userAddress.Address.Split('|')[0].Split(',')[2];
                L_Address.Text = userAddress.Address.Split('|')[1];
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["Verifycode"].ToString().CompareTo(txtcode.Value) != 0)
            {
                L_vialcode.Text = "验证码输入错误!";
                PageInit();
            }
            else
            {
                if (Session["ShoppingCart"] != null)
                {
                    StringBuilder str = new StringBuilder();  //餐品内容
                    OrderInfo orderinfoitem = new OrderInfo();
                    string orderno = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10, 100);
                    decimal decSum = 0;
                    decimal zkSum = 0;
                    List<Cart> list = (List<Cart>)Session["ShoppingCart"];
                    foreach (Cart caritem in list)
                    {
                        decSum += caritem.SumPrice;
                        str.Append(caritem.ProductName + "(" + caritem.BuyNum + ") ");
                        OrderItem oitem = new OrderItem();
                        oitem.OrderNo = orderno;
                        oitem.ProductId = caritem.ProductID;
                        oitem.ProductName = caritem.ProductName;
                        oitem.BuyNum = caritem.BuyNum;
                        oitem.Price = caritem.Price;
                        new OrderItemBLL().AddItem(oitem);
                    }
                    zkSum = (decSum * list[0].zk / 100); //积分
                    orderinfoitem.OrderNo = orderno;
                    orderinfoitem.ShopId = list[0].ShopID;
                    orderinfoitem.UserId = list[0].UserID;
                    orderinfoitem.OrderPoint = zkSum;
                    orderinfoitem.TotalPrice = decSum - zkSum;
                    orderinfoitem.UserTel = L_Mobile.Text;
                    orderinfoitem.UserName = L_Name.Text;
                    orderinfoitem.UserAddress = L_Address.Text + txtAddress.Value;
                    orderinfoitem.AreaId = Convert.ToInt32(hiddenaid.Value);
                    orderinfoitem.Remark = Request["hours"] + ":" + Request["minutes"];
                    orderinfoitem.AddTime = DateTime.Now;
                    if (new OrdersBLL().AddItem(orderinfoitem) > 0)
                    {
                        ModifyTGPoint(list[0].UserID, zkSum, orderinfoitem.AddTime);
                        Session["ShoppingCart"] = null;
                        FastSendToShop(list[0].ShopID, orderinfoitem.TotalPrice.ToString(), str.ToString(), orderinfoitem.Remark);
                        FastSendToUser(L_Mobile.Text, orderinfoitem.TotalPrice.ToString(), str.ToString());
                        Response.Redirect("/Users/");
                    }
                    else
                    {
                        Utils.alert("提交失败!", "shoppingsure.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/");
                }
            }
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
        /// 发送短信（用户）
        /// </summary>
        /// <param name="mobile">用户手机号</param>
        private void FastSendToUser(string mobile, string totalprice, string itemstr)
        {
            string contentstr = Server.UrlEncode(L_ShopName.Text + "：" + itemstr + "；合" + totalprice + "元；电话" + hiddenshoptel.Value);
            string sendurl = "http://www.ums86.com:8899/sms/Api/Send.do?SpCode=001418&LoginName=fz_lx&Password=lx6856&MessageContent=" + contentstr + "&UserNumber=" + mobile + "&SerialNumber=&ScheduleTime=&f=1";

            GetHtmlFromUrl(sendurl);
        }

        /// <summary>
        /// 发送短信（商户）
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="totalprice"></param>
        /// <param name="itemstr"></param>
        private void FastSendToShop(int shopid, string totalprice, string itemstr, string remark)
        {
            string mobile = ubll.GetShopUserMobile(shopid);
            if (!string.IsNullOrEmpty(mobile))
            {
                string contentstr = Server.UrlEncode(L_Address.Text + txtAddress.Value + "；" + itemstr + "；合" + totalprice + "元；" + L_Name.Text + "：" + L_Mobile.Text + "；送达时间：" + remark);
                string sendurl = "http://www.ums86.com:8899/sms/Api/Send.do?SpCode=001418&LoginName=fz_lx&Password=lx6856&MessageContent=" + contentstr + "&UserNumber=" + mobile + "&SerialNumber=&ScheduleTime=&f=1";
               
                GetHtmlFromUrl(sendurl);
            }
        }

        /// <summary>
        /// 短信接口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlFromUrl(string url)
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
