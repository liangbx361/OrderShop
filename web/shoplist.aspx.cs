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
        }

        private void PageInit()
        {
            AreaName = abll.GetAreaName(did);

            //加载店铺类别
            rpt_shoptypelist.DataSource = new ShopTypeBLL().GetList();
            rpt_shoptypelist.DataBind();

            //加载街道
            List<Area> list = new List<Area>();
            if (aid == 0)
                list = new AreaBLL().GetListByidlist("1,2,3,4");
            else
                list = new AreaBLL().GetListByidlist(aid.ToString());
            rpt_streets.DataSource = list;
            rpt_streets.DataBind();

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

            rpt_district.DataSource = list2;
            rpt_district.DataBind();

            #endregion

            hiddenaid.Value = aid.ToString();
            hiddensid.Value = sid.ToString();

            //加载店铺
            shopinit();
        }

        private void shopinit()
        {
            PagedDataSource pdsdata = new PagedDataSource();
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
                case "hit": dv.Sort = "hit desc"; break;
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
    }
}
