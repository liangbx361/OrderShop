using System;

namespace Cudo.Entities
{
    public class Favorites
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 店铺图片
        /// </summary>
        public string ShopPic { get; set; }

        /// <summary>
        /// 收藏人气
        /// </summary>
        public int Hit { get; set; }

        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
