using LabExam.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 学生申请不参加考试类,例如休学/硕博连读项目...</remarks>
    ///  <Create> 2018/9/6 20:54 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("StudentApplyForNotTakeExaminations")]
    public class StudentApplyForNotTakeExamination
    {
        [Key]
        public int StudentApplyForNotTakeExaminationID { get; set; }  //编号

        [MaxLength(2500)]
        [MinLength(10, ErrorMessage = "你也说得太少了吧")]
        public String ApplyDescription { get; set; }  //申请原因
        public StudentReExamApplicationStatus StudentReExamApplication { get; set; } //申请状态:只有两种 同意/不同意
        [Required]
        public DateTime ApplyTime { get; set; } //申请时间 

        [ForeignKey("Student")]
        public String StudentID { get; set; } //外键：学号 那个学生申请重考
        public Student Student { get; set; }
    }
}