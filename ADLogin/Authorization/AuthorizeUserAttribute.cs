using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLogin.Authorization
{
    public sealed class AuthorizeUserAttribute : ActionFilterAttribute
    {
        private static RedirectResult loginRedirect = new RedirectResult(ADLogin.Controllers.Paths.GetLoginPath());
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["username"] == null)
            { // Back to login if the user isn't logged in.
                filterContext.Result = loginRedirect;
            }
            base.OnActionExecuting(filterContext);
            
        }
    }
}