using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;

namespace web.touch
{
    public partial class FriendLink_AE : ManagePage
    {
        LinkBLL LinkBiz = new LinkBLL();
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            if (Id > 0)
            {
                Link LinkItem = LinkBiz.GetLinkItem(Id);
                txt_link_name.Value = LinkItem.LinkName;
                txt_link_site_url.Value = LinkItem.LinkUrl;
                txt_sortid.Value = LinkItem.SortId.ToString();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Link LinkItem = new Link();
            LinkItem.LinkName = txt_link_name.Value;
            LinkItem.LinkUrl = txt_link_site_url.Value;
            LinkItem.SortId = Convert.ToInt32(txt_sortid.Value);

            if (Id == 0)
            {
                //添加
                if (LinkBiz.AddLink(LinkItem) > 0)
                {
                    base.ErrorMsg("提交成功！", "FriendLinkList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "FriendLinkList.aspx", 0);
                }
            }
            else
            {
                //修改
                LinkItem.Id = Id;
                if (LinkBiz.UpdateLink(LinkItem) > 0)
                {
                    base.ErrorMsg("提交成功！", "FriendLinkList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "FriendLinkList.aspx", 0);
                }
            }
        }
    }
}
