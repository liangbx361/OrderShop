using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 新闻类别
    /// </summary>

    public class NewType
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
        /// 类别名称
        /// </summary>
        public string ClassName
        {
            get;
            set;
        }

        /// <summary>
        /// 父类ID
        /// </summary>
        public int ParentId
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
