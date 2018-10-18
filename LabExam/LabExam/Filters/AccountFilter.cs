using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam.Filters
{
    public class AccountValidateFilter:AuthorizeAttribute
    {
         private Boolean isCanAllowedAnonymous { get; set; }

         public AccountValidateFilter(Boolean isCanAnonymous)
         {
            this.isCanAllowedAnonymous = isCanAnonymous;
         }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!isCanAllowedAnonymous)
            {
                if (httpContext.Request.Cookies["User"] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
            
     }
}