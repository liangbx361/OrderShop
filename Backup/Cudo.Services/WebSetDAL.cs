using Cudo.Common;
using Cudo.Entities;

namespace Cudo.Services
{
    public class WebSetDAL
    {
        private static object lockHelper = new object();

        public WebSet loadConfig(string configFilePath)
        {
            return (WebSet)SerializationHelper.Load(typeof(WebSet), configFilePath);
        }

        public WebSet saveConifg(WebSet mode, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(mode, configFilePath);
            }
            return mode;
        }
    }
}

