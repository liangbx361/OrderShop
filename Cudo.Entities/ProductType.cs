using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 产品类别
    /// </summary>
    public class ProductType
    {
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string TypeName
        {
            get;
            set;
        }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId
        {
            get;
            set;
        }
    }
}
