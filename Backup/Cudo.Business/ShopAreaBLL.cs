using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class ShopAreaBLL
    {
        public int AddItem(int shopid, int areaid, int streetid, int districtid)
        {
            return ShopAreaDAL.AddItem(shopid, areaid, streetid, districtid);
        }

        public int CheckShopArea(int shopid, int districtid)
        {
            return ShopAreaDAL.CheckShopArea(shopid, districtid);
        }

        public int DeleteItem(int shopid, int areaid)
        {
            return ShopAreaDAL.DeleteItem(shopid, areaid);
        }
    }
}
