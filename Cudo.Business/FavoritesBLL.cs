using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class FavoritesBLL
    {
        public List<Favorites> GetList(int pageindex, int pagesize, int userid)
        {
            return FavoritesDAL.GetList(pageindex, pagesize, userid);
        }

        public int AddItem(Favorites item)
        {
            return FavoritesDAL.AddItem(item);
        }

        public int DeleteItem(int id)
        {
            return FavoritesDAL.DeleteItem(id);
        }

        public int GetCount(int userid)
        {
            return FavoritesDAL.GetCount(userid);
        }
    }
}
