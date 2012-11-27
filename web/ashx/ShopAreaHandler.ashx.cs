using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Cudo.Entities;
using Cudo.Business;
using System.Web.SessionState;

namespace web.ashx
{
    public class ShopAreaHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string strResult = "";
            string action = context.Request.QueryString["action"];
            string pid = context.Request.QueryString["pid"];
            switch (action)
            {
                case "street":
                    strResult = StreetInit(pid);
                    break;
                case "district":
                    strResult = DistrictInit(pid);
                    break;
                case "s-d":
                    strResult = Refresh(pid);
                    break;
                case "d-zm":
                    int sid = int.Parse(context.Request.QueryString["sid"]);
                    string filterStr = context.Request.QueryString["zm"];
                    string ot = context.Request.QueryString["ot"];
                    if (!string.IsNullOrEmpty(ot))
                        strResult = FilterDistrict(pid, sid, filterStr, ot);
                    else
                        strResult = FilterDistrict(pid, sid, filterStr);
                    break;
                case "delete":
                    string areaid = context.Request.QueryString["areaid"];
                    strResult = DeleteItem(context, areaid);
                    break;
                case "search":
                    string keyword = context.Request.QueryString["keyword"];
                    strResult = SearchDistrictByKey(keyword);
                    break;
                default: break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(strResult);
        }

        /// <summary>
        /// 加载街道
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        protected string StreetInit(string pid)
        {
            string strResult = "";
            List<Area> list = new List<Area>();
            if (pid == "0")
                list = new AreaBLL().GetListByidlist("1,2,3,4");
            else
                list = new AreaBLL().GetListByidlist(pid);
            foreach (Area item in list)
            {
                strResult += "<a id=\"district" + item.Id + "\" rel=\"" + item.Pid + "\" href=\"javascript:;\" onclick=\"district(" + item.Id + ")\">[" + item.AreaName + "]</a>";
            }
            return strResult;
        }

        /// <summary>
        /// 加载楼宇小区
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        protected string DistrictInit(string pid)
        {
            string strResult = "";
            List<Area> list = new AreaBLL().GetListByidlist(pid);
            foreach (Area item in list)
            {
                strResult += "<li><a href=\"javascript:;\" onclick=\"seldistrict(" + item.Id + "," + item.Pid + ",'" + item.AreaName + "')\">" + item.AreaName + "</a></li>";
            }
            return strResult;
        }

        /// <summary>
        /// 根据区域加载楼宇
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        protected string Refresh(string pid)
        {
            AreaBLL abll = new AreaBLL();
            string strResult = "";
            List<Area> list = new List<Area>();
            if (pid == "0")
                list = abll.GetListByidlist("1,2,3,4");
            else
                list = abll.GetListByidlist(pid);
            string prestr = "";
            foreach (Area item in list)
            {
                prestr += item.Id + ",";
            }
            prestr.Remove(prestr.Length - 1, 1);
            list = abll.GetListByidlist(prestr);
            foreach (Area item in list)
            {
                strResult += "<li><a href=\"javascript:;\" onclick=\"seldistrict(" + item.Id + "," + item.Pid + ",'" + item.AreaName + "')\">" + item.AreaName + "</a></li>";
            }
            return strResult;
        }

        /// <summary>
        /// 按照字母过滤楼宇小区
        /// </summary>
        /// <param name="pid">地区id</param>
        /// <param name="sid">街道id</param>
        /// <param name="filterStr">字母</param>
        /// <returns></returns>
        protected string FilterDistrict(string pid, int sid, string filterStr, string ot)
        {
            AreaBLL abll = new AreaBLL();
            string strResult = "";
            string prestr = "";
            List<Area> list = new List<Area>();
            string strurl = "index.aspx";
            if (ot == "2")
                strurl = "shoplist.aspx";
            if (pid == "0")
                list = abll.GetListByidlist("1,2,3,4");
            else
                list = abll.GetListByidlist(pid);

            foreach (Area item in list)
            {
                prestr += item.Id + ",";
            }
            prestr.Remove(prestr.Length - 1, 1);
            list = abll.GetListByidlist(prestr);
            if (sid > 0)
                list = list.FindAll(delegate(Area ca) { return ca.Pid == sid; });
            //按照字母过滤
            if (filterStr != string.Empty)
                list = list.FindAll(delegate(Area ca) { return ca.AreaKey == filterStr; });

            foreach (Area item in list)
            {
                strResult += "<li><a href=\"" + strurl + "?aid=" + GetPidById(item.Pid) + "&sid=" + item.Pid + "&did=" + item.Id + "\">" + item.AreaName + "</a></li>";
            }
            return strResult;
        }

        protected string FilterDistrict(string pid, int sid, string filterStr)
        {
            AreaBLL abll = new AreaBLL();
            string strResult = "";
            string prestr = "";
            List<Area> list = new List<Area>();
            if (pid == "0")
                list = abll.GetListByidlist("1,2,3,4");
            else
                list = abll.GetListByidlist(pid);

            foreach (Area item in list)
            {
                prestr += item.Id + ",";
            }
            prestr.Remove(prestr.Length - 1, 1);
            list = abll.GetListByidlist(prestr);
            if (sid > 0)
                list = list.FindAll(delegate(Area ca) { return ca.Pid == sid; });
            //按照字母过滤
            if (filterStr != string.Empty)
                list = list.FindAll(delegate(Area ca) { return ca.AreaKey == filterStr; });

            foreach (Area item in list)
            {
                strResult += "<li><a href=\"javascript:;\" onclick=\"seldistrict(" + item.Id + "," + item.Pid + ",'" + item.AreaName + "')\">" + item.AreaName + "</a></li>";
            }
            return strResult;
        }

        protected int GetPidById(object sid)
        {
            Area item = new AreaBLL().GetItem(Convert.ToInt32(sid));
            return item.Pid;
        }

        protected string DeleteItem(HttpContext context,string areaid)
        {
            string strResult = "";
            UserInfo item = context.Session["cudoUser"] as UserInfo;
            if (new ShopAreaBLL().DeleteItem(item.ShopId, int.Parse(areaid)) > 0)
            {
                strResult = "1";
            }
            else
            {
                strResult = "0";
            }
            return strResult;
        }

        protected string SearchDistrictByKey(string keyword)
        {
            string strResult = "";
            AreaBLL abll = new AreaBLL();
            List<Area> alllist = new List<Area>();
            if (HttpContext.Current.Cache["allarea"] != null)
            {
                alllist = HttpContext.Current.Cache["allarea"] as List<Area>;
            }
            else
            {
                List<Area> list = abll.GetListByidlist("1,2,3,4");
                string prestr = "";
                foreach (Area item in list)
                {
                    prestr += item.Id + ",";
                }
                prestr.Remove(prestr.Length - 1, 1);
                alllist = abll.GetListByidlist(prestr);
                HttpContext.Current.Cache.Insert("allarea", alllist);
            }
            //查找符合条件的数据集
            List<Area> filterlist = alllist.FindAll(delegate(Area ca) { return ca.AreaKey.IndexOf(keyword.ToUpper()) > -1 || ca.AreaName.IndexOf(keyword) > -1; });
            foreach (Area temp in filterlist)
            {
                strResult += "<p onclick=\"selsearchval('" + temp.AreaName.Trim() + "')\">" + temp.AreaName.Trim() + "</p>";
            }
            return strResult;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
