using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 用户地址簿
    /// </summary>
    public class UserAddress
    {
        public int Id
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile
        {
            get;
            set;
        }

        /// <summary>
        /// 是否默认（0否，1是）
        /// </summary>
        public int IsDefault
        {
            get;
            set;
        }
    }
}
