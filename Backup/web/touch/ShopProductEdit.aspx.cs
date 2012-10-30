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
    public partial class ShopProductEdit : ManagePage
    {
        ProductsBLL bll = new ProductsBLL();
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = base.GetIntValue("id");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            Product item = bll.GetItem(id);
            if (item != null)
            {
                txtProductName.Value = item.ProductName;
                ddl_shoptype.DataSource = new ProductTypeBLL().GetListByShopId(item.ShopId);
                ddl_shoptype.DataValueField = "Id";
                ddl_shoptype.DataTextField = "TypeName";
                ddl_shoptype.DataBind();
                ddl_shoptype.SelectedValue = item.TypeId.ToString();
                txtPrice.Value = item.Price.ToString();
                txtPrice2.Value = item.Price2.ToString();
                txtImgSrc.Value = item.ImgSrc;
                ProImgSrc.ImageUrl = "~/" + item.ImgSrc;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Product item = bll.GetItem(id);
            item.TypeId = Convert.ToInt32(ddl_shoptype.SelectedValue);
            item.ProductName = txtProductName.Value;
            item.Price = Convert.ToDecimal(txtPrice.Value);
            item.Price2 = Convert.ToDecimal(txtPrice2.Value);
            item.ImgSrc = txtImgSrc.Value;
            if (new ProductsBLL().UpdateItem(item) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('修改成功')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('修改失败')", true);
            }
        }
    }
}
