using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class ShopCommentBLL
    {
        /// <summary>
        /// 获取用户评论列表
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="shopid">店铺ID</param>
        /// <returns>List</returns>
        public List<ShopComment> GetShopCommentsByUserId(int pageindex, int pagesize, int userid)
        {
            return ShopCommentDAL.GetShopCommentsByUserId(pageindex, pagesize, userid);
        }

        /// <summary>
        /// 获取店铺评论列表
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="shopid">店铺ID</param>
        /// <returns>List</returns>
        public List<ShopComment> GetShopCommentsByShopId(int pageindex, int pagesize, int shopid, int checkstatus)
        {
            return ShopCommentDAL.GetShopCommentsByShopId(pageindex, pagesize, shopid, checkstatus);
        }

        public List<ShopComment> GetShopCommentsByShopId(int pageindex, int pagesize, int shopid)
        {
            return ShopCommentDAL.GetShopCommentsByShopId(pageindex, pagesize, shopid, 0);
        }

        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>item</returns>
        public ShopComment GetShopComment(int id)
        {
            return ShopCommentDAL.GetShopComment(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddShopComment(ShopComment item)
        {
            return ShopCommentDAL.AddShopComment(item);
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="checkstatus"></param>
        /// <returns></returns>
        public int UpdateShopComment(int id, int checkstatus)
        {
            return ShopCommentDAL.UpdateShopComment(id, checkstatus);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int DeleteShopComment(int id)
        {
            return ShopCommentDAL.DeleteShopComment(id);
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="shopid">店铺ID</param>
        /// <returns></returns>
        public int GetCountByShopId(int shopid, int checkstatus)
        {
            return ShopCommentDAL.GetCountByShopId(shopid, checkstatus);
        }

        public int GetCountByShopId(int shopid)
        {
            return ShopCommentDAL.GetCountByShopId(shopid, 2);
        }

        public int GetCountByUserId(int userid)
        {
            return ShopCommentDAL.GetCountByUserId(userid);
        }
    }
}
