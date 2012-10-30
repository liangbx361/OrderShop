using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class Menu_AE : ManagePage
    {
        MenuBLL menuBll = new MenuBLL();
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = base.GetIntValue("id");
            if (!IsPostBack)
            {
                BindCategory();
                PageInit();
            }
        }

        private void BindCategory()
        {
            List<MenuInfo> list = menuBll.GetMenuList(0);
            ddl_menu.DataValueField = "Id";
            ddl_menu.DataTextField = "MenuName";
            ddl_menu.DataSource = list;
            ddl_menu.DataBind();
            ddl_menu.Items.Insert(0, new ListItem("全部", "-1"));
            ddl_menu.Items.Insert(1, new ListItem("一级菜单", "0"));
        }

        private void PageInit()
        {
            ltlmenu.Text = "修改菜单";
            if (Id != 0) 
            {
                MenuInfo item = menuBll.GetMenuByMenuID(Id);
                txt_menuName.Value = item.MenuName;
                ddl_menu.Text = item.ParentId.ToString();
                txt_urlLink.Value = item.UrlLink;
                txt_sortId.Value = item.SortId.ToString();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            MenuInfo item = new MenuInfo();
            item.MenuName = txt_menuName.Value;
            item.ParentId = Convert.ToInt32(ddl_menu.SelectedValue);
            item.UrlLink = txt_urlLink.Value;
            item.SortId = Convert.ToInt32(txt_sortId.Value);

            if (Id == 0)
            {
                if (menuBll.AddMenu(item) > 0)
                {
                    base.ErrorMsg("提交成功！", "MenuList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "MenuList.aspx", 0);
                }
            }
            else
            {
                item.Id = Id;
                if (menuBll.UpdateMenu(item) > 0)
                {
                    base.ErrorMsg("提交成功！", "MenuList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "MenuList.aspx", 0);
                }
            }
        }
    }
}
