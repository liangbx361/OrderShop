using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Cudo.Common;

namespace web.touch
{
    public partial class UploadImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string ReturnID = Request.QueryString["cid"];//图片地址返回的ID
            if (File_ImgLink.Value != "")
            {
                //string filename = Path.GetFileName(File_ImgLink.Value);
                string filename = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + new Random().Next(10,100);
                filename = filename + Path.GetExtension(File_ImgLink.Value);
                //不存在文件夹则自动创建
                string filepath = Server.MapPath("~/upload/images/");
                FileOperate.FolderCreate(filepath);
                File_ImgLink.PostedFile.SaveAs(filepath + filename);
                string img = "upload/images/" + filename;
                Response.Write("<script>parent.document.getElementById(\"" + ReturnID + "\").value = \"" + img + "\";</script>");
            }
        }
    }
}
