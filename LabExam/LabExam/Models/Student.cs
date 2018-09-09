using LabExam.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 学生类,这个系统的中心 </remarks>
    ///  <Create> 2018/9/6 16:39 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Students")]
    public class Student
    {
        [Key]
        public String StudentID { get; set; } //学号

        [MaxLength(1000)][Required]
        public String Passwrod { get; set; } //密码

        [MaxLength(200)]
        public String Email { get; set; } //邮件

        [MaxLength(200)]
        public String IDNumber { get; set; } //身份证号码

        public bool Sex { get; set; } //性别

        [MaxLength(100)]
        public String Name { get; set; } //姓名

        [Required]
        public int Grade { get; set; } //年级

        public StudentIdentity StudentIdentity { get; set; } //枚举 本科生/研究生
        public Boolean? IsExam { get; set; } //是否已经参加考试
        public int? JoinExamYear { get; set; } //什么年度参加考试的
        public float? ExamScore { get; set; } //考试分数

        public Boolean IsMalicious { get; set; } //是否恶意不学习,而多次刷分


        [ForeignKey("Profession")]
        public int ProfessionID { get; set; }  //外键：学生专业
        public virtual Profession Profession { get; set; }
    }
}