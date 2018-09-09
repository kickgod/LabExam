using LabExam.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam.Controllers
{
    public class AccountController : Controller
    {
        private IPrincipalService principalService;

        public AccountController(IPrincipalService service)
        {
            this.principalService = service;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string userpassword, string returnurl)
        {
            return Redirect(returnurl ?? Url.Action("Index", "Home"));
        }
    }
}