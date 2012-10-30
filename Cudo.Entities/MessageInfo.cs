using System;

namespace Cudo.Entities
{
    /// <summary>
    /// 留言信息实体类
    /// </summary>

    public class MessageInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string MsgContent { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 查看状态（0未读，1已读）
        /// </summary>
        public int Status { get; set; }
    }
}
