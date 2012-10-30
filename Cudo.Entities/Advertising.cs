using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 广告类
    /// </summary>

    public class Advertising
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
        /// 类别ID
        /// </summary>
        public int ClassId
        {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string AdvertName
        {
            get;
            set;
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string AdvertPic
        {
            get;
            set;
        }

        /// <summary>
        /// 链接
        /// </summary>
        public string AdvertLink
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
