using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class ShopTypeBLL
    {
        public List<ShopType> GetList()
        {
            return ShopTypeDAL.GetList();
        }

        public ShopType GetItem(int id)
        {
            return ShopTypeDAL.GetItem(id);
        }

        public string GetTypeNameById(int id)
        {
            ShopType item = ShopTypeDAL.GetItem(id);
            return item != null ? item.TypeName : "";
        }

        public int AddItem(ShopType item)
        {
            return ShopTypeDAL.AddItem(item);
        }

        public int UpdateItem(ShopType item)
        {
            return ShopTypeDAL.UpdateItem(item);
        }

        public int DeleteItem(int id)
        {
            return ShopTypeDAL.DeleteItem(id);
        }
    }
}
