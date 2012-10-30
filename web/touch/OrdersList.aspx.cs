using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class OrdersList : ManagePage
    {
        OrdersBLL bll = new OrdersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            List<OrderInfo> list = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize);
            if (txtorderno.Value != "")
            {
                list = list.FindAll(delegate(OrderInfo info) { return info.OrderNo.IndexOf(txtorderno.Value.Trim()) > -1; });
            }
            if (txtmobile.Value != "")
            {
                list = list.FindAll(delegate(OrderInfo info) { return info.UserTel.IndexOf(txtmobile.Value.Trim()) > -1; });
            }
            if (ddl_orderstatus.SelectedValue != "")
            {
                list = list.FindAll(delegate(OrderInfo info) { return info.OrderStatus == int.Parse(ddl_orderstatus.SelectedValue); });
            }

            WebPager.RecordCount = bll.GetCount();
            myGrid.DataSource = list;
            myGrid.DataBind();
        }

        protected string ShopOrderStatus(object status)
        {
            string result = "";
            switch (status.ToString())
            {
                case "0": result = "未处理"; break;
                case "1": result = "处理中"; break;
                case "2": result = "已完成"; break;
                case "3": result = "作废"; break;
                default: break;
            }
            return result;
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
                bll.DeleteItem(e.CommandArgument.ToString());
            if (e.CommandName == "handle")
                bll.UpdateItem(1, Convert.ToInt32(e.CommandArgument));
            if (e.CommandName == "fins")
                bll.UpdateItem(2, Convert.ToInt32(e.CommandArgument));
            if (e.CommandName == "invalid")
                bll.UpdateItem(3, Convert.ToInt32(e.CommandArgument));
            PageInit();
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void myGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal li = e.Item.FindControl("L_OrderStatus") as Literal;
                LinkButton btnhandle = e.Item.FindControl("btnhandle") as LinkButton;
                LinkButton btninvalid = e.Item.FindControl("btninvalid") as LinkButton;
                LinkButton btnfins = e.Item.FindControl("btnfins") as LinkButton;

                if (li.Text == "1")
                    btnhandle.Visible = false;
                if (li.Text == "2" || li.Text == "3")
                {
                    btnhandle.Visible = false;
                    btnfins.Visible = false;
                    btninvalid.Visible = false;
                }
            }
        }
    }
}
