using System;
using System.IO;
using System.Text;
using System.Web;
using System.Data.SqlClient;

namespace Cudo.Common
{
    /// <summary>
    /// By:Cean
    /// QQ:245006690
    /// www.ceanhome.com
    /// </summary>
    public class LogTools
    {
        private void CreateFile()
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~") + "/Log/log.log";
                if (!File.Exists(path))
                {
                    File.CreateText(path);
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }

        public void WriteLog(string className, SqlException ce)
        {
            string path = HttpContext.Current.Server.MapPath("~") + "/Log/log.log";
            this.CreateFile();
            StreamWriter writer = null;
            StreamReader reader = null;
            string str2 = "";
            try
            {
                reader = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
                str2 = reader.ReadToEnd();
                reader.Close();
                writer = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8"));
                writer.WriteLine(str2);
                writer.WriteLine(className + "执行" + DateTime.Now.ToString() + "发生错误：");
                writer.WriteLine(ce.Message);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void WriteLog(string className, Exception ce)
        {
            string path = HttpContext.Current.Server.MapPath("~") + "/Log/log.log";
            this.CreateFile();
            StreamWriter writer = null;
            StreamReader reader = null;
            string str2 = "";
            try
            {
                reader = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
                str2 = reader.ReadToEnd();
                reader.Close();
                writer = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8"));
                writer.WriteLine(str2);
                writer.WriteLine(className + "执行" + DateTime.Now.ToString() + "发生错误：");
                writer.WriteLine(ce.Message);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void WriteLog(string className, string strnm)
        {
            string path = HttpContext.Current.Server.MapPath("~") + "/Log/log.log";
            this.CreateFile();
            StreamWriter writer = null;
            StreamReader reader = null;
            string str2 = "";
            try
            {
                reader = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
                str2 = reader.ReadToEnd();
                reader.Close();
                writer = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8"));
                writer.WriteLine(str2);
                writer.WriteLine(className + "执行" + DateTime.Now.ToString() + "发生错误：");
                writer.WriteLine(strnm);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}