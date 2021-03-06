﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.WebService
{
    /// <summary>
    /// update 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Update : System.Web.Services.WebService
    {

        [WebMethod]
        public AndroidVersionInfo getVersionInfo()
        {
            UpdateBLL bll = new UpdateBLL();
            return bll.getAndroidVersion();
        }
    }
}
