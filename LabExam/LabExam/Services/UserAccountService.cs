using LabExam.IServices;
using LabExam.Map;
using LabExam.Models;
using LabExam.Models.DataModel;
using LitJson;
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

        /// <summary>
        ///  修改用户密码
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="userType">用户类型</param>
        /// <returns>0</returns>
        public bool ChangeUserPassword(UserAccout account, UserType userType, IEncryptionDataService service)
        {
            if (userType == UserType.Principal) {
                Principal admin = db.Principals.Find(account.UserAccoutID);
                if(admin != null)
                {
                    admin.Password = service.Encode(account.UserPassword);
                }
                else
                {
                    throw new Exception("UserAccountService：管理员账号不存在");
                }

            }else if(userType == UserType.Student)
            {
                Student stu = db.Students.Find(account.UserAccoutID);
                if (stu != null)
                {
                    stu.Passwrod = service.Encode(account.UserPassword);
                    if (!db.ChangeTracker.HasChanges())
                    {
                        return true;

                    }
                    else if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("UserAccountService：学生账号不存在");
                }
            }
            return false;
        }

        /// <summary>
        ///  判断用户能否登录
        /// </summary>
        /// <param name="id">账户</param>
        /// <param name="pwd">密码</param>
        /// <param name="type">用户类型</param>
        /// <returns>是否账号密码都正确</returns>
        public Boolean Login(String id, String pwd, UserType type, IEncryptionDataService service)
        {
            if(type == UserType.Student)
            {
                var passwordDecode = service.Encode(pwd);
                int count = db.Students.Where(stu => stu.StudentID == id && stu.Passwrod == passwordDecode).Count();
                return count == 1;
            }else if(type == UserType.Principal)
            {
                var passwordDecode = service.Encode(pwd);
                int count = db.Principals.Where(tea => tea.PrincipalID == id && tea.Password == passwordDecode).Count();
                return count == 1;
            }
            else
            {
                return false;
            }
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

        public bool AddLoginRecord(UserLoginRecord record)
        {
            if(record == null)
            {
                return false;
            }
            else
            {
                db.UserLoginRecords.Add(record);
                return db.SaveChanges() == 1;
            }
        }

        public bool ConfirmStudentIDNumber(string AccountID, string ID)
        {
            int Count = db.Students.Where(val =>val.StudentID == AccountID && val.IDNumber == ID).Count();
            return Count == 1;
        }

        public string GetPrincipalByID(string ID)
        {
            JsonData pricipal = new JsonData();
            Principal val =  db.Principals.Find(ID);
            pricipal["Name"] = val.Name;
            pricipal["ID"] = val.JobNumber;
            pricipal["Status"] = (int)val.UserStatus;
            pricipal["Power"] = "部分权限";
            pricipal["LoginTime"] = DateTime.Now.ToString();
            pricipal["OperationCount"] = db.PrincipalOperationLoggs.Where(one => one.PrincipalID == ID).Count();
            return pricipal.ToJson();
        }
    }
}