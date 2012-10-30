using System;
using System.Web;
using System.Web.Caching;
using System.Configuration;
using System.Xml.Serialization;
using Cudo.Common;
using System.Xml;

/// <summary>
///RewriterConfiguration 返回配制节点信息

/// </summary>
namespace URLRewriter.Config
{
    [Serializable()]
    [XmlRoot("RewriterConfig")]
    public class RewriterConfiguration
    {
        public static RewriterConfiguration GetConfig()
        {
            if (HttpContext.Current.Cache["RewriterConfig"] == null)
            {
                //object spath = ConfigurationManager.GetSection("RewriterConfig");
                //HttpContext.Current.Cache.Insert("RewriterConfig", ConfigurationSettings.GetConfig("RewriterConfig"));
                
                XmlDocument xmldoc = new XmlDocument();
                string path = ConfigurationManager.AppSettings["Urlspath"]; //xml文件路径
                xmldoc.Load(HttpContext.Current.Server.MapPath(path));
                XmlNode node = xmldoc.SelectSingleNode("RewriterConfig");
                RewriterConfigSerializerSectionHandler configHandler = new RewriterConfigSerializerSectionHandler();
                HttpContext.Current.Cache.Insert("RewriterConfig", configHandler.Create(null, null, node));
            }
            return (RewriterConfiguration)HttpContext.Current.Cache["RewriterConfig"];
        }

        #region Public Properties
        /// <summary>
        /// As<see cref="RewriterRuleCollection"/> instance that provides access to a set of <see cref="RewriterRule"/>s.
        /// </summary>
        
        // 私有成员变量
        private RewriterRuleCollection rules;   // 一个实例
        public RewriterRuleCollection Rules
        {
            get
            {
                return rules;
            }
            set
            {
                rules = value;
            }
        }
        #endregion
    }
}