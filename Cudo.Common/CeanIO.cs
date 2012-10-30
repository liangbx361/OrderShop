using System;
using System.Web;
using System.IO;
using System.Text;

namespace Cudo.Common
{
    public class CeanIO
    {

        public static string Read(string FileName)
        {
            StreamReader StrRead = new StreamReader(HttpContext.Current.Server.MapPath(FileName));

            StringBuilder Template = new StringBuilder();
            try
            {
                Template.Append(StrRead.ReadToEnd());

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                StrRead.Close();
            }
            finally
            {
                StrRead.Close();
            }
            return Template.ToString();

        }

       
        public static void Write(string content, string Path)
        {
            Encoding code = Encoding.GetEncoding("utf-8");
            string path = HttpContext.Current.Server.MapPath(Path);
            string Floder = path.Substring(0, path.LastIndexOf('\\'));
            if (File.Exists(Floder) == false)
            {
                Directory.CreateDirectory(Floder);
            }

            StreamWriter StrWrite = new StreamWriter(path, false, code);
            try
            {

                StrWrite.Write(content);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
            }
            finally
            {
                StrWrite.Close();
            }
        }
    }
}
