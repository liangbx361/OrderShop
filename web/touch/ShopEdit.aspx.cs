using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.admin
{
    public partial class ShopEdit : ManagePage
    {
        ShopsBLL bll = new ShopsBLL();
        private int ShopId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopId = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            ddl_type.DataSource = new ShopTypeBLL().GetList();
            ddl_type.DataValueField = "Id";
            ddl_type.DataTextField = "TypeName";
            ddl_type.DataBind();
            ddl_type.Items.Insert(0, new ListItem("-请选择-", "0"));

            Shop ShopItem = bll.GetShopItem(ShopId);
            if (ShopItem != null)
            {
                ddl_type.SelectedValue = ShopItem.ShopType.ToString();
                txtShopName.Value = ShopItem.ShopName;
                txtPhone.Value = ShopItem.Phone;
                txtAddress.Value = ShopItem.Address;
                txtOpenTime.Value = ShopItem.OpenTime;
                txtSendTime.Value = ShopItem.SendTime.ToString();
                txtSendPrice.Value = ShopItem.SendPrice.ToString();
                txtLimit.Value = ShopItem.LimitPrice.ToString();
                txtIntro.Value = ShopItem.Intro;
                txtShopPic.Value = ShopItem.ShopPic;
                txtzk.Value = ShopItem.zk.ToString();
                ShopPic.ImageUrl = "~/" + ShopItem.ShopPic;
                string[] ordertime = ShopItem.OrderTime.Split('|');
                txtamtime.Value = ordertime[0];
                txtpmtime.Value = ordertime[1];
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Shop ShopItem = bll.GetShopItem(ShopId);
            string shopname = txtShopName.Value;
            if (bll.CheckShopByShopName(shopname) > 0 && ShopItem.ShopName != shopname)
            {
                Utils.alert("已存在店铺名称!", "ShopEdit.aspx?id=" + ShopId);
                return;
            }
            else
            {
                ShopItem.ShopType = Convert.ToInt32(ddl_type.SelectedValue);
                ShopItem.ShopName = shopname; //名称
                ShopItem.Phone = txtPhone.Value; //电话
                ShopItem.Address = txtAddress.Value; //地址
                ShopItem.OpenTime = txtOpenTime.Value; //营业时间
                ShopItem.OrderTime = txtamtime.Value + "|" + txtpmtime.Value;
                ShopItem.ShopPic = txtShopPic.Value; //店铺图片
                ShopItem.SendTime = Convert.ToInt32(txtSendTime.Value); //送货时间
                ShopItem.SendPrice = Convert.ToDecimal(txtSendPrice.Value); //配送费用
                ShopItem.LimitPrice = Convert.ToDecimal(txtLimit.Value); //起送限制
                ShopItem.zk = Convert.ToInt32(txtzk.Value);
                ShopItem.Intro = txtIntro.Value;
                if (bll.UpdateShop(ShopItem) > 0)
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
