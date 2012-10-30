using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;
using System.IO;

namespace web.touch
{
    public partial class Advertising_AE : ManagePage
    {
        AdvertBLL AdvertBiz = new AdvertBLL();
        private int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = base.GetIntValue("id");
            if (!IsPostBack)
                PageInit();
        }

        private void PageInit()
        {
            if (Id > 0) 
            {
                Advertising AdvertItem = AdvertBiz.GetAdvertItem(Id);
                ddl_type.SelectedValue = AdvertItem.ClassId.ToString();
                txtAdvertName.Value = AdvertItem.AdvertName;
                txt_link_url.Value = AdvertItem.AdvertLink;
                txt_link_logo.Value = AdvertItem.AdvertPic;
                txt_sortid.Value = AdvertItem.SortId.ToString();
                hy_img.ImageUrl = "~/" + AdvertItem.AdvertPic;
                hy_img.NavigateUrl = "~/" + AdvertItem.AdvertPic; 
            }
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            if (file_link_logo.FileName != string.Empty)
            {
                FileOperate.FolderCreate(Server.MapPath("~/upload/adlink/"));
                string filename = Path.GetFileNameWithoutExtension(file_link_logo.FileName);//文件名
                string fileExtension = Path.GetExtension(file_link_logo.FileName); //扩展名
                //上传图片
                file_link_logo.SaveAs(Server.MapPath("~/upload/adlink/") + filename + fileExtension);
                txt_link_logo.Value = "upload/adlink/" + filename + fileExtension;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Advertising AdvertItem = new Advertising();
            AdvertItem.ClassId = Convert.ToInt32(ddl_type.SelectedValue);
            AdvertItem.AdvertName = txtAdvertName.Value;
            AdvertItem.AdvertLink = txt_link_url.Value;
            AdvertItem.AdvertPic = txt_link_logo.Value;
            AdvertItem.SortId = Convert.ToInt32(txt_sortid.Value);
            if (Id == 0)
            {
                if (AdvertBiz.AddAdvert(AdvertItem) > 0)
                {
                    base.ErrorMsg("提交成功！", "AdvertisingList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "AdvertisingList.aspx", 0);
                }
            }
            else
            {
                AdvertItem.Id = Id;
                if (AdvertBiz.UpdateAdvert(AdvertItem) > 0)
                {
                    base.ErrorMsg("提交成功！", "AdvertisingList.aspx", 1);
                }
                else
                {
                    base.ErrorMsg("提交失败！", "AdvertisingList.aspx", 0);
                }
            }
        }
    }
}
