using System;

namespace Cudo.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int UserGroup { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPass { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别（0男 1女）
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 总积分
        /// </summary>
        public decimal TotalPoint { get; set; }

        /// <summary>
        /// 当前积分
        /// </summary>
        public decimal CurrentPoint { get; set; }

        /// <summary>
        /// 已消费积分
        /// </summary>
        public decimal UsePoint { get; set; }

        /// <summary>
        /// 推广的人数
        /// </summary>
        public int SpreadCount { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile{ get;set;}

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 会员类型（0普通，1商户）
        /// </summary>
        public int Utype { get; set; }

        /// <summary>
        /// 商户会员的店铺id
        /// </summary>
        public int ShopId { get; set; }

        public string ShopName { get; set; }

        public DateTime AddTime { get; set; }

        /// <summary>
        /// 推广的用户ID
        /// </summary>
        public int PromotionId { get; set; }
    }
}
