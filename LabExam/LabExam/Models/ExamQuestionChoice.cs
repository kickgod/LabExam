using LabExam.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks>
    ///       题目类,存储所有选择题 单选/多选
    ///  </remarks>
    ///  <Create> 2018/9/6 15:00 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("ExamQuestionChoice")]
    public class ExamQuestionChoice
    {
        [Key]
        public int ExamQuestionChoiceID { get; set; }  // 编号
        [MaxLength(3000)]
        public String Title { get; set; }  // 题干

        [MaxLength(20)]
        public String Answer { get; set; } // 题目答案

        [MaxLength(300)]
        public String A { get; set; }

        [MaxLength(300)]
        public String B { get; set; }

        [MaxLength(300)]
        public String C{ get; set; }
        [MaxLength(300)]
        public String D { get; set; }
        [MaxLength(300)]
        public String E { get; set; }
        [MaxLength(300)]
        public String F { get; set; }
        [MaxLength(300)]
        public String G { get; set; }
        [MaxLength(300)]
        public String h { get; set; }

        public DateTime AddTime { get; set; } // 添加时间

        public float? DegreeOfDifficulty { get; set; } // 题目难度系数问题

        public ExamQuestionType ExamQuestionType { get; set; } // 枚举：题目类型

        [ForeignKey("Principal")]
        public String PrincipalID { get; set; } //外键 ：添加题目的负责人
        public virtual Principal Principal { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; } // 外键：所属模块

        public virtual Module Module { get; set; }


    }
}