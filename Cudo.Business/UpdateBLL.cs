using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cudo.Services;
using Cudo.Entities;

namespace Cudo.Business
{
    public class UpdateBLL
    {
        public AndroidVersionInfo getAndroidVersion()
        {
            return UpdateDAL.getAndroidVersion();
        }

        public int UpdateAndroidVersion(AndroidVersionInfo versionInfo)
        {
            return UpdateDAL.UpdateAndroidVersion(versionInfo);
        }
    }
}
