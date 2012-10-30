using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class UserAddressBLL
    {
        /// <summary>
        /// 获取用户地址簿
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public List<UserAddress> GetList(int userid)
        {
            return UserAddressDAL.GetList(userid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserAddress GetAddressByID(int id)
        {
            return UserAddressDAL.GetItemByID(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddAddress(UserAddress item)
        {
            return UserAddressDAL.AddItem(item);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int UpdateAddress(UserAddress item)
        {
            return UserAddressDAL.UpdateItem(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public int DeleteAddress(int id)
        {
            return UserAddressDAL.DeleteItem(id);
        }
    }
}
