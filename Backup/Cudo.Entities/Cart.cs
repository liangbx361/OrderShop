using System;

namespace Cudo.Entities
{
    public class Cart
    {
        public int CartID
        {
            get;
            set;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get;
            set;
        }

        public int ShopID
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣
        /// </summary>
        public int zk { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductID
        {
            get;
            set;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyNum
        {
            get;
            set;
        }

        /// <summary>
        /// 小计
        /// </summary>
        public decimal SumPrice
        {
            get
            {
                return this.Price * BuyNum;
            }
        }
    }
}
