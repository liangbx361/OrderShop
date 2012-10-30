using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;


/// <summary>
///RewriterConfigSerializerSectionHandler 返回一个反序列化 XML 文档
/// </summary>

namespace URLRewriter.Config
{
    public class RewriterConfigSerializerSectionHandler : IConfigurationSectionHandler 
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            // Create an instance of XmlSerializer based on the RewriterConfiguration type...
            // 创建一个类型为 RewriterConfiguration 的 XmlSerializer 实例对象
            XmlSerializer ser = new XmlSerializer(typeof(RewriterConfiguration));
            // Return the Deserialized object from the Web.config XML  返回从webConfig反序列化的XML对象
            return ser.Deserialize(new XmlNodeReader(section));
        }
    }
}
