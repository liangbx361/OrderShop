using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            List<OrderInfo> list = new OrdersBLL().GetListByUserId(1, 10, item.Id);
            rpt_list.DataSource = list.FindAll(delegate(OrderInfo ca) { return ca.AddTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"); });
            rpt_list.DataBind();
        }

        protected string GetShopName(object shopid)
        {
            return new ShopsBLL().GetShopNameById(Convert.ToInt32(shopid));
        }
    }
}
