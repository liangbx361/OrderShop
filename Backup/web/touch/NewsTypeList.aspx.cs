using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.touch
{
    public partial class NewsTypeList : ManagePage
    {
        protected int parentId = 0; 
        private string HtmlListCategory = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            parentId = base.GetIntValue("pid");
        }

        public string loadCategory()
        {
            List<NewType> list = new NewTypeBLL().GetList();
            if (list.Count > 0)
            {
                List<NewType> list2 = list.FindAll(delegate(NewType ca) { return ca.ParentId == parentId; });
                foreach (NewType item in list2)
                {
                    HtmlListCategory += "<div style=\"width:98%;padding-left:20px;border-bottom:solid 1px #114983;\" onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\"><div style=\"width:45%;float:right\"><a href=\"NewsType_AE.aspx?pid=" + parentId + "&classId=" + item.Id + "&action=add" + "\">添加子分类</a>&nbsp;&nbsp;&nbsp;<a href=\"NewsType_AE.aspx?pid=" + parentId + "&classId=" + item.Id + "&action=edit" + "\" title='修改'>修改</a>&nbsp;&nbsp;&nbsp;<a href=\"NewsTypeDel.aspx?pid=" + parentId + "&classId=" + item.Id + "\" title='删除' onclick=\"javascript:return confirm('您确定要删除吗？');\">删除</a></div><div style=\"width:50%; cursor:pointer;\" onclick=\"ShowDiv('child" + item.Id + "')\" title='点击展开子类'>" + item.ClassName + "&nbsp;[" + item.Id + "]" + "</div></div><div>";
                    bindChild(list, 1, item.Id);
                    HtmlListCategory += "</div>";
                }
            }
            return HtmlListCategory;
        }

        public void bindChild(List<NewType> list, int length, int pid)
        {
            List<NewType> list2 = list.FindAll(delegate(NewType ca) { return ca.ParentId == pid; });
            foreach (NewType item in list2)
            {
                HtmlListCategory += "<div id=\"child" + pid + "_node_" + item.Id + "\" style=\"display:none;width:98%;padding-left:20px;border-bottom:dashed 1px #114983;\"  onmouseover=\"a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'\" onmouseout=\"this.style.backgroundColor=a\"><div style=\"float:right;width:45%;\"><a href=\"NewsType_AE.aspx?pid=" + parentId + "&classId=" + item.Id + "&action=add" + "\">添加子分类</a>&nbsp;&nbsp;&nbsp;<a href=\"NewsType_AE.aspx?pid=" + parentId + "&classId=" + item.Id + "&action=edit" + "\" title='修改'>修改</a>&nbsp;&nbsp;&nbsp;<a href=\"NewsTypeDel.aspx?pid=" + parentId + "&classId=" + item.Id + "\" title='删除' onclick=\"javascript:return confirm('您确定要删除吗？');\">删除</a></div><div style=\"width:50%; cursor:pointer;\" onclick=\"ShowDiv('child" + item.Id + "')\" title='点击展开子类'>" + Utils.SpaceLength(length) + item.ClassName + "&nbsp;[" + item.Id + "]" + "</div></div><div>";
                bindChild(list, length + 1, item.Id);
                HtmlListCategory += "</div>";
            }
        }
    }
}
