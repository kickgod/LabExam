using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 模块类，描述模块的实体类,将一切 课程 学院 题目 进行分类的关键  </remarks>
    ///  <Create> 2018/9/6 09:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Modules")]
    public class Module
    {
        [Key]
        public int ModuleID { get; set; } //编号
        [MaxLength(200)]
        public String Name { get;set;} //名称

        public virtual ICollection<Institute> Institutes { get; set; } //下辖学院

        public virtual ICollection<Course> Courses { get; set; } //下辖课程
    }
}