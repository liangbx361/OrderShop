using System;

namespace Cudo.Entities
{
    public class MenuInfo
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 父类ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string UrlLink { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
