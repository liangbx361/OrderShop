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
    public partial class NewsType_AE : ManagePage
    {
        NewTypeBLL bll = new NewTypeBLL();
        private int parentId = 0; //父类ID
        private int classId = 0; //类别ID
        private string action = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            parentId = base.GetIntValue("pid");
            classId = base.GetIntValue("classId");
            action = base.GetStringValue("action", "add");
            if (!IsPostBack)
            {
                BindCategory();
                PageInit();
            }
        }

        #region 递归绑定下拉框
        private void BindCategory()
        {
            List<NewType> list = bll.GetList();
            if (list.Count > 0)
            {
                List<NewType>list2 = list.FindAll(delegate(NewType ca) { return ca.ParentId == parentId; });
                foreach (NewType item in list2)
                {
                    ddl_type.Items.Add(new ListItem(Utils.SpaceLength(1) + item.ClassName, item.Id.ToString()));
                    bindChild(list, 2, item.Id, ddl_type);
                }
            }
        }

        public void bindChild(List<NewType> list, int length, int pid, DropDownList ddlcategory)
        {
            List<NewType> list2 = list.FindAll(delegate(NewType ca) { return ca.ParentId == pid; });
            foreach (NewType item in list2)
            {
                ddl_type.Items.Add(new ListItem(Utils.SpaceLength(length) + item.ClassName, item.Id.ToString()));
                bindChild(list, length + 1, item.Id, ddlcategory);
            }
        }
        #endregion

        private void PageInit()
        {
            if (action == "edit")
            {
                ltltitle.Text = "修改类别";
                ddl_type.Text = "0";
                NewType ClassItem = bll.GetNewTypeItem(classId);
                txt_ClassName.Text = ClassItem.ClassName;
                ddl_type.SelectedValue = ClassItem.ParentId.ToString();
                txt_SortId.Value = ClassItem.SortId.ToString();
            }
            else
            {
                ddl_type.SelectedValue = classId.ToString();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            NewType item = new NewType();
            item.Id = classId;
            item.ClassName = txt_ClassName.Text;
            item.ParentId = ddl_type.Text == "0" ? parentId : Convert.ToInt32(ddl_type.SelectedValue);
            item.SortId = Convert.ToInt32(txt_SortId.Value);
            if (action == "add")
            {
                if (bll.AddNewType(item) > 0)
                {
                    base.ErrorMsg("提交成功！", "NewsTypeList.aspx?pid=" + parentId, 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "NewsTypeList.aspx?pid=" + parentId, 0);
                }
            }
            else
            {
                if (bll.UpdateNewType(item) > 0)
                {
                    base.ErrorMsg("提交成功！", "NewsTypeList.aspx?pid=" + parentId, 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "NewsTypeList.aspx?pid=" + parentId, 0);
                }
            }
        }
    }
}
