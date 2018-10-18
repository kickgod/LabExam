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

        public ActionResult HaveLogin(String val)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
            ViewBag.valCookie = authTicket.UserData;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserAccoutID,UserPassword")] UserAccout userAccout , String returnurl)
        {
            if (ModelState.IsValid)
            {
                //将用户信息保存为Json信息存储在 Cookies 里面
                FormsAuthentication.SignOut();

                JsonData data = new JsonData();
                data["UserID"] = userAccout.UserAccoutID;
                data["UserPwd"] = userAccout.UserPassword;
                //用户数据
                String UserData = JsonMapper.ToJson(data).ToString();

                /*创建一个票据*/
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    userAccout.UserAccoutID,
                    DateTime.Now,
                    DateTime.Now.AddHours(4), //认证Cookie 设置过期时间4小时
                    true,
                    UserData,
                    FormsAuthentication.FormsCookieName
                );
                /*加密这个票据*/
                // 创建cookie
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return Redirect(returnurl ?? Url.Action("Index", "Home"));
            }
            else
            {
                return RedirectToAction("Error","Home");
            }
            
        }
    }
}