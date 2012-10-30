using System;

namespace Cudo.Entities
{
    public class OrderInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }

        public string ShopName { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 消费的积分
        /// </summary>
        public decimal OrderPoint { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string UserTel { get; set; }

        /// <summary>
        /// 收获地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 楼宇id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 订单状态（0未处理，1处理中，2已完成，3作废）
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 支付状态（0未支付，1已支付）
        /// </summary>
        public int PayStatus { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime AddTime { get; set; }

    }
}
