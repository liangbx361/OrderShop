using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using Cudo.Entities;
using Cudo.Business;

namespace web.ashx
{
    public class ModifyHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string srtResult = string.Empty;
            string action = context.Request.QueryString["action"];
            switch (action)
            {
                case "sendadd":
                    int aid = int.Parse(context.Request.QueryString["aid"]);
                    int sid = int.Parse(context.Request.QueryString["sid"]);
                    int did = int.Parse(context.Request.QueryString["did"]);
                    srtResult += ModifySendAddress(context, aid, sid, did);
                    break;
                default: break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(srtResult);
        }

        protected string ModifySendAddress(HttpContext context, int aid, int sid, int did)
        {
            string srtResult = string.Empty;
            UserInfo item = context.Session["cudoUser"] as UserInfo;
            Area aitem = new AreaBLL().GetItem(aid);
            Area aitem2 = new AreaBLL().GetItem(sid);
            Area aitem3 = new AreaBLL().GetItem(did);

            UserInfo uinfo = new UsersBLL().GetUserByID(item.Id);
            uinfo.Address = aid + "," + sid + "," + did + "|" + aitem.AreaName + aitem2.AreaName + aitem3.AreaName;
            if (new UsersBLL().UpdateUser(uinfo) > 0)
                srtResult = "1";
            else
                srtResult = "0";
            return srtResult;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
