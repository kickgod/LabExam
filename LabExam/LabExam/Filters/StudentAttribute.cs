using LabExam.Map;
using LabExam.Models.DataModel;
using LabExam.Services;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LabExam.Filters
{
    /// <summary>
    ///  这个页面只能学生参加
    /// </summary>
    public class StudentAttribute: AuthorizeAttribute
    {
        
        private Boolean isCanAllowedAnonymous { get; set; }

        /// <summary>
        /// 是否允许陌生人登录
        /// </summary>
        /// <param name="isCanAnonymous">true 允许陌生人 falase 非学生不能登录</param>
        public StudentAttribute(Boolean isCanAnonymous)
        {
            this.isCanAllowedAnonymous = isCanAnonymous;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!isCanAllowedAnonymous)
            {
                HttpCookie authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return false;
                }
                else
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                    var valCookie = authTicket.UserData;
                    UserAccout accout = JsonMapper.ToObject<UserAccout>(valCookie);
                    UserAccountService service = new UserAccountService();
                    UserType type = service.GetUserType(accout.UserAccoutID);
                    if(type ==UserType.Student)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}