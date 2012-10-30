using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class mycommentlist : BasePage
    {
        ShopCommentBLL bll = new ShopCommentBLL();
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
            WebPager.RecordCount = bll.GetCountByUserId(item.Id);
            rpt_list.DataSource = bll.GetShopCommentsByUserId(WebPager.CurrentPageIndex, WebPager.PageSize, item.Id);
            rpt_list.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteShopComment(Convert.ToInt32(e.CommandArgument));
            }
            PageInit();
        }
    }
}
