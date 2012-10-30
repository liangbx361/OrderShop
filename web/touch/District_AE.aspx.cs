using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.touch
{
    public partial class District_AE : ManagePage
    {
        AreaBLL bll = new AreaBLL();
        private string action = "";
        private int pid = 0;
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = base.GetStringValue("action");
            pid = base.GetIntValue("pid");
            Id = base.GetIntValue("id");
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
            
            if (action.Equals("edit"))
            {
                btnAdd.Visible = false;
                btnMoidfy.Visible = true;

                Area item = bll.GetItem(pid);
                ddl_counties.SelectedValue = item.Pid.ToString();
                StreetInit(item.Pid.ToString(), item.Id.ToString());

                Area item2 = bll.GetItem(Id);
                txtDistrict.Value = item2.AreaName;
                txtKey.Value = item2.AreaKey;
            }
            else
            {
                ddl_counties.SelectedValue = pid.ToString();
                StreetInit(pid.ToString(), Id.ToString());
            }
        }

        private void StreetInit(string defaulpid, string selectedvalue)
        {
            if (defaulpid != "0")
            {
                ddl_streets.DataSource = bll.GetListByidlist(defaulpid);
                ddl_streets.DataValueField = "Id";
                ddl_streets.DataTextField = "AreaName";
                ddl_streets.DataBind();
                ddl_streets.Items.Insert(0, new ListItem("-请选择-", ""));
                ddl_streets.SelectedValue = selectedvalue;
            }
        }

        protected void ddl_counties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_counties.SelectedIndex != 0)
            {
                StreetInit(ddl_counties.SelectedValue, "");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (bll.CheckAreaName(txtDistrict.Value) > 0)
            {
                L_msg.Text = "已存在名称,请勿重复操作!";
            }
            else
            {
                Area item = new Area();
                item.AreaName = txtDistrict.Value;
                item.Pid = Convert.ToInt32(ddl_streets.SelectedValue);
                item.AreaKey = txtKey.Value.Trim();

                if (bll.AddItem(item) > 0)
                    Utils.alert("添加成功!", "District_AE.aspx?action=add&pid=" + ddl_counties.SelectedValue + "&id=" + ddl_streets.SelectedValue);
                else
                    base.ErrorMsg("添加失败", "AreaList.aspx", 0);
            }
        }

        protected void btnMoidfy_Click(object sender, EventArgs e)
        {
            Area item = bll.GetItem(Id);
            if (txtDistrict.Value != item.AreaName && bll.CheckAreaName(txtDistrict.Value) > 0)
            {
                L_msg.Text = "已存在名称,请勿重复操作!";
            }
            else
            {
                item.AreaName = txtDistrict.Value;
                item.Pid = Convert.ToInt32(ddl_streets.SelectedValue);
                item.AreaKey = txtKey.Value;

                if (bll.UpdateItem(item) > 0)
                    base.ErrorMsg("修改成功", "AreaList.aspx", 1);
                else
                    base.ErrorMsg("修改失败", "AreaList.aspx", 0);
            }
        }

    }
}
