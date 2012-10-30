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
    public partial class ShopProductAdd : ManagePage
    {
        private int shopid = 0;
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
            ddl_shoptype.DataSource = new ProductTypeBLL().GetListByShopId(shopid);
            ddl_shoptype.DataValueField = "Id";
            ddl_shoptype.DataTextField = "TypeName";
            ddl_shoptype.DataBind();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        { 
            ProductsBLL bll =new ProductsBLL();
            if (bll.CheckProductName(shopid, txtProductName.Value) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('菜品名称已存在')", true);
            }
            else
            {
                Product item = new Product();
                item.ShopId = shopid;
                item.TypeId = Convert.ToInt32(ddl_shoptype.SelectedValue);
                item.ProductName = txtProductName.Value;
                item.Price = Convert.ToDecimal(txtPrice.Value);
                item.Price2 = Convert.ToDecimal(txtPrice2.Value);
                item.ImgSrc = txtImgSrc.Value;
                item.SortId = 1;
                item.SellStatus = 1;
                if (new ProductsBLL().AddItem(item) > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('添加成功')", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('添加失败')", true);
                }
            }
        }
    }
}
