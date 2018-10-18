using System;
using LabExam.Map;
using LabExam.Models;
using LabExam.Models.JsonObject;
using System.Web.Mvc;
using LitJson;
using System.Collections.Generic;
using LabExam.IServices;
using System.Web.Security;

namespace LabExam.Controllers
{
    public class HomeController : Controller
    {

        public IUserSuggestionService Service; 

        /// <summary>
        /// 注入事务类
        /// </summary>
        /// <param name="service"></param>
        public HomeController(IUserSuggestionService service)
        {
            this.Service = service; 
        }

        /// <summary>
        ///  返回系统首页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]     //允许陌生人访问的方法
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        /// <summary>
        ///  考试说明文件
        /// </summary>
        /// <returns></returns>
        public ActionResult Explanation()
        {
            return View();  
        }
        /// <summary>
        /// 用户帮助页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserHelping()
        {
            return View();
        }
        /// <summary>
        ///  用户投诉
        /// </summary>
        /// <returns></returns>
        public ActionResult UserComplaint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserComplaint(String Description,String ContactType, String Contact, String Title)
        {
            try {
                if (Description == "") {
                    throw new Exception("无内容请求");
                }
                UserSuggestion suggestion = new UserSuggestion();
                suggestion.AddTime = DateTime.Now;
                suggestion.Description = Description;
                suggestion.Contact = Contact;
                suggestion.Title = Title;
                suggestion.ContactType = ContactType;
                Service.AddUserSuggestion(suggestion);
            }
            catch(Exception ex) {
                return RedirectToAction("Error");
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}