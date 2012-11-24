using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web
{
    public partial class setaddress : BasePage
    {
        UserAddressBLL bll = new UserAddressBLL();
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
            UserInfo item = Session["cudoUser"] as UserInfo;
            List<UserAddress> list = bll.GetList(item.Id);
            for (int i = 0; i < list.Count; i++)
            {
                ddladdress.Items.Add(new ListItem(AddressType(list[i].Address.Split('|')[1]),list[i].Id.ToString()));
            }
            L_UserName.Text = list[0].UserName;
            L_UserTel.Text = list[0].Mobile;
            string[] str = list[0].Address.Split('|');
            if (list[0].Address.Split('|')[1] != string.Empty)
            {
                L_Area.Text = list[0].Address.Split('|')[1].Substring(0, 3);
                L_Address.Text = list[0].Address.Split('|')[1].Substring(3, list[0].Address.Split('|')[1].Length - 3);
            }
            
        }

        private string AddressType(string addtype)
        {
            string addname = string.Empty;
            switch (addtype)
            {
                case "1": addname = "住宅地址"; break;
                case "2": addname = "办公地址"; break;
                case "3": addname = "其他"; break;
                default: addname = "其他"; break;
            }
            return addname;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {   
            if (Session["cudoUser"] == null)
            {   
                //如果没有用户信息, 跳转到登录界面
                Response.Redirect("login.aspx");
            }
            else
            {
                //更新地址簿
                UserAddress item = bll.GetAddressByID(int.Parse(ddladdress.SelectedValue));
                item.IsDefault = 1;
                bll.UpdateAddress(item);

                //更新用户当前地址
                UserInfo uinfo = Session["cudoUser"] as UserInfo; //new UsersBLL().GetUserByID(item.UserId);
                uinfo.NickName = item.UserName;
                uinfo.Mobile = item.Mobile;
                uinfo.Address = item.Address;
                Session["cudoUser"] = uinfo;
                new UsersBLL().UpdateUser(uinfo);
                string[] addlist = item.Address.Split('|')[0].Split(',');
                //跳转到商店列表界面
                Response.Redirect("shoplist.aspx?aid=" + addlist[0] + "&sid=" + addlist[1] + "&did=" + addlist[2]);

            }
        }

        protected void ddladdress_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserAddress item = bll.GetAddressByID(int.Parse(ddladdress.SelectedValue));
            L_UserName.Text = item.UserName;
            L_UserTel.Text = item.Mobile;
            L_Area.Text = item.Address.Split('|')[1].Substring(0, 3);
            L_Address.Text = item.Address.Split('|')[1].Substring(3, item.Address.Split('|')[1].Length - 3);
        }
    }
}
