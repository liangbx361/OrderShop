using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;

namespace web.touch
{
    public partial class UserGroupList : ManagePage
    {
        UserGroupBLL bll = new UserGroupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            myGrid.DataSource = bll.GetList();
            myGrid.DataBind();
        }

        protected override void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            base.myGrid_ItemCreated(sender, e);
        }

        protected void myGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteItem(Convert.ToInt32(e.CommandArgument));
            }
            PageInit();
        }
    }
}
