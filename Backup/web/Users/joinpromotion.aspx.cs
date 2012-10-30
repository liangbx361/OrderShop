using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Users
{
    public partial class joinpromotion : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
        }
    }
}
