using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 推广链接
    /// </summary>
    public class JoinPromotion
    {
        /// <summary>
        /// 注册用户的ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int UserGroup { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        public DateTime time { get; set; }

        public int upoint { get; set; }
    }
}
