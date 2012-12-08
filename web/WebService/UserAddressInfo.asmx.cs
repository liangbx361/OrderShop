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

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        public int deleteAddress(int id)
        {
            UserAddressBLL bll = new UserAddressBLL();
            return bll.DeleteAddress(id);
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<Area> getArea()
        {
            AreaBLL abll = new AreaBLL();
            return abll.GetList(0);
        }

        /// <summary>
        /// 获取街道
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Area> getStreet(string aid)
        {
            AreaBLL abll = new AreaBLL();
            return abll.GetListByidlist(aid);
        }

        /// <summary>
        /// 获取楼宇
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Area> getDistrict(string sid)
        {
            AreaBLL abll = new AreaBLL();
            return abll.GetListByidlist(sid);
        }
    }
}
