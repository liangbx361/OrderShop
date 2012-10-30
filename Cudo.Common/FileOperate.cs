using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Xml;
using System.Collections.Generic;

namespace Cudo.Common
{
    /// <summary>
    /// FileOperate 文件操作类
    /// </summary>
    public class FileOperate
    {
        public FileOperate()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 导入或者导出word Excel
        /// <summary> 
        /// 导入或者导出word Excel
        /// </summary>
        /// <param name="FileType">application/ms-word或者application/ms-Excel</param>
        /// <param name="FileName">保存地址：例：d:\\报表.xls</param>
        /// <param name="DG">//从DataGrid导出</param>
        public static void ExportDataGrid(string FileType, string FileName, DataGrid DG) //从DataGrid导出 
        {
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
            HttpContext.Current.Response.ContentType = FileType;
            System.Web.UI.Page Page1 = new System.Web.UI.Page();
            Page1.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DG.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 文件夹操作

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="filepath">文件夹路径</param>
        public static void FolderCreate(string filepath)
        {
            //如果文件夹不存在，则创建
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void FolderDelete(string filepath)
        {
            //如果存在文件夹，则删除
            if (Directory.Exists(filepath))
            {
                Directory.Delete(filepath);
            }
        }

        /// <summary>
        /// 获取所有文件
        /// </summary>
        /// <param name="filesdirectorypath"></param>
        /// <param name="dirnamelength"></param>
        /// <returns></returns>
        private static Hashtable getAllFies(string filesdirectorypath, out int dirnamelength)
        {
            Hashtable FilesList = new Hashtable();
            DirectoryInfo fileDire = new DirectoryInfo(filesdirectorypath);
            if (!fileDire.Exists)
            {
                throw new System.IO.FileNotFoundException("目录:" + fileDire.FullName + "没有找到!");
            }
            dirnamelength = fileDire.Name.Length;
            getAllDirFiles(fileDire, FilesList);
            getAllDirsFiles(fileDire.GetDirectories(), FilesList);
            return FilesList;
        }
        /// 
        /// 获取一个文件夹下的所有文件夹里的文件
        /// 
        private static void getAllDirsFiles(DirectoryInfo[] dirs, Hashtable filesList)
        {
            foreach (DirectoryInfo dir in dirs)
            {
                foreach (FileInfo file in dir.GetFiles("*.*"))
                {
                    filesList.Add(file.FullName, file.LastWriteTime);
                }
                getAllDirsFiles(dir.GetDirectories(), filesList);
            }
        }
        /// 
        /// 获取一个文件夹下的文件
        /// 
        private static void getAllDirFiles(DirectoryInfo dir, Hashtable filesList)
        {
            foreach (FileInfo file in dir.GetFiles("*.*"))
            {
                filesList.Add(file.FullName, file.LastWriteTime);
            }
        }

        /// <summary>
        /// 获得所有文件夹下的所有文件（包含子目录）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileNames(string path)
        {
            StringBuilder str = new StringBuilder();
            DirectoryInfo dir = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(path));
            FileInfo[] fileinfos = dir.GetFiles();
            foreach (FileInfo file in fileinfos)
            {
                str.Append(file.Name + "|");
            }
            DirectoryInfo[] drs = dir.GetDirectories();
            foreach (DirectoryInfo dr in drs)
            {
                FileInfo[] files = dr.GetFiles();
                foreach (FileInfo file in files)
                {
                    str.Append(file.Name + "|");
                }
            }
            return str.ToString();
        }

        #endregion

        #region 文件操作

        #region 读取和设置配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="Target">节点名称（区分大小写）</param>
        /// <returns>节点的值</returns>
        public static string GetXmlValue(string Target)
        {
            string xmlPath = HttpContext.Current.Server.MapPath("~/xml/XMLFile.xml");
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNode node = root.SelectSingleNode(Target);
            if (node != null)
                return node.InnerText;
            else
                return string.Empty;
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="Target">节点名称</param>
        /// <param name="TargetValue">需要设置的值</param>
        public static void SetXmlValue(string Target, string TargetValue)
        {
            SetXmlTargetValue(Target, TargetValue);
        }

        /// <summary>
        /// 设置配置文件的值（需要一一对应）
        /// </summary>
        /// <param name="Targets">节点数组</param>
        /// <param name="TargetValues">节点值数组</param>
        public static void SetXmlValue(string[] Targets, string[] TargetValues)
        {
            for (int i = 0; i < Targets.Length; i++)
            {
                SetXmlTargetValue(Targets[i], TargetValues[i]);
            }
        }

        /// <summary>
        /// 私有方法-写入配置文件
        /// </summary>
        /// <param name="Target">节点名称</param>
        /// <param name="TargetValue">节点值</param>
        private static void SetXmlTargetValue(string Target, string TargetValue)
        {
            string xmlPath = HttpContext.Current.Server.MapPath("~/xml/XMLFile.xml");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(xmlPath); //加载XML文件
            XmlElement root = xmlDoc.DocumentElement; //获取根节点
            XmlNode node = root.SelectSingleNode(Target); //查找子节点
            if (node != null)
            { //如果存在，设值，如果不存在则自动创建
                node.InnerText = TargetValue;
            }
            else
            {
                node = xmlDoc.CreateElement(Target); //创建子节点
                root.AppendChild(node); //将节点添加到根节点末尾
                node.InnerText = TargetValue; //设值
            }
            xmlDoc.Save(xmlPath); //保存XML
        }

        #endregion

        /// <summary>
        /// 获取文本编辑器的数据，并自动上传远程图片
        /// </summary>
        /// <param name="uc">文本编辑器数据</param>
        /// <returns></returns>
        public string GetText(string str)
        {
            string mycontext = Regex.Replace(str, @"src[^>]*[^/].(?:jpg|bmp|gif|png|jpeg|JPG|BMP|GIF|JPEG)(?:\""|\')", new MatchEvaluator(SaveYuanFile));

            return mycontext;
        }

        #region 重命名文件
        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        protected string OverrideFileName(string filePath, string fileName)
        {
            string value = fileName;
            //判断文件是否存在
            if (System.IO.File.Exists(filePath + fileName))
            {
                //获取文件名（不包含扩展名）
                string fileWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
                //获取文件扩展名
                string fileExtension = System.IO.Path.GetExtension(fileName);
                int i;
                string str = string.Empty;
                for (i = 1; ; i++)
                {
                    str = fileWithoutExtension + "(" + i.ToString() + ")" + fileExtension;
                    if (!System.IO.File.Exists(filePath + str))
                    {
                        break;
                    }
                }
                value = str;
            }
            return value;
        }
        #endregion

        #region 获取文件名
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <returns>文件名</returns>
        public static string GetFileName()
        {
            System.Threading.Thread.Sleep(1000);
            string str1 = System.DateTime.Now.Year.ToString() + "-";

            if ((System.DateTime.Now.Month).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Month.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Month.ToString() + "-";
            }

            if ((System.DateTime.Now.Day).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Day.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Day.ToString() + "-";
            }

            if ((System.DateTime.Now.Hour).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Hour.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Hour.ToString() + "-";
            }

            if ((System.DateTime.Now.Minute).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Minute.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Minute.ToString() + "-";
            }

            if ((System.DateTime.Now.Second).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Second.ToString();
            }
            else
            {
                str1 += System.DateTime.Now.Second.ToString();
            }

            return str1;
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileupload">文件上传实例</param>
        /// <returns>保存的文件名称</returns>
        public static string UpLoadFile(FileUpload fileupload, string Folders)
        {
            string fullname = fileupload.PostedFile.FileName;
            if ((fullname == null) || (fullname.Equals("")))
            {
                return "";
            }
            string huozui = fullname.Substring(fullname.LastIndexOf("."));
            string filename = GetFileName();
            string p1 = Folders + filename + huozui;
            string path = System.Web.HttpContext.Current.Server.MapPath(p1);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            fileupload.PostedFile.SaveAs(path);
            return p1;
        }

        string sException = null;
        private bool GetHttpFile(string sUrl, string sSavePath)
        {
            bool bRslt = false;
            WebResponse oWebRps = null;
            WebRequest oWebRqst = WebRequest.Create(sUrl);
            oWebRqst.Timeout = 100000;
            try
            {
                oWebRps = oWebRqst.GetResponse();
            }
            catch (WebException e)
            {
                sException = e.Message.ToString();
            }
            catch (Exception e)
            {
                sException = e.ToString();
            }
            finally
            {
                if (oWebRps != null)
                {
                    BinaryReader oBnyRd = new BinaryReader(oWebRps.GetResponseStream(), System.Text.Encoding.GetEncoding("GB2312"));
                    int iLen = Convert.ToInt32(oWebRps.ContentLength);
                    FileStream oFileStream;
                    try
                    {
                        if (File.Exists(System.Web.HttpContext.Current.Request.MapPath("RecievedData.tmp")))
                        {
                            oFileStream = File.OpenWrite(sSavePath);
                        }
                        else
                        {
                            oFileStream = File.Create(sSavePath);
                        }
                        oFileStream.SetLength((Int64)iLen);
                        oFileStream.Write(oBnyRd.ReadBytes(iLen), 0, iLen);
                        oFileStream.Close();
                    }
                    catch (Exception ex)
                    {
                        //bRslt= false;
                    }
                    finally
                    {
                        oBnyRd.Close();
                        oWebRps.Close();

                    }
                    bRslt = true;

                }
            }
            return bRslt;
        }
        #endregion

        #region 保存远程文件
        /// <summary>
        /// 保存远程文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string SaveYuanFile(Match m)
        {
            string imgurl = "";
            string matchstr = m.Value;//str[i].ToString();
            string tempimgurl = "";
            tempimgurl = matchstr.Substring(5);
            tempimgurl = tempimgurl.Substring(0, tempimgurl.IndexOf("\""));

            Regex re = new Regex(@"^http://*");
            if (re.Match(tempimgurl).Success)
            {
                matchstr = matchstr.Substring(5);
                matchstr = matchstr.Substring(0, matchstr.IndexOf("\""));

                //Response.Write(matchstr + "<br>");

                //远程文件保存路径
                string Folders = ConfigurationManager.AppSettings["yuanimg"].ToString();
                string fullname = matchstr;

                string huozui = fullname.Substring(fullname.LastIndexOf("."));
                string filename = FileOperate.GetFileName();
                string path = Folders + filename + huozui;
                //Folders+fullname.Substring(fullname.LastIndexOf("\\") + 1);

                if (System.IO.File.Exists(System.Web.HttpContext.Current.Request.MapPath(path)))
                    System.IO.File.Delete(System.Web.HttpContext.Current.Request.MapPath(path));
                GetHttpFile(matchstr, System.Web.HttpContext.Current.Request.MapPath(path));
                imgurl = "src=\"/" + path.Replace("~/", "") + "\"";
            }
            else
            {
                imgurl = matchstr;
            }
            return imgurl;
        }
        #endregion

        #region 移动文件

        /// <summary>
        /// 批量转移文件
        /// </summary>
        /// <param name="oldpath">文件夹路径</param>
        /// <param name="newpath">新文件夹路径</param>
        /// <returns></returns>
        public static bool MoveFiles(string oldpath, string newpath)
        {
            DirectoryInfo dr = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(oldpath));
            FileInfo[] files = dr.GetFiles();
            try
            {
                foreach (FileInfo file in files)
                {
                    file.MoveTo(System.Web.HttpContext.Current.Server.MapPath(newpath + file.Name));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 转移单个文件
        /// </summary>
        /// <param name="oldpath">原文件名（完整路径）</param>
        /// <param name="newpath">新文件名（完整路径）</param>
        /// <returns></returns>
        public static bool MoveFile(string oldpath, string newpath)
        {
            try
            {
                FileInfo file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(oldpath));
                file.MoveTo(System.Web.HttpContext.Current.Server.MapPath(newpath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 移除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        #region

        #endregion

        #endregion

        #region 操作ini文件

        /******************************示例INI文件*************************************/
        // ;默认首页1
        // [default]
        // url1=http://www.tiantian21.com/servicemanage/netbar/default.html
        // url2=http://www.tiantian21.com/servicemanage/netbar/index.html
        // ;后面的视为注释
        // []里面的视为关键字名称
        // url1，url2视为关键字所对应的值
        /******************************************************************************/

        /******************************************************************************/
        // section：要读取的段落名
        // key: 要读取的键
        // defVal: 读取异常的情况下的缺省值
        // retVal: 此参数类型不是string，而是Byte[]用于返回byte类型的section组或键值组。
        // size: 值允许的大小
        // filePath: INI文件的完整路径和文件名 
        /******************************************************************************/

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, System.Text.StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);


        /// <summary>
        /// 写入（更新）INI文件
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的关键字</param>
        /// <param name="iValue">关键字所对应的值,null则删除该关键字</param>
        /// <param name="path">路径</param>
        public static void IniWriteValue(string section, string key, string iValue, string path)
        {
            WritePrivateProfileString(section, key, iValue, path);
        }

        /// <summary>
        /// 读出INI文件的数据（返回字符串）
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的关键字</param>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string IniReadValue(string section, string key, string path)
        {
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }


        /// <summary>
        /// 读出INI文件的数据（返回字节数组）
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的关键字</param>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static byte[] IniReadValues(string section, string key, string path)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp;
        }

        #endregion

        #endregion

        #region 图片操作

        #region 图片处理
        /// <summary>
        /// 生成等比缩略图
        /// </summary>
        /// <param name="originalImagePath">原图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {

            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            string mode = "Auto";//这以后可以更换//////////重要
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                case "Auto":
                    if ((double)originalImage.Width / (double)originalImage.Height > 1)
                    {
                        toheight = originalImage.Height * width / originalImage.Width;
                    }
                    else
                    {
                        towidth = originalImage.Width * height / originalImage.Height;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 处理文字水印
        /// </summary>
        /// <param name="Path">原图路径</param>
        /// <param name="NewPath">生成水印后的路径</param>
        /// <param name="WaterText">水印文字</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isDelOld">是否删除愿图</param>
        public static void MarkWaterText(string Path, string NewPath, string WaterText, int x, int y, bool isDelOld)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));

            try
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                g.DrawImage(image, 0, 0, image.Width, image.Height);
                System.Drawing.Font f = new System.Drawing.Font("System", 12);
                System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

                g.DrawString(WaterText, f, b, x, y);
                g.Dispose();
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            catch
            {
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            finally
            {
                if (isDelOld)
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
                }
            }
        }

        /// <summary>
        /// 处理文字水印
        /// </summary>
        /// <param name="Path">原图路径</param>
        /// <param name="NewPath">生成文字水印后的路径</param>
        /// <param name="WaterText">水印文字</param>
        /// <param name="isDelOld">是否删除愿图</param>
        public static void MarkWaterText(string Path, string NewPath, string WaterText, bool isDelOld)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));

            try
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                g.DrawImage(image, 0, 0, image.Width, image.Height);
                int fsize = 12;
                if (image.Height > image.Width)
                {
                    fsize = image.Height / 10;
                }
                else
                {
                    fsize = image.Width / 10;
                }
                if (fsize > 16) fsize = 16;
                System.Drawing.Font f = new System.Drawing.Font("Arial", fsize);

                System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                int leng = WaterText.Length * f.Height;

                int x, y;
                x = 15;
                y = 15;

                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.NoWrap;
                //g.DrawString(WaterText, f, b, x, y);
                g.DrawString(WaterText, f, b, image.Width - x - leng, image.Height - y - f.Height, drawFormat);
                g.Dispose();
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            catch
            {
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            finally
            {
                if (isDelOld)
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
                }
            }
        }

        /// <summary>
        /// 处理图片水印
        /// </summary>
        /// <param name="Path">原图路径</param>
        /// <param name="NewPath">生成图片水印后的路径</param>
        /// <param name="ImagePath">水印图片路径</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isDelOld">是否删除愿图</param>
        public static void MarkWaterImage(string Path, string NewPath, string ImagePath, int x, int y, bool isDelOld)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
            try
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);

                /*g.DrawImage(copyImage, new System.Drawing.Rectangle(x, y, copyImage.Width, copyImage.Height),
                    new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                    System.Drawing.GraphicsUnit.Pixel);*/
                g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width - x, image.Height - copyImage.Height - y, copyImage.Width, copyImage.Height),
                    new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                    System.Drawing.GraphicsUnit.Pixel);
                g.Dispose();
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            catch
            {
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            finally
            {
                if (isDelOld)
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
                }
            }
        }

        /// <summary>
        /// 处理图片水印
        /// </summary>
        /// <param name="Path">原图路径</param>
        /// <param name="NewPath">生成水印后的路径</param>
        /// <param name="ImagePath">水印图片路径</param>
        /// <param name="isDelOld">是否删除愿图</param>
        public static void MarkWaterImage(string Path, string NewPath, string ImagePath, bool isDelOld)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
            try
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                int x, y;
                x = 15;
                y = 15;
                /*g.DrawImage(copyImage, new System.Drawing.Rectangle(x, y, copyImage.Width, copyImage.Height),
                    new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                    System.Drawing.GraphicsUnit.Pixel);*/
                g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width - x, image.Height - copyImage.Height - y, copyImage.Width, copyImage.Height),
                    new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                    System.Drawing.GraphicsUnit.Pixel);
                g.Dispose();
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            catch
            {
                image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
                image.Dispose();
            }
            finally
            {
                if (isDelOld)
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
                }
            }
        }

        /// <summary>
        /// 保存远程图片
        /// </summary>
        /// <param name="Path">存放图片的路径</param>
        /// <param name="Url">网络图片地址</param>
        /// <returns>本地图片地址</returns>
        public static string GetRemotImage(string Path, string Url)
        {
            string[] Filters = new string[] { "image/gif", "image/jpeg", "image/bmp", "image/png" };

            HttpWebRequest hwq = (HttpWebRequest)WebRequest.Create(Url.ToLower());
            HttpWebResponse hwr = (HttpWebResponse)hwq.GetResponse();
            string contenttype = hwr.ContentType.ToString();
            string typeName = "";
            bool errortype = false;
            for (int i = 0; i <= Filters.Length - 1; i++)
            {
                if (contenttype == Filters[i].ToString().ToLower())
                {
                    switch (contenttype)
                    {
                        case "image/gif":
                            typeName = "gif";
                            break;
                        case "image/jpeg":
                            typeName = "jpg";
                            break;
                        case "image/bmp":
                            typeName = "bmp";
                            break;
                        case "image/png":
                            typeName = "png";
                            break;
                    }
                    errortype = true;
                    break;
                }
            }
            if (errortype)
            {
                System.Drawing.Image bmp = System.Drawing.Image.FromStream(hwr.GetResponseStream());
                string fileName = string.Empty;
                string y = DateTime.Now.Year.ToString();
                string m = DateTime.Now.Month.ToString();
                string d = DateTime.Now.Day.ToString();
                string h = DateTime.Now.Hour.ToString();
                string n = DateTime.Now.Minute.ToString();
                string s = DateTime.Now.Second.ToString();
                fileName = y + m + d + h + n + s;
                Random r = new Random();
                fileName = fileName + r.Next(1000);
                fileName = fileName + "." + typeName;
                string webFilePath = Path + fileName;
                bmp.Save(System.Web.HttpContext.Current.Server.MapPath(webFilePath));
                hwr.Close();
                return webFilePath;
            }
            else
            {
                hwr.Close();
                return "";
            }
        }

        #endregion

        #region 采集

        #region 采集相关私有成员
        private static string GetChartset(string url)
        {
            string html = getHTML(url);
            Regex reg_charset = new Regex(@"charset\b\s*=\s*(?<charset>[^""]*)");
            string enconding = null;
            if (reg_charset.IsMatch(html))
            {
                enconding = reg_charset.Match(html).Groups["charset"].Value;
            }
            else
            {
                enconding = Encoding.Default.EncodingName;
            }
            if (enconding.ToLower().Contains("gb2312"))
                enconding = "gb2312";
            if (enconding.ToLower().Contains("utf-8"))
                enconding = "utf-8";
            return enconding;
        }

        private static string getHTML(string url)
        {

            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(Encoding.ASCII.EncodingName));
                string html = sr.ReadToEnd();
                return html;
            }
            catch (UriFormatException ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            catch (WebException ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// 采集
        /// </summary>
        /// <param name="url">要采集的地址</param>
        /// <param name="Type">采集的类型，1-全部内容，2-不带脚本的内容，3-所有文本，4-所有图片，5-所有链接</param>
        /// <returns></returns>
        public static string GetRemotUrl(string url, int Type)
        {
            string Url = url.Trim();
            string returnvalue = string.Empty;
            string result = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string ce = response.ContentEncoding;
                Stream streamReceive = response.GetResponseStream();

                Encoding encoding = Encoding.GetEncoding(GetChartset(Url));
                if (ce.ToLower() == "gzip")//压缩的内容
                {
                    GZipStream gzip = new GZipStream(streamReceive, CompressionMode.Decompress);
                    using (StreamReader reader = new StreamReader(gzip, encoding))
                    {
                        result = reader.ReadToEnd();
                    }

                }
                else
                {
                    using (StreamReader streamReader = new StreamReader(streamReceive, encoding))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }

                switch (Type)
                {
                    case 1:
                        returnvalue = result;
                        break;
                    case 2:
                        returnvalue = wipeScript(result);
                        break;
                    case 3:
                        returnvalue = ClearHTML(result);
                        break;
                    case 4:
                        returnvalue = getImages(Url, result);
                        break;
                    case 5:
                        returnvalue = getLink(Url, result);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                returnvalue = "Error";
            }
            return returnvalue;
        }

        /// <summary>
        /// 得到所有图片
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string getImages(string Url, string html)
        {
            string resultStr = "";
            string temp = "";
            string url = "";
            string[] url2;
            Match m;
            Regex r = new Regex(@"<IMG[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", RegexOptions.IgnoreCase);
            for (m = r.Match(html); m.Success; m = m.NextMatch())
            {
                temp = m.Groups["src"].Value.ToLower();
                if (temp.IndexOf("http") == 0)
                {
                    resultStr += m.Value + "<br />";
                }
                else
                {
                    url2 = Url.Trim().Split('/');

                    try
                    {
                        if (url2.Length > 3)
                        {
                            url = Url.Trim().Replace(url2[url2.Length - 1], "");
                        }
                        else
                        {
                            url = Url.Trim();
                        }
                    }
                    catch
                    {
                        url = Url.Trim();
                    }

                    if (temp.IndexOf("/") == 0)
                    {

                        resultStr += m.Value.Replace(m.Groups["src"].Value, "http://" + url2[2] + m.Groups["src"].Value) + "<br/>";
                    }
                    else
                    {
                        resultStr += m.Value.Replace(m.Groups["src"].Value, url + m.Groups["src"].Value) + "<br/>";
                    }
                }
            }
            return resultStr;
        }

        /// <summary>
        /// 得到去除HTML标记的内容
        /// </summary>
        /// <param name="Htmlstring">要过滤的字符窜</param>
        /// <returns></returns>
        public static string ClearHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"<script[\s\S]+</script *>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<style[\s\S]+</style *>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 得到不带脚本的内容
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string wipeScript(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            return html;
        }

        /// <summary>
        /// 得到所有链接地址
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string getLink(string Url, string html)
        {
            string resultStr = "";
            string temp = "";
            string url = "";
            string[] url2;
            Regex re = new Regex(@"<a[^>]+href=\s*(?:'(?<href>[^']+)'|""(?<href>[^""]+)""|(?<href>[^>\s]+))\s*[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase);

            MatchCollection mc = re.Matches(html);
            foreach (Match m in mc)
            {
                temp = m.Groups["href"].Value.ToLower();
                if (temp.IndexOf("http") == 0)
                {
                    resultStr += m.Value + "<br/>";
                }
                else
                {
                    url2 = Url.Trim().Split('/');
                    try
                    {
                        if (url2.Length > 1)
                        {
                            url = Url.Trim().Replace(url2[url2.Length - 1], "");
                        }
                        else
                        {
                            url = Url.Trim();
                        }
                    }
                    catch
                    {
                        url = Url.Trim();
                    }

                    if (temp.IndexOf("/") == 0)
                    {
                        resultStr += m.Value.Replace(m.Groups["href"].Value, "http://" + url2[2] + m.Groups["href"].Value) + "<br/>";
                    }
                    else if (temp.IndexOf("mailto") == 0)
                    {
                        resultStr += m.Value + "<br/>";
                    }
                    else
                    {
                        resultStr += m.Value.Replace(m.Groups["href"].Value, url + m.Groups["href"].Value) + "<br/>";
                    }
                }
            }

            return resultStr;
        }

        #endregion

        #region 常用
        /// <summary>
        /// 获取指定长度的字符串(只限中文)
        /// </summary>
        /// <param name="stringToSub">要截取的字符串</param>
        /// <param name="length">截取的长度</param>
        /// <returns></returns>		
        public static string GetChinaString(string stringToSub, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            bool isCut = false;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }

                if (nLength > length)
                {
                    isCut = true;
                    break;
                }
            }
            if (isCut)
                return sb.ToString() + "..";
            else
                return sb.ToString();
        }

        /// <summary>
        /// 防sql注入
        /// </summary>
        /// <param name="str">要过虑的字符串</param>
        /// <returns></returns>
        public static string FiltSQL(string str)
        {
            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("update", "");
            str = str.Replace("delete", "");
            str = str.Replace("create", "");
            str = str.Replace("drop", "");
            str = str.Replace("delcare", "");
            str = str.Replace("   ", "&nbsp;");
            str = str.Replace("<script>", "");
            str = str.Replace("</script>", "");
            str = str.Trim();
            return str;
        }

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (r.IsMatch(str))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断是否为图片
        /// </summary>
        /// <param name="Ext">文件扩张名</param>
        /// <returns></returns>
        public static bool IsPic(string Ext)
        {
            bool flag = false;
            string[] AllowExts = new string[] { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
            foreach (string AllowExt in AllowExts)
            {
                if (AllowExt.Equals(Ext, StringComparison.InvariantCultureIgnoreCase))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        #endregion

        #region 生成随即验证码
        /// <summary>
        /// 根据随机数生成验证码
        /// </summary>
        /// <param name="checkCode">随机数</param>
        public static void CreateImage(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 11);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 19);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Chocolate, Color.Brown, Color.DarkCyan, Color.Purple };
            Random rand = new Random();

            //输出不同字体和颜色的验证码字符
            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                Font f = new System.Drawing.Font("Microsoft Sans Serif", 11);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                g.DrawString(checkCode.Substring(i, 1), f, b, (i * 10) + 1, 0, StringFormat.GenericDefault);
            }
            //画一个边框
            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

            //输出到浏览器
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ContentType = "image/Jpeg";
            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }

        /// <summary>
        /// 获得随机数
        /// </summary>
        /// <param name="num">几位数</param>
        /// <returns>随机数</returns>
        public static string GetValidateCode(int num)
        {
            char[] chars = "023456789".ToCharArray();
            System.Random random = new Random();
            string validateCode = string.Empty;
            for (int i = 0; i < num; i++)
            {
                char rc = chars[random.Next(0, chars.Length)];
                if (validateCode.IndexOf(rc) > -1)
                {
                    i--;
                    continue;
                }
                validateCode += rc;
            }
            return validateCode;
        }
        #endregion

        #endregion
    }
}
