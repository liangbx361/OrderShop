using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Users
{
    public partial class accountmanagement : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
        }
    }
}
