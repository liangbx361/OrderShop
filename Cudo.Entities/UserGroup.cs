using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 用户等级
    /// </summary>
    public class UserGroup
    {
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public int Zk { get; set; }
    }
}
