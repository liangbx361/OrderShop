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
    /// ShopInfo 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ShopInfo : System.Web.Services.WebService
    {

        [WebMethod]
        //获取该餐厅外卖种类列表
        public List<ProductType> getProductList(int shopId)
        {
            List<ProductType> productList = new ProductTypeBLL().GetListByShopId(shopId);

            return productList;
        }

        [WebMethod]
        //获取外卖种类的产品列表
        public List<Product> getProduct(int shopId, int productId)
        {
            List<Product> list = new ProductsBLL().GetListByTypeAndShop(productId, shopId);

            return list;
        }
    }
}
