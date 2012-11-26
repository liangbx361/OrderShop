using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;

namespace web.touch
{
    public partial class OrderDetails : ManagePage
    {
        protected string remark;

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderno = base.GetStringValue("orderno");
            rp_OrderList.DataSource = new OrderItemBLL().GetList(orderno);
            rp_OrderList.DataBind();

            remark = new OrderItemBLL().GetRemark(orderno);
        }
    }
}
