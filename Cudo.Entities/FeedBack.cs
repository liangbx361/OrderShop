using System;

namespace Cudo.Entities
{
    public class FeedBack
    {
        public int Id { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 反馈信息
        /// </summary>
        public string Content { get; set; }

        public DateTime AddTime { get; set; }
    }
}
