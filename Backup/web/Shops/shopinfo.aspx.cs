using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Shops
{
    public partial class shopinfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;

            Shop shopitem = new ShopsBLL().GetShopItem(item.ShopId);
            if (shopitem != null)
            {
                shopname.Value = shopitem.ShopName;
                address.Value = shopitem.Address;
                phone.Value = shopitem.Phone;
                intro.Value = shopitem.Intro;
            }
        }
    }
}
