using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 地区
    /// </summary>
     
    public class Area
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int Pid { get; set; }

        /// <summary>
        /// 大写字母
        /// </summary>
        public string AreaKey { get; set; }
    }
}
