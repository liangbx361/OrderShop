using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cudo.Entities;
using Cudo.Business;

namespace web.Shops
{
    public partial class shoporderreport : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            string starttime = txtstartdate.Value;
            string endtime = txtenddate.Value;

            PagedDataSource pdsdata = new PagedDataSource();
            DataSet ds = new OrdersBLL().GetOrderReportListByShopId(item.ShopId, starttime, endtime);
            
            pdsdata.DataSource = ds.Tables[0].DefaultView;
            pdsdata.AllowPaging = true;
            pdsdata.PageSize = WebPager.PageSize;
            pdsdata.CurrentPageIndex = WebPager.CurrentPageIndex - 1; //设置PagedDataSource的当前页数据（PagedDataSource的页数索引是从0开始）
            WebPager.RecordCount = pdsdata.DataSourceCount;

            rpt_list.DataSource = pdsdata;
            rpt_list.DataBind();

            decimal sumprice = 0;
            int ordercount = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ordercount += Convert.ToInt32(ds.Tables[0].Rows[i]["ordercount"]);
                sumprice += Convert.ToDecimal(ds.Tables[0].Rows[i]["sumprice"]);
            }
            L_ordercount.Text = ordercount.ToString();
            L_sumprice.Text = sumprice.ToString();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
