using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using System.Net;
using System.IO;
using System.Text;

namespace web.Users
{
    public partial class orderinfo : BasePage
    {
        protected string orderno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderno = base.GetStringValue("orderno");
            PageInit();
        }

        private void PageInit()
        {
            OrderInfo item = new OrdersBLL().GetItem(orderno);
            if (item != null)
            {
                L_OrderTime.Text = item.AddTime.ToString();
                L_Address.Text = item.UserAddress;
                L_UserName.Text = item.UserName;
                L_Phone.Text = item.UserTel;
                L_OrderPrice.Text = item.TotalPrice.ToString();
                L_SumPrice.Text = item.TotalPrice.ToString();

                int ordercount = 0;
                List<OrderItem> list = new OrderItemBLL().GetList(orderno);
                foreach (OrderItem temp in list)
                {
                    ordercount += temp.BuyNum;
                }
                L_OrderCount.Text = ordercount.ToString();

                rpt_list.DataSource = list;
                rpt_list.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();  //餐品内容
            OrderInfo item = new OrdersBLL().GetItem(orderno);
            Shop shopinfo = new ShopsBLL().GetShopItem(item.ShopId);
            List<OrderItem> list = new OrderItemBLL().GetList(orderno);
            foreach (OrderItem temp in list)
            {
                str.Append(temp.ProductName + "(" + temp.BuyNum + ") ");
            }
            string contentstr = Server.UrlEncode(shopinfo.ShopName + "：" + str.ToString() + "；合" + item.TotalPrice + "元；电话" + shopinfo.Phone);
            string sendurl = "http://www.ums86.com:8899/sms/Api/Send.do?SpCode=001418&LoginName=fz_lx&Password=lx6856&MessageContent=" + contentstr + "&UserNumber=" + item.UserTel + "&SerialNumber=&ScheduleTime=&f=1";
            GetHtmlFromUrl(sendurl);

            Response.Write("<script>window.parent.tb_remove();</script>");
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
