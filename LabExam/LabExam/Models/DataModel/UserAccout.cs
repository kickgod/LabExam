using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabExam.Models.DataModel
{
    /// <summary>
    /// 用户账户中间数据绑定
    /// </summary>
    public class UserAccout
    {
        [Required(ErrorMessage ="请填写你的账号")]
        [MaxLength(200, ErrorMessage = "你的账号超出限制")]
        public string UserAccoutID { get; set; }

        [Required(ErrorMessage ="请填写你的密码")]
        [MaxLength(200 ,ErrorMessage ="你的密码超出限制")]
        public String UserPassword { get; set; }
    }
}