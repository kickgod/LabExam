using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Map
{
    /// <summary>
    ///  <remarks> 负责人，描述用户的实体类,用户分为老师和管理员 管理员权限最大  </remarks>
    ///  <value> NotUsed 尚未使用</value>
    ///  <value> Using 使用中</value>
    ///  <value> AlreadyScrapped 已经报废</value>
    ///  <Create> 2018/9/6 10:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    public enum ExaminationPaperStatus
    {
        NotUsed =2,
        Using =4,
        AlreadyScrapped = 8
    }
}