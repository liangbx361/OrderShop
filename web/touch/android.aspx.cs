using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web.touch
{
    public partial class android : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            UpdateBLL bll = new UpdateBLL();
            AndroidVersionInfo adInfo = bll.getAndroidVersion();

            txtname.Value = adInfo.Name;
            txtVersionCode.Value = Convert.ToString(adInfo.VersionCode);
            txtVersionName.Value = adInfo.VersionName;
            txtDownloadAddr.Value = adInfo.Src;
            txtIntroduction.Value = adInfo.Introduction;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            AndroidVersionInfo adInfo = new AndroidVersionInfo();
            adInfo.Name = txtname.Value;
            adInfo.VersionCode = Convert.ToInt32(txtVersionCode.Value);
            adInfo.VersionName = txtVersionName.Value;
            adInfo.Src = txtDownloadAddr.Value;
            adInfo.Introduction = txtIntroduction.Value;

            UpdateBLL bll = new UpdateBLL();
            if (bll.UpdateAndroidVersion(adInfo) > 0)
            {
                base.JscriptPrint("修改成功！", "android.aspx", "Success");
            }
            else
            {
                base.JscriptPrint("修改失败！", "android.aspx", "Fail");
            }
        }
    }
}