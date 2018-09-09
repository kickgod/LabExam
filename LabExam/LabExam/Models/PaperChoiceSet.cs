using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using LabExam.Map;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 存储试卷的 选择题信息</remarks>
    ///  <Create> 2018/9/8 17:55 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor></LastAlterTimeAndAuthor>
    /// </summary>
    [Table("PaperChoiceSets")]
    public class PaperChoiceSet
    {
        [Key]
        public int PaperChoiceSetID { get; set; }

        [ForeignKey("ExamQuestionChoice")]
        public int ExamQuestionChoiceID { get; set; } //外键 选择题Id

        public ExamQuestionChoice ExamQuestionChoice { get; set; }

        [ForeignKey("ExaminationPaper")]
        public int ExaminationPaperID {get;set; }  //外键 试卷Id
        public ExaminationPaper ExaminationPaper { get; set; }

        public ExamQuestionType ExamQuestionType { get; set; }  //说明下是单选 还是多选
    }
}