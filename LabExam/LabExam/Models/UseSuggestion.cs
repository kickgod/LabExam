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
    [Table("UseSuggestions")]
    public class UseSuggestion
    {
        public int UseSuggestionID { get; set; }
        [MaxLength(3000)]
        public String Description { get; set; } //建议--描述

        public DateTime AddTime { get; set; } //添加时间

        [MaxLength(50)]
        public String QQNumber { get; set; } //QQ号


    }
}