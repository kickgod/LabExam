using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Models
{
    public class SystemCofigure
    {
        public Boolean isOpenLearing { get; set; } //整个系统是否开放学习

        public Boolean isOpenExam { get; set; } //整个系统是否开放考试

        public List<ModuleConfigure> ModuleConfigures { get; set; } //各个模块的设置

        public SystemCofigure(List<ModuleConfigure>  ModuleList)
        {
            ModuleConfigures = ModuleList;
        }

        public String ContactNumber { get; set; } //技术 联系人1姓名-电话
        public String ContactNumber1 { get; set; } //技术 联系人2姓名-电话 
        public DateTime? ExamEndTime { get; set; } //考试结束时间
        public Boolean? IsAutoAgreeReExaminationApplication { get; set; } //是否自动同意学生对于重考的申请
    }
}