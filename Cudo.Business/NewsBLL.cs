using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class NewsBLL
    {
        public List<NewInfo> GetNewList(int pageindex, int pagesize)
        {
            return NewsDAL.GetNewList(pageindex, pagesize);
        }

        /// <summary>
        /// 根据类别获取新闻
        /// </summary>
        /// <param name="classid">类别ID</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <returns>List数据集</returns>
        public List<NewInfo> GetNewList(int pageindex, int pagesize,int classid)
        {
            return NewsDAL.GetNewList(pageindex, pagesize, classid);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="keywords">关键字</param>
        /// <returns></returns>
        public List<NewInfo> GetNewList(int pageindex, int pagesize, string keywords)
        {
            return NewsDAL.GetNewList(pageindex, pagesize, keywords);
        }

        public List<NewInfo> GetTopNewList(int classid, int topsize)
        {
            return NewsDAL.GetNewList(1, topsize, classid);
        }

        /// <summary>
        /// 根据ID获取新闻
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>NewInfo</returns>
        public NewInfo GetNewItem(int id)
        {
            return NewsDAL.GetNewItem(id);
        }

        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="item">NewInfo</param>
        /// <returns></returns>
        public int AddNew(NewInfo item)
        {
            return NewsDAL.AddNew(item);
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="item">NewInfo</param>
        /// <returns></returns>
        public int UpdateNew(NewInfo item)
        {
            return NewsDAL.UpdateNew(item);
        }

        public int UpdateNew(int SortId, int id)
        {
            return NewsDAL.UpdateNew(SortId, id);
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public int DeleteNew(int id)
        {
            return NewsDAL.DeleteNew(id);
        }

        public int GetCount()
        {
            return Convert.ToInt32(NewsDAL.GetCount());
        }

        public int GetCount(int classid)
        {
            return Convert.ToInt32(NewsDAL.GetCountByClassId(classid));
        }

        public int GetCount(string keywords)
        {
            return Convert.ToInt32(NewsDAL.GetCount(keywords));
        }
    }
}
