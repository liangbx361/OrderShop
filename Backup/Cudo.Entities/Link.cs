using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 友情链接实体类
    /// </summary>

    public class Link
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
        /// 名称
        /// </summary>
        public string LinkName
        {
            get;
            set;
        }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortId
        {
            get;
            set;
        }
    }
}
