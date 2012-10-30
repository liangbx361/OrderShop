using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class ShopUserList : ManagePage
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
            string username = "";
            string shopname = "";
            if (txtusername.Value != "")
                username = "%" + txtusername.Value + "%";
            if (txtshopname.Value != "")
                shopname = "%" + txtshopname.Value + "%";
            WebPager.RecordCount = bll.GetCount(username, shopname);
            myGrid.DataSource = bll.GetUserList(WebPager.CurrentPageIndex, WebPager.PageSize, username, shopname);
            myGrid.DataBind();
        }

        protected string GetShopName(object shopid)
        {
            return new ShopsBLL().GetShopNameById(Convert.ToInt32(shopid));
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
