using System;
using LabExam.Map;
using LabExam.Models;
using LabExam.Models.JsonObject;
using System.Web.Mvc;
using LitJson;
using System.Collections.Generic;

namespace LabExam.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        ///  返回系统首页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]     //允许陌生人访问的方法
        public ActionResult Index()
        {
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
    }
}