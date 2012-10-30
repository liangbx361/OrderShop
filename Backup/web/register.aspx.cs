using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using Cudo.Common;

namespace web
{
    public partial class register : System.Web.UI.Page
    {
        AreaBLL bll = new AreaBLL();
        private int promotionid = 0; //推广人ID
        protected WebSet webset = new BasePage().webset;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userid"] != null)
            {
                try
                {
                    promotionid = Convert.ToInt32(Request.QueryString["userid"]);
                    HttpCookie cookie = HttpContext.Current.Request.Cookies["promotion"];
                    if (cookie == null)
                    {
                        cookie = new HttpCookie("promotion");
                    }
                    cookie.Value = promotionid.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.AppendCookie(cookie);
                }
                catch
                {
                    Response.Redirect("error.html");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["Verifycode"].ToString().CompareTo(txtCode.Value) != 0)
            {
                Utils.alert("验证码输入错误!", "register.aspx");
                return;
            }
            else
            {
                UsersBLL bll = new UsersBLL();
                string UserName = txtUserName.Value;
                UserInfo item = new UserInfo();
                item.UserName = UserName;
                item.NickName = "";
                item.UserPass = Utils.MD5Encrypt32(txtPass.Value);
                item.Gender = 0;
                item.Mobile = txtMobile.Value;
                item.Birthday = "";
                item.Email = txtEmail.Value;
                item.Address = ",,||2";
                item.Utype = 0;
                item.ShopId = 0;
                if (promotionid == 0)
                {
                    string promotion = Utils.GetCookie("promotion");
                    if (!string.IsNullOrEmpty(promotion))
                        promotionid = Convert.ToInt32(promotion);
                }
                item.PromotionId = promotionid;
                item.TotalPoint = 20;
                int UserID = bll.AddUser(item);
                if (UserID > 0)
                {
                    UserInfo item2 = bll.GetUserByID(UserID);
                    Session["cudoUser"] = item2;
                    Response.Redirect("/");
                }
                else
                {
                    Utils.alert("注册失败,请稍后重试!", "register.aspx");
                }
            }
        }
    }
}
