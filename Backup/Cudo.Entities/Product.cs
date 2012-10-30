using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImgSrc { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 价格2
        /// </summary>
        public decimal Price2 { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 出售状态（0下架，1上架）
        /// </summary>
        public int SellStatus { get; set; }
    }
}
