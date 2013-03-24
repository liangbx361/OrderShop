using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class accountmanagement : BasePage
    {
        protected UserInfo item;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            item = Session["cudoUser"] as UserInfo;

            UsersBLL ubll = new UsersBLL();
            item = ubll.GetUserByID(item.Id);
        }
    }
}
