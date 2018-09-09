using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using LabExam.Map;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 课程资料，描述课程对应的视频或者DOC/PPt资料  </remarks>
    ///  <Create> 2018/9/6 11:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Resources")]
    public class Resource
    {
        [Key]
        public int ResourceID { get; set; } //编号

        [MaxLength(200)]
        public String Name { get; set; } //课程名称

        [MaxLength(700)]
        public String Description { get; set; }  //350字的描述 资源

        public ReviewProcess ReviewProcess { get; set; } //枚举：审核状态  

        [Required]
        public DateTime AddTime { get; set; } //添加时间

        public ResourceType ResourceType { get; set; } //枚举：资源类型

        [MaxLength(600)]
        public String StorePath { get; set; } //上传文件存储位置

        public int? LengthOfStudy { get; set; } //学习时长 只有视频需要 可空 如果是其他类型那么可以不填写

        [ForeignKey("Principal")]
        public String PrincipalID { get; set; }  //资源负责人

        public virtual Principal Principal { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }   //所属课程
        public virtual Course Course { get; set; }


    }
}