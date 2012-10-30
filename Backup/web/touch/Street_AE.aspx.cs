using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class Street_AE : ManagePage
    {
        AreaBLL bll = new AreaBLL();
        private string action = "";
        private int Id = 0;
        private int pid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = base.GetStringValue("action");
            Id = base.GetIntValue("id");
            pid = base.GetIntValue("pid");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            ddl_counties.DataSource = bll.GetList(0);
            ddl_counties.DataValueField = "Id";
            ddl_counties.DataTextField = "AreaName";
            ddl_counties.DataBind();
            ddl_counties.Items.Insert(0, new ListItem("-请选择-", ""));
            ddl_counties.SelectedValue = pid.ToString();
            if (action.Equals("edit"))
            {
                btnAdd.Visible = false;
                btnMoidfy.Visible = true;

                Area item = bll.GetItem(Id);
                txtStreet.Value = item.AreaName;
                txtKey.Value = item.AreaKey.Trim();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (bll.CheckAreaName(txtStreet.Value) > 0)
            {
                L_msg.Text = "已存在名称,请勿重复操作!";
            }
            else
            {
                Area item = new Area();
                item.AreaName = txtStreet.Value;
                item.Pid = Convert.ToInt32(ddl_counties.SelectedValue);
                item.AreaKey = txtKey.Value;

                if (bll.AddItem(item) > 0)
                    base.ErrorMsg("添加成功", "AreaList.aspx", 1);
                else
                    base.ErrorMsg("添加失败", "AreaList.aspx", 0);
            }
        }

        protected void btnMoidfy_Click(object sender, EventArgs e)
        {
            Area item = bll.GetItem(Id);
            if (txtStreet.Value != item.AreaName && bll.CheckAreaName(txtStreet.Value) > 0)
            {
                L_msg.Text = "已存在名称,请勿重复操作!";
            }
            else
            {
                item.AreaName = txtStreet.Value;
                item.Pid = Convert.ToInt32(ddl_counties.SelectedValue);
                item.AreaKey = txtKey.Value;
                if (bll.UpdateItem(item) > 0)
                    base.ErrorMsg("修改成功", "AreaList.aspx", 1);
                else
                    base.ErrorMsg("修改失败", "AreaList.aspx", 0);
            }
        }
    }
}
