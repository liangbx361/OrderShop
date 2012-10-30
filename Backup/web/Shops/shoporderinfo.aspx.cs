using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Shops
{
    public partial class shoporderinfo : BasePage
    {
        protected string orderno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
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
                L_SendTime.Text = item.Remark;

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
    }
}
