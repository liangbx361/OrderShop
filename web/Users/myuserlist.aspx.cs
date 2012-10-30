using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using System.Data;

namespace web.Users
{
    public partial class myuserlist : BasePage
    {
        UserProfitBLL bll = new UserProfitBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;

            PagedDataSource pdsdata = new PagedDataSource();
            DataSet ds = bll.GetDataSetList(item.Id);
            pdsdata.DataSource = ds.Tables[0].DefaultView;
            pdsdata.AllowPaging = true;
            pdsdata.PageSize = WebPager.PageSize;
            pdsdata.CurrentPageIndex = WebPager.CurrentPageIndex - 1; //设置PagedDataSource的当前页数据（PagedDataSource的页数索引是从0开始）
            WebPager.RecordCount = pdsdata.DataSourceCount;

            decimal xfpointcount = 0;
            decimal sypointcount = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                xfpointcount += Convert.ToDecimal(ds.Tables[0].Rows[i]["xfpoint"]);
                sypointcount += Convert.ToDecimal(ds.Tables[0].Rows[i]["sypoint"]);
            }
            L_xfpointcount.Text = xfpointcount.ToString();
            L_sypointcount.Text = sypointcount.ToString();

            rpt_list.DataSource = pdsdata;
            rpt_list.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
