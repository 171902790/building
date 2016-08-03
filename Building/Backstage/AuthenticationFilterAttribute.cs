using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace Building.Admin
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute,IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var userCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (userCookie == null)
            {
                filterContext.Result=new RedirectResult("~/login");
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}