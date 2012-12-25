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
    public partial class shoplist : BasePage
    {
        AreaBLL abll = new AreaBLL();
        ShopsBLL bll = new ShopsBLL();
        protected string AreaName = string.Empty;
        protected int TypeId = 0;
        protected string sortstr = "";
        protected int aid = 0; //地区
        protected int sid = 0; //街道
        protected int did = 0; //楼宇
        protected int defaultIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sortstr = base.GetStringValue("order", "hit");
            TypeId = base.GetIntValue("typeid");
            aid = base.GetIntValue("aid");
            sid = base.GetIntValue("sid");
            did = base.GetIntValue("did");
            if (!IsPostBack)
            {
                PageInit();
            }

            if (aid == 0 && sid == 0 && did == 0)
            {
                AreaName = string.Empty;
            }
            else
            {
                AreaName = abll.GetAreaName(aid) + " " + abll.GetAreaName(sid) + " " + abll.GetAreaName(did);
                //address_list.SelectedIndex = defaultIndex;
            }
        }

        private void addrssListInit()
        {
            UserInfo user = Session["cudoUser"] as UserInfo;
            UserAddressBLL bll = new UserAddressBLL();
            List<UserAddress> list = bll.GetList(user.Id);         
            List<string> addressList = new List<string>();
            int i=0;
            foreach(UserAddress u in list) {
                addressList.Add(u.Address.Split('|')[1]);
                if (i++ == 0) Session["selectAddress"] = u;
            }

            defaultIndex = addressList.IndexOf(abll.GetAreaName(aid)+ abll.GetAreaName(sid) + abll.GetAreaName(did));

            address_list.DataSource = addressList;
            address_list.DataBind();
        }

        private void PageInit()
        {
            rpt_adverts.DataSource = new AdvertBLL().GetAdvertList(1);
            rpt_adverts.DataBind();
            rpt_advertnum.DataSource = rpt_adverts.DataSource;
            rpt_advertnum.DataBind();

            if(aid == 0 && sid == 0 && did == 0) {
                AreaName = string.Empty;
            } else {
                AreaName = abll.GetAreaName(aid) + " " + abll.GetAreaName(sid) + " " + abll.GetAreaName(did);
            }
            

            //加载店铺类别
            rpt_shoptypelist.DataSource = new ShopTypeBLL().GetList();
            rpt_shoptypelist.DataBind();

            //加载街道
            List<Area> list = new List<Area>();
            if (aid == 0)
                list = new AreaBLL().GetListByidlist("1,2,3,4");
            else
                list = new AreaBLL().GetListByidlist(aid.ToString());
            //rpt_streets.DataSource = list;
            //rpt_streets.DataBind();

            List<Area> list2 = new List<Area>();
            #region ===========加载小区============
            //加载小区
            if (sid > 0)
            {
                list2 = abll.GetListByidlist(sid.ToString());
            }
            else
            {
                List<Area> alllist = new List<Area>();
                if (Cache["allarea"] != null)
                {
                    alllist = HttpContext.Current.Cache["allarea"] as List<Area>;
                }
                else
                {
                    string prestr = "";
                    foreach (Area item in list)
                    {
                        prestr += item.Id + ",";
                    }
                    prestr.Remove(prestr.Length - 1, 1);
                    alllist = abll.GetListByidlist(prestr);
                    HttpContext.Current.Cache.Insert("allarea", alllist);
                }
                int i = 0;
                foreach (Area ar in alllist)
                {
                    if (i > 24)
                        break;
                    list2.Add(ar);
                    i++;
                }
            }
            //list2 = abll.GetListByidlist(prestr);

            //rpt_district.DataSource = list2;
            //rpt_district.DataBind();

            #endregion

            hiddenaid.Value = aid.ToString();
            hiddensid.Value = sid.ToString();

            //加载店铺
            shopinit();

            addrssListInit();
        }

        private void shopinit()
        {
            PagedDataSource pdsdata = new PagedDataSource();
            // 获取数据
            DataSet ds = bll.GetListByAreaId(aid);
            if (sid > 0)
                ds = bll.GetListByStreetId(sid);
            if (did > 0)
                ds = bll.GetListByDistrictId(did);

            DataView dv = ds.Tables[0].DefaultView;
            if (TypeId > 0)
                dv.RowFilter = "shoptype=" + TypeId;
            switch (sortstr)
            {
                case "time": dv.Sort = "id desc"; break;
                case "hit": dv.Sort = "addtime desc"; break;
                case "point": dv.Sort = "sumpoint desc"; break;
                default: dv.Sort = "hit desc"; break;
            }

            pdsdata.DataSource = dv;
            pdsdata.AllowPaging = true;
            pdsdata.PageSize = WebPager.PageSize;
            pdsdata.CurrentPageIndex = WebPager.CurrentPageIndex - 1; //设置PagedDataSource的当前页数据（PagedDataSource的页数索引是从0开始）
            WebPager.RecordCount = pdsdata.DataSourceCount;

            rpt_shoplist.DataSource = pdsdata;
            rpt_shoplist.DataBind();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            shopinit();
        }

        protected int GetPidById(object sid)
        {
            Area item = abll.GetItem(Convert.ToInt32(sid));
            return item.Pid;
        }

        protected string CreateTypeUrl()
        {
            string prestr = "shoplist.aspx?";
            SortedDictionary<string, string> para = Utils.GetRequestGet();
            para = Utils.FilterPara(para, "typeid");
            if (para.Count > 0)
            {
                prestr += Utils.CreateLinkStringUrl(para) + "&";
            }
            return prestr;
        }

        protected string CreateSortUrl()
        {
            string prestr = "shoplist.aspx?";
            SortedDictionary<string, string> para = Utils.GetRequestGet();
            para = Utils.FilterPara(para, "order");
            if (para.Count > 0)
            {
                prestr += Utils.CreateLinkStringUrl(para) + "&";
            }
            return prestr;
        }

        protected void addresIndexChange(object sender, EventArgs e)
        {
            string address = address_list.SelectedValue;

            if (AreaName != address)
            {

            }
        }

        protected void addresbtn_Click(object sender, EventArgs e)
        {
            string address = address_list.SelectedValue;

            if (AreaName != string.Empty && address != string.Empty && !AreaName.Equals(address))
            {
                UserInfo user = Session["cudoUser"] as UserInfo;
                UserAddressBLL bll = new UserAddressBLL();
                List<UserAddress> list = bll.GetList(user.Id);
                foreach (UserAddress u in list)
                {
                    if (u.Address.Split('|')[1].Equals(address))
                    {
                        Session["selectAddress"] = u;
                        string[] id = u.Address.Split('|')[0].Split(',');
                        Response.Redirect("/shoplist.aspx?aid=" + id[0] + "&sid=" + id[1] + "&did=" + id[2]);
                    }
                }
            }
            else
            {
                PageInit();
            }
        }
    }
}
