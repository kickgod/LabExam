using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 存储试卷的 判断信息</remarks>
    ///  <Create> 2018/9/8 18:12 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor></LastAlterTimeAndAuthor>
    /// </summary>
    [Table("PaperSubjectiveSets")]
    public class PaperSubjectiveSet
    {
        [Key]
        public int PaperSubjectiveSetID { get; set; }

        [ForeignKey("ExamQuestionSubjective")]
        public int ExamQuestionSubjectiveID { get; set; }

        public ExamQuestionSubjective ExamQuestionSubjective { get; set; }

        [ForeignKey("ExaminationPaper")]
        public int ExaminationPaperID { get; set; }  //外键 试卷Id
        public ExaminationPaper ExaminationPaper { get; set; }
    }
}