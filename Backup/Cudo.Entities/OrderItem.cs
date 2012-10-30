using System;

namespace Cudo.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyNum { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        public decimal TotalPrice
        {
            get { return this.BuyNum * this.Price; }
        }
    }
}
