using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class shopcommentlist : ManagePage
    {
        ShopCommentBLL bll = new ShopCommentBLL();
        private int ShopId = 0;
        protected string ShopName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopId = base.GetIntValue("shopid");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            ShopName = new ShopsBLL().GetShopNameById(ShopId);

            WebPager.RecordCount = bll.GetCountByShopId(ShopId, 0);
            myGrid.DataSource = bll.GetShopCommentsByShopId(WebPager.CurrentPageIndex, WebPager.PageSize, ShopId, 0);
            myGrid.DataBind();
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
                bll.DeleteShopComment(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "chk")
            {
                bll.UpdateShopComment(Convert.ToInt32(e.CommandArgument), 2);
            }
            if (e.CommandName == "unchk")
            {
                bll.UpdateShopComment(Convert.ToInt32(e.CommandArgument), 1);
            }
            PageInit();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridItem item in myGrid.Items)
            {
                //循环判断是否选中，选中则获取id
                CheckBox cb = (CheckBox)item.Cells[1].FindControl("chkdg");
                if (cb.Checked)
                {
                    bll.UpdateShopComment(Convert.ToInt32(item.Cells[0].Text), 2);
                }
            }
            PageInit();
        }

        protected void btnUnCheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridItem item in myGrid.Items)
            {
                //循环判断是否选中，选中则获取id
                CheckBox cb = (CheckBox)item.Cells[1].FindControl("chkdg");
                if (cb.Checked)
                {
                    bll.UpdateShopComment(Convert.ToInt32(item.Cells[0].Text), 1);
                }
            }
            PageInit();
        }
    }
}
