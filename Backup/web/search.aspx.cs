using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;
using System.Data;

namespace web
{
    public partial class search : BasePage
    {
        ShopsBLL bll = new ShopsBLL();
        private string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            keywords = Server.UrlDecode(base.GetStringValue("keyword", keywords));
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            PagedDataSource pdsdata = new PagedDataSource();
            DataSet ds = bll.GetListByKeyword(keywords);

            pdsdata.DataSource = ds.Tables[0].DefaultView;
            pdsdata.AllowPaging = true;
            pdsdata.PageSize = WebPager.PageSize;
            pdsdata.CurrentPageIndex = WebPager.CurrentPageIndex - 1; //设置PagedDataSource的当前页数据（PagedDataSource的页数索引是从0开始）
            WebPager.RecordCount = pdsdata.DataSourceCount;

            rpt_shoplist.DataSource = pdsdata;
            rpt_shoplist.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
