using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 用户权限类
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// ID（自动编号）
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 权限
        /// </summary>
        public string Permissions
        {
            get;
            set;
        }
    }
}
