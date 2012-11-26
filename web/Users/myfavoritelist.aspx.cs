using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class myfavoritelist : BasePage
    {
        FavoritesBLL bll = new FavoritesBLL();
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
            WebPager.RecordCount = bll.GetCount(item.Id, item.Utype);
            rpt_list.DataSource = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize, item.Id, item.Utype);
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
                bll.DeleteItem(Convert.ToInt32(e.CommandArgument));
            }
            PageInit();
        }

        protected void btndeleteall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rpt_list.Items.Count; i++)
            {
                int id = Convert.ToInt32(((LinkButton)rpt_list.Items[i].FindControl("lbtn_delete")).CommandArgument);
                CheckBox cb = (CheckBox)rpt_list.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    bll.DeleteItem(id);
                }
            }
            PageInit();
        }
    }
}
