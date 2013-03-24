using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.Users
{
    public partial class pointdetail : BasePage
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
            WebPager.RecordCount = bll.GetCountByStatus(item.Id);
            List<OrderInfo> orderList = bll.GetListByStauts(WebPager.CurrentPageIndex, WebPager.PageSize, item.Id);
            rpt_list.DataSource = orderList;
            rpt_list.DataBind();
        }

        protected int getOrderPoint(object orderPoint)
        {
            return Convert.ToInt32(orderPoint);
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}