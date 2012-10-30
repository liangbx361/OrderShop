using System;

namespace Cudo.Entities
{
    public class UserProfit
    {
        public int id { get; set; }

        public int userid { get; set; }

        /// <summary>
        /// 推广会员
        /// </summary>
        public int reguid { get; set; }

        /// <summary>
        /// 会员名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime xftime { get; set; }

        /// <summary>
        /// 消费积分
        /// </summary>
        public decimal xfpoint { get; set; }

        /// <summary>
        /// 收益积分
        /// </summary>
        public decimal sypoint { get; set; }
    }
}
