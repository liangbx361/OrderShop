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
    public partial class ShopTypeList : ManagePage
    {
        ShopTypeBLL bll = new ShopTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            rpt_list.DataSource = bll.GetList();
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
                ShopType item = bll.GetItem(id);
                item.TypeName = (e.Item.FindControl("txttypename") as TextBox).Text;
                bll.UpdateItem(item);
            }
            PageInit();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShopType item = new ShopType();
            item.TypeName = txtinpTypeName.Value;
            bll.AddItem(item);
            txtinpTypeName.Value = "";
            PageInit();
        }
    }
}
