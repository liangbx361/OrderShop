using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Caching;
using Cudo.Services;
using Cudo.Entities;

namespace Cudo.Business
{
    public class WebSetBLL
    {
        private readonly WebSetDAL dal = new WebSetDAL();

        public WebSet loadConfig(string configFilePath)
        {
            WebSet Cache_Webset = HttpContext.Current.Cache["Cache_Webset"] as WebSet;
            if (Cache_Webset == null)
            {
                CacheDependency dependency = new CacheDependency(configFilePath);
                HttpContext.Current.Cache.Add("Cache_Webset", dal.loadConfig(configFilePath), dependency, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), CacheItemPriority.Default, null);
                Cache_Webset = HttpContext.Current.Cache["Cache_Webset"] as WebSet;
            }
            return Cache_Webset;
        }

        public WebSet saveConifg(WebSet mode, string configFilePath)
        {
            return dal.saveConifg(mode, configFilePath);
        }
    }
}
