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
    public partial class ShopProductList : ManagePage
    {
        ProductsBLL bll = new ProductsBLL();
        protected int shopid = 0;
        protected string ShopName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = base.GetIntValue("shopid");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            this.ShopName = new ShopsBLL().GetShopNameById(shopid);

            WebPager.RecordCount = bll.GetCount(shopid);
            myGrid.DataSource = bll.GetListByShopId(WebPager.CurrentPageIndex, WebPager.PageSize, shopid);
            myGrid.DataBind();
        }

        protected string GetTypeNameById(object typeid)
        {
            return new ProductTypeBLL().GetTypeNameById(Convert.ToInt32(typeid));
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

        protected void lbtnDelAll_Click(object sender, EventArgs e)
        {
            #region 批量删除
            foreach (DataGridItem item in myGrid.Items)
            {
                //循环判断是否选中，选中则获取id
                CheckBox cb = (CheckBox)item.Cells[1].FindControl("chkdg");
                if (cb.Checked)
                {
                    bll.DeleteItem(Convert.ToInt32(item.Cells[0].Text));
                }
            }
            PageInit();
            #endregion
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
