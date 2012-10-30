using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class UserGroupEdit :ManagePage
    {
        UserGroupBLL bll = new UserGroupBLL();
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
            UserGroup item = bll.GetItemById(id);
            if (item != null)
            {
                txtGroupName.Value = item.GroupName;
                txtZK.Value = item.Zk.ToString();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            UserGroup item = bll.GetItemById(id);
            item.GroupName = txtGroupName.Value;
            item.Zk = Convert.ToInt32(txtZK.Value);
            if (bll.UpdateItem(item) > 0)
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
