using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 学院类，描述学院的实体类  </remarks>
    ///  <Create> 2018/9/6 10:29 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("Institutes")]
    public class Institute
    {
        [Key]
        public int InstituteID { get; set; }
        [MaxLength(200)]
        public String Name { get; set; }
        public DateTime AddTime { get; set; }
        [ForeignKey("Module")]
        public int ModuleID { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<Profession> Professions { get; set; }
    }
}