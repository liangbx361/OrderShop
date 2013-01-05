using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;
using System.Data;

namespace web.WebService
{
    /// <summary>
    /// shoplistWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ShopList : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet getShopList(string sortType)
        {
            ShopsBLL bll = new ShopsBLL();
            DataSet ds = bll.GetListByAreaId(0);

            return ds;
        }

        /// <summary>
        /// 根据id搜索餐厅
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="sid"></param>
        /// <param name="did"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet getShopListByAddressId(int aid, int sid, int did, string orderType)
        {
            ShopsBLL bll = new ShopsBLL();
            DataSet ds = null;
 
            if (did > 0)
                ds = bll.GetListByDistrictId(did);  //根据楼宇搜索
            else if (sid > 0)
                ds = bll.GetListByStreetId(sid);    //根据街道搜索
            else
                ds = bll.GetListByAreaIdSort(aid, orderType); //搜索所有的数据

            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        return ds;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 通过用户id来搜索用户的地址 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet getShopListByUserId(int userId, string orderType)
        {
            UsersBLL userBll = new UsersBLL();
            UserInfo userInfo = userBll.GetUserByID(userId);

            if (userInfo != null)
            {
                string[] itemlist = userInfo.Address.Split('|')[0].Split(',');

                DataSet ds = getShopListByAddressId(Convert.ToInt32(itemlist[0]), Convert.ToInt32(itemlist[1]), Convert.ToInt32(itemlist[2]), orderType);
                return ds;
            }
            else
            {
                return null;
            }
            
        }   
    }
}
