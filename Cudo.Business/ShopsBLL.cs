using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;
using System.Data;

namespace Cudo.Business
{
    public class ShopsBLL
    {
        public DataSet GetListByAreaId(int areaid)
        {
            return ShopsDAL.GetListByAreaId(areaid, "area");
        }

        public DataSet GetListByStreetId(int streetid)
        {
            return ShopsDAL.GetListByAreaId(streetid, "street");
        }

        public DataSet GetListByDistrictId(int districtid)
        {
            return ShopsDAL.GetListByAreaId(districtid, "district");
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="sortstr">排序</param>
        /// <returns>List</returns>
        public List<Shop> GetList(int pageindex, int pagesize)
        {
            return ShopsDAL.GetList(pageindex, pagesize);
        }

        /// <summary>
        /// 按照名称搜索
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public DataSet GetListByKeyword(string keyword)
        {
            return ShopsDAL.GetListByKeyword(keyword);
        }

        public List<Shop> GetListBydid(int did)
        {
            return ShopsDAL.GetListBydid(did);
        }

        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public Shop GetShopItem(int shopid)
        {
            return ShopsDAL.GetShopItem(shopid);
        }

        public string GetShopNameById(int shopid)
        {
            Shop item = ShopsDAL.GetShopItem(shopid);
            return item != null ? item.ShopName : "";
        }

        /// <summary>
        /// 获取折扣
        /// </summary>
        public int GetShopZK(int shopid)
        {
            Shop item = ShopsDAL.GetShopItem(shopid);
            return item != null ? item.zk : 0;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ShopItem">item</param>
        /// <returns></returns>
        public int AddShop(Shop ShopItem)
        {
            return ShopsDAL.AddShop(ShopItem);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ShopItem">item</param>
        /// <returns></returns>
        public int UpdateShop(Shop ShopItem)
        {
            return ShopsDAL.UpdateShop(ShopItem);
        }

        /// <summary>
        /// 更新人气度
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public int UpdateShopHit(int shopid)
        {
            return ShopsDAL.UpdateShopHit(shopid);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public int DeleteShop(int shopid)
        {
            return ShopsDAL.DeleteShop(shopid);
        }

        public int GetCount()
        {
            return ShopsDAL.GetCount();
        }

        public int CheckShopByShopName(string shopname)
        {
            return ShopsDAL.CheckShopByShopName(shopname);
        }
    }
}
