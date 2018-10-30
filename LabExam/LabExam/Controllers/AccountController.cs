using LabExam.IServices;
using LabExam.Map;
using LabExam.Models;
using LabExam.Models.DataModel;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LabExam.Controllers
{
    public class AccountController : Controller
    {
        private IUserAccountService Service;

        private IEncryptionDataService EncodeServive;

        public AccountController(IUserAccountService Service, IEncryptionDataService EncodeServive)
        {
            this.Service = Service;
            this.EncodeServive = EncodeServive;
        }

        public ActionResult Login()
        {
            ViewBag.isLogin = Service.UserIsLogin();
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        /// <summary>
        /// 修改账户密码/只允许学生修改  教师密码只允许管理员修改
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserNewPassword"></param>
        /// <param name="IDNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public String ChangePassword(String UserID,String UserNewPassword,String IDNumber) {

            Map.UserType type = Service.GetUserType(UserID ?? "");

            JsonData val = new JsonData();
            val["Type"] = type.ToString();
            if (UserID != null || UserNewPassword != null || IDNumber != null)
            {
                UserAccout accout = new UserAccout();
                accout.UserAccoutID = UserID;
                accout.UserPassword = UserNewPassword;

                bool isRight = Service.ConfirmStudentIDNumber(UserID, IDNumber);
                val["idNumberIsRight"] = isRight;

                if (type == UserType.Student && isRight)
                {
                    Boolean result = Service.ChangeUserPassword(accout, Map.UserType.Student, EncodeServive);
                    FormsAuthentication.SignOut();
                    val["isOk"] = result;
                }
                else
                {
                    val["isOk"] = false;
                }
                val["DataStatus"] = true;
                //返回状态如何 成功
            }
            else {
                val["isOk"] = false;
                val["DataStatus"] = false;
                //返回状态如何 失败
            }

            return val.ToJson();
        }
        /// <summary>
        ///  判断用户能否登陆
        /// </summary>
        /// <param name="UserAccoutID">账户</param>
        /// <param name="UserPassword">密码</param>
        /// <returns>返回Json 字符串</returns>
        public String IsCanLogin(String UserAccoutID,String UserPassword)
        {
            JsonData validator = new JsonData();
            UserType type = Service.GetUserType(UserAccoutID);
            validator["Type"] = type.ToString();
            validator["isLogin"] = Service.Login(UserAccoutID, UserPassword, type, EncodeServive);
            return validator.ToJson();
        }


        /// <summary>
        ///  用户登录 
        ///  判断用户是否合法 对于合法用户 
        ///  判断身份 教师跳转到教师页面 学生跳转到学生页面
        ///  记录登陆信息 存放到登陆表中
        /// </summary>
        /// <param name="userAccout">用户账号和密码</param>
        /// <param name="returnurl">会跳页面</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserAccoutID,UserPassword")] UserAccout userAccout , String returnurl)
        {
            if (ModelState.IsValid)
            {
                UserType type = Service.GetUserType(userAccout.UserAccoutID);
                if(type == UserType.Anonymous)
                {
                    //陌生人登录
                    return RedirectToAction("Login", "Account"); 
                }

                if(!Service.Login(userAccout.UserAccoutID, userAccout.UserPassword, type, EncodeServive))
                {
                    return RedirectToAction("Login", "Account");
                }

                #region 用户登录信息票证      
                FormsAuthentication.SignOut(); //将之前的票证取消
                //将用户信息保存为Json信息存储在 Cookies 里面 

                //用户数据
                String UserData = JsonMapper.ToJson(userAccout).ToString();


                /*创建一个票据*/
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    userAccout.UserAccoutID,
                    DateTime.Now,              //发放票证的时间
                    DateTime.Now.AddHours(12), //认证Cookie 设置过期时间6小时
                    true,
                    UserData,
                    FormsAuthentication.FormsCookieName
                );
                /*加密这个票据*/
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                cookie.HttpOnly = true;
                //添加cookie信息
                Response.Cookies.Add(cookie);
                #endregion

                #region 存储用户登陆信息
                UserLoginRecord record = new UserLoginRecord();
                record.UserID = userAccout.UserAccoutID;
                record.LoginTime = DateTime.Now;
                record.LoginYear = DateTime.Now.Year;
                record.LoginMonth = DateTime.Now.Month;
                record.LoginDay = DateTime.Now.Day;
                Service.AddLoginRecord(record);
                #endregion

                #region 登录跳转页面
                if(type == UserType.Principal)
                {
                    return Redirect(returnurl ?? Url.Action("Index", "SystemConfiguration"));
                }
                else 
                {
                    return Redirect(returnurl ?? Url.Action("Index", "Student"));
                }
                #endregion
            }
            else
            {
                return RedirectToAction("Error","Home");
            }
        }
        /// <summary>
        /// 当用户已经登录后！跳转到登录页面之后
        /// </summary>
        /// <returns></returns>
        public ActionResult HaveLoginToUserPage()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                var valCookie = authTicket.UserData;
                UserAccout accout = JsonMapper.ToObject<UserAccout>(valCookie);
                if (Service.GetUserType(accout.UserAccoutID) == UserType.Principal)
                {
                    return Redirect(Url.Action("Index", "SystemConfiguration"));
                }
                else
                {
                    return Redirect(Url.Action("Index", "Student"));
                }
            }
            else
            {
                return Redirect(Url.Action("Login", "Account"));
            }

        }
    }
}