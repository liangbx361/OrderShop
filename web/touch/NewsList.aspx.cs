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
    public partial class NewsList : ManagePage
    {
        NewsBLL bll = new NewsBLL();
        protected int parentId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            parentId = base.GetIntValue("pid");
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
            int classid = Convert.ToInt32(ddl_type.SelectedValue);
            WebPager.RecordCount = bll.GetCount(classid);
            myGrid.DataSource = bll.GetNewList(WebPager.CurrentPageIndex, WebPager.PageSize, classid);
            myGrid.DataBind();
        }

        protected string GetTypeNameById(object classId)
        {
            return new NewTypeBLL().GetTypeNameById(Convert.ToInt32(classId));
        }

        protected override void myGrid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            base.myGrid_ItemCreated(sender, e);
        }

        protected void myGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                bll.DeleteNew(Convert.ToInt32(e.CommandArgument)); 
                HiddenField hf_img = e.Item.Cells[7].FindControl("hf_img") as HiddenField;
                FileOperate.DeleteFile(Server.MapPath("~/" + hf_img.Value));
            }
            PageInit();
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            #region 批量删除
            foreach (DataGridItem item in myGrid.Items)
            {
                //循环判断是否选中，选中则获取id
                CheckBox cb = (CheckBox)item.Cells[1].FindControl("chkdg");
                if (cb.Checked)
                {
                    bll.DeleteNew(Convert.ToInt32(item.Cells[0].Text)); 
                    HiddenField hf_img = item.Cells[7].FindControl("hf_img") as HiddenField;
                    FileOperate.DeleteFile(Server.MapPath("~/" + hf_img.Value));
                }
            }
            PageInit();
            #endregion
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            foreach (DataGridItem item in myGrid.Items)
            {
                TextBox txt_SortID = (TextBox)item.FindControl("txt_SortID");
                if (txt_SortID.Text != "")
                {
                    bll.UpdateNew(Convert.ToInt32(txt_SortID.Text), Convert.ToInt32(item.Cells[0].Text));
                }
            }
            PageInit();
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            PageInit();
        }

        protected void WebPager_PageChanged(object sender, EventArgs e)
        {
            PageInit();
        }
    }
}
