using System;

namespace Cudo.Entities
{
    public class AdminUser
    {
        /// <summary>
        /// ID
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
        /// 密码
        /// </summary>
        public string UserPwd
        {
            get;
            set;
        }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get;
            set;
        }
 
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string LoginIP
        {
            get;
            set;
        }

        /// <summary>
        /// 是否系统
        /// </summary>
        public int IsSystem
        {
            get;
            set;
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime AddTime
        {
            get;
            set;
        }
    }
}
