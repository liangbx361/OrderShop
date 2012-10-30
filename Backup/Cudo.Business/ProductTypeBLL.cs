using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class ProductTypeBLL
    {
        /// <summary>
        /// 根据店铺ID获取产品类别
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns>List</returns>
        public List<ProductType> GetListByShopId(int shopid)
        {
            return ProductTypeDAL.GetList(shopid);
        }

        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="id">产品类别ID</param>
        /// <returns></returns>
        public ProductType GetItem(int id)
        {
            return ProductTypeDAL.GetItem(id);
        }

        public string GetTypeNameById(int typeid)
        {
            ProductType item = ProductTypeDAL.GetItem(typeid);
            return item != null ? item.TypeName : "";
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddItem(ProductType item)
        {
            return ProductTypeDAL.AddItem(item);
        }

        /// <summary>
        /// 修改产品类别
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int UpdateItem(ProductType item)
        {
            return ProductTypeDAL.UpdateItem(item);
        }

        /// <summary>
        /// 删除产品类别
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int DeleteItem(int id)
        {
            return ProductTypeDAL.DeleteItem(id);
        }
    }
}
