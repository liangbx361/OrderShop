using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web
{
    public partial class cooperation : BasePage
    {
        protected int Id = 0;
        protected string NewContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = base.GetIntValue("id", Id);
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            NewsBLL bll = new NewsBLL();
            rpt_list.DataSource = bll.GetTopNewList(2, 10);
            rpt_list.DataBind();

            NewInfo item = bll.GetNewItem(Id);
            if (item != null)
                this.NewContent = item.NewContent;
        }
    }
}
