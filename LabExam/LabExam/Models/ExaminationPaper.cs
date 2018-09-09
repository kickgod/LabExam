using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using LabExam.Map;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 试卷,描述老师出题试卷  </remarks>
    ///  <Create> 2018/9/7 17:55 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("ExaminationPapers")]
    public class ExaminationPaper
    {
        [Key]
        public int ExaminationPaperID { get; set; }
        [ForeignKey("Principal")]
        public String PrincipalID { get; set; }  //外键：负责人 谁出的试卷
        public virtual Principal Principal { get; set; }
        public DateTime AddTime { get; set; } //添加时间
        public int AdaptedGrade { get; set; }  //适应年级
        public ExaminationPaperStatus ExaminationPaperStatus { get; set; } //试卷状态
        
        public int QuestionChoiceCount { get; set; }  //选择题 数目
        public int QuestionJudgemtnCount { get; set; } //判断题 数目
        public int QuestionSubjectCount { get; set; }  //主观题 数目
        public int TotalScore { get; set; } //总分
        public float PassScore { get; set; } //通过分数

    }
}