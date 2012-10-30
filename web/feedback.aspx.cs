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
    public partial class feedback : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpt_list.DataSource = new NewsBLL().GetTopNewList(3, 10);
                rpt_list.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FeedBack item = new FeedBack();
            item.UserName = txtusername.Value;
            item.Subject = txtsubject.Value;
            item.Content = txtcontent.Value;

            if (new FeedBackBLL().AddItem(item) > 0)
            {
                Utils.alert("提交成功!", "feedback.aspx");
            }
            else
            {
                Utils.alert("提交成功!", "feedback.aspx");
            }
        }
    }
}
