using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.Users
{
    public partial class userinfo : BasePage
    {
        UsersBLL bll = new UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            if (item != null)
            {
                txt_NickName.Value = item.NickName;
                txt_Mobile.Value = item.Mobile;
                txt_Email.Value = item.Email;
                txt_BirthDay.Value = item.Birthday;
                rdogender.SelectedValue = item.Gender.ToString();
            }
        }

        protected string GetGroupName(int group)
        {
            return new UserGroupBLL().GetItemById(group).GroupName;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            item.NickName = txt_NickName.Value;
            item.Gender = Convert.ToInt32(rdogender.SelectedValue);
            item.Mobile = txt_Mobile.Value;
            item.Birthday = txt_BirthDay.Value;
            item.Email = txt_Email.Value;
            if (bll.UpdateUser(item) > 0)
            {
                Session["cudoUser"] = item;
                Utils.alert("修改成功!", "userinfo.aspx");
            }
            else
            {
                Utils.alert("修改失败!", "userinfo.aspx");
            }
        }
    }
}
