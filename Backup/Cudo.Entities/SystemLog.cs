using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 日记实体类
    /// </summary>

    public class SystemLog
    {
        /// <summary>
        /// ID(自动编号)
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string LogInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddTime
        {
            get;
            set;
        }
    }
}
