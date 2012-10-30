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
    public partial class admin_user_AE : ManagePage
    {
        AdminUserBLL AdminUserBiz = new AdminUserBLL();
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            if (Id > 0)
            {
                txtuserName.Text = AdminUserBiz.GetUserNameById(Id);
                txtuserName.BackColor = System.Drawing.Color.BlanchedAlmond;
                txtuserName.ReadOnly = true;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string password = Utils.MD5Encrypt32(Utils.MD5Encrypt32(Utils.MD5Encrypt32(txtpassword.Text)));
            AdminUser User = new AdminUser();
            User.UserName = Filter.AllFilter(txtuserName.Text.Trim());
            User.UserPwd = password;
            User.LastLoginTime = DateTime.Now;

            if (Id == 0)
            {
                //添加
                int UserID = AdminUserBiz.AddAdminUser(User);
                if (UserID > 0)
                {
                    AdminUserBiz.AddUserRole(string.Empty, UserID);
                    Response.Write("<script>self.parent.tb_remove();</script>");
                }
                else
                {
                    Response.Write("<script>self.parent.tb_remove();</script>");
                }
            }
            else
            {
                if (txtpassword.Text != string.Empty)
                    AdminUserBiz.UpdateUser(Id, password, true);
                Response.Write("<script>self.parent.tb_remove();</script>");
            }
        }
    }
}
