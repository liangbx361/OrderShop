using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace web.WebService
{
    /// <summary>
    /// OrderCheck 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "", Name = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class OrderCheck : System.Web.Services.WebService
    {
        
        [WebMethod]
        public void orderCheck(string orderMesage)
        {
        }
    }
}
