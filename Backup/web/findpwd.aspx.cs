using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using System.Net;
using System.Net.Mail;
using Cudo.Common;

namespace web
{
    public partial class findpwd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UsersBLL bll = new UsersBLL();
            string username = txtUserName.Value;
            string mobile = txtMobile.Value;
            string email = txtEmail.Value;

            int userid = bll.CheckUserIDByUserName(username);
            if (userid > 0)
            {
                UserInfo item = bll.GetUserByID(userid);
                if (item != null)
                {
                    if (item.Mobile.Equals(mobile) && item.Email.Equals(email))
                    {
                        string newpass = Utils.CreateRandomCode(6).ToLower();
                        string sendstr = "尊敬的用户" + username + "，您要找回的用户密码是" + newpass + ",请您收好，并及时更改密码。";
                        if (SendMails(webset.EmailLoginName, email, "您找回的用户密码", sendstr, webset.SmtpServer, webset.EmailLoginName, webset.EmailLoginPass, true, "utf-8"))
                        {
                            bll.UpdatePass(Utils.MD5Encrypt32(newpass), userid);
                            Utils.alert("已向您的注册邮箱发送邮件，请注意查收!", "login.aspx");
                        }
                        else
                        {
                            Utils.alert("未知错误!", "default.aspx");
                        }
                    }
                    else
                    {
                        L_msg.Text = "<font color='red'>邮箱和手机号码输入错误!</font>";
                    }
                }
            }
            else
            {
                L_msg.Text = "<font color='red'>用户名不存在!</font>";
            }
        }

        private static bool SendMails(string fromMail, string toMail, string subject, string body, string smtpHost, string userName, string password, bool sendMode, string encoding)
        {
            try
            {
                MailMessage myMail = new MailMessage(fromMail, toMail);
                myMail.Subject = subject;
                myMail.IsBodyHtml = sendMode;
                myMail.Body = body;
                myMail.BodyEncoding = System.Text.Encoding.GetEncoding(encoding);

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(userName, password); //验证用户名和密码
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = smtpHost; //SMTP服务器地址
                client.Send(myMail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
