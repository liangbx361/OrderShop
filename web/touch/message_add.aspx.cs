using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class message_add : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            rpt_list.DataSource = new UsersBLL().GetUserList();
            rpt_list.DataBind();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string[] idlist = hidden_ids.Value.Split(',');
            string[] namelist = txt_names.Value.Split(';');
            string title = txt_title.Value;
            string content = txt_content.Value;
            for (int i = 0; i < idlist.Length - 1; i++)
            {
                MessageInfo item = new MessageInfo();
                item.Title = title;
                item.MsgContent = content;
                item.UserId = Convert.ToInt32(idlist[i]);
                item.UserName = namelist[i];
                new MessageBLL().AddItem(item);
            }
            base.ErrorMsg("发送成功", "messagelist.aspx", 1);
        }
    }
}
