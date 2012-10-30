using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;

namespace web.touch
{
    public partial class admin_roleRight_manager : ManagePage
    {
        private int UserId = 0;
        MenuBLL MenuBiz = new MenuBLL();
        AdminUserBLL AdminUserUserBiz = new AdminUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            rpt_UserRole.DataSource = MenuBiz.GetMenuList(0);
            rpt_UserRole.DataBind();

            if (UserId != 0)
            {
                lbl_Permissions.Text = AdminUserUserBiz.GetUserNameById(UserId);
                string Permissions = AdminUserUserBiz.GetPermissionsByUserID(UserId);
                if (Permissions != string.Empty)
                {
                    foreach (RepeaterItem item in rpt_UserRole.Items)
                    {
                        Repeater rptRole = (Repeater)item.FindControl("rptRole"); //子菜单repeater
                        CheckBox CheckBox1 = (CheckBox)item.FindControl("CheckBox1"); //大类别前的CheckBox
                        Label lbl_id = (Label)item.FindControl("lbl_id"); //大类别ID
                        if (Permissions.IndexOf("," + lbl_id.Text + ",") != -1)
                        { //如果存在此选项则选中复选框
                            CheckBox1.Checked = true;
                        }

                        #region 二级分类
                        foreach (RepeaterItem itemRole in rptRole.Items)
                        {
                            CheckBox cbkrowone = (CheckBox)itemRole.FindControl("cbkrowone");//子菜单前的CheckBox
                            HiddenField hfid = (HiddenField)itemRole.FindControl("hfid"); //子菜单的ID
                            if (Permissions.IndexOf("," + hfid.Value + ",") != -1)
                            { //如果存在此选项则选中复选框
                                cbkrowone.Checked = true;
                            }
                        }
                        #endregion
                    }

                    if (Permissions.IndexOf("Permissions_s1") != -1)
                    {
                        cbk_Permissions.Checked = true;
                    }
                }
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string str = ",";
            if (UserId > 0)
            {
                foreach (RepeaterItem item in rpt_UserRole.Items)
                {
                    CheckBox CheckBox1 = (CheckBox)item.FindControl("CheckBox1"); //大类别前的CheckBox
                    Label lbl_id = (Label)item.FindControl("lbl_id"); //大类别id
                    if (CheckBox1.Checked == true)
                    {
                        //如果复选框有选中，添加权限
                        str += lbl_id.Text + ",";
                    }

                    #region 二级分类
                    Repeater rptRole = (Repeater)item.FindControl("rptRole");
                    foreach (RepeaterItem itemRole in rptRole.Items)
                    {
                        CheckBox cbkrowone = (CheckBox)itemRole.FindControl("cbkrowone");//子菜单前的CheckBox
                        HiddenField hfid = (HiddenField)itemRole.FindControl("hfid"); //子菜单的ID
                        if (cbkrowone.Checked == true)
                        {
                            str += hfid.Value + ","; //添加到权限（子菜单一定要勾选）
                        }
                    }
                    #endregion
                }

                if (cbk_Permissions.Checked == true)
                {
                    str += "Permissions_s1,";
                }

                if (AdminUserUserBiz.UpdateUserRoleByUserID(str, UserId) > 0)
                {
                    base.ErrorMsg("提交成功!", Request.Url.ToString(), 1);
                }
                else
                {
                    base.ErrorMsg("提交失败!", Request.Url.ToString(), 0);
                }
            }
        }

        protected void rpt_UserRole_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                #region 行绑定事件
                Label lbl_id = (Label)e.Item.FindControl("lbl_id"); //大类ID
                Repeater rptRole = (Repeater)e.Item.FindControl("rptRole");
                if (lbl_id != null)
                {
                    //绑定第二个大类别底下的小类别repeater
                    rptRole.DataSource = MenuBiz.GetMenuList(Convert.ToInt32(lbl_id.Text));
                    rptRole.DataBind();
                }
                #endregion
            }
        }
    }
}
