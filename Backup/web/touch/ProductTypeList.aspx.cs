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
    public partial class ProductTypeList : ManagePage
    {
        ProductTypeBLL bll = new ProductTypeBLL();
        private int shopid = 0;
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
            ShopName = new ShopsBLL().GetShopNameById(shopid);

            rpt_list.DataSource = bll.GetListByShopId(shopid);
            rpt_list.DataBind();
        }

        protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteItem(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProductType item = bll.GetItem(id);
                item.TypeName = (e.Item.FindControl("txttypename") as TextBox).Text;
                bll.UpdateItem(item);
            }
            PageInit();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductType item = new ProductType();
            item.ShopId = shopid;
            item.TypeName = txtinpTypeName.Value;
            bll.AddItem(item);
            txtinpTypeName.Value = "";
            PageInit();
        }
    }
}
