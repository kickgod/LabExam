using LabExam.IServices;
using LabExam.Map;
using LabExam.Models;
using LabExam.Models.DataModel;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LabExam.Services
{
    public class UserAccountService : IUserAccountService
    {
        private LabContext db = new LabContext();

        /* 修改用户密码 */
        public bool ChangeUserPassword(UserAccout account, UserType userType)
        {
            throw new NotImplementedException();
        }
        public  Boolean StudentIsRight()
        {
            throw new NotImplementedException();
        }
        public Boolean PrincipalIsRight()
        {
            throw new NotImplementedException();
        }
        public UserType GetUserType(string UserID)
        {
            UserType type = UserType.Anonymous; 
            //匿名非法用户
            Principal p = new Principal();
            if (db.Principals.Find(UserID) != null)
            {
                type = UserType.Principal;
                //身份为管理员教师
            }
            else if (db.Students.Find(UserID) != null) {
                type = UserType.Student;
                //身份为学生
            }
            return type;

        }

        public bool IsHavaPrincipal(string UserID)
        {
            Principal p = new Principal();
            return db.Principals.Find(UserID) == null ;
        }


        public bool UserIsLogin()
        {
            HttpContext context = HttpContext.Current;
            HttpCookie authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null) {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}