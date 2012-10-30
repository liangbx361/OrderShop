using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.touch
{
    public partial class ShopUserEdit : ManagePage
    {
        UsersBLL bll = new UsersBLL();
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = bll.GetUserByID(Id);
            if (item != null)
            {
                txtshopname.Value = new ShopsBLL().GetShopItem(item.ShopId).ShopName;
                txtMobile.Value = item.Mobile;
                txtEmail.Value = item.Email;
                txtNickName.Value = item.NickName;
                txtUserName.Value = item.UserName;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserInfo item = bll.GetUserByID(Id);
            if (txtpassword.Value != "")
                item.UserPass = Utils.MD5Encrypt32(txtpassword.Value);
            item.NickName = txtNickName.Value;
            item.Mobile = txtMobile.Value;
            item.Email = txtEmail.Value;

            if (new UsersBLL().UpdateUser(item) > 0)
                base.ErrorMsg("修改成功", "ShopUserList.aspx", 1);
            else
                base.ErrorMsg("修改成功", "ShopUserList.aspx", 0);
        }
    }
}
