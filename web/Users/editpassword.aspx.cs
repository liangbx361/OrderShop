using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Common;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class EditPassWord : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UsersBLL bll = new UsersBLL();
            string oldpass = txt_OldPwd.Value;
            string password = txt_pwd.Value;
            UserInfo item = Session["cudoUser"] as UserInfo;
            if (item.UserPass.CompareTo(Utils.MD5Encrypt32(oldpass)) != 0)
            {
                Utils.alert("原始密码输入错误!", "editpassword.aspx");
            }
            else
            {
                if (bll.UpdatePass(Utils.MD5Encrypt32(password), item.Id) > 0)
                {
                    Utils.alert("修改成功!", "editpassword.aspx");
                }
                else
                {
                    Utils.alert("修改失败!", "editpassword.aspx");
                }
            }
        }
    }
}
