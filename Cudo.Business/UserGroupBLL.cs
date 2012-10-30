using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class UserGroupBLL
    {
        public List<UserGroup> GetList()
        {
            return UserGroupDAL.GetList();
        }

        public UserGroup GetItemById(int id)
        {
            return UserGroupDAL.GetItemById(id);
        }

        public int AddItem(UserGroup item)
        {
            return UserGroupDAL.AddItem(item);
        }

        public int UpdateItem(UserGroup item)
        {
            return UserGroupDAL.UpdateItem(item);
        }

        public int DeleteItem(int id)
        {
            return UserGroupDAL.DeleteItem(id);
        }
    }
}
