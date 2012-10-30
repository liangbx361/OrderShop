using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;

namespace web.touch
{
    public partial class NewsTypeDel : ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = base.GetIntValue("classId");
            if (!IsPostBack)
            {
                DeteCategory();
            }
        }

        protected void DeteCategory()
        {
            if (new NewTypeBLL().DeleteNewType(id) > 0)
            {
                base.ErrorMsg("删除成功!", Request.UrlReferrer.ToString(), 1);
            }
            else
            {
                base.ErrorMsg("删除失败!", Request.UrlReferrer.ToString(), 0);
            }
        }
    }
}
