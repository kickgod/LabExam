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
    public class PrincipalAttribute : AuthorizeAttribute
    {
        private Boolean isCanAllowedAnonymous { get; set; }

        public PrincipalAttribute(Boolean isCanAnonymous)
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
                    if (type == UserType.Principal)
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