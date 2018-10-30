using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabExam.Models
{
    /// <summary>
    ///  <remarks> 登陆日志文件 </remarks>
    ///  <Create> 2018/9/6 11:42 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    [Table("UserLoginRecords")]
    public class UserLoginRecord
    {
        [Key]
        public long UserLoginRecordID { get; set; }
        public string UserID { get; set; } //登陆ID 没有外键 只是做记录

        public DateTime LoginTime { get; set; } //登陆时间

        public int LoginYear { get; set; } //登陆年份

        public int LoginMonth { get; set; } //登陆月份

        public int LoginDay { get; set; } //登陆日
    }
}