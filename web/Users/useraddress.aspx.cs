using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.Users
{
    public partial class useraddress : BasePage
    {
        UserAddressBLL bll = new UserAddressBLL();
        AreaBLL abll = new AreaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            if (!IsPostBack)
            {
                PageInit();
                AreaInit("");
            }
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            rpt_list.DataSource = bll.GetList(item.Id);
            rpt_list.DataBind();
        }

        protected void rpt_list_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteAddress(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "edit")
            {
                btn_Add.Visible = false;
                btn_modify.Visible = true;
                UserAddress item = bll.GetAddressByID(Convert.ToInt32(e.CommandArgument));
                ddladdtype.Value = item.Address.Split('|')[2];
                txtusername.Value = item.UserName;
                txtmobile.Value = item.Mobile;
                chkdefult.Checked = item.IsDefault == 1 ? true : false;
                hiddenid.Value = e.CommandArgument.ToString();

                string[] itemlist = item.Address.Split('|')[0].Split(',');
                AreaInit(itemlist[0]);
                StreetInit(itemlist[0], itemlist[1]);
                DistrictInit(itemlist[1], itemlist[2]);
            }
            if (e.CommandName == "default")
            {
                UserAddress item = bll.GetAddressByID(Convert.ToInt32(e.CommandArgument));
                item.IsDefault = 1;
                bll.UpdateAddress(item);
            }
            PageInit();
        }

        /// <summary>
        /// 区县
        /// </summary>
        /// <param name="selectedvalue"></param>
        private void AreaInit(string selectedvalue)
        {
            ddl_counties.DataSource = abll.GetList(0);
            ddl_counties.DataValueField = "Id";
            ddl_counties.DataTextField = "AreaName";
            ddl_counties.DataBind();
            ddl_counties.Items.Insert(0, new ListItem("-请选择-", ""));
            ddl_counties.SelectedValue = selectedvalue;
        }
        /// <summary>
        /// 街道
        /// </summary>
        /// <param name="idlist"></param>
        /// <param name="selectedvalue"></param>
        private void StreetInit(string idlist, string selectedvalue)
        {
            ddl_streets.DataSource = abll.GetListByidlist(idlist);
            ddl_streets.DataValueField = "Id";
            ddl_streets.DataTextField = "AreaName";
            ddl_streets.DataBind();
            ddl_streets.Items.Insert(0, new ListItem("-请选择-", ""));
            ddl_streets.SelectedValue = selectedvalue;
        }
        /// <summary>
        /// 楼宇
        /// </summary>
        /// <param name="idlist"></param>
        /// <param name="selectedvalue"></param>
        private void DistrictInit(string idlist, string selectedvalue)
        {
            ddl_district.DataSource = abll.GetListByidlist(idlist);
            ddl_district.DataValueField = "Id";
            ddl_district.DataTextField = "AreaName";
            ddl_district.DataBind();
            ddl_district.Items.Insert(0, new ListItem("-请选择-", ""));
            ddl_district.SelectedValue = selectedvalue;
        }

        protected string AddressType(object stype)
        {
            string addname = string.Empty;
            switch (stype.ToString())
            {
                case "1": addname = "住宅地址"; break;
                case "2": addname = "办公地址"; break;
                case "3": addname = "其他"; break;
                default: addname = "其他"; break;
            }
            return addname;
        }

        protected string SubAddressStr(string address)
        {
            return address.Split('|')[1];
        }

        protected void ddl_counties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_counties.SelectedIndex != 0)
            {
                StreetInit(ddl_counties.SelectedValue, "");
                ddl_district.Items.Clear();
            }
        }

        protected void ddl_streets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_streets.SelectedIndex != 0)
            {
                DistrictInit(ddl_streets.SelectedValue, "");
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            if (Session["cudoUser"] != null)
            {
                string addpre = ddl_counties.SelectedValue + "," + ddl_streets.SelectedValue + "," + ddl_district.SelectedValue;
                addpre += "|" + ddl_counties.SelectedItem.Text + ddl_streets.SelectedItem.Text + ddl_district.SelectedItem.Text;
                addpre += "|" + ddladdtype.Value;
                UserAddress item = new UserAddress();
                item.UserId = (Session["cudoUser"] as UserInfo).Id;
                item.UserName = txtusername.Value;
                item.Mobile = txtmobile.Value;
                item.Address = addpre;
                item.IsDefault = chkdefult.Checked == true ? 1 : 0;
                if (rpt_list.Items.Count >= 3)
                {
                    Utils.alert("添加失败，超过3个地址!", "useraddress.aspx");
                }
                else
                {
                    bool flag = false;
                    foreach(RepeaterItem temp in rpt_list.Items)
                    {
                        HiddenField hf = temp.FindControl("hfaddtype") as HiddenField;
                        if (hf.Value == ddladdtype.Value)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Utils.alert("已存在相同场所地址，请更换!", "useraddress.aspx");
                    }
                    else
                    {
                        bll.AddAddress(item);
                    }
                }
            }
            PageInit();
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            if (Session["cudoUser"] != null)
            {
                string addpre = ddl_counties.SelectedValue + "," + ddl_streets.SelectedValue + "," + ddl_district.SelectedValue;
                addpre += "|" + ddl_counties.SelectedItem.Text + ddl_streets.SelectedItem.Text + ddl_district.SelectedItem.Text;
                addpre += "|" + ddladdtype.Value;
                UserAddress item = bll.GetAddressByID(Convert.ToInt32(hiddenid.Value));
                bool flag = false;
                foreach (RepeaterItem temp in rpt_list.Items)
                {
                    HiddenField hf = temp.FindControl("hfaddtype") as HiddenField;
                    if (!item.Address.Split('|')[2].Equals(ddladdtype.Value) && hf.Value == ddladdtype.Value)
                    {
                        flag = true;
                        break;
                    }
                }
                //bll.UpdateAddress(item);
                if (flag)
                {
                    Utils.alert("已存在相同场所地址，请更换!", "useraddress.aspx");
                }
                else
                {
                    item.UserName = txtusername.Value;
                    item.Mobile = txtmobile.Value;
                    item.Address = addpre;
                    item.IsDefault = chkdefult.Checked == true ? 1 : 0;
                    bll.UpdateAddress(item);
                }
            }
            PageInit();
        }
    }
}
