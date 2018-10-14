using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Models
{
    public class ModuleConfigure
    {
        public Boolean isOpenToStudy { get; set; } //是否开发学习

        public Boolean isOpenToLearing { get; set; } //是否开发考试

        public int ModuleID { get; set; } //开放模块ID


    }
}