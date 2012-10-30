using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 店铺评价
    /// </summary>
    public class ShopComment
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 总体评分
        /// </summary>
        public int TotalPoint { get; set; }

        /// <summary>
        /// 口味评分
        /// </summary>
        public int TastePoint { get; set; }

        /// <summary>
        /// 环境评分
        /// </summary>
        public int MilieuPoint { get; set; }

        /// <summary>
        /// 服务评分
        /// </summary>
        public int ServicePoint { get; set; }

        /// <summary>
        /// 评价内容
        /// </summary>
        public string CommentContent { get; set; }

        /// <summary>
        /// 是否审核（0未审核，1已审核）
        /// </summary>
        public int CheckStatus { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
