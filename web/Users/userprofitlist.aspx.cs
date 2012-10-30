using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class userprofitlist : BasePage
    {
        UserProfitBLL bll = new UserProfitBLL();
        private int uid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = base.GetIntValue("uid");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            WebPager.RecordCount = bll.GetCount(uid);
            rpt_list.DataSource = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize, uid);
            rpt_list.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
