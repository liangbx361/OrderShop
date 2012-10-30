using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class mymessagelist : BasePage
    {
        MessageBLL bll = new MessageBLL();
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
            UserInfo uinfo = Session["cudoUser"] as UserInfo;
            WebPager.RecordCount = bll.GetCount(uinfo.Id);
            rpt_list.DataSource = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize, uinfo.Id);
            rpt_list.DataBind();
        }

        protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
                bll.DeleteItem(Convert.ToInt32(e.CommandArgument));
            PageInit();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
