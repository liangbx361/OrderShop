using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Cudo.Services;
using Cudo.Entities;

namespace Cudo.Business
{
    public class MenuBLL
    {
        public DataSet GetMenusBySql(string sql)
        {
            return MenuDAL.GetMenusBySql(sql);
        }

        public List<MenuInfo> GetMenuList(int parentId)
        {
            return MenuDAL.GetMenuList(parentId, 0, 0);
        }

        public List<MenuInfo> GetMenuList(int pageindex, int pagesize)
        {
            return MenuDAL.GetMenuList(pageindex, pagesize);
        }

        public List<MenuInfo> GetMenuList(int parentId, int pageindex, int pagesize)
        {
            return MenuDAL.GetMenuList(parentId, pageindex, pagesize);
        }

        /// <summary>
        /// 根据MenuID获取名称
        /// </summary>
        /// <param name="MenuID">MenuID</param>
        /// <returns>名称</returns>
        public string GetMenuNameById(int MenuID)
        {
            MenuInfo item = MenuDAL.GetMenuByMenuID(MenuID);
            return item != null ? item.MenuName : "";
        }

        /// <summary>
        /// 根据MenuID获取MenuEntity
        /// </summary>
        /// <param name="MenuID">MenuID</param>
        /// <returns>MenuEntity 对象</returns>
        public MenuInfo GetMenuByMenuID(int MenuID)
        {
            return MenuDAL.GetMenuByMenuID(MenuID);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="MenuItem">Menus 实体</param>
        /// <returns></returns>
        public int AddMenu(MenuInfo MenuItem)
        {
            return MenuDAL.AddMenu(MenuItem);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="MenuItem">Menus 实体</param>
        /// <returns></returns>
        public int UpdateMenu(MenuInfo MenuItem)
        {
            return MenuDAL.UpdateMenu(MenuItem);
        }

        public int UpdateMenu(int SortId, int MenuID)
        {
            return MenuDAL.UpdateMenu(SortId, MenuID);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuID">ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteMenu(int MenuID)
        {
            return MenuDAL.DeleteMenu(MenuID);
        }

        public int GetCount()
        {
            return MenuDAL.GetCount();
        }

        public int GetCount(int parentid)
        {
            return MenuDAL.GetCount(parentid);
        }
    }
}
