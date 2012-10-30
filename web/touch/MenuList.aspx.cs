using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class MenuList : ManagePage
    {
        MenuBLL bll = new MenuBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
                PageInit();
            }
        }

        private void PageInit()
        {
            if (ddl_menu.SelectedValue != "-1")
            {
                int parentid = Convert.ToInt32(ddl_menu.SelectedValue);
                WebPager.RecordCount = bll.GetCount(parentid);
                myGrid.DataSource = bll.GetMenuList(parentid, WebPager.CurrentPageIndex, WebPager.PageSize);
                myGrid.DataBind();
            }
            else
            {
                WebPager.RecordCount = bll.GetCount();
                myGrid.DataSource = bll.GetMenuList(WebPager.CurrentPageIndex, WebPager.PageSize);
                myGrid.DataBind();
            }
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }

        private void BindCategory()
        {
            List<MenuInfo> list = bll.GetMenuList(0);
            ddl_menu.DataValueField = "Id";
            ddl_menu.DataTextField = "MenuName";
            ddl_menu.DataSource = list;
            ddl_menu.DataBind();
            ddl_menu.Items.Insert(0, new ListItem("全部", "-1"));
            ddl_menu.Items.Insert(1, new ListItem("一级菜单", "0"));
        }

        protected string GetMenuNameByID(object id)
        {
            return bll.GetMenuNameById(Convert.ToInt32(id));
        }

        protected override void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            base.myGrid_ItemCreated(sender, e);
        }

        protected void myGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteMenu(Convert.ToInt32(e.CommandArgument));
            }
            PageInit();
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_up_Click(object sender, EventArgs e)
        {
            #region 批量修改
            foreach (DataGridItem item in myGrid.Items)
            {
                TextBox txt_SortID = (TextBox)item.FindControl("txt_SortID");
                if (txt_SortID.Text != "")
                {
                    bll.UpdateMenu(Convert.ToInt32(txt_SortID.Text), Convert.ToInt32(item.Cells[0].Text));
                }
            }
            PageInit();
            #endregion
        }

        protected void lbtnDelAll_Click(object sender, EventArgs e)
        {
            #region 批量删除
            foreach (DataGridItem item in myGrid.Items)
            {
                //循环判断是否选中，选中则获取id
                CheckBox cb = (CheckBox)item.Cells[1].FindControl("chkdg");
                if (cb.Checked)
                {
                    bll.DeleteMenu(Convert.ToInt32(item.Cells[0].Text));
                }
            }
            PageInit();
            #endregion
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
