using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class messageinfo : BasePage
    {
        private int Id = 0;
        protected string Subject = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            Id = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            MessageBLL bll = new MessageBLL();
            MessageInfo item = bll.GetItem(Id);
            if (item != null)
            {
                this.Subject = item.MsgContent;
                bll.UpdateItem(Id);
            }
        }
    }
}
