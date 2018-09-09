using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using LabExam.Map;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 存储试卷的 判断信息</remarks>
    ///  <Create> 2018/9/8 18:12 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor></LastAlterTimeAndAuthor>
    /// </summary>
    [Table("PaperJudgmentSets")]
    public class PaperJudgmentSet
    {
        [Key]
        public int PaperJudgmentSetID { get; set; }
        [ForeignKey("ExamQuestionJudgmental")]
        public int ExamQuestionJudgmentalID { get; set; }

        public ExamQuestionJudgmental ExamQuestionJudgmental { get; set; }

        [ForeignKey("ExaminationPaper")]
        public int ExaminationPaperID { get; set; }  //外键 试卷Id
        public ExaminationPaper ExaminationPaper { get; set; }

    }
}