using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Cudo.Services;
using Cudo.Entities;

namespace Cudo.Business
{
    public class SystemLogBLL
    {
        /// <summary>
        /// 添加日记
        /// </summary>
        /// <param name="LogItem">SystemLog 实体</param>
        /// <returns></returns>
        public int AddLog(SystemLog LogItem)
        {
            return SystemLogDAL.AddLog(LogItem);
        }

        /// <summary>
        /// 删除日记
        /// </summary>
        /// <param name="LogID">LogID</param>
        /// <returns></returns>
        public int DeleteLog(object LogID)
        {
            return SystemLogDAL.DeleteLog(LogID);
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void ClearLog()
        {
            SystemLogDAL.ClearLog();
        }

        /// <summary>
        /// 删除日记
        /// </summary>
        /// <param name="ListID">ID集合</param>
        /// <returns></returns>
        public int DeleteLogByIdList(string ListID)
        {
            return SystemLogDAL.DeleteLogByIdList(ListID);
        }
    }
}
