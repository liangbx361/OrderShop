using System;
using System.Collections.Generic;
using System.Data;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class UsersBLL
    {
        public List<UserInfo> GetUserList(int pageindex, int pagesize, string username, string shopname)
        {
            return UsersDAL.GetShopUserList(pageindex, pagesize, username, shopname);
        }

        public List<UserInfo> GetUserList(int pageindex,int pagesize,int utype)
        {
            return UsersDAL.GetUserList(pageindex, pagesize, utype);
        }

        public List<UserInfo> GetUserList()
        {
            return UsersDAL.GetUserList();
        }

        public UserInfo GetUserByID(int UserID)
        {
            return UsersDAL.GetUserByID(UserID);
        }

        public string GetUserNameByuid(int userid)
        {
            UserInfo item = UsersDAL.GetUserByID(userid);
            return item != null ? item.UserName : "";
        }

        public int AddUser(UserInfo item)
        {
            return UsersDAL.AddUser(item);
        }

        public int UpdateUser(UserInfo item)
        {
            return UsersDAL.UpdateUser(item);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int UpdatePass(string pass,int UserID)
        {
            return UsersDAL.UpdateUser(pass, UserID);
        }

        /// <summary>
        /// 修改积分
        /// </summary>
        /// <param name="point"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int UpdatePoint(decimal point, int userid)
        {
            return UsersDAL.UpdateUser(point, userid);
        }

        public int DeleteUser(int UserID)
        {
            return UsersDAL.DeleteUser(UserID);
        }

        /// <summary>
        /// 检查用户是否已存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>User ID</returns>
        public int CheckUserIDByUserName(string username)
        {
            return UsersDAL.CheckUserByUserName(username);
        }

        public int CheckUserByMobile(string mobile)
        {
            return UsersDAL.CheckUserByMobile(mobile);
        }

        public int CheckUserByEmail(string email)
        {
            return UsersDAL.CheckUserByEmail(email);
        }

        public UserInfo UserLogin(string UserName, string UserPass)
        {
            return UsersDAL.UserLogin(UserName, UserPass);
        }

        public int GetCount(int utype)
        {
            return UsersDAL.GetUserCount(utype);
        }

        public int GetCount(string username, string shopname)
        {
            return UsersDAL.GetUserCount(username, shopname);
        }

        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="uinfo">会员信息</param>
        public UserInfo UpdateUserGroup(UserInfo uinfo)
        {
            int groupid = 1; //普通
            if ((uinfo.SpreadCount > 5 && uinfo.SpreadCount <= 10) || (uinfo.UsePoint >= 50 && uinfo.UsePoint < 150))
                groupid = 2; //vip 推广人数5-10 消费积分50-150
            if ((uinfo.SpreadCount > 10 && uinfo.SpreadCount <= 20) || (uinfo.UsePoint >= 150 && uinfo.UsePoint < 350))
                groupid = 3; //银卡 推广人数10-20 消费积分150-350
            if ((uinfo.SpreadCount > 20 && uinfo.SpreadCount <= 30) || (uinfo.UsePoint >= 350 && uinfo.UsePoint < 600))
                groupid = 4; //金卡 推广人数2-30 消费积分350-600
            if (uinfo.SpreadCount > 30 || uinfo.UsePoint >= 600)
                groupid = 5; //钻石
            uinfo.UserGroup = groupid;
            UsersDAL.UpdateUser(uinfo);
            return uinfo;
        }

        public string GetShopUserMobile(int shopid)
        {
            return UsersDAL.GetShopUserMobile(shopid);
        }
    }
}
