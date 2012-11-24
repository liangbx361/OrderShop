/************************************************************************/
/* 登录账号检测                                                                     
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.WebService
{
    /// <summary>
    /// LoginWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LoginCheck : System.Web.Services.WebService
    {
        [WebMethod]
        //登录后返回用户信息
        public UserInfo getLoginUserInfo(string username, string password)
        {
            UsersBLL bll = new UsersBLL();
            UserInfo item = bll.UserLogin(username, password);
          
            if (item != null)
            {
                DataSet data = new DataSet("userInfo");     
            }
            return item;
        }

        [WebMethod]
        //登录验证接口
        public string login(string username, string password)
        {
            string _password = Utils.MD5Encrypt32(password);

            UsersBLL bll = new UsersBLL();
            UserInfo item = bll.UserLogin(username, _password);

            if (item != null)
            {
                return _password;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public bool autoLoginCheck(string username, string password)
        {
            UsersBLL bll = new UsersBLL();
            UserInfo item = bll.UserLogin(username, password);

            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
