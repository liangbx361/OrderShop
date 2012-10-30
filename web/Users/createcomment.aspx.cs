using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.Users
{
    public partial class createcomment : BasePage
    {
        private int shopid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin();
            shopid = base.GetIntValue("shopid");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShopCommentBLL bll = new ShopCommentBLL();
            UserInfo uinfo = Session["cudoUser"] as UserInfo;
            ShopComment item = new ShopComment();
            item.TotalPoint = Convert.ToInt32(stars_input.Value);
            item.TastePoint = Convert.ToInt32(ddltaste.Value);
            item.MilieuPoint = Convert.ToInt32(ddlmilieu.Value);
            item.ServicePoint = Convert.ToInt32(ddlservice.Value);
            item.CommentContent = txtcontent.Value;
            item.ShopId = shopid;
            item.UserId = uinfo.Id;
            item.UserName = uinfo.UserName;
            if (bll.AddShopComment(item) > 0)
            {
                Utils.alert("评价成功,感谢您的参与!", "mycommentlist.aspx");
            }
            else
            {
                Utils.alert("评价失败!", "createcomment.aspx?shopid=" + shopid);
            }
        }
    }
}
