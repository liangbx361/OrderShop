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
    public partial class busecooperation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpt_list.DataSource = new NewsBLL().GetTopNewList(2, 10);
                rpt_list.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Cooperation item = new Cooperation();
            item.ShopName = txtshopname.Value;
            item.UserName = txtusername.Value;
            item.Phone = txtphone.Value;
            item.Address = txtaddress.Value;

            if (new CooperationBLL().AddItem(item) > 0)
            {
                Utils.alert("提交成功!", "busecooperation.aspx");
            }
            else
            {
                Utils.alert("提交失败!", "busecooperation.aspx");
            }
        }
    }
}
