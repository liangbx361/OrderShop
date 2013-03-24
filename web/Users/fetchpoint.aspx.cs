using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.Users
{
    public partial class fetchpoint : BasePage
    {
        OrdersBLL bll = new OrdersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            WebPager.RecordCount = bll.GetCountByPoint(item.Id);
            List<OrderInfo> orderList = bll.GetListByPoint(WebPager.CurrentPageIndex, WebPager.PageSize, item.Id);
            rpt_list.DataSource = orderList;
            rpt_list.DataBind();
        }

        private void filterList(List<OrderInfo> list)
        {
            
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected int getOrderPoint(object orderPoint)
        {
            return Convert.ToInt32(orderPoint);
        }

        protected string getFetchButton(object orderNo)
        {
            string result = "";

            OrderInfo orderItem = new OrdersBLL().GetItem(Convert.ToString(orderNo));
            TimeSpan timeSub = DateTime.Now - orderItem.AddTime;

            if (orderItem.OrderStatus == 2)
            {
                result = "";
            }
            else if (timeSub.Days >= 1)
            {
                result = "";
            }
            else
            {
                result = "";
            }

            return result;
        }

        /**
         * 判断是否能提取积分
         * 交易状态显示为已完成,则可提示积分
         */
        protected string isAbleGetPoint(object orderNo)
        {
            string result = "";

            OrderInfo orderItem = new OrdersBLL().GetItem(Convert.ToString(orderNo));
            TimeSpan timeSub = DateTime.Now - orderItem.AddTime;

            if (orderItem.OrderStatus == 2)
            {
                result = "积分可提取";
            }
            else if (timeSub.Days >= 1)
            {
                result = "积分可提取";
            }
            else
            {
                result = "积分不可提取";
            }

            return result;
        }

        protected void fetchPointClick(object sender, EventArgs e)
        {
            Utils.alert("提取成功", "");
        }

        protected void rp_itemcommand(object sender, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "fetch_point":
                    string orderNo = Convert.ToString(e.CommandArgument);
                    fetchPoint(orderNo);
                    //Utils.alert("提取成功", "");
                    break;
            }
        }

        /// <summary>
        /// 提取当前订单积分
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="?"></param>
        private void fetchPoint(string orderNo)
        {
            OrdersBLL orderbll = new OrdersBLL();
            OrderInfo orderItem = orderbll.GetItem(Convert.ToString(orderNo));
            orderbll.UpdateItem(4, orderItem.Id);

            UsersBLL ubll = new UsersBLL();
            ubll.UpdatePoint(orderItem.OrderPoint, orderItem.UserId);



            PageInit();
        }
    }
}