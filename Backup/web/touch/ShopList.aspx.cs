using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.touch
{
    public partial class ShopList : ManagePage
    {
        ShopsBLL bll = new ShopsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TypeInit();
                PageInit();
            }
        }

        private void TypeInit()
        {
            ddltype.DataSource = new ShopTypeBLL().GetList();
            ddltype.DataValueField = "Id";
            ddltype.DataTextField = "TypeName";
            ddltype.DataBind();
            ddltype.Items.Insert(0, new ListItem("-请选择-", ""));
        }

        private void PageInit()
        {
            WebPager.RecordCount = bll.GetCount();
            List<Shop> list = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize);
            if (txtshopname.Value != "")
            {
                list = list.FindAll(delegate(Shop info) { return info.ShopName.IndexOf(txtshopname.Value.Trim()) > -1; });
            }
            if (ddltype.SelectedIndex != 0)
            {
                list = list.FindAll(delegate(Shop info) { return info.ShopType==int.Parse(ddltype.SelectedValue); });
            }
            myGrid.DataSource = list;
            myGrid.DataBind();
        }

        protected string GetShopType(object ShopType)
        {
            return new ShopTypeBLL().GetTypeNameById(Convert.ToInt32(ShopType));
        }

        protected override void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            base.myGrid_ItemCreated(sender, e);
        }

        protected void myGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int shopid = Convert.ToInt32(e.CommandArgument);
                bll.DeleteShop(shopid);
                HiddenField hf_img = e.Item.Cells[2].FindControl("hf_img") as HiddenField;
                FileOperate.DeleteFile(Server.MapPath("~/" + hf_img.Value));
            }
            PageInit();
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            #region 批量删除
            List<string> ListID = new List<string>();
            foreach (DataGridItem item in myGrid.Items)
            {
                //循环判断是否选中，选中则获取id
                CheckBox cb = (CheckBox)item.Cells[1].FindControl("chkdg");
                if (cb.Checked)
                {
                    int shopid = Convert.ToInt32(item.Cells[0].Text);
                    bll.DeleteShop(Convert.ToInt32(shopid));
                    HiddenField hf_img = item.Cells[2].FindControl("hf_img") as HiddenField;
                    FileOperate.DeleteFile(Server.MapPath("~/" + hf_img.Value));
                }
            }
            PageInit();
            #endregion
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
