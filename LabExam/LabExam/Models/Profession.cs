using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 专业，描述学生专业  </remarks>
    ///  <Create> 2018/9/6 10:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Professions")]
    public class Profession
    {
        [Key]
        public int ProfessionID { get; set; } // 编号
        [MaxLength(200)]
        public String Name { get; set; }   // 名称
        public DateTime AddTime { get; set;} // 添加时间
        [ForeignKey("Institute")]
        public int InstituteID { get; set; } // 学院
        public virtual Institute Institute { get; set; }

    }
}