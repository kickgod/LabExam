using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Map
{
    /// <summary>
    ///  枚举：正常的审核流程
    ///  编辑
    ///  提交
    ///  通过
    ///  未通过
    ///  在使用
    /// </summary>
    public enum ReviewProcess
    {
        Editing =10,
        Submitted = 20,
        Passed =40,
        NotPass = 80,
        Using =160
    }
}