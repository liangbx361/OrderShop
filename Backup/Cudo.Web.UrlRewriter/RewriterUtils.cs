using System;
using System.Web;

/// <summary>
///RewriterUtils 根据设定的路径转换URL并进行RewritePath
//可以看到最后，只是执行了context.RewritePath(path)方法,在httphandle中，用的是context.Server.Transfer(url)
/// </summary>
namespace URLRewriter
{
    internal class RewriterUtils
    {
        #region RewriteUrl
        /// <summary>
        /// 改写一个URL <b>HttpContext.RewriteUrl()</b>.
        /// </summary>
        /// <param name="context">HttpContext对象的URL重写</param>
        /// <param name="sendToUrl">重写的URL</param>
        internal static void RewriteUrl(HttpContext context, string sendToUrl)
        {
            string x, y;
            RewriteUrl(context, sendToUrl, out x, out y);
        }

        /// <summary>
        /// 改写一个URL <b>HttpContext.RewriteUrl()</b>.
        /// </summary>
        /// <param name="context">HttpContext对象的URL重写</param>
        /// <param name="sendToUrl">重写的URL.</param>
        /// <param name="sendToUrlLessQString">Returns the value of sendToUrl stripped of the querystring.</param>
        /// <param name="filePath">物理文件路径返回到请求的页面</param>
        internal static void RewriteUrl(HttpContext context, string sendToUrl, out string sendToUrlLessQString, out string filePath)
        {
            // see if we need to add any extra querystring information 看看我们是否需要添加任何额外的查询字符串信息

            if (context.Request.QueryString.Count > 0)
            {
                if (sendToUrl.IndexOf('?') != -1)
                    sendToUrl += "&" + context.Request.QueryString.ToString();
                else
                    sendToUrl += "?" + context.Request.QueryString.ToString();
            }

            // 第一条查询字符串，如果有的话
            string queryString =string.Empty;
            sendToUrlLessQString = sendToUrl;
            if (sendToUrl.IndexOf('?') > 0)
            {
                sendToUrlLessQString = sendToUrl.Substring(0, sendToUrl.IndexOf('?'));
                queryString = sendToUrl.Substring(sendToUrl.IndexOf('?') + 1);
            }

            // 获取文件的物理路径
            filePath = string.Empty;
            filePath = context.Server.MapPath(sendToUrlLessQString);

            // 输出重写后的路径
            context.RewritePath(sendToUrlLessQString, string.Empty, queryString);

            // NOTE!  The above RewritePath() overload is only supported in the .NET Framework 1.1
            // If you are using .NET Framework 1.0, use the below form instead:
            // context.RewritePath(sendToUrl);
        }
        #endregion

        /// <summary>
        /// 转换成一个网址，为在请求客户端可用
        /// </summary>
        /// <remarks>Converts ~ to the requesting application path.  Mimics the behavior of the 
        /// <b>Control.ResolveUrl()</b> method, which is often used by control developers.</remarks>
        /// <param name="appPath">The application path.</param>
        /// <param name="url">The URL, which might contain ~.</param>
        /// <returns>A resolved URL.  If the input parameter <b>url</b> contains ~, it is replaced with the
        /// value of the <b>appPath</b> parameter.</returns>
        internal static string ResolveUrl(string appPath, string url)
        {
            if (url.Length == 0 || url[0] != '~')
                return url;  // there is no ~ in the first character position, just return the url
            else
            {
                if (url.Length == 1)
                    return appPath;  // there is just the ~ in the URL, return the appPath
                if (url[1] == '/' || url[1] == '\\')
                {
                    // url looks like ~/ or ~\
                    if (appPath.Length > 1)
                        return appPath + "/" + url.Substring(2);
                    else
                        return "/" + url.Substring(2);
                }
                else
                {
                    // url looks like ~something
                    if (appPath.Length > 1)
                        return appPath + "/" + url.Substring(1);
                    else
                        return appPath + url.Substring(1);
                }
            }
        }
    }
}
