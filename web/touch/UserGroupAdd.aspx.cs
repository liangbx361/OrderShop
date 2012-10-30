using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class UserGroupAdd : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            UserGroup item = new UserGroup();
            item.GroupName = txtGroupName.Value;
            item.Zk = Convert.ToInt32(txtZK.Value);
            if (new UserGroupBLL().AddItem(item) > 0)
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
