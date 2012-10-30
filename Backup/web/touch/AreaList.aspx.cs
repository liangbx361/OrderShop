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
    public partial class AreaList : ManagePage
    {
        AreaBLL bll = new AreaBLL();
        private string HtmlListCategory = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string loadCategory()
        {
            List<Area> list = bll.GetList();
            if (list.Count > 0)
            {
                List<Area> list2 = list.FindAll(delegate(Area ca) { return ca.Pid == 0; });
                foreach (Area item in list2)
                {
                    HtmlListCategory += "<div style=\"width:98%;padding-left:20px;border-bottom:solid 1px #114983;\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\"><div style=\"width:45%;float:right\"><a href=\"Street_AE.aspx?action=add&pid=" + item.Id + "\">添加街道</a>&nbsp;&nbsp;&nbsp;</div><div style=\"width:50%; cursor:pointer;\" onclick=\"ShowDiv('child_" + item.Id + "')\">" + item.AreaName + "</div></div>";
                    HtmlListCategory += "<div id='child_" + item.Id + "' style='display:none;'>";
                    bindChild(list, 1, item.Id);
                    HtmlListCategory+="</div>";
                }
            }
            return HtmlListCategory;
        }

        public void bindChild(List<Area> list, int length, int pid)
        {
            List<Area> list2 = list.FindAll(delegate(Area ca) { return ca.Pid == pid; });
            foreach (Area item in list2)
            {
                if (("1,2,3,4").IndexOf(item.Pid.ToString()) >= 0)
                {
                    if (CheckChild(item.Id))
                    {
                        HtmlListCategory += "<div style=\"width:98%;padding-left:20px;border-bottom:dashed 1px #114983;\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\"><div style=\"float:right;width:45%;\"><a href=\"District_AE.aspx?action=add&pid=" + item.Pid + "&id=" + item.Id + "\">添加楼宇/小区</a>&nbsp;&nbsp;&nbsp;<a href=\"Street_AE.aspx?action=edit&pid=" + item.Pid + "&id=" + item.Id + "\" >修改</a></div><div style=\"width:50%; cursor:pointer;\" onclick=\"ShowDiv('child_node_" + item.Id + "')\">" + Utils.SpaceLength(length) + item.AreaName + " [ " + item.AreaKey + " ] " + "</div></div>";
                        HtmlListCategory += "<div id='child_node_" + item.Id + "' style='display:none;'>";
                    }
                    else
                    {
                        HtmlListCategory += "<div style=\"width:98%;padding-left:20px;border-bottom:dashed 1px #114983;\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\"><div style=\"float:right;width:45%;\"><a href=\"District_AE.aspx?action=add&pid=" + item.Pid + "&id=" + item.Id + "\">添加楼宇/小区</a>&nbsp;&nbsp;&nbsp;<a href=\"Street_AE.aspx?action=edit&pid=" + item.Pid + "&id=" + item.Id + "\" >修改</a>&nbsp;&nbsp;&nbsp;<a href=\"Area_Del.aspx?id=" + item.Id + "\" title='删除' onclick=\"javascript:return confirm('您确定要删除吗？');\">删除</a></div><div style=\"width:50%; cursor:pointer;\" onclick=\"ShowDiv('child_node_" + item.Id + "')\">" + Utils.SpaceLength(length) + item.AreaName + " [ " + item.AreaKey + " ] " + "</div></div>";
                        HtmlListCategory += "<div id='child_node_" + item.Id + "' style='display:none;'>";
                    }
                }
                else
                {
                    HtmlListCategory += "<div style=\"width:98%;padding-left:20px;border-bottom:dashed 1px #114983;\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\"><div style=\"float:right;width:45%;\"><a href=\"District_AE.aspx?action=edit&pid=" + item.Pid + "&id=" + item.Id + "\">修改</a>&nbsp;&nbsp;&nbsp;<a href=\"Area_Del.aspx?id=" + item.Id + "\" title='删除' onclick=\"javascript:return confirm('您确定要删除吗？');\">删除</a></div><div style=\"width:50%; cursor:pointer;\">" + Utils.SpaceLength(length) + item.AreaName + " [ " + item.AreaKey + " ] " + "</div></div>";
                    HtmlListCategory += "</div>";
                }
                bindChild(list, length + 1, item.Id);
            }
        }

        private bool CheckChild(int pid)
        {
            List<Area> list = bll.GetList(pid);
            if (list.Count > 0)
                return true;
            else
                return false;
        }

        protected string GetStreet(int pid)
        {
            string strResult = "";
            List<Area> list = bll.GetList(pid);
            foreach (Area item in list)
            {
                string str = GetDistrict(item.Id);
                strResult += "<div class=\"dline\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\">";
                if (str != string.Empty)
                    strResult += "  <div class=\"dleft\" onclick=\"ShowDiv('child_node_" + item.Id + "')\">　├" + item.AreaName + "[ " + item.AreaKey + " ]</div>";
                else
                    strResult += "  <div class=\"dleft\">　├" + item.AreaName + "[ " + item.AreaKey + " ]</div>";
                strResult += "  <div class=\"dright\"><a href=\"District_AE.aspx?action=add&pid=" + item.Pid + "&id=" + item.Id + "\">添加楼宇/小区</a>&nbsp;&nbsp;&nbsp;<a href=\"Street_AE.aspx?action=edit&pid=" + item.Pid + "&id=" + item.Id + "\" >修改</a>";
                if (str == string.Empty)
                    strResult += "&nbsp;&nbsp;&nbsp;<a href=\"Area_Del.aspx?id=" + item.Id + "\" title='删除' onclick=\"javascript:return confirm('您确定要删除吗？');\">删除</a>";
                strResult += "  </div>";
                strResult += "</div>";
                strResult += str;
            }
            return strResult;
        }

        protected string GetDistrict(int pid)
        {
            string strResult = "";
            List<Area> list = bll.GetList(pid);
            if (list.Count > 0)
            {
                strResult += "<div id='child_node_" + pid + "' style='display:none'>";
                foreach (Area item in list)
                {
                    strResult += "<div class=\"dline\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\">";
                    strResult += "  <div class=\"dleft\">　　├" + item.AreaName + " [ " + item.AreaKey + " ] " + "</div>";
                    strResult += "  <div class=\"dright\"><a href=\"District_AE.aspx?action=edit&pid=" + item.Pid + "&id=" + item.Id + "\">修改</a>&nbsp;&nbsp;&nbsp;<a href=\"Area_Del.aspx?id=" + item.Id + "\" title='删除' onclick=\"javascript:return confirm('您确定要删除吗？');\">删除</a></div>";
                    strResult += "</div>";
                }
                strResult += "</div>";
            }
            return strResult;
        }
    }
}
