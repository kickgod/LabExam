using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Map
{
    /// <summary>
    ///  <remarks> 枚举: 题目审核状态</remarks>
    ///  <value>编辑中</value>
    ///  <value>已提交</value>
    ///  <value>通过</value>
    ///  <value>未通过</value>
    ///  <Create> 2018/9/6 11:00 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    public enum ExamQuestionStatus
    {
        Editing = 10,
        Submitted = 20,
        Passed = 40,
        NotPass = 80
    }
}