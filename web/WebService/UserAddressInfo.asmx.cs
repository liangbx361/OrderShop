using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Cudo.Business;
using Cudo.Entities;

namespace web.WebService
{
    /// <summary>
    /// UserAddressInfo 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UserAddressInfo : System.Web.Services.WebService
    {
        [WebMethod]
        public UserAddress getDefaultAddress(int userId)
        {
            UserAddressBLL user = new UserAddressBLL();
            return user.GetDefaultAddress(userId);
        }

        [WebMethod]
        public List<UserAddress> getList(int userId)
        {
            UserAddressBLL user = new UserAddressBLL();
            return user.GetList(userId);
        }
    }
}
