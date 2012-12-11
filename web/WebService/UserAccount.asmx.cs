using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.IO;

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
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        [WebMethod]
        public String changeMemberInfo(String values)
        {
            UserInfo item = new UserInfo();
            UsersBLL bll = new UsersBLL();
            JObject orderObject = JObject.Parse(values);

            item.Id = Convert.ToInt32(orderObject["id"].ToString());
            item.UserGroup = Convert.ToInt32(orderObject["usergroup"].ToString());
            item.Gender = Convert.ToInt32(orderObject["gender"].ToString());
            item.NickName = orderObject["nickName"].ToString().Replace("\"", "");
            item.Mobile = orderObject["phone"].ToString().Replace("\"", "");
            item.Email = orderObject["email"].ToString().Replace("\"", "");
            item.Birthday = orderObject["birthday"].ToString().Replace("\"", "");
            item.Address = orderObject["address"].ToString().Replace("\"", "");

            if (bll.UpdateUser(item) > 0)
            {
                return "ok";
            }
            else
            {
                return "fail";
            }
        }

        [WebMethod]
        public List<OrderInfo> getOrderList(int userid)
        {
            OrdersBLL bll = new OrdersBLL();
            return bll.GetListByUserId(1, 1, userid);

        }
    }
}
