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
    public partial class UsersEdit : ManagePage
    {
        UsersBLL bll = new UsersBLL();
        private int Id = 0;
        protected string UserName = string.Empty;
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
                this.UserName = item.UserName;
                txtNickName.Value = item.NickName;
                txtBirthday.Value = item.Birthday;
                txtMobile.Value = item.Mobile;
                txtEmail.Value = item.Email;
                txtAddress.Value = item.Address.Split('|')[1];
                txtPoint.Value = item.CurrentPoint.ToString();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            UserInfo item = bll.GetUserByID(Id);
            item.NickName = txtNickName.Value;
            item.Mobile = txtMobile.Value;
            item.Email = txtEmail.Value;
            item.Birthday = txtBirthday.Value;
            if (bll.UpdateUser(item) > 0)
            {
                bll.UpdatePoint(Convert.ToDecimal(txtPoint.Value), item.Id);
                base.ErrorMsg("提交成功!", "UsersList.aspx", 1);
            }
            else
            {
                base.ErrorMsg("提交失败!", "UsersList.aspx", 1);
            }
        }
    }
}
