using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class LinkBLL
    {
        /// <summary>
        /// 获取所有友情链接
        /// </summary>
        /// <returns>List数据集</returns>
        public List<Link> GetLinkList()
        {
            return LinkDAL.GetLinkList(0, 0);
        }

        /// <summary>
        /// 获取所有友情链接带分页
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <returns>List数据集</returns>

        public List<Link> GetLinkList(int pageindex, int pagesize)
        {
            return LinkDAL.GetLinkList(pageindex, pagesize);
        }

        /// <summary>
        /// 根据ID获取Item
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Link</returns>
        public Link GetLinkItem(int id)
        {
            return LinkDAL.GetLinkItem(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>受影响的行数</returns>
        public int AddLink(Link item)
        {
            return LinkDAL.AddLink(item);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>受影响的行数</returns>
        public int UpdateLink(Link item)
        {
            return LinkDAL.UpdateLink(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteLink(int id)
        {
            return LinkDAL.DeleteLink(id);
        }

        public int GetLinkCount()
        {
            return Convert.ToInt32(LinkDAL.GetLinkCount());
        }
    }
}
