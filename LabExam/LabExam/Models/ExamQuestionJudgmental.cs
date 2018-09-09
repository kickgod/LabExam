using LabExam.Map;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks>
    ///       题目类,存储所有选择题
    ///  </remarks>
    ///  <Create> 2018/9/6 15:00 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("ExamQuestionJudgmentals")]
    public class ExamQuestionJudgmental
    {
        [Key]
        public int ExamQuestionJudgmentalID { get; set; }  // 编号
        [MaxLength(3000)]
        public String Title { get; set; }  // 题干
        
        public Boolean Answer { get; set; } // 题目答案

        public DateTime AddTime { get; set; } // 添加时间

        public float? DegreeOfDifficulty { get; set; } // 题目难度系数问题

        public ExamQuestionType ExamQuestionType { get; set; } // 枚举：题目类型 选择

        [ForeignKey("Principal")]
        public String PrincipalID { get; set; } //外键 ：添加题目的负责人
        public virtual  Principal Principal { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; } // 外键：所属模块

        public virtual Module Module { get; set; } 


    }
}