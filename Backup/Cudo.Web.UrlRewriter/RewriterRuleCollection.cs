using System;
using System.Collections;

/// <summary>
///RewriterRuleCollection 的摘要说明
/// </summary>
/// 

namespace URLRewriter.Config
{
    [Serializable()]
    public class RewriterRuleCollection : CollectionBase
    {
        /// <summary>
        /// 添加一个新的RewriterRule集合
        /// </summary>
        /// <param name="r">RewriterRule 实例</param>
        public virtual void Add(RewriterRule r)
        {
            this.InnerList.Add(r);
        }

        /// <summary>
        /// 获取或设置在指定序号索引RewriterRule
        /// </summary>
        public RewriterRule this[int index]
        {
            get
            {
                return (RewriterRule)this.InnerList[index];
            }
            set
            {
                this.InnerList[index] = value;
            }
        }
    }
}
