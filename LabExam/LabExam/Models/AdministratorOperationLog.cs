using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabExam.Models
{
    [Table("AdministratorOperationLogs")]
    public class AdministratorOperationLog
    {
        [Key]
        public int KeyID { get; set; }  //主键
        [MaxLength(15)]
        public String OperationCode { get; set; }  //增删改查
        [MaxLength(50)]
        public String OperationName { get; set; } //操作名称
        [MaxLength(300)]
        public String Description { get; set; } //操作描述

        public int OperationStyle { get; set; } //操作类型

        public DateTime OprationDateTime { get; set; } //操作时间

    }
}