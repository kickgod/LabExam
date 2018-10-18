using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam.Controllers
{
    [Authorize]
    public class SystemConfigurationController : Controller
    {
        // GET: SystemConfiguration
        public ActionResult Index()
        {
            return View();
        }
    }
}