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
    public partial class ShopAdd : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            ddl_type.DataSource = new ShopTypeBLL().GetList();
            ddl_type.DataValueField = "Id";
            ddl_type.DataTextField = "TypeName";
            ddl_type.DataBind();
            ddl_type.Items.Insert(0, new ListItem("-请选择-", "0"));
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string shopname = txtShopName.Value;
            if (new ShopsBLL().CheckShopByShopName(shopname) > 0)
            {
                Utils.alert("已存在店铺名称!", "ShopAdd.aspx");
                return;
            }
            else
            {
                Shop item = new Shop();
                item.ShopType = Convert.ToInt32(ddl_type.Text);
                item.ShopName = shopname; //名称
                item.ShopPic = txtShopPic.Value; //店铺图片
                item.Phone = txtPhone.Value; //电话
                item.Address = txtAddress.Value; //地址
                item.OpenTime = txtOpenTime.Value; //营业时间
                item.OrderTime = txtamtime.Value + "|" + txtpmtime.Value;
                item.SendTime = Convert.ToInt32(txtSendTime.Value); //送货时间
                item.SendPrice = Convert.ToDecimal(txtSendPrice.Value); //配送费用
                item.LimitPrice = Convert.ToDecimal(txtLimitPrice.Value); //起送费
                item.zk = Convert.ToInt32(txtzk.Value);
                item.Payment = txtPayment.Value;
                item.Intro = txtIntro.Value;
                if (new ShopsBLL().AddShop(item) > 0)
                {
                    base.ErrorMsg("提交成功！", "ShopList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "ShopList.aspx", 0);
                }
            }
        }
    }
}
