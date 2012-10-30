using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class rechargeorders : BasePage
    {
        RechargeorderBLL bll = new RechargeorderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            WebPager.RecordCount = bll.GetCount(item.Id);
            List<Rechargeorder> list = bll.GetListByuid(WebPager.CurrentPageIndex, WebPager.PageSize, item.Id);
            if (txtorderno.Value != string.Empty)
            {
                list = list.FindAll(delegate(Rechargeorder rc) { return rc.OrderNo.IndexOf(txtorderno.Value.Trim()) > -1; });
            }
            rpt_list.DataSource = list;
            rpt_list.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
