using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using LabExam.Map;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 用户使用建议--投诉建议  </remarks>
    ///  <Create> 2018/9/6 11:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("UserSuggestions")]
    public class UserSuggestion
    {
        [Key]
        public int UseSuggestionID { get; set; }
        [Required(ErrorMessage = "请填写你的投诉或建议的具体内容")]
        [MaxLength(3000)]
        public String Description { get; set; } //建议--描述

        public DateTime AddTime { get; set; } //添加时间

        [MaxLength(50)]
        public String ContactType { get; set; } //联系方式

        [MaxLength(300)]
        public String Contact { get; set; }

        [MaxLength(300)]
        public string Title { get; set; } //主题


    }
}