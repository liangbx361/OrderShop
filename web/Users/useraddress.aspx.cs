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

                //AreaInit("");
            }
        }

        private void PageInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            rpt_list.DataSource = bll.GetList(item.Id); 
            rpt_list.DataBind();

            List<UserAddress> list = bll.GetList(item.Id);
            foreach (UserAddress user in list) {
                string[] itemlist = user.Address.Split('|')[0].Split(',');
                if (user.IsDefault == 1 && itemlist[0] == "")
                {
                    btn_Add.Visible = false;
                    btn_modify.Visible = true;
                    ddladdtype.Value = user.Address.Split('|')[2];
                    txtusername.Value = user.UserName;
                    txtmobile.Value = user.Mobile;
                    chkdefult.Checked = user.IsDefault == 1 ? true : false;
                    hiddenid.Value = Convert.ToString(user.Id);
                    itemlist = user.Address.Split('|')[0].Split(',');
                    AreaInit(itemlist[0]);
                    StreetInit(itemlist[0], itemlist[1]);
                    DistrictInit(itemlist[1], itemlist[2]);
                    break;
                }
                else
                {
                    AreaInit("");
                    break;
                }
            }
            
        }

        private void PageReInit()
        {
            UserInfo item = Session["cudoUser"] as UserInfo;
            rpt_list.DataSource = bll.GetList(item.Id);
            rpt_list.DataBind();

            ddladdtype.Value = "";
            txtusername.Value = "";
            txtmobile.Value = "";
            chkdefult.Checked = false;

            AreaInit("");
            StreetInit("", "");
            DistrictInit("", "");
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
                if (itemlist[0] != "")
                {
                    AreaInit(itemlist[0]);
                    StreetInit(itemlist[0], itemlist[1]);
                    DistrictInit(itemlist[1], itemlist[2]);
                }
            }
            if (e.CommandName == "default")
            {
                UserAddress item = bll.GetAddressByID(Convert.ToInt32(e.CommandArgument));
                item.IsDefault = 1;
                bll.UpdateAddress(item);

                //更新session里面的地址数据
                UserInfo userInfo = Session["cudoUser"] as UserInfo;
                userInfo.Address = item.Address;
                Session["cudoUser"] = userInfo;
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
                    foreach (RepeaterItem temp in rpt_list.Items)
                    {
                        HiddenField hf = temp.FindControl("hfaddtype") as HiddenField;
                        if (hf.Value == addpre.Split('|')[1])
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
            PageReInit();

            btn_Add.Visible = true;
            btn_modify.Visible = false;
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
                    string[] oldAddress = item.Address.Split('|')[0].Split(',');
                    item.UserName = txtusername.Value;
                    item.Mobile = txtmobile.Value;
                    item.Address = addpre;
                    item.IsDefault = chkdefult.Checked == true ? 1 : 0;
                    bll.UpdateAddress(item);

                    if (oldAddress[0] == "")
                    {
                        //第一次设置地址，直接跳转到餐厅
                        string[] addlist = item.Address.Split('|')[0].Split(',');
                        Response.Redirect("/shoplist.aspx?aid=" + addlist[0] + "&sid=" + addlist[1] + "&did=" + addlist[2]);
                    }
                }
            }
            PageReInit();

            btn_Add.Visible = true;
            btn_modify.Visible = false;
        }

        protected void order_Click(object sender, EventArgs e)
        {

        }

        protected void order_command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "order")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                UserInfo item = Session["cudoUser"] as UserInfo;            
                List<UserAddress> addressList = bll.GetList(item.Id);

                foreach (UserAddress emement in addressList)
                {
                    if (emement.Id == id)
                    {
                        try
                        {
                            string[] addlist = emement.Address.Split('|')[0].Split(',');
                            if(addlist[0] != "") {
                                Response.Redirect("/shoplist.aspx?aid=" + addlist[0] + "&sid=" + addlist[1] + "&did=" + addlist[2]);
                            } else {
                                Utils.alert("您尚未拥有收餐地址，请先设定一个", "/Users/useraddress.aspx");
                            }
                        }
                        catch (Exception ee)
                        {
                            Utils.alert("您尚未拥有收餐地址，请先设定一个", "/Users/useraddress.aspx");
                        }
                    }
                }

            }
        }
    }
}
