using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 店铺信息
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 店铺类型
        /// </summary>
        public int ShopType { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ShopPic { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string OpenTime { get; set; }

        /// <summary>
        /// 点餐时间段
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 最低起送费
        /// </summary>
        public decimal LimitPrice { get; set; }

        /// <summary>
        /// 外送费
        /// </summary>
        public decimal SendPrice { get; set; }

        /// <summary>
        /// 送达时间
        /// </summary>
        public int SendTime { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string Payment { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 人气
        /// </summary>
        public int Hit { get; set; }

        /// <summary>
        /// 总体评分总和
        /// </summary>
        public int SumPoint { get; set; }

        /// <summary>
        /// 口味评分总和
        /// </summary>
        public int SumTastePoint { get; set; }

        /// <summary>
        /// 环境评分总和
        /// </summary>
        public int SumMilieuPoint { get; set; }

        /// <summary>
        /// 服务评分总和
        /// </summary>
        public int SumServicePoint { get; set; }

        /// <summary>
        /// 总评价人数
        /// </summary>
        public int SumPerson { get; set; }

        /// <summary>
        /// 折扣比例
        /// </summary>
        public int zk { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 平均
        /// </summary>
        public int AvgPoint
        {
            get
            {
                try
                {
                    return this.SumPoint / SumPerson;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 平均口味
        /// </summary>
        public decimal AvgTastePoint
        {
            get 
            {
                try
                {
                    return Convert.ToDecimal(this.SumTastePoint / SumPerson);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 平均环境
        /// </summary>
        public decimal AvgMilieuPoint
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.SumMilieuPoint / SumPerson);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 平均服务
        /// </summary>
        public decimal AvgServicePoint
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.SumServicePoint / SumPerson);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int ShopOrder { get; set; }

        /// <summary>
        /// 点评数量
        /// </summary>
        public int ShopComment { get; set; }
    }
}
