using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.WebService
{
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UserAccount : System.Web.Services.WebService
    {
        [WebMethod]
        public string chanagePassword(string username, string password)
        {
            UsersBLL bll = new UsersBLL();
            string _password = Utils.MD5Encrypt32(password);
            int userId = bll.CheckUserIDByUserName(username);

            if (bll.UpdatePass(Utils.MD5Encrypt32(password), userId) > 0)
            {
                return _password;
            }
            else {
                return null;
            }
        }
    }
}
