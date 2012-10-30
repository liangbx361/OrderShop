using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Business;

namespace web.touch
{
    public partial class Area_Del : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = base.GetIntValue("id");
            if (!IsPostBack)
            {
                if (new AreaBLL().DeleteItem(Id) > 0)
                    base.ErrorMsg("删除成功", "AreaList.aspx", 1);
                else
                    base.ErrorMsg("删除失败", "AreaList.aspx", 0);
            }
        }
    }
}
