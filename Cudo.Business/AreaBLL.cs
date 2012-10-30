using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class AreaBLL
    {
        public List<Area> GetList()
        {
            return AreaDAL.GetList();
        }

        public List<Area> GetList(int pid)
        {
            return AreaDAL.GetList(pid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public List<Area> GetListByidlist(string idlist)
        {
            return AreaDAL.GetList(idlist);
        }

        public List<Area> GetListByShopId(int shopid)
        {
            return AreaDAL.GetListByShopId(shopid);
        }

        public Area GetItem(int id)
        {
            return AreaDAL.GetItem(id);
        }

        public string GetAreaName(int id)
        {
            Area item = AreaDAL.GetItem(id);
            return item != null ? item.AreaName : "";
        }

        public int AddItem(Area item)
        {
            return AreaDAL.AddItem(item);
        }

        public int UpdateItem(Area item)
        {
            return AreaDAL.UpdateItem(item);
        }

        public int DeleteItem(int id)
        {
            return AreaDAL.DeleteItem(id);
        }

        public int CheckAreaName(string areaname)
        {
            return AreaDAL.CheckAreaName(areaname);
        }
    }
}
