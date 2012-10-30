using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class rechargeorderlist : ManagePage
    {
        RechargeorderBLL bll = new RechargeorderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            WebPager.RecordCount = bll.GetCount();
            List<Rechargeorder> list = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize);
            if (txtorderno.Value != "")
            {
                list = list.FindAll(delegate(Rechargeorder info) { return info.OrderNo.IndexOf(txtorderno.Value.Trim()) > -1; });
            }
            if (txtusername.Value != "")
            {
                list = list.FindAll(delegate(Rechargeorder info) { return info.UserName.IndexOf(txtusername.Value.Trim()) > -1; });
            }
            if (txtprice.Value != "")
            {
                list = list.FindAll(delegate(Rechargeorder info) { return info.OrderPrice == Convert.ToDecimal(txtprice.Value.Trim()); });
            }
            myGrid.DataSource = list;
            myGrid.DataBind();
        }

        protected string GetUserName(object userid)
        {
            return new UsersBLL().GetUserNameByuid(Convert.ToInt32(userid));
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected override void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            base.myGrid_ItemCreated(sender, e);
        }

        protected void myGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string orderno = e.CommandArgument.ToString();
                bll.DeleteItem(orderno);
            }
            PageInit();
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
