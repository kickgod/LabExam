using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Map
{  
    /// <summary>
     ///  <remarks> 枚举: 学生考试类型</remarks>
     ///  <value>当前年度考试 应届生</value>
     ///  <value>以前未参加考试或者考试未通过 加入进考生中</value>
     ///  <Create> 2018/9/6 16:38 </Create>
     ///  <Author> 2016110418 蒋星 </Author>
     ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
     /// </summary>
    public enum StudentExamIdentity
    {
        MeetTheYear=2,
        PreviousYear=4
    }
}