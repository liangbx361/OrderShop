using System;
using System.Text.RegularExpressions;
using System.Configuration;
using URLRewriter.Config;

/// <summary>
///ModuleRewriter 循环出每个rule执行RewriteUrl
/// </summary>
namespace URLRewriter
{
    public class ModuleRewriter : BaseModuleRewriter
    {
        protected override void Rewrite(string requestedPath, System.Web.HttpApplication app)
        {
            // get the configuration rules 获得配置规则
            RewriterRuleCollection rules = RewriterConfiguration.GetConfig().Rules;

            // iterate through each rule... 遍历每个规则...
            for (int i = 0; i < rules.Count; i++)
            {
                // get the pattern to look for, and Resolve the Url (convert ~ into the appropriate directory) 获得要查找的模式，并且解析 Url（转换为相应的目录）
                string lookFor = "^" + RewriterUtils.ResolveUrl(app.Context.Request.ApplicationPath,rules[i].LookFor) + "$";

                // Create a regex (note that IgnoreCase is set...) 创建 regex（请注意，已设置 IgnoreCase...）
                Regex re = new Regex(lookFor, RegexOptions.IgnoreCase);

                //See if a match is found 查看是否找到了匹配的规则

                if (re.IsMatch(requestedPath))
                {
                    //match found - do any replacement needed 找到了匹配的规则 -- 进行必要的替换
                    string sendToUrl = RewriterUtils.ResolveUrl(app.Context.Request.ApplicationPath, re.Replace(requestedPath, rules[i].SendTo));

                    // Rewrite the URL 重写 URL
                    RewriterUtils.RewriteUrl(app.Context, sendToUrl);
                    break; //exit the for loop 退出 For 循环
                }
            }
        }
    }
}
