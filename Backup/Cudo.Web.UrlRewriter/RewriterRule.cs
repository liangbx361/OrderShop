using System;

/// <summary>
///RewriterRule 的摘要说明
/// </summary>

namespace URLRewriter.Config
{
    public class RewriterRule
    {
        private string lookFor; //虚拟地址
        public string LookFor
        {
            get
            {
                return lookFor;
            }
            set
            {
                lookFor = value;
            }
        }

        private string sendTo; //真实地址
        public string SendTo
        {
            get
            {
                return sendTo;
            }
            set
            {
                sendTo = value;
            }
        }
    }
}
