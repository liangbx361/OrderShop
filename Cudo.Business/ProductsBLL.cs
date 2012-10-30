using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class ProductsBLL
    {
        public List<Product> GetList(int pageindex, int pagesize)
        {
            return ProductsDAL.GetList(pageindex, pagesize);
        }

        /// <summary>
        /// 根据店铺和类别获取菜单
        /// </summary>
        /// <param name="typeid">类别ID</param>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public List<Product> GetListByShopId(int pageindex, int pagesize, int shopid)
        {
            return ProductsDAL.GetList(pageindex, pagesize, shopid);
        }

        /// <summary>
        /// 根据店铺和类别获取菜单
        /// </summary>
        /// <param name="typeid">类别ID</param>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public List<Product> GetListByTypeAndShop(int typeid,int shopid)
        {
            return ProductsDAL.GetListByTypeAndShop(typeid, shopid);
        }

        public Product GetItem(int id)
        {
            return ProductsDAL.GetItem(id);
        }

        public string GetProductNameById(int id)
        {
            return ProductsDAL.GetItem(id).ProductName;
        }

        public int AddItem(Product item)
        {
            return ProductsDAL.AddItem(item);
        }

        public int UpdateItem(Product item)
        {
            return ProductsDAL.UpdateItem(item);
        }

        public int DeleteItem(int id)
        {
            return ProductsDAL.DeleteItem(id);
        }

        public int GetCount()
        {
            return ProductsDAL.GetCount();
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public int GetCount(int shopid)
        {
            return ProductsDAL.GetCount(shopid);
        }

        public int CheckProductName(int shopid, string proname)
        {
            return ProductsDAL.CheckProductName(shopid, proname);
        }
    }
}
