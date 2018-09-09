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
        [AllowAnonymous]     //允许陌生人访问的方法
        public ActionResult Index()
        {
            using (LabContext lab = new LabContext())
            {
                /*
                List<JsonModule> list = new List<JsonModule>();
                JsonModule module1 = new JsonModule();
                module1.ModuleID = 1;
                module1.Name = "化学生物类";
                JsonModule module2 = new JsonModule();
                module2.ModuleID = 2;
                module2.Name = "文史艺体类";
                JsonModule module3 = new JsonModule();
                module3.ModuleID = 3;
                module3.Name = "物理信息类";
                JsonModule module4 = new JsonModule();
                module4.ModuleID = 4;
                module4.Name = "文史艺体（影传专用课）";
                JsonModule module5 = new JsonModule();
                module5.ModuleID = 5;
                module5.Name = "文史艺体（国教必修补充）";
                JsonModule module6 = new JsonModule();
                module6.ModuleID = 6;
                module6.Name = "其它理工类";

                list.Add(module1);
                list.Add(module2);
                list.Add(module3);
                list.Add(module4);
                list.Add(module5);
                list.Add(module6);
                list.AddRange(list);

                System.IO.File.WriteAllText(Server.MapPath(@"~/Resources/JsonData/Modules.json"),JsonMapper.ToJson(list));


                /*

                String JsonString= System.IO.File.ReadAllText(Server.MapPath(@"~/Resources/JsonData/Modules.json"),System.Text.Encoding.UTF8);
                ViewBag.bag = JsonString;
                List<JsonModule> list = JsonMapper.ToObject<List<JsonModule>>(JsonString);
                foreach(var val in list)
                {
                    Module module = new Module();
                    module.Name = val.Name;
                    module.ModuleID = val.ModuleID;
                    lab.Modules.Add(module);
                }
                */
               // lab.SaveChanges();
            }
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}