﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class messagelist : ManagePage
    {
        MessageBLL bll = new MessageBLL();
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
            myGrid.DataSource = bll.GetList(WebPager.CurrentPageIndex, WebPager.PageSize);
            myGrid.DataBind();
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
                bll.DeleteItem(Convert.ToInt32(e.CommandArgument));
            }
            PageInit();
        }
    }
}
