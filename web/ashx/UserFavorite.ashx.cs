using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using Cudo.Entities;
using Cudo.Business;

namespace web.ashx
{
    public class UserFavorite : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string strResult = string.Empty;
            string shopid = context.Request.QueryString["shopid"];
            if (!string.IsNullOrEmpty(shopid))
            {
                UserInfo uinfo = context.Session["cudoUser"] as UserInfo;
                if (uinfo==null)
                {
                    strResult = "{\"types\":\"0\",\"msg\":\"您还未登录，请先登录!\"}";
                }
                else
                {
                    Favorites item = new Favorites();
                    item.ShopId = Convert.ToInt32(shopid);
                    item.UserId = uinfo.Id;
                    if(new FavoritesBLL().AddItem(item)>0)
                        strResult = "{\"types\":\"1\",\"msg\":\"收藏成功\"}";
                    else
                        strResult = "{\"types\":\"0\",\"msg\":\"收藏失败\"}";
                }
            }
            else
            {
                strResult = "{\"types\":\"0\",\"msg\":\"系统错误\"}";
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(strResult);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
