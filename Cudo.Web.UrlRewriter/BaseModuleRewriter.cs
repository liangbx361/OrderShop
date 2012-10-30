using System;
using System.Web;

/// <summary>
///BaseModuleRewriter 对RewriterRule进行处理
/// </summary>
/// 
namespace URLRewriter
{
    public abstract class BaseModuleRewriter : IHttpModule
    {
        public virtual void Init(HttpApplication app)
        {
            // 警告！此代码不适用于 Windows 身份验证！
            // 如果使用 Windows 身份验证，
            // 请改为 app.BeginRequest
            //app.BeginRequest += new EventHandler(this.BaseModuleRewriter_AuthorizeRequest);
            app.AuthorizeRequest += new EventHandler(this.BaseModuleRewriter_AuthorizeRequest);
        }

        public virtual void Dispose() { }

        protected virtual void BaseModuleRewriter_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            Rewrite(app.Request.Path, app);
        }

        protected abstract void Rewrite(string requestedPath, HttpApplication app);

    }
}
