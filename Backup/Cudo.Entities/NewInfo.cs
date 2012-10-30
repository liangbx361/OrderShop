using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 新闻实体类
    /// </summary>

    public class NewInfo
    {
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 类别
        /// </summary>
        public int ClassId
        {
            get;
            set;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string NewTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string NewContent
        {
            get;
            set;
        }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro
        {
            get;
            set;
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImgSrc
        {
            get;
            set;
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            get;
            set;
        }

        /// <summary>
        /// 人气
        /// </summary>
        public int Hit
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
