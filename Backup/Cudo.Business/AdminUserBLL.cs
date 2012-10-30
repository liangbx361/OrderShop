using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class AdminUserBLL
    {
        public DataSet GetUserList(int pageindex,int pagesize,int IsSystem)
        {
            return AdminUserDAL.GetUserList(pageindex, pagesize, IsSystem);
        }

        public int GetCount(int IsSystem)
        {
            return Convert.ToInt32(AdminUserDAL.GetCount(IsSystem));
        }

        /// <summary>
        /// 根据用户ID取用户名
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public string GetUserNameById(int UserID)
        {
            object objName = AdminUserDAL.GetUserNameById(UserID);
            return objName != null ? objName.ToString() : "";
        }

        public AdminUser UserLogin(string UserName, string password)
        {
            return AdminUserDAL.UserLogin(UserName, password);
        }

        public AdminUser GetUserByUserID(int UserID)
        {
            return AdminUserDAL.GetUserByUserID(UserID);
        }

        public int GetIsSystemByUserID(int UserID)
        {
            AdminUser item = GetUserByUserID(UserID);
            return item.IsSystem;
        }

        public int AddAdminUser(AdminUser item)
        {
            return AdminUserDAL.AddAdminUser(item);
        }

        public int UpdateUser(int UserID, string password, bool flag)
        {
            return AdminUserDAL.UpdateUser(UserID, password, flag);
        }

        public void UpdateUser(int UserID, string LoginIP)
        {
            AdminUserDAL.UpdateUser(UserID, LoginIP);
        }

        public int DeleteUser(int UserID)
        {
            return AdminUserDAL.DeleteUser(UserID);
        }


        public string GetPermissionsByUserID(int UserID)
        {
            return AdminUserDAL.GetPermissionsByUserID(UserID).ToString();
        }

        public int AddUserRole(string Permissions, int UserID)
        {
            return AdminUserDAL.AddUserRole(Permissions, UserID);
        }

        public int UpdateUserRoleByUserID(string Permissions, int UserID)
        {
            return AdminUserDAL.UpdateUserRoleByUserID(Permissions, UserID);
        }

        public int DeleteUserRoleByUserID(int UserID)
        {
            return AdminUserDAL.DeleteUserRoleByUserID(UserID);
        }
    }
}
