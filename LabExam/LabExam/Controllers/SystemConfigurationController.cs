using System;
using LabExam.Map;
using LabExam.Models;
using LabExam.Models.JsonObject;
using System.Web.Mvc;
using LitJson;
using System.Collections.Generic;
using LabExam.IServices;
using System.Web.Security;
using System.Web;
using LabExam.Models.DataModel;
using LabExam.Filters;

namespace LabExam.Controllers
{
    [Principal(false)]
    public class SystemConfigurationController : Controller
    {
        private IUserAccountService service;

        public SystemConfigurationController(IUserAccountService Service)
        {
            this.service = Service;
        }
        // GET: SystemConfiguration
        public ActionResult Index()
        {
            return View();
        }

        public String LoadPricipalInfo()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密
            var valCookie = authTicket.UserData;
            UserAccout accout = JsonMapper.ToObject<UserAccout>(valCookie);
            return service.GetPrincipalByID(accout.UserAccoutID);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}