using LabExam.IServices;
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
        private IUserAccountService UserAccountService;

        public AccountController(IUserAccountService service)
        {
            this.UserAccountService = service;
        }
        public ActionResult Login()
        {
            ViewBag.isLogin = UserAccountService.UserIsLogin();
            return View();
        }

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
        public String ChangePassword(String UserID,String UserNewPassword,String IDNumber) {

            Map.UserType type = UserAccountService.GetUserType(UserID);

            JsonData val = new JsonData();
            if (UserID.Trim() != "" || UserNewPassword.Trim() != "" || IDNumber.Trim() != "")
            {
                FormsAuthentication.SignOut();
                UserAccout accout = new UserAccout();
                accout.UserAccoutID = UserID;
                accout.UserPassword = UserNewPassword;
                Boolean result =  UserAccountService.ChangeUserPassword(accout,Map.UserType.Student);
                val["isOk"] = result;//返回状态如何 成功
            }
            else {
                RedirectToAction("Error", "Home");
                val["isOk"] = false;//返回状态如何 失败
            }
            return val.ToJson();
        }

        
        public ActionResult HaveLogin(String val)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
            ViewBag.valCookie = authTicket.UserData;
            return View();
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
                #region 用户登录信息票证      
                FormsAuthentication.SignOut(); //将之前的票证取消
                //将用户信息保存为Json信息存储在 Cookies 里面 
                //用户数据
                JsonData data = new JsonData();
                data["UserID"] = userAccout.UserAccoutID;
                data["UserPwd"] = userAccout.UserPassword;
                String UserData = JsonMapper.ToJson(data).ToString();

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

                #endregion

                return Redirect(returnurl ?? Url.Action("Index", "Home"));
            }
            else
            {
                return RedirectToAction("Error","Home");
            }
            
        }
    }
}