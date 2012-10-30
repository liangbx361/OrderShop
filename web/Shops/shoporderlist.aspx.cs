using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.Shops
{
    public partial class shoporderlist : BasePage
    {
        OrdersBLL bll = new OrdersBLL();
        private string date = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            date = base.GetStringValue("date");
            base.IsLogin();
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            ddl_district.DataSource = new AreaBLL().GetListByShopId(item.ShopId);
            ddl_district.DataValueField = "Id";
            ddl_district.DataTextField = "AreaName";
            ddl_district.DataBind();
            ddl_district.Items.Insert(0, new ListItem("-请选择-", ""));

            OrderInit();
        }

        private void OrderInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            WebPager.RecordCount = bll.GetCountByShopId(item.ShopId);
            List<OrderInfo> list = bll.GetListByShopId(WebPager.CurrentPageIndex, WebPager.PageSize, item.ShopId);
            list = list.FindAll(delegate(OrderInfo info) { return info.AddTime.ToString("yyyy-MM-dd") == (date != string.Empty ? date : DateTime.Now.ToString("yyyy-MM-dd")); });
            if (ddl_district.SelectedValue != "")
            {
                list = list.FindAll(delegate(OrderInfo info) { return info.AreaId == int.Parse(ddl_district.SelectedValue); });
            }
            if (ddl_orderstatus.SelectedValue != "")
            {
                list = list.FindAll(delegate(OrderInfo info) { return info.OrderStatus == int.Parse(ddl_orderstatus.SelectedValue); });
            }

            rpt_list.DataSource = list;
            rpt_list.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            OrderInit();
        }

        protected string ShopOrderStatus(object status)
        {
            string result = "";
            switch (status.ToString())
            {
                case "0": result = "<font color='#FF0000'>未处理</font>"; break;
                case "1": result = "<font color='#0000FF'>处理中</font>"; break;
                case "2": result = "<font color='#66FF66'>已完成</font>"; break;
                case "3": result = "作废"; break;
                default: break;
            }
            return result;
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            OrderInit();
        }

        protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "handle")
                bll.UpdateItem(1, Convert.ToInt32(e.CommandArgument));
            if (e.CommandName == "fins")
                bll.UpdateItem(2, Convert.ToInt32(e.CommandArgument));
            if(e.CommandName == "invalid")
                bll.UpdateItem(3, Convert.ToInt32(e.CommandArgument));
            PageInit();
        }

        protected void rpt_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
