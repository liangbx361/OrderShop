using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class AdvertBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <returns>List数据集</returns>

        public DataSet GetDataSetList()
        {
            return AdvertisingDAL.GetDataSetList(0);
        }

        public List<Advertising> GetAdvertList(int classid)
        {
            return AdvertisingDAL.GetAdvertList(classid);
        }

        /// <summary>
        /// 根据ID获取Item
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Link</returns>
        public Advertising GetAdvertItem(int id)
        {
            return AdvertisingDAL.GetAdvertItem(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>受影响的行数</returns>
        public int AddAdvert(Advertising item)
        {
            return AdvertisingDAL.AddAdvert(item);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>受影响的行数</returns>
        public int UpdateAdvert(Advertising item)
        {
            return AdvertisingDAL.UpdateAdvert(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteAdvert(int id)
        {
            return AdvertisingDAL.DeleteAdvert(id);
        }

    }
}
