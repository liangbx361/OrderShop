using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class UsersList : ManagePage
    {
        UsersBLL bll = new UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            WebPager.RecordCount = bll.GetCount(0);
            List<UserInfo> list = bll.GetUserList(WebPager.CurrentPageIndex, WebPager.PageSize, 0);
            if (txtusername.Value != "")
                list = list.FindAll(delegate(UserInfo info) { return info.UserName.IndexOf(txtusername.Value.Trim()) > -1; });
            if (txtmobile.Value != "")
                list = list.FindAll(delegate(UserInfo info) { return info.Mobile == txtmobile.Value.Trim(); });
            myGrid.DataSource = list;
            myGrid.DataBind();
        }

        protected string GetGroupName(object groupid)
        {
            return new UserGroupBLL().GetItemById(Convert.ToInt32(groupid)).GroupName;
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected override void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            base.myGrid_ItemCreated(sender, e);
        }

        protected void myGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteUser(Convert.ToInt32(e.CommandArgument));
            }
            PageInit();
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
