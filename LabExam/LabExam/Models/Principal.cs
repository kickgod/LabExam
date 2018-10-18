using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using LabExam.Map;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 负责人，描述用户的实体类,用户分为老师和管理员 管理员权限最大  </remarks>
    ///  <Create> 2018/9/6 10:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Principals")]
    public class Principal
    {
        [Key] [MaxLength(100)]
        public String PrincipalID { get; set; }  //用户ID
        [MaxLength(600)][Required]
        public String Password { get; set; }   //密码 必须加密

        [MaxLength(100)]
        public String JobNumber { get; set; }   //工号
        [MaxLength(100)]
        public String Name { get; set; }   //姓名

        public UserStatus UserStatus { get; set; }  //枚举：UserStatus 用户状态

        [MaxLength(400)]
        [Required()]
        public String UserConfige { get; set; }  //用户配置文件地址

        public ICollection<Resource> Resources { get; set; }  //负责人上传的资料

        public ICollection<Course> Courses { get; set; }  //负责人负责的课程

        public ICollection<ExamQuestionChoice> ExamQuestionChoices { get; set; }  //负责人负责的选择题
        public ICollection<ExamQuestionJudgmental> ExamQuestionJudgmentals { get; set; }  //负责人负责的判断题
        public ICollection<ExamQuestionSubjective> ExamQuestionSubjectives { get; set; }  //负责人负责的主观题



    }
}