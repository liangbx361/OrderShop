using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class NewTypeBLL
    {
        public List<NewType> GetList()
        {
            return NewTypeDAL.GetList();
        }

        public List<NewType> GetListByPid(int parentid)
        {
            return NewTypeDAL.GetList(parentid);
        }

        /// <summary>
        /// 根据ID获取Item
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>NewType</returns>
        public NewType GetNewTypeItem(int id)
        {
            return NewTypeDAL.GetNewTypeItem(id);
        }

        public string GetTypeNameById(int id)
        {
            NewType item = NewTypeDAL.GetNewTypeItem(id);
            return item != null ? item.ClassName : "";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item">NewType</param>
        /// <returns></returns>
        public int AddNewType(NewType item)
        {
            return NewTypeDAL.AddNewType(item);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item">NewType</param>
        /// <returns></returns>
        public int UpdateNewType(NewType item)
        {
            return NewTypeDAL.UpdateNewType(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public int DeleteNewType(int id)
        {
            return NewTypeDAL.DeleteNewType(id);
        }
    }
}
