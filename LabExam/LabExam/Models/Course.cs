using LabExam.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 课程表,描述学习课程的实体类 </remarks>
    ///  <Create> 2018/9/6 14:09 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseID { get; set; }  //课程编号

        [MaxLength(200)]
        public String Name { get; set; }   //课程名称

        [Required]
        public DateTime AddTime{get;set;}   //添加时间
        

        public Boolean IsCompulsory { get; set; }  //指定是否必修

        [MaxLength(1000)]
        public String Introduction { get; set; }        //课程介绍五百字为限

        [Required]
        public float Credit { get; set; }                //课程学分

        public ReviewProcess ReviewProcess { get; set; } //课程状态


        [ForeignKey("Principal")]
        public String PrincipalID { get; set; }     // 外键: 课程负责人

        public virtual Principal Principal { get; set; }


        [ForeignKey("Module")]
        public int ModuleID { get; set; }           // 外键： 课程所属模块

        public virtual Module Module { get; set; }

        public virtual ICollection<Resource> Collection { get; set; }

    }
}