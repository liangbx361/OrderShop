using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInit();
        }

        private void PageInit()
        {
            ltl_copyright.Text = new BasePage().webset.WebCopyright;

            NewsBLL bll = new NewsBLL();
            rpt_about.DataSource = bll.GetTopNewList(3,10);
            rpt_about.DataBind();
            rpt_hz.DataSource = bll.GetTopNewList(2, 10);
            rpt_hz.DataBind();
            rpt_help.DataSource = bll.GetTopNewList(1, 10);
            rpt_help.DataBind();
        }
    }
}