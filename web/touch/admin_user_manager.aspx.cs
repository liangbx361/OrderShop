using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;

namespace web.touch
{
    public partial class admin_user_manager : ManagePage
    {
        AdminUserBLL UserBiz = new AdminUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            int issystem = Convert.ToInt32(Session["issystem"]);
            WebPager.RecordCount = UserBiz.GetCount(issystem);
            myGrid.DataSource = UserBiz.GetUserList(WebPager.CurrentPageIndex, WebPager.PageSize, issystem);
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
            if (e.CommandName.Equals("del"))
            {
                int uid = Convert.ToInt32(e.CommandArgument);
                UserBiz.DeleteUser(uid);
                UserBiz.DeleteUserRoleByUserID(uid);
            }
            PageInit();
        }

        protected void myGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                #region 屏蔽按钮 不能删除本身
                CheckBox chk = (CheckBox)e.Item.FindControl("chkdg");
                LinkButton lbtndel = (LinkButton)e.Item.FindControl("lbtnDel");
                if (Session["admin_userid"].ToString()==e.Item.Cells[0].Text)
                {
                    chk.Enabled = false;
                    lbtndel.Enabled = false;
                }
                #endregion

                Literal labIsSystem = (Literal)e.Item.Cells[6].FindControl("labIsSystem");
                HyperLink hylrole = (HyperLink)e.Item.Cells[6].FindControl("hylrole");
                if (Session["issystem"].Equals(-2))
                {
                    //如果登录的是最高权限的管理员则不可编辑、删除、分配权限
                    if (labIsSystem != null && labIsSystem.Text=="-2")
                    {
                        if (hylrole != null)
                            hylrole.Visible = false;
                    }
                }
                else
                {//如果不是最高权限的管理员
                    //判断是否有分配权限，如果没有则屏蔽配置权限按钮
                    if (Session["Permissions"].ToString().IndexOf("Permissions_s1") == -1)
                    {
                        if (hylrole != null)
                            hylrole.Visible = false;
                    }
                }
            }
        }
    }
}
