using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web
{
    public partial class modifyaddress : BasePage
    {
        AreaBLL bll = new AreaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            ddl_counties.DataSource = bll.GetList(0);
            ddl_counties.DataValueField = "Id";
            ddl_counties.DataTextField = "AreaName";
            ddl_counties.DataBind();
            ddl_counties.Items.Insert(0, new ListItem("-请选择-", ""));
        }

        protected void ddl_counties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_counties.SelectedIndex != 0)
            {
                ddl_streets.DataSource = bll.GetListByidlist(ddl_counties.SelectedValue);
                ddl_streets.DataValueField = "Id";
                ddl_streets.DataTextField = "AreaName";
                ddl_streets.DataBind();
                ddl_streets.Items.Insert(0, new ListItem("-请选择-", ""));
                ddl_district.Items.Clear();
            }
        }

        protected void ddl_streets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_streets.SelectedIndex != 0)
            {
                ddl_district.DataSource = bll.GetListByidlist(ddl_streets.SelectedValue);
                ddl_district.DataValueField = "Id";
                ddl_district.DataTextField = "AreaName";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("-请选择-", ""));
            }
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            //地址
            string addpre = ddl_counties.SelectedValue + "," + ddl_streets.SelectedValue + "," + ddl_district.SelectedValue;
            addpre += "|" + ddl_counties.SelectedItem.Text + ddl_streets.SelectedItem.Text + ddl_district.SelectedItem.Text;

            UserInfo item = Session["cudoUser"] as UserInfo;
            List<UserAddress> addresslist = new UserAddressBLL().GetList(item.Id);
            UserAddress additem = addresslist[0];
            additem.UserName = txtusername.Value;
            additem.Address = addpre;

            UserInfo uinfo = new UsersBLL().GetUserByID(item.Id);
            uinfo.NickName = txtusername.Value;
            uinfo.Address = addpre;

            if (new UserAddressBLL().UpdateAddress(additem) > 0)
            {
                new UsersBLL().UpdateUser(uinfo);
                Response.Write("<script>window.parent.self.location = \"shoplist.aspx?aid=" + ddl_counties.SelectedValue + "&sid=" + ddl_streets.SelectedValue + "&did=" + ddl_district.SelectedValue + "\";</script>");
                //L_msg.Text = "<font color='green'>修改成功!</font>";
            }
            else
            {
                L_msg.Text = "<font color='red'>修改失败!</font>";
            }
        }
    }
}
