using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Cudo.Business;
using Cudo.Entities;
using Cudo.Common;

namespace web.touch
{
    public partial class NewsEdit : ManagePage
    {
        NewsBLL NewBiz = new NewsBLL();
        protected int parentId = 0;
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            parentId = base.GetIntValue("pid");
            Id = base.GetIntValue("id");
            if (!IsPostBack)
            {
                BindCategory();
                PageInit();
            }
        }

        #region 递归绑定类别
        private void BindCategory()
        {
            List<NewType> list = new NewTypeBLL().GetList();
            if (list.Count > 0)
            {
                List<NewType> list1 = list.FindAll(delegate(NewType ca) { return ca.Id == parentId; });
                foreach (NewType item in list1)
                {
                    ddl_type.Items.Add(new ListItem(item.ClassName, item.Id.ToString()));
                }
                List<NewType> list2 = list.FindAll(delegate(NewType ca) { return ca.ParentId == parentId; });
                foreach (NewType item in list2)
                {
                    ddl_type.Items.Add(new ListItem(Utils.SpaceLength(1) + item.ClassName, item.Id.ToString()));
                    bindChild(list, 2, item.Id, ddl_type);
                }
            }
            //ddl_type.Items.Insert(0, new ListItem("-请选择-", "0"));
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
            if (Id > 0)
            {
                NewInfo NewItem = NewBiz.GetNewItem(Id);
                ddl_type.SelectedValue = NewItem.ClassId.ToString();
                txtArticleTitle.Value = NewItem.NewTitle;
                txtSortId.Value = NewItem.SortId.ToString();
                txtAddTime.Value = NewItem.AddTime.ToString();
                txtArticleContent.Value = NewItem.NewContent;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            NewInfo NewItem = NewBiz.GetNewItem(Id);
            NewItem.ClassId = Convert.ToInt32(ddl_type.SelectedValue);
            NewItem.NewTitle = txtArticleTitle.Value;
            NewItem.SortId = Convert.ToInt32(txtSortId.Value);
            NewItem.AddTime = Convert.ToDateTime(txtAddTime.Value);
            NewItem.NewContent = txtArticleContent.Value;

            if (NewBiz.UpdateNew(NewItem) > 0)
            {
                base.ErrorMsg("提交成功！", "NewsList.aspx?pid=" + parentId, 1);
            }
            else
            {
                base.ErrorMsg("提交失败！", "NewsList.aspx?pid=" + parentId, 1);
            }
        }
    }
}
