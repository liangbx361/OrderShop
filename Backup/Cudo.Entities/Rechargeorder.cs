using System;

namespace Cudo.Entities
{
    public class Rechargeorder
    {
        public int Id { get; set; }

        /// <summary>
        /// 充值单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string Payment { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int OrderStatus { get; set; }

        public DateTime AddTime { get; set; }
    }
}
