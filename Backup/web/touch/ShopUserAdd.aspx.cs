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
    public partial class ShopUserAdd : ManagePage
    {
        AreaBLL abll = new AreaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_counties.DataSource = abll.GetList(0);
                ddl_counties.DataValueField = "Id";
                ddl_counties.DataTextField = "AreaName";
                ddl_counties.DataBind();
                ddl_counties.Items.Insert(0, new ListItem("-请选择-", ""));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (new UsersBLL().CheckUserIDByUserName(txtUserName.Value) > 0)
            {
                Utils.alert("已存在用户名请更换", "ShopUserAdd.aspx");
                return;
            }
            else
            {
                UserInfo info = new UserInfo();
                info.UserName = txtUserName.Value;
                info.UserPass = Utils.MD5Encrypt32(txtpassword.Value);
                info.UserGroup = 0;
                info.NickName = txtNickName.Value;
                info.Gender = 0;
                info.Mobile = txtMobile.Value;
                info.Birthday = "";
                info.Email = txtEmail.Value;
                info.Address = ",,|";
                info.Utype = 1;
                info.ShopId = Convert.ToInt32(ddl_shop.SelectedValue);
                info.PromotionId = 0;
                info.TotalPoint = 20;
                if (new UsersBLL().AddUser(info) > 0)
                    base.ErrorMsg("添加成功", "ShopUserList.aspx", 1);
                else
                    base.ErrorMsg("添加成功", "ShopUserList.aspx", 0);
            }
        }

        protected void ddl_counties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_counties.SelectedIndex != 0)
            {
                ddl_streets.DataSource = abll.GetListByidlist(ddl_counties.SelectedValue);
                ddl_streets.DataValueField = "Id";
                ddl_streets.DataTextField = "AreaName";
                ddl_streets.DataBind();
                ddl_streets.Items.Insert(0, new ListItem("-请选择-", ""));
            }
        }

        protected void ddl_streets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_streets.SelectedIndex != 0)
            {
                ddl_shop.DataSource = new ShopsBLL().GetListBydid(Convert.ToInt32(ddl_streets.SelectedValue));
                ddl_shop.DataValueField = "ShopId";
                ddl_shop.DataTextField = "ShopName";
                ddl_shop.DataBind();
            }
        }
    }
}
